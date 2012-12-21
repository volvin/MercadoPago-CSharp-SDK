namespace ReportGenerator
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
            this.loginButton = new System.Windows.Forms.Button();
            this.generateButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.saluteLabel = new System.Windows.Forms.Label();
            this.logoutButton = new System.Windows.Forms.Button();
            this.logoutBrowser = new System.Windows.Forms.WebBrowser();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.movementsRadioButton = new System.Windows.Forms.RadioButton();
            this.collectionsRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.csvRadioButton = new System.Windows.Forms.RadioButton();
            this.excelRadioButton = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.openGetFolderDialogButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.fileNameTextBox = new System.Windows.Forms.TextBox();
            this.folderTextBox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.reportToPicker = new System.Windows.Forms.DateTimePicker();
            this.reportFromPicker = new System.Windows.Forms.DateTimePicker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.progressLabel = new System.Windows.Forms.Label();
            this.abortButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(35, 111);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(188, 41);
            this.loginButton.TabIndex = 0;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(35, 172);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(188, 44);
            this.generateButton.TabIndex = 1;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 446);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(701, 23);
            this.progressBar.TabIndex = 2;
            // 
            // saluteLabel
            // 
            this.saluteLabel.AutoSize = true;
            this.saluteLabel.Location = new System.Drawing.Point(132, 17);
            this.saluteLabel.MinimumSize = new System.Drawing.Size(500, 0);
            this.saluteLabel.Name = "saluteLabel";
            this.saluteLabel.Size = new System.Drawing.Size(500, 13);
            this.saluteLabel.TabIndex = 31;
            this.saluteLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // logoutButton
            // 
            this.logoutButton.Location = new System.Drawing.Point(638, 12);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(75, 23);
            this.logoutButton.TabIndex = 32;
            this.logoutButton.Text = "Logout";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // logoutBrowser
            // 
            this.logoutBrowser.Location = new System.Drawing.Point(12, 390);
            this.logoutBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.logoutBrowser.Name = "logoutBrowser";
            this.logoutBrowser.Size = new System.Drawing.Size(69, 53);
            this.logoutBrowser.TabIndex = 33;
            this.logoutBrowser.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.movementsRadioButton);
            this.groupBox1.Controls.Add(this.collectionsRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(300, 336);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(413, 73);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Report Type";
            // 
            // movementsRadioButton
            // 
            this.movementsRadioButton.AutoSize = true;
            this.movementsRadioButton.Location = new System.Drawing.Point(225, 30);
            this.movementsRadioButton.Name = "movementsRadioButton";
            this.movementsRadioButton.Size = new System.Drawing.Size(140, 17);
            this.movementsRadioButton.TabIndex = 39;
            this.movementsRadioButton.Text = "My Account Movements";
            this.movementsRadioButton.UseVisualStyleBackColor = true;
            // 
            // collectionsRadioButton
            // 
            this.collectionsRadioButton.AutoSize = true;
            this.collectionsRadioButton.Checked = true;
            this.collectionsRadioButton.Location = new System.Drawing.Point(43, 30);
            this.collectionsRadioButton.Name = "collectionsRadioButton";
            this.collectionsRadioButton.Size = new System.Drawing.Size(93, 17);
            this.collectionsRadioButton.TabIndex = 38;
            this.collectionsRadioButton.TabStop = true;
            this.collectionsRadioButton.Text = "My Collections";
            this.collectionsRadioButton.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.csvRadioButton);
            this.groupBox2.Controls.Add(this.excelRadioButton);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.openGetFolderDialogButton);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.fileNameTextBox);
            this.groupBox2.Controls.Add(this.folderTextBox);
            this.groupBox2.Location = new System.Drawing.Point(300, 184);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(413, 133);
            this.groupBox2.TabIndex = 42;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Target File";
            // 
            // csvRadioButton
            // 
            this.csvRadioButton.AutoSize = true;
            this.csvRadioButton.Location = new System.Drawing.Point(201, 96);
            this.csvRadioButton.Name = "csvRadioButton";
            this.csvRadioButton.Size = new System.Drawing.Size(46, 17);
            this.csvRadioButton.TabIndex = 47;
            this.csvRadioButton.Text = "CSV";
            this.csvRadioButton.UseVisualStyleBackColor = true;
            // 
            // excelRadioButton
            // 
            this.excelRadioButton.AutoSize = true;
            this.excelRadioButton.Checked = true;
            this.excelRadioButton.Location = new System.Drawing.Point(124, 96);
            this.excelRadioButton.Name = "excelRadioButton";
            this.excelRadioButton.Size = new System.Drawing.Size(51, 17);
            this.excelRadioButton.TabIndex = 46;
            this.excelRadioButton.TabStop = true;
            this.excelRadioButton.Text = "Excel";
            this.excelRadioButton.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 45;
            this.label5.Text = "Report Format:";
            // 
            // openGetFolderDialogButton
            // 
            this.openGetFolderDialogButton.Location = new System.Drawing.Point(355, 40);
            this.openGetFolderDialogButton.Name = "openGetFolderDialogButton";
            this.openGetFolderDialogButton.Size = new System.Drawing.Size(32, 23);
            this.openGetFolderDialogButton.TabIndex = 44;
            this.openGetFolderDialogButton.Text = "...";
            this.openGetFolderDialogButton.UseVisualStyleBackColor = true;
            this.openGetFolderDialogButton.Click += new System.EventHandler(this.openGetFolderDialogButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 43;
            this.label4.Text = "File Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 42;
            this.label3.Text = "Folder";
            // 
            // fileNameTextBox
            // 
            this.fileNameTextBox.Location = new System.Drawing.Point(98, 66);
            this.fileNameTextBox.Name = "fileNameTextBox";
            this.fileNameTextBox.Size = new System.Drawing.Size(251, 20);
            this.fileNameTextBox.TabIndex = 41;
            this.fileNameTextBox.Text = "my_report";
            // 
            // folderTextBox
            // 
            this.folderTextBox.Location = new System.Drawing.Point(98, 40);
            this.folderTextBox.Name = "folderTextBox";
            this.folderTextBox.ReadOnly = true;
            this.folderTextBox.Size = new System.Drawing.Size(251, 20);
            this.folderTextBox.TabIndex = 40;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.reportToPicker);
            this.groupBox3.Controls.Add(this.reportFromPicker);
            this.groupBox3.Location = new System.Drawing.Point(300, 66);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(413, 100);
            this.groupBox3.TabIndex = 43;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Creation Date Filter";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "Date to";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Date from";
            // 
            // reportToPicker
            // 
            this.reportToPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.reportToPicker.Location = new System.Drawing.Point(131, 56);
            this.reportToPicker.Name = "reportToPicker";
            this.reportToPicker.Size = new System.Drawing.Size(130, 20);
            this.reportToPicker.TabIndex = 36;
            // 
            // reportFromPicker
            // 
            this.reportFromPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.reportFromPicker.Location = new System.Drawing.Point(131, 30);
            this.reportFromPicker.Name = "reportFromPicker";
            this.reportFromPicker.Size = new System.Drawing.Size(130, 20);
            this.reportFromPicker.TabIndex = 35;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ReportGenerator.Properties.Resources.LogoMercadoPago_es;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(227, 52);
            this.pictureBox1.TabIndex = 40;
            this.pictureBox1.TabStop = false;
            // 
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.Location = new System.Drawing.Point(213, 430);
            this.progressLabel.MinimumSize = new System.Drawing.Size(500, 0);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(500, 13);
            this.progressLabel.TabIndex = 45;
            this.progressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // abortButton
            // 
            this.abortButton.BackColor = System.Drawing.Color.White;
            this.abortButton.Location = new System.Drawing.Point(148, 224);
            this.abortButton.Name = "abortButton";
            this.abortButton.Size = new System.Drawing.Size(75, 23);
            this.abortButton.TabIndex = 46;
            this.abortButton.Text = "Abort";
            this.abortButton.UseVisualStyleBackColor = false;
            this.abortButton.Click += new System.EventHandler(this.abortButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(730, 491);
            this.Controls.Add(this.abortButton);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.logoutBrowser);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.saluteLabel);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.loginButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MercadoPago Report Generator";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label saluteLabel;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.WebBrowser logoutBrowser;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton movementsRadioButton;
        private System.Windows.Forms.RadioButton collectionsRadioButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox folderTextBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker reportToPicker;
        private System.Windows.Forms.DateTimePicker reportFromPicker;
        private System.Windows.Forms.TextBox fileNameTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button openGetFolderDialogButton;
        private System.Windows.Forms.Label progressLabel;
        private System.Windows.Forms.RadioButton csvRadioButton;
        private System.Windows.Forms.RadioButton excelRadioButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button abortButton;
    }
}

