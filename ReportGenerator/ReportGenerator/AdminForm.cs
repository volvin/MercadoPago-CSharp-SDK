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
using System.Text.RegularExpressions;

namespace ReportGenerator
{
    public partial class AdminForm : Form
    {
        public MainForm FirstForm;

        public AdminForm()
        {
            InitializeComponent();
        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            int userId = 0;

            // Validate token
            if (tokenTextBox.Text == String.Empty)
                return;

            // Validate user id
            try
            {
                userId = Convert.ToInt32(userTextBox.Text);
            }
            catch
            {
                return;
            }

            // Do admin login
            FirstForm.MainForm_AdminLoginReady(tokenTextBox.Text, userId);
        }
    }
}
