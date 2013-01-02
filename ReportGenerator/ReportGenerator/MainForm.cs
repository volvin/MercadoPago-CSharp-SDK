/*
 * Copyright 2012 MercadoLibre, Inc.
 *
 * Changed to retrieve a well-formed json string running .ToString() method.
 * Allows to serialize scalar data at CreateFromString method.
 * 
 * Licensed under the Apache License, Version 2.0 (the "License"); you may
 * not use this file except in compliance with the License. You may obtain
 * a copy of the License at
 * 
 *  http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
 * WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the
 * License for the specific language governing permissions and limitations
 * under the License.
 */

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
using System.Text.RegularExpressions;
using System.IO;

namespace ReportGenerator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        // Delegates to help working thread
        public delegate void DoLoadingCallback();
        public delegate void StopLoadingCallback();
        public delegate void EnableGenerateControlsCallback();
        public delegate void UpdateProgressBarFinishedCallback();
        public delegate void UpdateProgressBarMaximumCallback(int maximum);

        /// <summary>
        /// Receives admin login event and inits authorization vars.
        /// </summary>
        public void MainForm_AdminLoginReady(string adminToken, int userId)
        {
            try
            {
                // Set app authorization
                _authorization = new OAuthResponse(adminToken, DateTime.Now.AddHours(18), userId, null, true);

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
        /// Main Form key up event. Sniffs for admin access
        /// </summary>
        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Alt && e.KeyCode == Keys.A && _authorization == null)
            {
                _adminForm = new AdminForm();
                _adminForm.FirstForm = this;
                _adminForm.ShowDialog();
            }
        }

        /// <summary>
        /// Main Form load event.
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e)
        {
            DisableLoginControls();
            reportFromPicker.Value = DateTime.Now.AddDays(-30);
            reportToPicker.Value = DateTime.Now;
            folderTextBox.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

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
        /// Receives logout event and resets authorization vars.
        /// </summary>
        public void MainForm_LogoutReady()
        {
            // Reset authorization, form controls and values
            saluteLabel.Text = "";
            DisableLoginControls();
            _authorization = null;

            StopLoading();
        }

        #region "Private Members"

        private const int ADMIN_API_QUERY_PAGE_SIZE = 1000;
        private const int USER_API_QUERY_PAGE_SIZE = 50;
        private OAuthResponse _authorization;
        private AdminForm _adminForm = null;
        private bool _continue = true;
        private LoginForm _loginForm = null;

        /// <summary>
        /// Disables generation controls.
        /// </summary>
        private void DisableGenerateControls()
        {
            generateButton.Enabled = false;
            abortButton.Enabled = true;
            abortButton.BackColor = Color.Red;
            abortButton.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// Disables login controls.
        /// </summary>
        private void DisableLoginControls()
        {
            loginButton.Enabled = true;
            logoutButton.Enabled = false;
            generateButton.Enabled = false;
            abortButton.Enabled = false;
            abortButton.BackColor = Color.White;
        }

        /// <summary>
        /// Changes form cursor to waiting.
        /// </summary>
        private void DoLoading()
        {
            this.Cursor = Cursors.WaitCursor;
        }

        /// <summary>
        /// Generate button working thread.
        /// </summary>
        private void DoWork()
        {
            int apiQueryPageSize = 0;
            List<Collection> collections = null;
            SearchPage<Collection> collectionsPage = null;
            string exceptionMessage = String.Empty;
            System.IO.StreamWriter file = null;
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

            // Set API query page size
            if (_authorization.IsAdmin)
            {
                apiQueryPageSize = ADMIN_API_QUERY_PAGE_SIZE;
            }
            else
            {
                apiQueryPageSize = USER_API_QUERY_PAGE_SIZE;            
            }

            // TODO: Simplify this, same logic twice!

            try
            {
                // Do the first API search
                progressBar.Invoke(new DoLoadingCallback(this.DoLoading), null);
                if (collectionsRadioButton.Checked)
                {
                    reportType = ReportTypes.CollectionsReport;
                    collectionsPage = BackendHelper.GetCollectionsPage(offset, apiQueryPageSize, _authorization, reportFromPicker.Value, reportToPicker.Value);
                    collections = collectionsPage.Results;
                    progressBar.Invoke(new UpdateProgressBarMaximumCallback(this.UpdateProgressBarMaximum), new object[] { collectionsPage.Total.Value });
                }
                else
                {
                    reportType = ReportTypes.MovementsReport;
                    movementsPage = BackendHelper.GetMovementsPage(offset, apiQueryPageSize, _authorization, reportFromPicker.Value, reportToPicker.Value);
                    movements = movementsPage.Results;
                    progressBar.Invoke(new UpdateProgressBarMaximumCallback(this.UpdateProgressBarMaximum), new object[] { movementsPage.Total.Value });
                }
                offset += apiQueryPageSize;
                progressBar.Invoke(new StopLoadingCallback(this.StopLoading), null);

                // Check for Excel limitation
                if ((reportFormat == ReportFormats.ExcelReport) && (progressBar.Maximum > 60000))
                {
                    MessageBox.Show("The number of rows exceeds Excel report size. Choose CSV instead.");
                    progressBar.Invoke(new EnableGenerateControlsCallback(this.EnableGenerateControls), null);
                    return;
                }

                // Set file name
                string fileName = folderTextBox.Text;
                if (fileName.Substring(fileName.Length - 1) != "\\")
                {
                    fileName += "\\";
                }
                fileName += fileNameTextBox.Text + fileExtension;

                // Open file            
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
                        // api call
                        progressBar.Invoke(new DoLoadingCallback(this.DoLoading), null);
                        collectionsPage = BackendHelper.GetCollectionsPage(offset, apiQueryPageSize, _authorization, reportFromPicker.Value, reportToPicker.Value);
                        collections = collectionsPage.Results;
                        progressBar.Invoke(new StopLoadingCallback(this.StopLoading), null);
                        if (collectionsPage.Total.Value != progressBar.Maximum)  // validate total rows consistency
                            throw new RESTAPIException(500, "Internal Server Error", "Max rows violation", "Max rows violation: current-" + collectionsPage.Total.Value.ToString() + ", previous-" + progressBar.Maximum.ToString());

                        // write to file
                        reportWritter.WriteCollections(collections);

                        offset += apiQueryPageSize;
                    }
                }
                else
                {
                    // Write first page
                    reportWritter.WriteMovements(movements);

                    // loop for more movements pages
                    while (movementsPage.Total.Value > offset && _continue)
                    {
                        // api call
                        progressBar.Invoke(new DoLoadingCallback(this.DoLoading), null);
                        movementsPage = BackendHelper.GetMovementsPage(offset, apiQueryPageSize, _authorization, reportFromPicker.Value, reportToPicker.Value);
                        movements = movementsPage.Results;
                        progressBar.Invoke(new StopLoadingCallback(this.StopLoading), null);
                        if (movementsPage.Total.Value != progressBar.Maximum)  // validate total rows consistency
                            throw new RESTAPIException(500, "Internal Server Error", "Max rows violation", "Max rows violation: current-" + movementsPage.Total.Value.ToString() + ", previous-" + progressBar.Maximum.ToString());

                        // write to file
                        reportWritter.WriteMovements(movements);

                        offset += apiQueryPageSize;
                    }
                }

                // Write report footer and close the file
                reportWritter.WriteFooter();
                file.Close();
            }
            catch (RESTAPIException raex)
            {
                exceptionMessage = "MP API Exception: " + raex.Cause;
            }
            catch (IOException ex)
            {
                exceptionMessage = "File exception: " + ex.Message;
            }
            catch (Exception e)
            {
                exceptionMessage = "Internal Exception: " + e.Message;
            }
            finally
            {
                // if error
                if (exceptionMessage != String.Empty)
                {
                    // try closing the file
                    try
                    {
                        file.Close();
                    }
                    catch
                    { }

                    // Stop loading cursor
                    progressBar.Invoke(new StopLoadingCallback(this.StopLoading), null);

                    // Show error message
                    MessageBox.Show(exceptionMessage);

                    // Enable generate buttons
                    progressBar.Invoke(new EnableGenerateControlsCallback(this.EnableGenerateControls), null);
                }
            }

            // Finish
            progressBar.Invoke(new UpdateProgressBarFinishedCallback(this.UpdateProgressBarFinished), null);
        }

        /// <summary>
        /// Enables generation controls.
        /// </summary>
        private void EnableGenerateControls()
        {
            generateButton.Enabled = true;
            abortButton.Enabled = false;
            abortButton.BackColor = Color.White;
        }

        /// <summary>
        /// Enables login controls.
        /// </summary>
        private void EnableLoginControls()
        {
            loginButton.Enabled = false;
            logoutButton.Enabled = true;
            EnableGenerateControls();
        }

        /// <summary>
        /// Changes form cursor to default.
        /// </summary>
        private void StopLoading()
        {
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Finishes process changing label text and enabling controls.
        /// </summary>
        private void UpdateProgressBarFinished()
        {
            progressLabel.Text = "Finished! Processed " + progressLabel.Text;
            EnableGenerateControls();
        }

        /// <summary>
        /// Updates progress bar maximum value.
        /// </summary>
        private void UpdateProgressBarMaximum(int maximum)
        {
            progressBar.Maximum = maximum;
        }

        /// <summary>
        /// Aborts the current process.
        /// </summary>
        private void abortButton_Click(object sender, EventArgs e)
        {
            _continue = false;
        }

        /// <summary>
        /// Verifies file name textbox input.
        /// </summary>
        private void fileNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for valid file name chars
            var regex = @"^[0-9A-Za-z_-]$";

            Match match = Regex.Match(e.KeyChar.ToString(), regex, RegexOptions.IgnoreCase);

            if (!match.Success && e.KeyChar.ToString() != "\b")
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Generate button click event.
        /// </summary>
        private void generateButton_Click(object sender, EventArgs e)
        {
            // Reset controls
            DisableGenerateControls();
            progressBar.Value = 0;
            progressLabel.Text = "";

            Thread workerThread = new Thread(DoWork);

            // Start the worker thread
            _continue = true;  // reset abort flag
            workerThread.Start();
            Console.WriteLine("main thread: Starting worker thread...");

            // Loop until worker thread activates
            while (!workerThread.IsAlive) ;

            // Put the main thread to sleep for 1 millisecond to
            // allow the worker thread to do some work:
            Thread.Sleep(1);
        }

        /// <summary>
        /// Login button click event.
        /// </summary>
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

        /// <summary>
        /// Do logout.
        /// </summary>
        private void logoutButton_Click(object sender, EventArgs e)
        {
            // Clean logout form from a previous session
            DoLoading();
            if (!_authorization.IsAdmin)
            {
                NavigateLogout();
            }
            else
            {
                MainForm_LogoutReady();
            }
        }

        /// <summary>
        /// Opens the get folder dialog.
        /// </summary>
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

        #endregion

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
    }
}
