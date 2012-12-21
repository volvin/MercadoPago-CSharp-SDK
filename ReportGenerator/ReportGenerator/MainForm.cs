using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MercadoPagoSDK;
using System.Web;
using System.Threading;

namespace ReportGenerator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private const int API_QUERY_PAGE_SIZE = 1000;
        private OAuthResponse _authorization;
        private AdminForm _adminForm = null;
        private bool _continue = true;
        private LoginForm _loginForm = null;

        /// <summary>
        /// Receives login event and inits authorization vars.
        /// </summary>
        public void MainForm_LoginReady(OAuthResponse response)
        {
            try
            {
                // Set app authorization
                _authorization = response;

                // Get user info and set salute label text
                UsersHelper uh = new UsersHelper();
                uh.AccessToken = _authorization.AccessToken;
                User user = uh.GetUser(response.UserId);
                saluteLabel.Text = "Hi, " + user.FirstName + " " + user.LastName + " (" + user.Email + ")";

                // Set authorization site id
                _authorization.SiteId = user.SiteId;

                // Hide login form and enable main form buttons
                _loginForm.Hide();
                EnableLoginControls();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login failure: " + ex.Message);
            }
        }

        /// <summary>
        /// Receives admin login event and inits authorization vars.
        /// </summary>
        public void MainForm_AdminLoginReady(string adminToken, int userId)
        {
            try
            {
                // Set app authorization
                _authorization = new OAuthResponse(adminToken, DateTime.Now.AddDays(1), userId, null, true);

                // Get user info and set salute label text
                UsersHelper uh = new UsersHelper();
                uh.AccessToken = _authorization.AccessToken;
                User user = uh.GetUser(userId);
                if ((user.FirstName == null) && (user.LastName == null))
                {
                    saluteLabel.Text = "Hi Admin, you're now an alias of " + user.Nickname;                
                }
                else
                {
                    saluteLabel.Text = "Hi Admin, you're now an alias of " + user.FirstName + " " + user.LastName + " (" + user.Email + ")";
                }

                // Set authorization site id
                _authorization.SiteId = user.SiteId;

                // Hide admin form and enable main form buttons
                _adminForm.Hide();
                EnableLoginControls();
            }
            catch
            {
                MessageBox.Show("Login failure: Please try again");
            }
        }

        /// <summary>
        /// Receives logout event and resets authorization vars.
        /// </summary>
        public void MainForm_LogoutReady()
        {
            // Reset authorization, form controls and values
            saluteLabel.Text = "";
            DisableLoginControls();
            _authorization = null;

            this.Cursor = Cursors.Default;
        }

        private void EnableGenerateControls()
        {
            generateButton.Enabled = true;
            abortButton.Enabled = false;
            abortButton.BackColor = Color.White;
        }

        private void EnableLoginControls()
        {
            loginButton.Enabled = false;
            logoutButton.Enabled = true;
            EnableGenerateControls();
        }

        private void DisableGenerateControls()
        {
            generateButton.Enabled = false;
            abortButton.Enabled = true;
            abortButton.BackColor = Color.Red;
        }

        private void DisableLoginControls()
        {
            loginButton.Enabled = true;
            logoutButton.Enabled = false;
            generateButton.Enabled = false;
            abortButton.Enabled = false;
            abortButton.BackColor = Color.White;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            // Clean login form from a previous session
            if (_loginForm != null)
            {
                _loginForm.Dispose();
                _loginForm = null;
            }

            // Show login form
            _loginForm = new LoginForm();
            _loginForm.FirstForm = this;
            _loginForm.Show();
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            // Reset controls
            DisableGenerateControls();
            progressBar.Value = 0;
            progressLabel.Text = "";

            Thread workerThread = new Thread(DoWork);

            // Start the worker thread.
            _continue = true;  // reset abort flag
            workerThread.Start();
            Console.WriteLine("main thread: Starting worker thread...");

            // Loop until worker thread activates.
            while (!workerThread.IsAlive) ;

            // Put the main thread to sleep for 1 millisecond to
            // allow the worker thread to do some work:
            Thread.Sleep(1);
        }

        private void DoWork()
        {
            List<Collection> collections = null;
            SearchPage<Collection> collectionsPage = null;
            string fileExtension = "";
            List<Movement> movements = null;
            SearchPage<Movement> movementsPage = null;
            int offset = 0;
            ReportFormats reportFormat;
            ReportTypes reportType;

            // Define file extension and report format
            if (excelRadioButton.Checked)
            {
                reportFormat = ReportFormats.ExcelReport;
                fileExtension = ".xml";
            }
            else
            {
                reportFormat = ReportFormats.CSVReport;
                fileExtension = ".csv";
            }

            // Set progress bar max value

            //Search the API
            try
            {
                if (collectionsRadioButton.Checked)
                {
                    reportType = ReportTypes.CollectionsReport;
                    collectionsPage = BackendHelper.GetCollectionsPage(offset, API_QUERY_PAGE_SIZE, _authorization, reportFromPicker.Value, reportToPicker.Value);
                    collections = collectionsPage.Results;
                    progressBar.Invoke(new UpdateProgressBarMaximumCallback(this.UpdateProgressBarMaximum), new object[] { collectionsPage.Total.Value });
                }
                else
                {
                    reportType = ReportTypes.MovementsReport;
                    movementsPage = BackendHelper.GetMovementsPage(offset, API_QUERY_PAGE_SIZE, _authorization, reportFromPicker.Value, reportToPicker.Value);
                    movements = movementsPage.Results;
                    progressBar.Invoke(new UpdateProgressBarMaximumCallback(this.UpdateProgressBarMaximum), new object[] { movementsPage.Total.Value });
                }
                offset += API_QUERY_PAGE_SIZE;
            }
            catch (RESTAPIException raex)
            {
                MessageBox.Show("MP API Exception: " + raex.Cause);
                return;
            }

            // Check for Excel limitation
            if ((reportFormat == ReportFormats.ExcelReport) && (progressBar.Maximum > 60000))
            {
                MessageBox.Show("The number of rows exceeds Excel report size. Choose CSV instead.");
                generateButton.Enabled = true;
                return;
            }

            // Open file
            System.IO.StreamWriter file;
            string fileName = folderTextBox.Text;  // TODO: add file name format validation
            if (fileName.Substring(fileName.Length - 1) != "\\")
            {
                fileName += "\\";
            }
            fileName += fileNameTextBox.Text + fileExtension;
            file = new System.IO.StreamWriter(fileName);

            // Set Report Writter
            ReportWritter reportWritter = ReportWritterFactory.GetReportWritter(file, reportFormat);
            reportWritter.ProgressBar = progressBar;
            reportWritter.ProgressText = progressLabel;

            // Write report header
            reportWritter.WriteHeader(reportType, progressBar.Maximum);

            if (collectionsRadioButton.Checked)
            {
                // Write first page
                reportWritter.WriteCollections(collections);

                // loop for more collections pages
                while (collectionsPage.Total.Value > offset && _continue)
                {
                    collectionsPage = BackendHelper.GetCollectionsPage(offset, API_QUERY_PAGE_SIZE, _authorization, reportFromPicker.Value, reportToPicker.Value);
                    collections = collectionsPage.Results;
                    reportWritter.WriteCollections(collections);
                    offset += API_QUERY_PAGE_SIZE;
                }
            }
            else
            {
                // Write first page
                reportWritter.WriteMovements(movements);

                // loop for more movements pages
                while (movementsPage.Total.Value > offset && _continue)
                {
                    movementsPage = BackendHelper.GetMovementsPage(offset, API_QUERY_PAGE_SIZE, _authorization, reportFromPicker.Value, reportToPicker.Value);
                    movements = movementsPage.Results;
                    reportWritter.WriteMovements(movements);
                    offset += API_QUERY_PAGE_SIZE;
                }
            }

            // Write report footer
            reportWritter.WriteFooter();

            // Close the file
            file.Close();

            // Finish
            progressBar.Invoke(new UpdateProgressBarFinishedCallback(this.UpdateProgressBarFinished), null);
        }

        public delegate void UpdateProgressBarFinishedCallback();
        public delegate void UpdateProgressBarMaximumCallback(int maximum);

        private void UpdateProgressBarMaximum(int maximum)
        {
            progressBar.Maximum = maximum;
        }

        private void UpdateProgressBarFinished()
        {
            progressLabel.Text = "Finished! Processed " + progressLabel.Text;
            EnableGenerateControls();
        }

        /// <summary>
        /// Do logout.
        /// </summary>
        private void logoutButton_Click(object sender, EventArgs e)
        {
            // Clean logout form from a previous session
            this.Cursor = Cursors.WaitCursor;
            if (!_authorization.IsAdmin)
            {
                NavigateLogout();
            }
            else
            {
                MainForm_LogoutReady();
            }
        }

        #region "Logout Browser"

        private bool _keepNavigating = true;

        private void NavigateLogout()
        {
            logoutBrowser.Navigate("https://www.mercadolibre.com/jms/mla/lgz/logout?go=www.google.com");
            logoutBrowser.NewWindow += new CancelEventHandler(logoutBrowser_NewWindow);
            SHDocVw.WebBrowser axBrowser = (SHDocVw.WebBrowser)this.logoutBrowser.ActiveXInstance;
            axBrowser.NewWindow3 += new SHDocVw.DWebBrowserEvents2_NewWindow3EventHandler(axBrowser_NewWindow3);
        }

        void logoutBrowser_NewWindow(object sender, CancelEventArgs e)
        {
            e.Cancel = true; //cancel the navigating
        }

        void axBrowser_NewWindow3(ref object ppDisp, ref bool Cancel, uint dwFlags, string bstrUrlContext, string bstrUrl)
        {
            // access the web page with the URL bstrUrl 
        }

        private void logoutBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            _keepNavigating = false;
            MainForm_LogoutReady();
        }

        private void logoutBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (!_keepNavigating)
            {
                e.Cancel = true;
            }
        }

        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {
            DisableLoginControls();
            reportFromPicker.Value = DateTime.Now.AddDays(-30);
            reportToPicker.Value = DateTime.Now;
            folderTextBox.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        private void openGetFolderDialogButton_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Open a folder which contains the xml output";
                dialog.ShowNewFolderButton = false;
                dialog.RootFolder = Environment.SpecialFolder.MyComputer;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    folderTextBox.Text = dialog.SelectedPath;
                }
            }
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Alt && e.KeyCode == Keys.A && _authorization == null)
            {
                _adminForm = new AdminForm();
                _adminForm.FirstForm = this;
                _adminForm.ShowDialog();
            }
        }

        private void abortButton_Click(object sender, EventArgs e)
        {
            _continue = false;
        }
    }
}
