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

        private const int API_QUERY_PAGE_SIZE = 50;
        private OAuthResponse _authorization;
        private AdminForm _adminForm = null;
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
                EnableControls();
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
                EnableControls();
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
            DisableControls();
            _authorization = null;

            this.Cursor = Cursors.Default;
        }

        private void EnableControls()
        {
            adminAccessButton.Enabled = false;
            loginButton.Enabled = false;
            generateButton.Enabled = true;
            logoutButton.Enabled = true;        
        }

        private void DisableControls()
        {
            adminAccessButton.Enabled = true;
            loginButton.Enabled = true;
            generateButton.Enabled = false;
            logoutButton.Enabled = false;
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
            List<Collection> collections = null;
            SearchPage<Collection> collectionsPage = null;
            string fileExtension = "";
            List<Movement> movements = null;
            SearchPage<Movement> movementsPage = null;
            int offset = 0;
            ReportFormats reportFormat;
            ReportTypes reportType;

            generateButton.Enabled = false;

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
            progressBar.Value = 0;
            progressLabel.Text = "";

            //Search the API
            try
            {
                if (collectionsRadioButton.Checked)
                {
                    reportType = ReportTypes.CollectionsReport;
                    collectionsPage = BackendHelper.GetCollectionsPage(offset, API_QUERY_PAGE_SIZE, _authorization, reportFromPicker.Value, reportToPicker.Value);
                    collections = collectionsPage.Results;
                    progressBar.Maximum = collectionsPage.Total.Value;
                }
                else 
                {
                    reportType = ReportTypes.MovementsReport;
                    movementsPage = BackendHelper.GetMovementsPage(offset, API_QUERY_PAGE_SIZE, _authorization, reportFromPicker.Value, reportToPicker.Value);
                    movements = movementsPage.Results;
                    progressBar.Maximum = movementsPage.Total.Value;
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

            // Write report header
            reportWritter.WriteHeader(reportType, progressBar.Maximum);

            if (collectionsRadioButton.Checked)
            {
                // Write first page
                reportWritter.WriteCollections(collections);

                // loop for more collections pages
                while (collectionsPage.Total.Value > offset)
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
                while (movementsPage.Total.Value > offset)
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
            MessageBox.Show("Done!");
            generateButton.Enabled = true;
        }
        /*
        private SearchPage<Collection> GetCollectionsPage(Int32 offset, Int32 limit)
        {
            PaymentsHelper ph = new PaymentsHelper();

            // Set access token and hook API call event
            ph.AccessToken = _authorization.AccessToken;
            //ah.APICall += new APICallEventHandler(OnAPICall);

            // Prepare API call arguments
            List<KeyValuePair<string, string>> args = new List<KeyValuePair<string, string>>();
            if (_authorization.IsAdmin)
            {
                args.Add(new KeyValuePair<string, string>("collector_id", _authorization.UserId.ToString()));            
            }
            args.Add(new KeyValuePair<string, string>("sort", "date_created"));
            args.Add(new KeyValuePair<string, string>("criteria", "desc"));
            args.Add(new KeyValuePair<string, string>("offset", offset.ToString()));
            args.Add(new KeyValuePair<string, string>("limit", limit.ToString()));
            args.Add(new KeyValuePair<string, string>("range", "date_created"));
            args.Add(new KeyValuePair<string, string>("begin_date", HttpUtility.UrlEncode(reportFromPicker.Value.GetDateTimeFormats('s')[0].ToString() + ".000Z")));
            args.Add(new KeyValuePair<string, string>("end_date", HttpUtility.UrlEncode(reportToPicker.Value.GetDateTimeFormats('s')[0].ToString() + ".000Z")));

            // Call API
            this.Cursor = Cursors.WaitCursor;
            SearchPage<Collection> searchPage = null;
            try
            {
                searchPage = ph.SearchCollections(args);
            }
            catch (RESTAPIException raex)
            {
                this.Cursor = Cursors.Default;
                throw raex;
            }
            this.Cursor = Cursors.Default;

            return searchPage;
        }

        private SearchPage<Movement> GetMovementsPage(Int32 offset, Int32 limit)
        { 
            AccountsHelper ah = new AccountsHelper();

            // Set access token and hook API call event
            ah.AccessToken = _authorization.AccessToken;
            //ah.APICall += new APICallEventHandler(OnAPICall);

            // Prepare API call arguments
            List<KeyValuePair<string, string>> args = new List<KeyValuePair<string, string>>();
            if (_authorization.IsAdmin)
            {
                args.Add(new KeyValuePair<string, string>("user_id", _authorization.UserId.ToString()));
            }
            args.Add(new KeyValuePair<string, string>("sort", "date_created"));
            args.Add(new KeyValuePair<string, string>("criteria", "desc"));
            args.Add(new KeyValuePair<string, string>("offset", offset.ToString()));
            args.Add(new KeyValuePair<string, string>("limit", limit.ToString()));
            args.Add(new KeyValuePair<string, string>("range", "date_created"));
            args.Add(new KeyValuePair<string, string>("begin_date", HttpUtility.UrlEncode(reportFromPicker.Value.GetDateTimeFormats('s')[0].ToString() + ".000Z")));
            args.Add(new KeyValuePair<string, string>("end_date", HttpUtility.UrlEncode(reportToPicker.Value.GetDateTimeFormats('s')[0].ToString() + ".000Z")));

            // Call API
            SearchPage<Movement> searchPage = null;
            try
            {
                searchPage = ah.SearchMovements(args);
            }
            catch (RESTAPIException raex)
            {
                throw raex;
            }

            return searchPage;
        }
        */
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
            DisableControls();
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

        private void adminAccessButton_Click(object sender, EventArgs e)
        {
            _adminForm = new AdminForm();
            _adminForm.FirstForm = this;
            _adminForm.ShowDialog();
        }
    }
}
