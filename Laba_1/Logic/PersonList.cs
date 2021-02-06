using System;



namespace Laba_1.Logic
{

	class PersonList
    {
        private Person[] _localPersonArray= new Person[0];

		public Person[] Persons => _localPersonArray;

        public int Count => _localPersonArray.Length;


		public void addElement(Person newelement)
		{ 
			int elementCount = Count;

			Array.Resize(ref _localPersonArray, elementCount + 1);
            _localPersonArray[elementCount] = newelement;
		}


		public string[] Showmassive()
		{
			string[] PersonInfoArray = new string[Count];
			for (int i = 0; i < Count; i++)
			{
				PersonInfoArray[i]=_localPersonArray[i].GetInfo();
			}
			return PersonInfoArray;
		}

		public void deleteElement(int index)
		{
			int elementCount = Count;
			
			for (int i = index; i + 1 < elementCount; i++)
			{
				Person PersonTMP;
				PersonTMP=_localPersonArray[i];
				_localPersonArray[i] = _localPersonArray[i + 1];
				_localPersonArray[i + 1] = PersonTMP;
			}
			Array.Resize(ref _localPersonArray, elementCount - 1);

		}

		public Person FindByIndex(int Index)
		{
			return _localPersonArray[Index];
		}
		
	}
}
