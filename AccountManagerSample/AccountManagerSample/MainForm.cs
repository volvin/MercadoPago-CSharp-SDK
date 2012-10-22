/*
 * Copyright 2011 MercadoLibre, Inc.
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

using MercadoPagoSDK;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MercadoPagoSDK.IO;

namespace AccountManagerSample
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private const int MOVEMENTS_PAGE_SIZE = 25;
        private OAuthResponse _authorization;
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

                // Hide login form and enable main form buttons
                _loginForm.Hide();
                EnableControlButtons();
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
            DisableButtons();
            ResetAccountValues();
            _authorization = null;

            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Disable form buttons and controls.
        /// </summary>
        private void DisableButtons()
        {
            DisableControlButtons();
            DisablePagerButtons();
        }

        private void DisableControlButtons()
        {
            loginButton.Enabled = true;
            getSummaryButton.Enabled = false;
            getMovementsButton.Enabled = false;
            logoutButton.Enabled = false;
        }

        private void DisablePagerButtons()
        {
            firstPageButton.Enabled = false;
            pageDownButton.Enabled = false;
            pageUpButton.Enabled = false;
            lastPageButton.Enabled = false;
            refreshPageButton.Enabled = false;
            pagerFrom.Visible = false;
            pagerTo.Visible = false;
            pagerTotal.Visible = false;
            dashLabel.Visible = false;
            ofLabel.Visible = false;
        }

        /// <summary>
        /// Reset account values.
        /// </summary>
        private void ResetAccountValues()
        {
            AvailableBalanceGridView.DataSource = null;
            AvailableBalanceLabel.Text = "";
            CurrencyIdLabel.Text = "";
            MovementsGridView.DataSource = null;
            TotalBalanceLabel.Text = "";
            UnavailableBalanceGridView.DataSource = null;
            UnavailableBalanceLabel.Text = "";
        }

        /// <summary>
        /// Enable form buttons and controls.
        /// </summary>
        private void EnableControlButtons()
        {
            loginButton.Enabled = false;
            getSummaryButton.Enabled = true;
            getMovementsButton.Enabled = true;
            logoutButton.Enabled = true;
        }

        private void EnablePagerButtons()
        {
            firstPageButton.Enabled = true;
            pageDownButton.Enabled = true;
            pageUpButton.Enabled = true;
            lastPageButton.Enabled = true;
            refreshPageButton.Enabled = true;
            pagerFrom.Visible = true;
            pagerTo.Visible = true;
            pagerTotal.Visible = true;
            dashLabel.Visible = true;
            ofLabel.Visible = true;
        }

        /// <summary>
        /// Do login.
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
        /// Do pager first page action.
        /// </summary>
        private void firstPageButton_Click(object sender, EventArgs e)
        {
            LoadSearchGrid(1, MOVEMENTS_PAGE_SIZE);
        }

        /// <summary>
        /// Do get summary.
        /// </summary>
        private void getSummaryButton_Click(object sender, EventArgs e)
        {
            AccountsHelper ah = new AccountsHelper();

            try
            {
                this.Cursor = Cursors.WaitCursor;

                // Set access token and hook API call event
                ah.AccessToken = _authorization.AccessToken;
                ah.APICall += new APICallEventHandler(OnAPICall);

                // Call API
                DateTime dt = DateTime.Now;
                AccountBalance ab = ah.GetAccountBalance(_authorization.UserId);
                TimeSpan pt = DateTime.Now.Subtract(dt);
                responseTime.Text = pt.TotalMilliseconds.ToString();

                // Set currency id
                CurrencyIdLabel.Text = ab.CurrencyId;

                // Set available balance
                AvailableBalanceLabel.Text = ab.AvailableBalance.ToString();
                AvailableBalanceGridView.DataSource = ab.AvailableBalanceByTransactionType.ToList();

                // Set unavailable balance
                UnavailableBalanceLabel.Text = ab.UnavailableBalance.ToString();
                UnavailableBalanceGridView.DataSource = ab.UnavailableBalanceByReason.ToList();

                // Set total balance
                TotalBalanceLabel.Text = ab.TotalBalance.ToString();

                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("Get Summary failure: " + ex.Message);
            }
            finally
            {
                ah.APICall -= new APICallEventHandler(OnAPICall);            
            }
        }

        /// <summary>
        /// Do get account movements.
        /// </summary>
        private void getMovementsButton_Click(object sender, EventArgs e)
        {
            LoadSearchGrid(1, MOVEMENTS_PAGE_SIZE);
            EnablePagerButtons();
        }

        /// <summary>
        /// Load search grid with API values.
        /// </summary>
        private void LoadSearchGrid(int offset, int pageSize)
        {
            AccountsHelper ah = new AccountsHelper();

            try
            {
                this.Cursor = Cursors.WaitCursor;

                // Set access token and hook API call event
                ah.AccessToken = _authorization.AccessToken;
                ah.APICall += new APICallEventHandler(OnAPICall);

                // Prepare API call arguments
                List<KeyValuePair<string, string>> args = new List<KeyValuePair<string, string>>();
                args.Add(new KeyValuePair<string, string>("sort", "date_created"));
                args.Add(new KeyValuePair<string, string>("criteria", "desc"));
                args.Add(new KeyValuePair<string, string>("offset", (offset - 1).ToString()));
                args.Add(new KeyValuePair<string, string>("limit", pageSize.ToString()));

                // Call API
                DateTime dt = DateTime.Now;
                SearchPage<Movement> searchPage = ah.SearchMovements(args);
                TimeSpan pt = DateTime.Now.Subtract(dt);
                responseTime.Text = pt.TotalMilliseconds.ToString();
                List<Movement> movements = searchPage.Results;

                // Bind this info to the grid view
                MovementsGridView.AutoGenerateColumns = false;
                MovementsGridView.DataSource = movements;

                // Set pager info
                pagerFrom.Text = offset.ToString();
                pagerTo.Text = (offset + movements.Count - 1).ToString();
                pagerTotal.Text = searchPage.Total.ToString();

                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("Search Movements failure: " + ex.Message);
            }
            finally
            {
                ah.APICall -= new APICallEventHandler(OnAPICall);
            }
        }

        /// <summary>
        /// Do pager previous page action.
        /// </summary>
        private void pageDownButton_Click(object sender, EventArgs e)
        {
            int nextOffset = Convert.ToInt16(pagerFrom.Text) - MOVEMENTS_PAGE_SIZE;
            if (nextOffset >= 1)
            {
                LoadSearchGrid(nextOffset, MOVEMENTS_PAGE_SIZE);
            }
        }

        /// <summary>
        /// Do pager next page action.
        /// </summary>
        private void pageUpButton_Click(object sender, EventArgs e)
        {
            int nextOffset = Convert.ToInt16(pagerTo.Text) + 1;
            if (nextOffset <= Convert.ToInt16(pagerTotal.Text))
            {
                LoadSearchGrid(nextOffset, MOVEMENTS_PAGE_SIZE);
            }
        }

        /// <summary>
        /// Do pager last page action.
        /// </summary>
        private void lastPageButton_Click(object sender, EventArgs e)
        {
            decimal pages = Convert.ToDecimal(pagerTotal.Text) / MOVEMENTS_PAGE_SIZE;
            int nextOffset = ((int)Math.Truncate(pages) * MOVEMENTS_PAGE_SIZE) + 1;
            LoadSearchGrid(nextOffset, MOVEMENTS_PAGE_SIZE);
        }

        /// <summary>
        /// Do pager logout.
        /// </summary>
        private void logoutButton_Click(object sender, EventArgs e)
        {
            // Clean logout form from a previous session
            this.Cursor = Cursors.WaitCursor;
            NavigateLogout();
        }

        /// <summary>
        /// Do pager refresh action.
        /// </summary>
        private void refreshPageButton_Click(object sender, EventArgs e)
        {
            int nextOffset = Convert.ToInt16(pagerFrom.Text);
            LoadSearchGrid(nextOffset, MOVEMENTS_PAGE_SIZE);
        }

        /// <summary>
        /// Initialize main form.
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.logoutBrowser.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.logoutBrowser_Navigated);
            this.logoutBrowser.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.logoutBrowser_Navigating);

            DisableButtons();
        }

        /// <summary>
        /// Manage API call event.
        /// </summary>
        private void OnAPICall(object sender, APICallEventArgs e)
        {
            DebugTextBox.Text = "";
            AppendText(DebugTextBox, "API Call:\n", Color.Brown, true);
            AppendText(DebugTextBox, "Url: ", Color.DarkGreen, true);
            AppendText(DebugTextBox, e.Url + "\n", Color.Blue, false);
            AppendText(DebugTextBox, "Response: ", Color.DarkOrange, true);
            AppendText(DebugTextBox, e.Response + "\n", Color.Blue, false);
        }

        /// <summary>
        /// Debug rich text helper.
        /// </summary>
        private void AppendText(RichTextBox box, string text, Color color, bool bold = false)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            Font selectionFont;
            if (bold)
            {
                selectionFont = new Font(box.Font, FontStyle.Bold);
            }
            else
            {
                selectionFont = new Font(box.Font, FontStyle.Regular);            
            }
            box.SelectionFont = selectionFont;
            box.AppendText(text);

            box.SelectionColor = box.ForeColor;
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
    }
}
