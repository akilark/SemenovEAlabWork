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
	public partial class StartForm : Form
	{
		SearchForm searchForm = null;
		AddWorkerForm addWorkerForm = null;
		ChangeWorkerDataForm changeWorkerDataForm = null;
		public StartForm()
		{
			InitializeComponent();
		}

		private void StartForm_Load(object sender, EventArgs e)
		{
			searchForm = new SearchForm();
			addWorkerForm = new AddWorkerForm();
			resetButton.Visible = false;
			
		}

		private void closeButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void searchButton_Click(object sender, EventArgs e)
		{
			this.Hide();
			resetButton.Visible = true;
			searchForm.ShowDialog();
			this.Show();
		}

		private void addButton_Click(object sender, EventArgs e)
		{
			this.Hide();
			addWorkerForm.ShowDialog();
			this.Show();
		}

		private void changeButton_Click(object sender, EventArgs e)
		{
			this.Hide();
			changeWorkerDataForm = new ChangeWorkerDataForm();
			changeWorkerDataForm.ShowDialog();
			this.Show();
		}

		private void resetButton_Click(object sender, EventArgs e)
		{
			resetButton.Visible = false;
		}

		private void workerListDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}
	}
}
