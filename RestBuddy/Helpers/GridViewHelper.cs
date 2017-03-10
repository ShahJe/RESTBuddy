using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace RestBuddy
{
	public static class GridViewHelper
	{
		public static List<GridViewItem> ConvertToGridViewItem(WebApiTest test)
		{
			var gridViewItems = new List<GridViewItem>();

			foreach (var testProperty in typeof(WebApiTest).GetProperties())
			{
				var val = testProperty.GetValue(test, null);
				gridViewItems.Add(new GridViewItem(testProperty.Name, val == null ? null : val.ToString()));
			}

			return gridViewItems;
		}

		public static List<string> GetAvailableProperties()
		{
			var list = new List<string>();

			foreach (var testProperty in typeof(WebApiTest).GetProperties())
			{				
				list.Add(testProperty.Name);
			}

			return list;
		}

		public static void UpdateRowBackgoundColor(DataGridViewRow row)
		{
			var test = (WebApiTest)row.DataBoundItem;

			if (test.IsEnabled)
			{
				if (test.IsTestSuccess.HasValue && !test.IsTestSuccess.Value)
				{
					row.DefaultCellStyle.BackColor = Color.Red;
				}
				else
				{
					row.DefaultCellStyle.BackColor = Color.White;					
				}
			}
			else
			{
				row.DefaultCellStyle.BackColor = Color.Yellow;
			}
		}

		public static void UpdateRowBackgoundColor(DataGridView gridView)
		{
			foreach (DataGridViewRow row in gridView.Rows)
			{
				UpdateRowBackgoundColor(row);
			}
		}
	}
}
