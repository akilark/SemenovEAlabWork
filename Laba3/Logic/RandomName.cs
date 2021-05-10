using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba3.Logic
{
	/// <summary>
	/// Статический класс для генерации случайных имен
	/// </summary>
	public static class RandomName
	{
		/// <summary>
		/// Поле класса необходимое для случайной генерации имен
		/// </summary>
		public static Random _rand = new Random();

		/// <summary>
		/// Поле класса содержашее массив имен
		/// </summary>
		public static string[] firstName =
		{
			"Архип",
			"Добрыня",
			"Светогор",
			"Галина",
			"Изольда",
			"Казимир",
			"Евдокия",
			"Елисей",
			"Ефросинья",
			"Митрофан",
			"Марфа",
			"Терентий"
		};

		/// <summary>
		/// Поле класса содержащее массив фамилий
		/// </summary>
		public static string[] secondName =
		{
			"Ющенко",
			"Тимошенко",
			"Мудко",
			"Шнайдер",
			"Шуткевич",
			"Дубяго",
			"Сухих",
			"Белаго",
			"Соловей",
			"Хосе",
			"Пынзарь",
			"Йобманн"
		};

		/// <summary>
		/// Метод выбирающий случайное имя из соответсвующего поля класса
		/// </summary>
		/// <returns>Имя работника</returns>
		public static string RandomFirstName()
		{
			return firstName[_rand.Next(secondName.Length)];
		}

		/// <summary>
		/// Метод выбирающий случайную фамилию из соответсвующего поля класса
		/// </summary>
		/// <returns>Фамилию работника</returns>
		public static string RandomSecondName()
		{
			return secondName[_rand.Next(secondName.Length)];
		}
	}
}
