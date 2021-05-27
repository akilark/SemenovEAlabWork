using System;
using System.Collections.Generic;
using System.ComponentModel;
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
		public string filepath = @"C:\";
		public WorkWithFiles filesWork;
		BindingList<Worker> bindingList;

		#if !DEBUG
		CreateRandomData.Visible = false
		#endif

		public StartForm()
		{
			InitializeComponent();
			
			
		}

		private void StartForm_Load(object sender, EventArgs e)
		{
			searchForm = new SearchForm();
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
			fillingGridParam();
			this.Show();
		}

		private void addButton_Click(object sender, EventArgs e)
		{
			addWorkerForm = new AddWorkerForm();
			this.Hide();
			addWorkerForm.ShowDialog();
			//files = new WorkWithFiles(filepath);
		//	files.ReadFileInfo();
		//	workerInfoList = files.WorkerArray;
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
			bindingList = new BindingList<Worker>(filesWork.ReadFileInfo());
			var source = new BindingSource(bindingList, null);
			workerListDataGrid.DataSource = source;
			workerListDataGrid.Columns[0].HeaderText = "Фамилия";
			workerListDataGrid.Columns[1].HeaderText = "Имя";
			workerListDataGrid.Columns[2].HeaderText = "Зарплата за месяц";
			workerListDataGrid.Columns[3].HeaderText = "Месяц оплаты";
			workerListDataGrid.Columns[5].HeaderText = "тип ЗП";
			workerListDataGrid.Columns[4].Visible = false;

		}

		private void deleteButton_Click(object sender, EventArgs e)
		{
			int indexDataGrid = workerListDataGrid.CurrentRow.Index;
			bindingList.Remove(workerListDataGrid.CurrentRow.DataBoundItem as Worker);
		}

		private void groupBox1_Enter(object sender, EventArgs e)
		{

		}

		private void DownloadButton_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog DirDialog = new FolderBrowserDialog();
			DirDialog.Description = "Выбор директории";
			DirDialog.SelectedPath = filepath;

			if (DirDialog.ShowDialog() == DialogResult.OK)
			{
				filepath = DirDialog.SelectedPath + @"\WorkersData.kek";
				filesWork = new WorkWithFiles(filepath);
				fillingGridParam();
				
			}
		}

		private void CreateRandomData_Click(object sender, EventArgs e)
		{
			var workerTmp = new List<Worker>();
			for(int i = 0; i<10; i++)
			{
				workerTmp.Add(RandomWorker.WorkerFullInformation(8));
			}
			filesWork.rewriteFile(workerTmp);
			fillingGridParam();
		}

		private void StartForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			filesWork.rewriteFile(new List<Worker>(bindingList));
		}
	}
}
