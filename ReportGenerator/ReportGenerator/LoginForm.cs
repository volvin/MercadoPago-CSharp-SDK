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

using SHDocVw;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ReportGenerator
{
    public partial class LoginForm : Form
    {
        public MainForm FirstForm;

        public LoginForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Navigates the login page. 
        /// </summary>
        private void LoginForm_Load(object sender, EventArgs e)
        {
            loginBrowser.Navigate("http://auth.mercadolibre.com/authorization?platform_id=mp&response_type=token&client_id=12214");
            loginBrowser.NewWindow += new CancelEventHandler(loginBrowser_NewWindow);
            SHDocVw.WebBrowser axBrowser = (SHDocVw.WebBrowser)this.loginBrowser.ActiveXInstance;
            axBrowser.NewWindow3 += new SHDocVw.DWebBrowserEvents2_NewWindow3EventHandler(axBrowser_NewWindow3);
        }

        void loginBrowser_NewWindow(object sender, CancelEventArgs e)
        {
            e.Cancel = true; // cancel navigation and avoid ie pop up
        }

        void axBrowser_NewWindow3(ref object ppDisp,ref bool Cancel, uint dwFlags, string bstrUrlContext, string bstrUrl)
        {
            // access the web page with the URL bstrUrl 
        }

        /// <summary>
        /// Browser navigation event. 
        /// </summary>
        private void loginBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            try
            {
                string accessToken = GetAccessTokenFromUrl("access_token", e.Url.ToString());
                // If navigation url includes an access token, this is our page!
                if (accessToken != "")
                {
                    DateTime expirationDate = DateTime.Now.AddSeconds(Convert.ToInt32(GetAccessTokenFromUrl("expires_in", e.Url.ToString())));
                    Int32 userId = Convert.ToInt32(GetAccessTokenFromUrl("user_id", e.Url.ToString()));
                    OAuthResponse response = new OAuthResponse(accessToken, expirationDate, userId, "");
                    FirstForm.MainForm_LoginReady(response);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message + "___" + ex.StackTrace);
            }
        }

        private string GetAccessTokenFromUrl(string key, string url)
        {
            if (url.IndexOf(key) > 0)
            {
                return SubstringUntil(url, url.IndexOf(key) + key.Length + 1, Convert.ToChar("&"));
            }
            else
            {
                return "";
            }
        }

        private string SubstringUntil(string str, int startIndex, Char stopper)
        {
            string aux = "";
            for (int i = startIndex; i <= str.Length; i++)
            {
                if (Convert.ToChar(str[i]) != stopper)
                {
                    aux += str[i];
                }
                else
                {
                    break;
                }
            }
            return aux;
        }
    }
}
