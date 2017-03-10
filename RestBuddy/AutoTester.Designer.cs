namespace RestBuddy
{
	partial class RestBuddy
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
			this.topPanel = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.showColumnComboBox = new System.Windows.Forms.ComboBox();
			this.openButton = new System.Windows.Forms.Button();
			this.recentComboBox = new System.Windows.Forms.ComboBox();
			this.testRunningLabel = new System.Windows.Forms.Label();
			this.testCancelButton = new System.Windows.Forms.Button();
			this.testRunTimelabel = new System.Windows.Forms.Label();
			this.runAllTestsButton = new System.Windows.Forms.Button();
			this.runOneTestButton = new System.Windows.Forms.Button();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.leftPanel = new System.Windows.Forms.GroupBox();
			this.testDataGridView = new System.Windows.Forms.DataGridView();
			this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.propertyDetailWebBrowser = new System.Windows.Forms.WebBrowser();
			this.testDetailDataGridView = new System.Windows.Forms.DataGridView();
			this.PropertyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.PropertyValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.topPanel.SuspendLayout();
			this.leftPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.testDataGridView)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.testDetailDataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// topPanel
			// 
			this.topPanel.BackColor = System.Drawing.SystemColors.Control;
			this.topPanel.Controls.Add(this.label4);
			this.topPanel.Controls.Add(this.label3);
			this.topPanel.Controls.Add(this.label2);
			this.topPanel.Controls.Add(this.label1);
			this.topPanel.Controls.Add(this.showColumnComboBox);
			this.topPanel.Controls.Add(this.openButton);
			this.topPanel.Controls.Add(this.recentComboBox);
			this.topPanel.Controls.Add(this.testRunningLabel);
			this.topPanel.Controls.Add(this.testCancelButton);
			this.topPanel.Controls.Add(this.testRunTimelabel);
			this.topPanel.Controls.Add(this.runAllTestsButton);
			this.topPanel.Controls.Add(this.runOneTestButton);
			this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.topPanel.Location = new System.Drawing.Point(0, 0);
			this.topPanel.Name = "topPanel";
			this.topPanel.Size = new System.Drawing.Size(984, 78);
			this.topPanel.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(59, 34);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(195, 13);
			this.label1.TabIndex = 8;
			this.label1.Text = "Choose property to display automatically";
			// 
			// showColumnComboBox
			// 
			this.showColumnComboBox.FormattingEnabled = true;
			this.showColumnComboBox.Location = new System.Drawing.Point(261, 31);
			this.showColumnComboBox.Name = "showColumnComboBox";
			this.showColumnComboBox.Size = new System.Drawing.Size(177, 21);
			this.showColumnComboBox.TabIndex = 7;
			// 
			// openButton
			// 
			this.openButton.Location = new System.Drawing.Point(599, 3);
			this.openButton.Name = "openButton";
			this.openButton.Size = new System.Drawing.Size(75, 23);
			this.openButton.TabIndex = 6;
			this.openButton.Text = "Open";
			this.openButton.UseVisualStyleBackColor = true;
			this.openButton.Click += new System.EventHandler(this.openButton_Click);
			// 
			// recentComboBox
			// 
			this.recentComboBox.FormattingEnabled = true;
			this.recentComboBox.Location = new System.Drawing.Point(261, 3);
			this.recentComboBox.Name = "recentComboBox";
			this.recentComboBox.Size = new System.Drawing.Size(332, 21);
			this.recentComboBox.TabIndex = 5;
			this.recentComboBox.SelectedIndexChanged += new System.EventHandler(this.recentComboBox_SelectedIndexChanged);
			// 
			// testRunningLabel
			// 
			this.testRunningLabel.AutoSize = true;
			this.testRunningLabel.Dock = System.Windows.Forms.DockStyle.Right;
			this.testRunningLabel.Location = new System.Drawing.Point(742, 0);
			this.testRunningLabel.Name = "testRunningLabel";
			this.testRunningLabel.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
			this.testRunningLabel.Size = new System.Drawing.Size(67, 18);
			this.testRunningLabel.TabIndex = 4;
			this.testRunningLabel.Text = "Not Running";
			// 
			// testCancelButton
			// 
			this.testCancelButton.Enabled = false;
			this.testCancelButton.Location = new System.Drawing.Point(179, 3);
			this.testCancelButton.Name = "testCancelButton";
			this.testCancelButton.Size = new System.Drawing.Size(75, 23);
			this.testCancelButton.TabIndex = 3;
			this.testCancelButton.Text = "Cancel";
			this.testCancelButton.UseVisualStyleBackColor = true;
			this.testCancelButton.Click += new System.EventHandler(this.testCancelButton_Click);
			// 
			// testRunTimelabel
			// 
			this.testRunTimelabel.AutoSize = true;
			this.testRunTimelabel.Dock = System.Windows.Forms.DockStyle.Right;
			this.testRunTimelabel.Location = new System.Drawing.Point(809, 0);
			this.testRunTimelabel.Name = "testRunTimelabel";
			this.testRunTimelabel.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
			this.testRunTimelabel.Size = new System.Drawing.Size(175, 18);
			this.testRunTimelabel.TabIndex = 2;
			this.testRunTimelabel.Text = "Progress: 0%, Run Time: 0 seconds";
			// 
			// runAllTestsButton
			// 
			this.runAllTestsButton.Location = new System.Drawing.Point(2, 3);
			this.runAllTestsButton.Name = "runAllTestsButton";
			this.runAllTestsButton.Size = new System.Drawing.Size(75, 23);
			this.runAllTestsButton.TabIndex = 1;
			this.runAllTestsButton.Text = "Run All";
			this.runAllTestsButton.UseVisualStyleBackColor = true;
			this.runAllTestsButton.Click += new System.EventHandler(this.runAllTestsButton_Click);
			// 
			// runOneTestButton
			// 
			this.runOneTestButton.Location = new System.Drawing.Point(83, 3);
			this.runOneTestButton.Name = "runOneTestButton";
			this.runOneTestButton.Size = new System.Drawing.Size(90, 23);
			this.runOneTestButton.TabIndex = 0;
			this.runOneTestButton.Text = "Run Selected";
			this.runOneTestButton.UseVisualStyleBackColor = true;
			this.runOneTestButton.Click += new System.EventHandler(this.runOneTestButton_Click);
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(300, 78);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(3, 523);
			this.splitter1.TabIndex = 2;
			this.splitter1.TabStop = false;
			// 
			// backgroundWorker1
			// 
			this.backgroundWorker1.WorkerReportsProgress = true;
			this.backgroundWorker1.WorkerSupportsCancellation = true;
			this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
			this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
			this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.Title = "Select Test Config File";
			this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
			// 
			// leftPanel
			// 
			this.leftPanel.BackColor = System.Drawing.SystemColors.Control;
			this.leftPanel.Controls.Add(this.testDataGridView);
			this.leftPanel.Dock = System.Windows.Forms.DockStyle.Left;
			this.leftPanel.Location = new System.Drawing.Point(0, 78);
			this.leftPanel.Name = "leftPanel";
			this.leftPanel.Size = new System.Drawing.Size(300, 523);
			this.leftPanel.TabIndex = 1;
			this.leftPanel.TabStop = false;
			this.leftPanel.Text = "Available Tests";
			// 
			// testDataGridView
			// 
			this.testDataGridView.AllowUserToAddRows = false;
			this.testDataGridView.AllowUserToDeleteRows = false;
			this.testDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.testDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
			this.testDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.testDataGridView.Location = new System.Drawing.Point(3, 16);
			this.testDataGridView.Name = "testDataGridView";
			this.testDataGridView.Size = new System.Drawing.Size(294, 504);
			this.testDataGridView.TabIndex = 0;
			this.testDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.testDataGridView_DataError);
			this.testDataGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.testDataGridView_RowEnter);
			// 
			// Column1
			// 
			this.Column1.DataPropertyName = "IsEnabled";
			this.Column1.HeaderText = "Enabled";
			this.Column1.Name = "Column1";
			this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.Column1.Width = 50;
			// 
			// Column2
			// 
			this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Column2.DataPropertyName = "Name";
			this.Column2.HeaderText = "Test Name";
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.propertyDetailWebBrowser);
			this.groupBox1.Controls.Add(this.testDetailDataGridView);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(303, 78);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(681, 523);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Selected Test Details";
			// 
			// propertyDetailWebBrowser
			// 
			this.propertyDetailWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
			this.propertyDetailWebBrowser.Location = new System.Drawing.Point(3, 369);
			this.propertyDetailWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
			this.propertyDetailWebBrowser.Name = "propertyDetailWebBrowser";
			this.propertyDetailWebBrowser.ScriptErrorsSuppressed = true;
			this.propertyDetailWebBrowser.Size = new System.Drawing.Size(675, 151);
			this.propertyDetailWebBrowser.TabIndex = 6;
			// 
			// testDetailDataGridView
			// 
			this.testDetailDataGridView.AllowUserToAddRows = false;
			this.testDetailDataGridView.AllowUserToDeleteRows = false;
			this.testDetailDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.testDetailDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PropertyName,
            this.PropertyValue});
			this.testDetailDataGridView.Dock = System.Windows.Forms.DockStyle.Top;
			this.testDetailDataGridView.Location = new System.Drawing.Point(3, 16);
			this.testDetailDataGridView.MultiSelect = false;
			this.testDetailDataGridView.Name = "testDetailDataGridView";
			this.testDetailDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.testDetailDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.testDetailDataGridView.Size = new System.Drawing.Size(675, 353);
			this.testDetailDataGridView.TabIndex = 5;
			this.testDetailDataGridView.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.testDetailDataGridView_CellEnter);
			this.testDetailDataGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.testDetailDataGridView_RowEnter);
			// 
			// PropertyName
			// 
			this.PropertyName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.PropertyName.DataPropertyName = "PropertyName";
			this.PropertyName.HeaderText = "PropertyName";
			this.PropertyName.Name = "PropertyName";
			this.PropertyName.ReadOnly = true;
			this.PropertyName.Width = 99;
			// 
			// PropertyValue
			// 
			this.PropertyValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.PropertyValue.DataPropertyName = "PropertyValue";
			this.PropertyValue.HeaderText = "PropertyValue";
			this.PropertyValue.Name = "PropertyValue";
			this.PropertyValue.Width = 98;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Yellow;
			this.label2.Location = new System.Drawing.Point(129, 54);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 13);
			this.label2.TabIndex = 9;
			this.label2.Text = "Disabled";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Red;
			this.label3.ForeColor = System.Drawing.Color.White;
			this.label3.Location = new System.Drawing.Point(183, 54);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(35, 13);
			this.label3.TabIndex = 10;
			this.label3.Text = "Failed";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(59, 54);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 13);
			this.label4.TabIndex = 11;
			this.label4.Text = "Test Status:";
			// 
			// RestBuddy
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 601);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.leftPanel);
			this.Controls.Add(this.topPanel);
			this.MinimumSize = new System.Drawing.Size(1000, 640);
			this.Name = "RestBuddy";
			this.Text = "RestBuddy";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.topPanel.ResumeLayout(false);
			this.topPanel.PerformLayout();
			this.leftPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.testDataGridView)).EndInit();
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.testDetailDataGridView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel topPanel;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Button runOneTestButton;
		private System.ComponentModel.BackgroundWorker backgroundWorker1;
		private System.Windows.Forms.Button runAllTestsButton;
		private System.Windows.Forms.Label testRunTimelabel;
		private System.Windows.Forms.Button testCancelButton;
		private System.Windows.Forms.Label testRunningLabel;
		private System.Windows.Forms.ComboBox recentComboBox;
		private System.Windows.Forms.Button openButton;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.GroupBox leftPanel;
		private System.Windows.Forms.DataGridView testDataGridView;
		private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
		private System.Windows.Forms.ComboBox showColumnComboBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.WebBrowser propertyDetailWebBrowser;
		private System.Windows.Forms.DataGridView testDetailDataGridView;
		private System.Windows.Forms.DataGridViewTextBoxColumn PropertyName;
		private System.Windows.Forms.DataGridViewTextBoxColumn PropertyValue;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
	}
}