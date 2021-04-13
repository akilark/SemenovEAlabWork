using System;



namespace Laba2.Logic
{
	/// <summary>
	/// Класс позволяющий хранить информацию о списке персон, добавлять персон,
	/// находить и удалять их по индексу
	/// </summary>
	public class PersonList
	{
		/// <summary>
		/// список персон
		/// </summary>
		private PersonBase[] _localPersonArray = new PersonBase[0];


		/// <summary>
		/// Метод возвращающий лист персон
		/// </summary>
		public PersonBase[] Persons => _localPersonArray;


		/// <summary>
		/// Метод возвращающий размерность листа персон
		/// </summary>
		private int Count => _localPersonArray.Length;


		/// <summary>
		/// Метод позволяющий добавить персону в конец PersonList
		/// </summary>
		/// <param name="newElement">Персона подлежащая добавлению</param>
		public void AddElement(PersonBase newElement)
		{
			int elementCount = Count;

			Array.Resize(ref _localPersonArray, elementCount + 1);

			_localPersonArray[elementCount] = newElement;
		}


		/// <summary>
		/// Метод позволяющий получить информацию про каждую персону в PersonList
		/// </summary>
		/// <returns> Массив содержащий информацию про каждую персону </returns>
		public string[] PersonsInfo()
		{
			string[] personInfoArray = new string[Count];

			for (int i = 0; i < Count; i++)
			{
				personInfoArray[i] = _localPersonArray[i].Info();
			}
			return personInfoArray;
		}


		/// <summary>
		/// Метод позволяющий удалить персону из PersonList по индексу
		/// </summary>
		/// <param name="index">Номер удаляемой персоны из листа 
		/// (нумерация начинается с нуля)</param>
		public void DeleteElement(int index)
		{
			int elementCount = Count;

			if (index < Count - 1)
			{
				for (int i = index; i + 1 < elementCount; i++)
				{
					_localPersonArray[i] = _localPersonArray[i + 1];
				}
				Array.Resize(ref _localPersonArray, elementCount - 1);
			}
		}


		/// <summary>
		/// Метод позволяющий получить информацию о персоне 
		/// из PersonList по индексу
		/// </summary>
		/// <param name="index">Номер искомой персоны из листа
		/// (нумерация начинается с нуля)</param>
		/// <returns> Персона с необходимым индексом, если запращиваемый индекс
		/// больше размерности PersonList, возвращает последний элемент </returns>
		public PersonBase FindByIndex(int index)
		{
			if (index < Count - 1)
			{
				return _localPersonArray[index];
			}
			else
			{
				index = Count - 1;

				return _localPersonArray[index];
			}
		}
	}
}
