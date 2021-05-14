using System;
using System.Collections.Generic;
using Laba3.Logic;
using System.IO;
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
		WorkersArray workerInfoList;
		string filepath = @"C:\Users\akila\source\repos\akilark\SemenovEAlabWork\Laba3\data\202104.kek";
		WorkWithFiles files;


		public StartForm()
		{
			InitializeComponent();
		}

		private void StartForm_Load(object sender, EventArgs e)
		{
			searchForm = new SearchForm();
			addWorkerForm = new AddWorkerForm();
			resetButton.Visible = false;
			files = new WorkWithFiles(filepath);
			files.ReadFileInfo();
			workerInfoList = files.WorkerArray;
			fillingGridParam();

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
			files = new WorkWithFiles(filepath);
			files.ReadFileInfo();
			workerInfoList = files.WorkerArray;
			fillingGridParam();
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

		internal void fillingGridParam()
		{
			workerListDataGrid.Rows.Clear();
			foreach (Worker info in workerInfoList.Workers)
			{
				workerListDataGrid.Rows.Add(new string[] {
					info.SecondName, 
					info.FirstName, 
					info.Wage.NameOfWageType,
					info.Wage.AmountMoney.ToString() });
			}
			
		}
	}
}
