using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba3.Logic
{
	public static class RandomName
	{
		public static Random _rand = new Random();

		//TODO: RSDN
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

		
		public static string RandomFirstName()
		{
			return firstName[_rand.Next(secondName.Length)];
		}
		public static string RandomSecondName()
		{
			return secondName[_rand.Next(secondName.Length)];
		}
	}
}
