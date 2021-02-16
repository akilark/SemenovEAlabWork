﻿

namespace Laba_1.Logic
{
	class RandomPersonList
	{
		/// <summary>
		/// Функция формирующая массив заданной размерности из случайных персон 
		/// </summary>
		/// <param name="quantity">Размер массива персон</param>
		/// <returns>Массив персон </returns>
		public static PersonList Create(int quantity)
		{
			//TODO: RSDN
			PersonList PersonArray = new PersonList();
			
			

			for (int i = 0; i < quantity; i++)
			{
				PersonArray.AddElement(RandomPerson.Create());
			}
			return PersonArray;
		}
	}
}
