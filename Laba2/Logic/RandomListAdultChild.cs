using System;

namespace Laba2.Logic
{
	//TODO: RSDN
	//TODO:  XML комментарий
	class RandomListAdultChild
	{

		//TODO:  XML комментарий
		public static PersonList CreatePersonList(int quantity)
		{
			PersonList personArray = new PersonList();

			for (int i = 0; i < quantity; i++)
			{
				personArray.AddElement(
					DeterminateAdultOrChild(RandomPerson.CreatePerson()));
			}
			return personArray;
		}


		//TODO:  XML комментарий
		private static Person DeterminateAdultOrChild(Person personTmp)
		{
			Adult adultTmp = new Adult();
			Child childTmp = new Child();

			if (personTmp.Age >= adultTmp.MinAge)
			{
				TransferPersonData(personTmp, adultTmp);
				RandomPersonAtributes.ForAdult(adultTmp);
				RandomPersonAtributes.Partner(adultTmp);
				return adultTmp;
			}
			else if (personTmp.Age <= childTmp.MaxAge)
			{
				TransferPersonData(personTmp, childTmp);
				RandomPersonAtributes.ForChild(childTmp);
				return childTmp;
			}
			else
			{
				throw new Exception("Проблема с заданными значениями MinAge и MaxAge " +
					"для классов Child, Adult, Person");
			}


		}


		//TODO:  XML комментарий
		public static void TransferPersonData(Person personOutput, Person personInput)
		{
			personInput.Name = personOutput.Name;
			personInput.SecondName = personOutput.SecondName;
			personInput.Age = personOutput.Age;
			personInput.Gender = personOutput.Gender;
		}
	}
}
