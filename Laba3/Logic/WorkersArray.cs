using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba3.Logic
{
	public class WorkersArray
	{
		/// <summary>
		/// список персон
		/// </summary>
		private Worker[] _localWorkerArray = new Worker[0];


		/// <summary>
		/// 
		/// </summary>
		public Worker[] Workers => _localWorkerArray;


		/// <summary>
		/// 
		/// </summary>
		public int Count => _localWorkerArray.Length;


		/// <summary>
		/// 
		/// </summary>
		/// <param name="newElement">Персона подлежащая добавлению</param>
		public void AddElement(Worker newElement)
		{
			int elementCount = Count;

			Array.Resize(ref _localWorkerArray, elementCount + 1);

			_localWorkerArray[elementCount] = newElement;
		}


		/// <summary>
		/// 
		/// </summary>
		/// <returns> Массив содержащий информацию про каждую персону </returns>
		public string[] WorkerInfo()
		{
			string[] workerInfoArray = new string[Count];

			for (int i = 0; i < Count; i++)
			{
				workerInfoArray[i] = _localWorkerArray[i].Info();
			}
			return workerInfoArray;
		}
		
		public static WorkersArray Create(int quantity)
		{
			WorkersArray workersArray = new WorkersArray();

			for (int i = 0; i < quantity; i++)
			{
				workersArray.AddElement(new Worker());
			}
			return workersArray;
		}
	}
}
