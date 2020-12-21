using System;



namespace laba1
{

	class PersonList
    {
        private Person[] _localPersonArray= new Person[1];

		public Person[] Persons => _localPersonArray;

        public int Count => _localPersonArray.Length;

		public Person[] CreateListofPerson()
		{
			int quantity = 3;
			Person personRnd = new Person();

			Person[] ListOfPerson = new Person[quantity];
			for (int i = 0; i < quantity; i++)
			{
				ListOfPerson[i] = personRnd.GetRandomPerson();
			}
			return ListOfPerson;
		}

		public void addElement(Person newelement)
		{ 
			int elementCount = Count;

			Array.Resize(ref _localPersonArray, _localPersonArray.Length + 1);
            _localPersonArray[elementCount] = newelement;
		}


		public void Showmassive(Person[] listofperson)
		{
			for (int i = 0; i < Count; i++)
			{
				listofperson[i].GetInfo();
			}
		}

		public Person[] deleteElement(int Index)
		{
			int elementCount = Count;
			bool flag = false;

			Person[] listofpersonsmall = new Person[elementCount - 1];
			for (int i = 0; i < elementCount - 1; i++)
			{
				if (i == Index)
				{
					flag = true;
				}
				if (flag == false)
				{
					listofpersonsmall[i] = _localPersonArray[i];
				}
				if (flag == true)
				{
					listofpersonsmall[i] = _localPersonArray[i + 1];
				}

			}
			return listofpersonsmall;
		}

		public Person FindByIndex(int Index)
		{
			return _localPersonArray[Index];
		}
		
	}
}
