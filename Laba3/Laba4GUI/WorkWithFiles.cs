﻿using Laba3.Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Laba4GUI
{
	public class WorkWithFiles
	{
		private string _path;
		WorkersArray _workerArray;
		public WorkWithFiles(string path)
		{
			if (File.Exists(path))
			{
				_path = path;
			}
		}

		public WorkersArray WorkerArray
		{
			get
			{
				return _workerArray;
			}
		}


		public void ReadFileInfo()
		{
			using (StreamReader sr = new StreamReader(_path, Encoding.UTF8))
			{
				int count = File.ReadAllLines(_path).Length;
				_workerArray = new WorkersArray();
				string[] fileWorkerInfo = new string[count];
				
				for (int i = 0; i < count; i++)
				{
					fileWorkerInfo[i] = sr.ReadLine();
					string[] stringWorkerInfo = fileWorkerInfo[i].Split(new char[] { '|' });
					Worker workerForAdd = new Worker(Int32.Parse(stringWorkerInfo[7]));
					workerForAdd.WageType(WageType.NonIdentified); /////// Заглушка
					workerForAdd.DesiredDate(extractDate());
					workerForAdd.FirstName = stringWorkerInfo[1];
					workerForAdd.SecondName = stringWorkerInfo[0];
					workerForAdd.MoneyEarnedInMonth(Int32.Parse(stringWorkerInfo[5]), Int32.Parse(stringWorkerInfo[6]));
					_workerArray.AddElement(workerForAdd);
				}
				sr.Close();
			}
		}

		public void WriteWorkerInfoToFile(Worker workerTmp)
		{
			using (StreamWriter sw = new StreamWriter(_path, true , Encoding.UTF8))
			{

				sw.WriteLine(workerInfo(workerTmp));
				sw.Close();
			}
		}

		public DateTime extractDate()
		{
			string fileName = Path.GetFileName(_path);
			int year = Int32.Parse(fileName.Substring(0,4));
			int month = Int32.Parse(fileName.Substring(4, 2));
			return new DateTime(year, month, 1);
		}

		public void rewriteFile(WorkersArray workersArray)
		{
			using (StreamWriter sw2 = new StreamWriter(_path, false, Encoding.UTF8))
			{
				int lenght = workersArray.Count;
				for (int i = 0; i < lenght; i++)
				{
					sw2.WriteLine(workerInfo(workersArray[i]));
				}
				sw2.Close();
			}
		}


		private string workerInfo(Worker workerTmp)
		{
			return workerTmp.SecondName + "|" +
			workerTmp.FirstName + "|" +
			workerTmp.Wage.NameOfWageType + "|" +
			workerTmp.Wage.AmountMoney + "|" +
			workerTmp.TypeOfWage + "|" +
			workerTmp.Wage.PriceOfWork + "|" +
			workerTmp.Wage.WorkHours + "|" +
			workerTmp.Wage.AllowToWorkHoursInDay;
		}
	}
}
