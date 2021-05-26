using System;


namespace Laba3.Logic
{
	/// <summary>
	/// Класс определяющий массив работников
	/// </summary>
	public class WorkersArray 
	{
		/// <summary>
		/// Объявление индексатора
		/// </summary>
		/// <param name="index">индекс</param>
		/// <returns>работника</returns>
		public Worker this[int index]
		{
			get
			{
				return _localWorkerArray[index];
			}
		}

		/// <summary>
		/// список работников
		/// </summary>
		private Worker[] _localWorkerArray = new Worker[0];

		/// <summary>
		/// свойство возвращающее список работников
		/// </summary>
		public Worker[] Workers => _localWorkerArray;


		/// <summary>
		/// Свойсвто возвращающее размерность списка работников
		/// </summary>
		public int Count => _localWorkerArray.Length;


		/// <summary>
		/// Мотод позволяющий добавить нового работника в список работников
		/// </summary>
		/// <param name="newElement">Персона подлежащая добавлению</param>
		public void AddElement(Worker newElement)
		{
			var elementCount = Count;

			Array.Resize(ref _localWorkerArray, elementCount + 1);

			_localWorkerArray[elementCount] = newElement;
		}


		/// <summary>
		/// Метод возврщающий массив информации о работниках
		/// </summary>
		/// <returns> Массив содержащий информацию про каждого работника </returns>
		public string[] WorkerInfo()
		{
			var workerInfoArray = new string[Count];

			for (int i = 0; i < Count; i++)
			{
				workerInfoArray[i] = _localWorkerArray[i].Info();
			}
			return workerInfoArray;
		}

		/// <summary>
		/// Метод позволяющий удалить работника из массива по индексу
		/// </summary>
		/// <param name="index">Номер удаляемого работника из массива 
		/// (нумерация начинается с нуля)</param>
		public void DeleteElement(int index)
		{
			var elementCount = Count;

			if (index < Count )
			{
				for (int i = index; i + 1 < elementCount; i++)
				{
					_localWorkerArray[i] = _localWorkerArray[i + 1];
				}
				Array.Resize(ref _localWorkerArray, elementCount - 1);
			}
		}

		/// <summary>
		/// Метод позволяющий получить работника 
		/// из Pмассива работников по индексу
		/// </summary>
		/// <param name="index">Номер искомого работника из массива
		/// (нумерация начинается с нуля)</param>
		/// <returns> Персона с необходимым индексом, если запращиваемый индекс
		/// больше размерности массива, возвращает последний элемент </returns>
		public Worker FindByIndex(int index)
		{
			if (index < Count - 1)
			{
				return _localWorkerArray[index];
			}
			else
			{
				return _localWorkerArray[Count - 1];
			}
		}


		/// <summary>
		/// Метод возвращающий индекс работника найденного по имени и фамилии
		/// из списка работников
		/// </summary>
		/// <param name="secondName">Фамилия искомого работника</param>
		/// <param name="firstName">Имя искомого работника</param>
		/// <returns>индекс работника в списке</returns>
		public int FindByName(string secondName, string firstName)
		{
			for(int i=0; i<Count;i++)
			{
				if(_localWorkerArray[i].SecondName == secondName 
					&& _localWorkerArray[i].FirstName == firstName)
				{
					return i;
				}
			}
			throw new Exception("Работника с такой комбинацией имени и фамилии нет");
			
		}


		/// <summary>
		/// Статический метод создания нового массива 
		/// случайных работников без информации о ЗП
		/// </summary>
		/// <param name="quantity">Размерность массива</param>
		/// <param name="allowWorkHoursInDay">Сколько часов в день разрешается 
		/// работать</param>
		/// <returns>Массив работников</returns>
		public static WorkersArray Create(int quantity, int allowWorkHoursInDay)
		{
			var workersArray = new WorkersArray();

			for (int i = 0; i < quantity; i++)
			{
				workersArray.AddElement(
					RandomWorker.WorkerWithoutWageInformation(allowWorkHoursInDay));
			}
			return workersArray;
		}


		/// <summary>
		/// Статический метод создания нового массива случайных 
		/// работников с полной информацией
		/// </summary>
		/// <param name="quantity">Размерность массива</param>
		/// <param name="allowWorkHoursInDay">Сколько часов в день разрешается 
		/// работать</param>
		/// <returns>Массив работников</returns>
		public static WorkersArray CreateFullInfo(
			int quantity, 
			int allowWorkHoursInDay)
		{
			var workersArray = new WorkersArray();

			for (int i = 0; i < quantity; i++)
			{
				workersArray.AddElement(
					RandomWorker.WorkerWithoutWageInformation(allowWorkHoursInDay));
			}
			return workersArray;
		}
	}
}
