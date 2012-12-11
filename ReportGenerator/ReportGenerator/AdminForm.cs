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
    public partial class AdminForm : Form
    {
        public MainForm FirstForm;

        public AdminForm()
        {
            InitializeComponent();
        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            // TODO: validations
            FirstForm.MainForm_AdminLoginReady(tokenTextBox.Text, Convert.ToInt32(userTextBox.Text));
        }
    }
}
