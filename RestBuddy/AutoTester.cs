using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml.Xsl;

namespace RestBuddy
{
	public partial class RestBuddy : Form
	{
		private XslCompiledTransform Xsl { get; set; }

		private DateTime TestStartTime { get; set; }

		private WebApiTest SelectedTest { get; set; }		

		public RestBuddy()
		{
			InitializeComponent();			
			testDataGridView.AutoGenerateColumns = false;
			Xsl = XmlHelper.LoadXsl();
			LoadRecent();
			LoadAvailableProperties();
		}

		private void LoadAvailableProperties()
		{
			showColumnComboBox.DataSource = GridViewHelper.GetAvailableProperties();
		}

		private void LoadRecent()
		{
			try
			{
				recentComboBox.Items.Clear();
				XmlHelper.LoadRecent().ForEach(x => recentComboBox.Items.Add(x));

				if (recentComboBox.Items.Count > 0)
				{
					recentComboBox.SelectedIndex = 0;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Unable to load recent files", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void LoadTests(string fileName)
		{
			try
			{
				var tests = XmlHelper.LoadTests(fileName);

				testDataGridView.DataSource = tests;

				if (testDataGridView.Rows.Count > 0)
				{
					testDataGridView.Rows[0].Selected = true;
					SelectedTest = (WebApiTest)testDataGridView.Rows[0].DataBoundItem;
					RefreshDetailGrid();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Unable to load tests", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void DisplayProgress(int percent, double seconds)
		{
			testRunTimelabel.Text = string.Format("Progress: {0}%, Run Time: {1} seconds", percent, seconds);
		}

		private void RefreshDetailGrid()
		{
			testDetailDataGridView.DataSource = GridViewHelper.ConvertToGridViewItem(SelectedTest);
			testDataGridView.ClearSelection();
			
			foreach(DataGridViewRow row in testDetailDataGridView.Rows)			
			{
				var dataItem = (GridViewItem)row.DataBoundItem;
				
				if (dataItem.PropertyName == (string)showColumnComboBox.SelectedItem)
				{
					row.Selected = true;
					UpdateBrowser(dataItem.PropertyValue);
				}
			}			
		}

		private void UpdateBrowser(string displayText)
		{
			propertyDetailWebBrowser.DocumentText = XmlHelper.GetFormattedStringForBrowser(displayText, Xsl);
		}

		private void SetTestRunning(bool isRunning)
		{
			if (isRunning)
			{
				DisplayProgress(0, 0);
			}

			testRunningLabel.Text = isRunning ? "Running" : "Not Running";
			testCancelButton.Enabled = isRunning;
			runOneTestButton.Enabled = !isRunning;
			runAllTestsButton.Enabled = !isRunning;
		}

		#region Event Handlers
		private void runOneTestButton_Click(object sender, EventArgs e)
		{
			SetTestRunning(true);
			var tests = new List<WebApiTest> { SelectedTest };
			backgroundWorker1.RunWorkerAsync(tests);
		}

		private void runAllTestsButton_Click(object sender, EventArgs e)
		{
			SetTestRunning(true);

			var tests = new List<WebApiTest>();
			foreach (DataGridViewRow row in testDataGridView.Rows)
			{
				var test = (WebApiTest)row.DataBoundItem;

				if (test.IsEnabled)
				{
					tests.Add(test);
				}
			}

			backgroundWorker1.RunWorkerAsync(tests);			
		}

		private void testCancelButton_Click(object sender, EventArgs e)
		{
			backgroundWorker1.CancelAsync();
			testRunningLabel.Text = "Cancelling";
		}

		private void testDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
		{
			SelectedTest = (WebApiTest)testDataGridView.Rows[e.RowIndex].DataBoundItem;
			RefreshDetailGrid();
		}

		private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
		{
			TestStartTime = DateTime.Now;
			var tests = (List<WebApiTest>)e.Argument;
			var count = 1;
			var totalTests = tests.Count;

			foreach (var test in tests)
			{
				if (backgroundWorker1.CancellationPending)
				{
					e.Cancel = true;
					return;
				}

				e.Result = test.Run();
				backgroundWorker1.ReportProgress((count * 100) / totalTests);
				count++;
			}
		}

		private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			DisplayProgress(e.ProgressPercentage, (DateTime.Now - TestStartTime).TotalSeconds);
		}

		private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			SetTestRunning(false);
			RefreshDetailGrid();
			GridViewHelper.UpdateRowBackgoundColor(testDataGridView);
		}

		private void testDetailDataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			UpdateBrowser(testDetailDataGridView.Rows[e.RowIndex].Cells[1].Value as string);
		}

		private void testDetailDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
		{
			UpdateBrowser(testDetailDataGridView.Rows[e.RowIndex].Cells[1].Value as string);
		}

		private void testDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{

		}		

		private void openButton_Click(object sender, EventArgs e)
		{
			openFileDialog1.Filter = @"XML Files(*.xml)|*.xml";
			openFileDialog1.ShowDialog();
		}

		private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
		{
			if (!recentComboBox.Items.Contains(openFileDialog1.FileName))
			{
				recentComboBox.Items.Add(openFileDialog1.FileName);
				recentComboBox.SelectedItem = openFileDialog1.FileName;

				XmlHelper.WriteRecentFiles(recentComboBox.Items);
			}
		}

		private void recentComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			LoadTests(recentComboBox.SelectedItem.ToString());
		}

		#endregion		
	}
}
