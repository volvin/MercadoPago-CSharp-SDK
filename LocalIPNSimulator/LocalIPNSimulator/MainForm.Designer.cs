namespace LocalIPNSimulator
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Release the icon resource.
                _trayIcon.Dispose();
            }
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ClientIdTextBox = new System.Windows.Forms.TextBox();
            this.ClientSecretTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.LocalEndPointTextBox = new System.Windows.Forms.TextBox();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SandboxEnvButton = new System.Windows.Forms.RadioButton();
            this.LiveEnvButton = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Client Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Client Secret";
            // 
            // ClientIdTextBox
            // 
            this.ClientIdTextBox.Location = new System.Drawing.Point(116, 24);
            this.ClientIdTextBox.Name = "ClientIdTextBox";
            this.ClientIdTextBox.Size = new System.Drawing.Size(141, 20);
            this.ClientIdTextBox.TabIndex = 2;
            // 
            // ClientSecretTextBox
            // 
            this.ClientSecretTextBox.Location = new System.Drawing.Point(116, 63);
            this.ClientSecretTextBox.Name = "ClientSecretTextBox";
            this.ClientSecretTextBox.Size = new System.Drawing.Size(255, 20);
            this.ClientSecretTextBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Local End Point";
            // 
            // LocalEndPointTextBox
            // 
            this.LocalEndPointTextBox.Location = new System.Drawing.Point(116, 102);
            this.LocalEndPointTextBox.Name = "LocalEndPointTextBox";
            this.LocalEndPointTextBox.Size = new System.Drawing.Size(307, 20);
            this.LocalEndPointTextBox.TabIndex = 5;
            // 
            // UpdateButton
            // 
            this.UpdateButton.Location = new System.Drawing.Point(312, 172);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(111, 41);
            this.UpdateButton.TabIndex = 6;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SandboxEnvButton);
            this.groupBox1.Controls.Add(this.LiveEnvButton);
            this.groupBox1.Location = new System.Drawing.Point(31, 135);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(202, 100);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Environment";
            // 
            // SandboxEnvButton
            // 
            this.SandboxEnvButton.AutoSize = true;
            this.SandboxEnvButton.Checked = true;
            this.SandboxEnvButton.Location = new System.Drawing.Point(58, 61);
            this.SandboxEnvButton.Name = "SandboxEnvButton";
            this.SandboxEnvButton.Size = new System.Drawing.Size(67, 17);
            this.SandboxEnvButton.TabIndex = 10;
            this.SandboxEnvButton.TabStop = true;
            this.SandboxEnvButton.Text = "Sandbox";
            this.SandboxEnvButton.UseVisualStyleBackColor = true;
            // 
            // LiveEnvButton
            // 
            this.LiveEnvButton.AutoSize = true;
            this.LiveEnvButton.Location = new System.Drawing.Point(58, 23);
            this.LiveEnvButton.Name = "LiveEnvButton";
            this.LiveEnvButton.Size = new System.Drawing.Size(45, 17);
            this.LiveEnvButton.TabIndex = 9;
            this.LiveEnvButton.Text = "Live";
            this.LiveEnvButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 276);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.LocalEndPointTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ClientSecretTextBox);
            this.Controls.Add(this.ClientIdTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Options";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ClientIdTextBox;
        private System.Windows.Forms.TextBox ClientSecretTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox LocalEndPointTextBox;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton SandboxEnvButton;
        private System.Windows.Forms.RadioButton LiveEnvButton;
    }
}

