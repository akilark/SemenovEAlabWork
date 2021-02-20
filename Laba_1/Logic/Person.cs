using System;
using System.Text.RegularExpressions;

namespace Laba_1.Logic
{
	class Person
	{
		
		private string _localName;
		private string _localSecondName;
		private int _localAge;
		private GenderType _localGender = GenderType.Unknown;

		public string Name => _localName;

		public string SecondName => _localSecondName;
		
		public int Age => _localAge;
		
		public GenderType Gender => _localGender;



		/// <summary>
		/// Метод позволяющий получить информацию о Персоне
		/// </summary>
		/// <returns>Строка типа "Имя: ; Фамилия: ; Возраст: ; Пол: "</returns>
		public string Info()=> $"Имя: {_localName};" +
							   $" Фамилия: {_localSecondName}; " +
							   $"Возраст: {_localAge};" +
							   $" Пол: {_localGender}";
		


		/// <summary>
		/// Метод позволяющий добавить к созданному объекта класса Person информацию о полях класса
		/// </summary>
		/// <param name="name">Имя персоны</param>
		/// <param name="secondName">Фамилия персоны</param>
		/// <param name="age">Возраст персоны</param>
		/// <param name="gender">Пол персоны</param>
		public void AddInfo(string name, string secondName, int age, GenderType gender)
		{
			_localName = name;
			_localSecondName = secondName;
			_localAge = age;
			_localGender = gender;
		}


		/// <summary>
		/// Функция приводящая имена и фамилии к правильному виду
		/// </summary>
		/// <param name="name">Либо имя, либо фамилия</param>
		/// <returns>Строка содержащая слово с первой заглавной буквой, 
		/// если слова разделены через тире, оба слова начинаются с большой буквы </returns>
		public static string CorrectName(string name)
		{
			//TODO: RSDN
			string NameTmp = "";
			string OutputName = "";
			string[] SubString = name.Split('-', StringSplitOptions.RemoveEmptyEntries);
			foreach (string SubTmp in SubString)
			{
				for (int i = 0; i < SubTmp.Length; i++)
				{
					//TODO: скобочки
					if (SubTmp.Length > 1)
					{
						NameTmp = SubTmp.Substring(0, 1).ToUpper() +
							SubTmp.Substring(1, SubTmp.Length - 1).ToLower();
					}
					else
					{
						NameTmp = SubTmp.ToUpper();
					}
				}

				if (OutputName.Length == 0)
				{
					OutputName += NameTmp;
				}
				else
				{
					OutputName += "-" + NameTmp;
				}
			}
			return OutputName;
		}

		/// <summary>
		/// Функция проверяющая имена и фамилии на наличие запрещенных симоволов
		/// </summary>
		/// <param name="name">Либо имя, либо фамилия</param>
		/// <returns>false- если запрещенных символов нет. 
		/// true- если запрещенные символ есть </returns>
		public static bool CheckName(string name)
		{
			string pattern = @"[^a-zа-я-]";
			Regex reg = new Regex(pattern, RegexOptions.IgnoreCase);
			Match mat = reg.Match(name);
			if (mat.Success)
			{
				Console.WriteLine("Имя и Фамилия могут содержать только буквы!!!");
			}
			return mat.Success;
		}
	}
}
