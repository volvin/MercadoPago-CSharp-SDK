/*
 * Copyright 2013 MercadoLibre, Inc.
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
using System.Threading;
using System.IO;
using System.Reflection;

namespace LocalIPNSimulator
{
    public partial class MainForm : Form
    {
        private string _clientId = "";
        private string _clientSecret = "";
        private string _endPoint = "";
        private Int32? _lastProcessedCollectionId = null;
        private bool _manualStop = false;
        private bool _terminating = false;
        private NotifyIcon _trayIcon;
        private ContextMenu _trayMenu;

        public MainForm()
        {
            // Create tray menu              
            _trayMenu = new ContextMenu();
            _trayMenu.MenuItems.Add("Start", OnStart);
            _trayMenu.MenuItems.Add("Stop", OnStop);
            _trayMenu.MenuItems.Add("Options", OnOptions);
            _trayMenu.MenuItems.Add("Exit", OnExit);

            // Disable stop option
            _trayMenu.MenuItems[1].Enabled = false;

            // Create a tray icon
            _trayIcon = new NotifyIcon();
            _trayIcon.Text = "Local IPN Simulator";
            System.Reflection.Assembly myAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream("LocalIPNSimulator.Resources.icon_red.ico");
            _trayIcon.Icon = new Icon(myStream);

            // Add menu to tray icon and show it
            _trayIcon.ContextMenu = _trayMenu;
            _trayIcon.Visible = true;

            // Do standard initialize
            InitializeComponent();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_terminating)
            {
                // Prevent Options form from closing, except when finalizing app
                e.Cancel = true;
                this.Visible = false;
            }
        }

        private void OnExit(object sender, EventArgs e)
        {
            // Terminate app
            _terminating = true;
            _trayIcon.Dispose();
            Application.Exit();
        }

        protected override void OnLoad(EventArgs e)
        {
            Visible = false; // Hide form window.
            ShowInTaskbar = false; // Remove from taskbar.

            base.OnLoad(e);
        }

        private void OnOptions(object sender, EventArgs e)
        {
            // Show options form
            this.Visible = true;
            this.TopLevel = true;
        }

        private void OnStart(object sender, EventArgs e)
        {
            // Validate configuration
            _clientId = ClientIdTextBox.Text;
            _clientSecret = ClientSecretTextBox.Text;
            _endPoint = LocalEndPointTextBox.Text;
            if ((_clientId == String.Empty) || (_clientSecret == String.Empty) || (_endPoint == String.Empty))
            {
                OnOptions(null, null);
                return;
            }

            // Rebuild menu, disable start, enable stop
            _manualStop = false;
            _trayMenu.MenuItems[0].Enabled = false;
            _trayMenu.MenuItems[1].Enabled = true;
            _trayMenu.MenuItems[2].Enabled = false;
            _trayMenu.MenuItems[3].Enabled = false;
            System.Reflection.Assembly myAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream("LocalIPNSimulator.Resources.icon_green.ico");
            _trayIcon.Icon = new Icon(myStream);

            // Run the process in a new thread
            Thread _processThread = new Thread(this.RunProcess);
            _processThread.IsBackground = true;
            _processThread.Start();
        }

        private void OnStop(object sender, EventArgs e)
        {
            // Show stopping message
            _trayIcon.ShowBalloonTip(200, "Stopping", "Wait a moment please ...", ToolTipIcon.None);

            // Change manual stop flag
            _manualStop = true;
        }

        private void RunProcess()
        {
            // Show start message
            _trayIcon.ShowBalloonTip(200, "Ready!", "Waiting for payments ...", ToolTipIcon.None);
            
            // Set MercadoPago helper
            MercadoPagoHelper mph = new MercadoPagoHelper();

            // Set helper environment
            if (SandboxEnvButton.Checked)
            {
                mph.EnvironmentScope = MercadoPagoSDK.Environment.Scopes.Sandbox;
            }
            else
            {
                mph.EnvironmentScope = MercadoPagoSDK.Environment.Scopes.Live;
            }

            // Set helper credentials
            try
            {
                Token token = AuthHelper.CreateAccessToken(_clientId, _clientSecret);
                mph.AccessToken = token.AccessToken;
            }
            catch (Exception ex)
            {
                _trayIcon.ShowBalloonTip(200, "Error resolving credentials", ex.Message, ToolTipIcon.Error);
                _manualStop = true;
            }

            // Iterate until manual stop ...
            while (!_manualStop)
            {
                // Search collections
                List<Int32> pendingCollections = new List<Int32>();
                try
                {
                    pendingCollections = mph.GetPendingCollections(_lastProcessedCollectionId);
                }
                catch (Exception ex)
                {
                    _trayIcon.ShowBalloonTip(200, "Error retrieving collections", ex.Message, ToolTipIcon.Error);
                    _manualStop = true;
                }

                // For each non-processed collection, get notification and post message to the local listener
                if (pendingCollections.Count != 0)
                {
                    if (_lastProcessedCollectionId != null)
                    {
                        for (int i = (pendingCollections.Count - 1); i >= 0; i--)
                        {
                            try
                            {
                                // Post IPN message
                                _trayIcon.ShowBalloonTip(200, "Found!", "Collection: " + pendingCollections[i].ToString(), ToolTipIcon.None);
                                mph.PostIPNMessage(_endPoint, pendingCollections[i]);
                            }
                            catch (Exception ex)
                            {
                                // In this version of the tool any possible error is ignored. Don't worry about debugging problems
                                // or timeouts. But this hides potential local IPN url configuration errors.
                            }
                        }
                    }

                    // Mark last processed collection
                    _lastProcessedCollectionId = pendingCollections[0];
                }
                else
                {
                    if (_lastProcessedCollectionId == null)
                    {
                        _lastProcessedCollectionId = -1;
                    }
                }

                // Wait for next loop ...
                Thread.Sleep(3000);
            }

            // Rebuild menu, enable start, disable stop
            _trayMenu.MenuItems[0].Enabled = true;
            _trayMenu.MenuItems[1].Enabled = false;
            _trayMenu.MenuItems[2].Enabled = true;
            _trayMenu.MenuItems[3].Enabled = true;
            System.Reflection.Assembly myAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream("LocalIPNSimulator.Resources.icon_red.ico");
            _trayIcon.Icon = new Icon(myStream);
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            // TODO: Save info?

            // Hide Options form
            this.Visible = false;
        }
    }
}
