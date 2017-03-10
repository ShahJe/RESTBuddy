using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestBuddy
{
	public class GridViewItem
	{
		public GridViewItem()
		{				
		}

		public GridViewItem(string propertyName, string propertyValue)
		{
			PropertyName = propertyName;
			PropertyValue = propertyValue;
		}

		public string PropertyName { get; set; }

		public string PropertyValue { get; set; }
	}
}
