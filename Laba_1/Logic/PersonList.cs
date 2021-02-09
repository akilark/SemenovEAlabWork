using System;



namespace Laba_1.Logic
{

	class PersonList
    {
        private Person[] _localPersonArray= new Person[0];

		public Person[] Persons => _localPersonArray;

        private int Count => _localPersonArray.Length;

		/// <summary>
		/// Метод позволяющий добавить персону в конец PersonList
		/// </summary>
		/// <param name="newElement">Персона подлежащая добавлению</param>
		public void AddElement(Person newElement)
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
			string[] PersonInfoArray = new string[Count];
			for (int i = 0; i < Count; i++)
			{
				PersonInfoArray[i]=_localPersonArray[i].Info();
			}
			return PersonInfoArray;
		}

		/// <summary>
		/// Метод позволяющий удалить персону из PersonList по индексу
		/// </summary>
		/// <param name="index">Номер удаляемой персоны из листа (нумерация начинается с нуля)</param>
		public void DeleteElement(int index)
		{
			int elementCount = Count;
			if (index < Count - 1)
			{
				for (int i = index; i + 1 < elementCount; i++)
				{
					Person PersonTMP;
					PersonTMP = _localPersonArray[i];
					_localPersonArray[i] = _localPersonArray[i + 1];
					_localPersonArray[i + 1] = PersonTMP;
				}
				Array.Resize(ref _localPersonArray, elementCount - 1);
			}
		}

		/// <summary>
		/// Метод позволяющий получить информацию о персоне из PersonList по индексу
		/// </summary>
		/// <param name="index">Номер искомой персоны из листа (нумерация начинается с нуля)</param>
		/// <returns> Персона с необходимым индексом, если запращиваемый индекс больше размерности PersonList, возвращает последний элемент </returns>
		public Person FindByIndex(int index)
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
