namespace AccountManagerSample
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.loginButton = new System.Windows.Forms.Button();
            this.getSummaryButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AvailableBalanceGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnavailableBalanceGridView = new System.Windows.Forms.DataGridView();
            this.Reason1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnavailableBalanceLabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.CurrencyIdLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.AvailableBalanceLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TotalBalanceLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.MovementsGridView = new System.Windows.Forms.DataGridView();
            this.DateCreated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Detail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BalancedAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.getMovementsButton = new System.Windows.Forms.Button();
            this.pagerFrom = new System.Windows.Forms.Label();
            this.pagerTo = new System.Windows.Forms.Label();
            this.pagerTotal = new System.Windows.Forms.Label();
            this.firstPageButton = new System.Windows.Forms.Button();
            this.refreshPageButton = new System.Windows.Forms.Button();
            this.pageDownButton = new System.Windows.Forms.Button();
            this.pageUpButton = new System.Windows.Forms.Button();
            this.lastPageButton = new System.Windows.Forms.Button();
            this.dashLabel = new System.Windows.Forms.Label();
            this.ofLabel = new System.Windows.Forms.Label();
            this.responseTime = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.saluteLabel = new System.Windows.Forms.Label();
            this.logoutButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.logoutBrowser = new System.Windows.Forms.WebBrowser();
            this.DebugTextBox = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AvailableBalanceGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UnavailableBalanceGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MovementsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(12, 524);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(260, 38);
            this.loginButton.TabIndex = 0;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // getSummaryButton
            // 
            this.getSummaryButton.Location = new System.Drawing.Point(12, 568);
            this.getSummaryButton.Name = "getSummaryButton";
            this.getSummaryButton.Size = new System.Drawing.Size(260, 38);
            this.getSummaryButton.TabIndex = 1;
            this.getSummaryButton.Text = "Get Account Summary";
            this.getSummaryButton.UseVisualStyleBackColor = true;
            this.getSummaryButton.Click += new System.EventHandler(this.getSummaryButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AvailableBalanceGridView);
            this.groupBox1.Controls.Add(this.UnavailableBalanceGridView);
            this.groupBox1.Controls.Add(this.UnavailableBalanceLabel);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.CurrencyIdLabel);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.AvailableBalanceLabel);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TotalBalanceLabel);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 506);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Account Summary";
            // 
            // AvailableBalanceGridView
            // 
            this.AvailableBalanceGridView.AllowUserToAddRows = false;
            this.AvailableBalanceGridView.AllowUserToDeleteRows = false;
            this.AvailableBalanceGridView.AllowUserToOrderColumns = true;
            this.AvailableBalanceGridView.AllowUserToResizeRows = false;
            this.AvailableBalanceGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.AvailableBalanceGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AvailableBalanceGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.AvailableBalanceGridView.Location = new System.Drawing.Point(6, 84);
            this.AvailableBalanceGridView.MultiSelect = false;
            this.AvailableBalanceGridView.Name = "AvailableBalanceGridView";
            this.AvailableBalanceGridView.Size = new System.Drawing.Size(248, 150);
            this.AvailableBalanceGridView.TabIndex = 25;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "TransactionType";
            this.dataGridViewTextBoxColumn1.HeaderText = "Available for";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Amount";
            this.dataGridViewTextBoxColumn2.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // UnavailableBalanceGridView
            // 
            this.UnavailableBalanceGridView.AllowUserToAddRows = false;
            this.UnavailableBalanceGridView.AllowUserToDeleteRows = false;
            this.UnavailableBalanceGridView.AllowUserToOrderColumns = true;
            this.UnavailableBalanceGridView.AllowUserToResizeRows = false;
            this.UnavailableBalanceGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.UnavailableBalanceGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UnavailableBalanceGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Reason1,
            this.Amount2});
            this.UnavailableBalanceGridView.Location = new System.Drawing.Point(6, 277);
            this.UnavailableBalanceGridView.MultiSelect = false;
            this.UnavailableBalanceGridView.Name = "UnavailableBalanceGridView";
            this.UnavailableBalanceGridView.Size = new System.Drawing.Size(248, 150);
            this.UnavailableBalanceGridView.TabIndex = 24;
            // 
            // Reason1
            // 
            this.Reason1.DataPropertyName = "Reason";
            this.Reason1.HeaderText = "Reason";
            this.Reason1.Name = "Reason1";
            this.Reason1.ReadOnly = true;
            // 
            // Amount2
            // 
            this.Amount2.DataPropertyName = "Amount";
            this.Amount2.HeaderText = "Amount";
            this.Amount2.Name = "Amount2";
            this.Amount2.ReadOnly = true;
            // 
            // UnavailableBalanceLabel
            // 
            this.UnavailableBalanceLabel.AutoSize = true;
            this.UnavailableBalanceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UnavailableBalanceLabel.Location = new System.Drawing.Point(150, 261);
            this.UnavailableBalanceLabel.Name = "UnavailableBalanceLabel";
            this.UnavailableBalanceLabel.Size = new System.Drawing.Size(0, 13);
            this.UnavailableBalanceLabel.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(25, 261);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Unavailable Balance:";
            // 
            // CurrencyIdLabel
            // 
            this.CurrencyIdLabel.AutoSize = true;
            this.CurrencyIdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrencyIdLabel.Location = new System.Drawing.Point(109, 29);
            this.CurrencyIdLabel.Name = "CurrencyIdLabel";
            this.CurrencyIdLabel.Size = new System.Drawing.Size(0, 13);
            this.CurrencyIdLabel.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Currency Id:";
            // 
            // AvailableBalanceLabel
            // 
            this.AvailableBalanceLabel.AutoSize = true;
            this.AvailableBalanceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AvailableBalanceLabel.Location = new System.Drawing.Point(137, 68);
            this.AvailableBalanceLabel.Name = "AvailableBalanceLabel";
            this.AvailableBalanceLabel.Size = new System.Drawing.Size(0, 13);
            this.AvailableBalanceLabel.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Available Balance:";
            // 
            // TotalBalanceLabel
            // 
            this.TotalBalanceLabel.AutoSize = true;
            this.TotalBalanceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalBalanceLabel.ForeColor = System.Drawing.Color.Blue;
            this.TotalBalanceLabel.Location = new System.Drawing.Point(161, 464);
            this.TotalBalanceLabel.Name = "TotalBalanceLabel";
            this.TotalBalanceLabel.Size = new System.Drawing.Size(0, 20);
            this.TotalBalanceLabel.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(24, 464);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Total Amount:";
            // 
            // MovementsGridView
            // 
            this.MovementsGridView.AllowUserToAddRows = false;
            this.MovementsGridView.AllowUserToDeleteRows = false;
            this.MovementsGridView.AllowUserToResizeColumns = false;
            this.MovementsGridView.AllowUserToResizeRows = false;
            this.MovementsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MovementsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DateCreated,
            this.Detail,
            this.Amount,
            this.BalancedAmount});
            this.MovementsGridView.Location = new System.Drawing.Point(287, 41);
            this.MovementsGridView.MultiSelect = false;
            this.MovementsGridView.Name = "MovementsGridView";
            this.MovementsGridView.Size = new System.Drawing.Size(615, 477);
            this.MovementsGridView.TabIndex = 13;
            // 
            // DateCreated
            // 
            this.DateCreated.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DateCreated.DataPropertyName = "DateCreated";
            this.DateCreated.HeaderText = "Date";
            this.DateCreated.Name = "DateCreated";
            this.DateCreated.ReadOnly = true;
            this.DateCreated.Width = 110;
            // 
            // Detail
            // 
            this.Detail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Detail.DataPropertyName = "Detail";
            this.Detail.HeaderText = "Detail";
            this.Detail.Name = "Detail";
            this.Detail.ReadOnly = true;
            this.Detail.Width = 240;
            // 
            // Amount
            // 
            this.Amount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Amount.DataPropertyName = "Amount";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.Amount.DefaultCellStyle = dataGridViewCellStyle5;
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // BalancedAmount
            // 
            this.BalancedAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.BalancedAmount.DataPropertyName = "BalancedAmount";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.BalancedAmount.DefaultCellStyle = dataGridViewCellStyle6;
            this.BalancedAmount.HeaderText = "Balanced Amount";
            this.BalancedAmount.Name = "BalancedAmount";
            this.BalancedAmount.ReadOnly = true;
            // 
            // getMovementsButton
            // 
            this.getMovementsButton.Location = new System.Drawing.Point(12, 612);
            this.getMovementsButton.Name = "getMovementsButton";
            this.getMovementsButton.Size = new System.Drawing.Size(260, 38);
            this.getMovementsButton.TabIndex = 14;
            this.getMovementsButton.Text = "Get Account Movements";
            this.getMovementsButton.UseVisualStyleBackColor = true;
            this.getMovementsButton.Click += new System.EventHandler(this.getMovementsButton_Click);
            // 
            // pagerFrom
            // 
            this.pagerFrom.AutoSize = true;
            this.pagerFrom.Location = new System.Drawing.Point(302, 529);
            this.pagerFrom.Name = "pagerFrom";
            this.pagerFrom.Size = new System.Drawing.Size(25, 13);
            this.pagerFrom.TabIndex = 15;
            this.pagerFrom.Text = "100";
            // 
            // pagerTo
            // 
            this.pagerTo.AutoSize = true;
            this.pagerTo.Location = new System.Drawing.Point(349, 529);
            this.pagerTo.Name = "pagerTo";
            this.pagerTo.Size = new System.Drawing.Size(25, 13);
            this.pagerTo.TabIndex = 16;
            this.pagerTo.Text = "200";
            // 
            // pagerTotal
            // 
            this.pagerTotal.AutoSize = true;
            this.pagerTotal.Location = new System.Drawing.Point(402, 529);
            this.pagerTotal.Name = "pagerTotal";
            this.pagerTotal.Size = new System.Drawing.Size(25, 13);
            this.pagerTotal.TabIndex = 17;
            this.pagerTotal.Text = "100";
            // 
            // firstPageButton
            // 
            this.firstPageButton.Location = new System.Drawing.Point(489, 524);
            this.firstPageButton.Name = "firstPageButton";
            this.firstPageButton.Size = new System.Drawing.Size(38, 23);
            this.firstPageButton.TabIndex = 19;
            this.firstPageButton.Text = "<<";
            this.firstPageButton.UseVisualStyleBackColor = true;
            this.firstPageButton.Click += new System.EventHandler(this.firstPageButton_Click);
            // 
            // refreshPageButton
            // 
            this.refreshPageButton.Location = new System.Drawing.Point(665, 524);
            this.refreshPageButton.Name = "refreshPageButton";
            this.refreshPageButton.Size = new System.Drawing.Size(75, 23);
            this.refreshPageButton.TabIndex = 22;
            this.refreshPageButton.Text = "Refresh";
            this.refreshPageButton.UseVisualStyleBackColor = true;
            this.refreshPageButton.Click += new System.EventHandler(this.refreshPageButton_Click);
            // 
            // pageDownButton
            // 
            this.pageDownButton.Location = new System.Drawing.Point(533, 524);
            this.pageDownButton.Name = "pageDownButton";
            this.pageDownButton.Size = new System.Drawing.Size(38, 23);
            this.pageDownButton.TabIndex = 23;
            this.pageDownButton.Text = "<";
            this.pageDownButton.UseVisualStyleBackColor = true;
            this.pageDownButton.Click += new System.EventHandler(this.pageDownButton_Click);
            // 
            // pageUpButton
            // 
            this.pageUpButton.Location = new System.Drawing.Point(577, 524);
            this.pageUpButton.Name = "pageUpButton";
            this.pageUpButton.Size = new System.Drawing.Size(38, 23);
            this.pageUpButton.TabIndex = 24;
            this.pageUpButton.Text = ">";
            this.pageUpButton.UseVisualStyleBackColor = true;
            this.pageUpButton.Click += new System.EventHandler(this.pageUpButton_Click);
            // 
            // lastPageButton
            // 
            this.lastPageButton.Location = new System.Drawing.Point(621, 524);
            this.lastPageButton.Name = "lastPageButton";
            this.lastPageButton.Size = new System.Drawing.Size(38, 23);
            this.lastPageButton.TabIndex = 25;
            this.lastPageButton.Text = ">>";
            this.lastPageButton.UseVisualStyleBackColor = true;
            this.lastPageButton.Click += new System.EventHandler(this.lastPageButton_Click);
            // 
            // dashLabel
            // 
            this.dashLabel.AutoSize = true;
            this.dashLabel.Location = new System.Drawing.Point(333, 529);
            this.dashLabel.Name = "dashLabel";
            this.dashLabel.Size = new System.Drawing.Size(10, 13);
            this.dashLabel.TabIndex = 26;
            this.dashLabel.Text = "-";
            // 
            // ofLabel
            // 
            this.ofLabel.AutoSize = true;
            this.ofLabel.Location = new System.Drawing.Point(380, 529);
            this.ofLabel.Name = "ofLabel";
            this.ofLabel.Size = new System.Drawing.Size(16, 13);
            this.ofLabel.TabIndex = 27;
            this.ofLabel.Text = "of";
            // 
            // responseTime
            // 
            this.responseTime.AutoSize = true;
            this.responseTime.Location = new System.Drawing.Point(759, 529);
            this.responseTime.MinimumSize = new System.Drawing.Size(100, 0);
            this.responseTime.Name = "responseTime";
            this.responseTime.Size = new System.Drawing.Size(100, 13);
            this.responseTime.TabIndex = 28;
            this.responseTime.Text = "?";
            this.responseTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(865, 529);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "ms";
            // 
            // saluteLabel
            // 
            this.saluteLabel.AutoSize = true;
            this.saluteLabel.Location = new System.Drawing.Point(320, 22);
            this.saluteLabel.MinimumSize = new System.Drawing.Size(500, 0);
            this.saluteLabel.Name = "saluteLabel";
            this.saluteLabel.Size = new System.Drawing.Size(500, 13);
            this.saluteLabel.TabIndex = 30;
            this.saluteLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // logoutButton
            // 
            this.logoutButton.Location = new System.Drawing.Point(826, 17);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(75, 23);
            this.logoutButton.TabIndex = 31;
            this.logoutButton.Text = "Logout";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(288, 566);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Debug";
            // 
            // logoutBrowser
            // 
            this.logoutBrowser.Location = new System.Drawing.Point(12, 625);
            this.logoutBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.logoutBrowser.Name = "logoutBrowser";
            this.logoutBrowser.Size = new System.Drawing.Size(69, 53);
            this.logoutBrowser.TabIndex = 32;
            this.logoutBrowser.Visible = false;
            // 
            // DebugTextBox
            // 
            this.DebugTextBox.Location = new System.Drawing.Point(287, 582);
            this.DebugTextBox.Name = "DebugTextBox";
            this.DebugTextBox.Size = new System.Drawing.Size(615, 96);
            this.DebugTextBox.TabIndex = 35;
            this.DebugTextBox.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 690);
            this.Controls.Add(this.DebugTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.logoutBrowser);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.saluteLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.responseTime);
            this.Controls.Add(this.ofLabel);
            this.Controls.Add(this.dashLabel);
            this.Controls.Add(this.lastPageButton);
            this.Controls.Add(this.pageUpButton);
            this.Controls.Add(this.pageDownButton);
            this.Controls.Add(this.refreshPageButton);
            this.Controls.Add(this.firstPageButton);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.pagerTotal);
            this.Controls.Add(this.pagerTo);
            this.Controls.Add(this.pagerFrom);
            this.Controls.Add(this.getMovementsButton);
            this.Controls.Add(this.MovementsGridView);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.getSummaryButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Account Manager Sample";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AvailableBalanceGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UnavailableBalanceGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MovementsGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Button getSummaryButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label UnavailableBalanceLabel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label CurrencyIdLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label AvailableBalanceLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label TotalBalanceLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView MovementsGridView;
        private System.Windows.Forms.Button getMovementsButton;
        private System.Windows.Forms.Label pagerFrom;
        private System.Windows.Forms.Label pagerTo;
        private System.Windows.Forms.Label pagerTotal;
        private System.Windows.Forms.Button firstPageButton;
        private System.Windows.Forms.Button refreshPageButton;
        private System.Windows.Forms.Button pageDownButton;
        private System.Windows.Forms.Button pageUpButton;
        private System.Windows.Forms.Button lastPageButton;
        private System.Windows.Forms.Label dashLabel;
        private System.Windows.Forms.Label ofLabel;
        private System.Windows.Forms.Label responseTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label saluteLabel;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.WebBrowser logoutBrowser;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateCreated;
        private System.Windows.Forms.DataGridViewTextBoxColumn Detail;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn BalancedAmount;
        private System.Windows.Forms.DataGridView UnavailableBalanceGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reason1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount2;
        private System.Windows.Forms.DataGridView AvailableBalanceGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox DebugTextBox;
    }
}

