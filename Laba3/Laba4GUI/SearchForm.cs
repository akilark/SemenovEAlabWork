using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba4GUI
{
	public partial class SearchForm : Form
	{
		StartForm startForm = null;
		public SearchForm()
		{
			InitializeComponent();
			startForm = new StartForm();
		}

		private void closeButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void searchButton_Click(object sender, EventArgs e)
		{
			
		}
	}
}
