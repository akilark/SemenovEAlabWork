using System;
using System.Collections.Generic;
using System.Text;


namespace laba1
{

	class PersonList
	{
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

		public Person[] addElement(Person[] listofperson, Person newelement)
		{ int elementCount = listofperson.Length;

			Array.Resize(ref listofperson, listofperson.Length + 1);
			listofperson[elementCount] = newelement;
			return listofperson;
		}


		public void Showmassive(Person[] listofperson)
		{
			int elementCount = listofperson.Length;
			for (int i = 0; i < elementCount; i++)
			{
				listofperson[i].GetInfo();
			}
		}

		public Person[] deleteElement(Person[] listofperson, int Index)
		{
			int elementCount = listofperson.Length;
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
					listofpersonsmall[i] = listofperson[i];
				}
				if (flag == true)
				{
					listofpersonsmall[i] = listofperson[i + 1];
				}

			}
			return listofpersonsmall;
		}

		public Person selectPerson(Person[] listofperson, int Index)
		{
			Person returnPerson = listofperson[Index];
			return returnPerson;
		}
		

	}
}
