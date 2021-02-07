using System;
using System.Collections.Generic;
using System.Text;

namespace Laba_1.Logic
{
	class RandomPersonList
	{
		/// <summary>
		/// Метод формирующий массив заданной размерности из случайных персон 
		/// </summary>
		/// <param name="quantity">Размер массива персон</param>
		/// <returns>Массив персон </returns>
		public PersonList Create(int quantity)
		{
			PersonList PersonArray = new PersonList();
			RandomPerson personRnd = new RandomPerson();
			

			for (int i = 0; i < quantity; i++)
			{
				PersonArray.AddElement(personRnd.GetPerson());
			}
			return PersonArray;
		}
	}
}
