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
		
		internal WorkersArray workerInfoList;
		string filepath = @"C:\Users\akila\source\repos\akilark\SemenovEAlabWork\Laba3\data\202104.kek";
		public WorkWithFiles files;


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
			fillingGridParam();
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

		private void deleteButton_Click(object sender, EventArgs e)
		{
			int indexDataGrid = workerListDataGrid.CurrentRow.Index;
			int indexRemove = workerInfoList.FindByName(
				workerListDataGrid.Rows[indexDataGrid].Cells[0].Value.ToString(), 
				workerListDataGrid.Rows[indexDataGrid].Cells[1].Value.ToString());
			workerInfoList.DeleteElement(indexRemove);
			files.rewriteFile(workerInfoList);
			workerListDataGrid.Rows.Remove(workerListDataGrid.CurrentRow);
		}

		private void groupBox1_Enter(object sender, EventArgs e)
		{

		}
	}
}
