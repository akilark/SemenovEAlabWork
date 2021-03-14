using System;
using System.Text.RegularExpressions;

namespace Laba1.Logic
{
	//TODO:XML (v)
	/// <summary>
	/// Класс позволяющий хранить информацию о персоне, выводить эту информацию
	/// и проверять ее на наличие ошибок при введении.
	/// </summary>
	public class Person
	{
		/// <summary>
		/// Имя персоны
		/// </summary>
		private string _localName;


		/// <summary>
		/// Минимальный возраст персоны 
		/// </summary>
		private int _localMinAge = 0;


		/// <summary>
		/// Максимальный возраст персоны 
		/// </summary>
		private int _localMaxAge = 114;

		/// <summary>
		/// Фамилия персоны
		/// </summary>
		private string _localSecondName;


		/// <summary>
		/// Возраст персоны 
		/// </summary>
		private int _localAge;


		/// <summary>
		/// Пол персоны
		/// </summary>
		private GenderType _localGender;


		/// <summary>
		/// Конструктор для создания объекта типа Person с дефолтными полями
		/// </summary>
		public Person() : this("Неизвестно", "Неизвестно", 0, GenderType.Unknown) { }


		/// <summary>
		/// Метод возвращающий минимально возможный возраст персоны 
		/// </summary>
		public int MinAge
		{
			get
			{
				return _localMinAge;
			}
			protected set
			{
				_localMinAge = value;
			}
		}


		/// <summary>
		/// Метод возвращающий максимально возможный возраст персоны 
		/// </summary>
		public int MaxAge
		{
			get
			{
				return _localMaxAge;
			}
			protected set
			{
				_localMaxAge = value;
			}
		}


		/// <summary>
		/// Метод возвращающий имя персоны и принимающий имя персоны 
		/// с проверкой правильности введенных данных
		/// </summary>
		public string Name
		{
			get
			{
				return _localName;
			}
			set
			{
				CheckName(value);
				_localName = CorrectName(value);
			}
		}


		/// <summary>
		/// Метод возвращающий фамилию персоны и принимающий фамилию персоны
		/// с проверкой правильности введенных данных
		/// </summary>
		public string SecondName
		{
			get
			{
				return _localSecondName;
			}
			set
			{
				CheckName(value);
				_localSecondName = CorrectName(value);
			}
		}


		/// <summary>
		/// Метод возвращающий возраст персоны и принимающий возраст персоны
		/// с проверкой правильности введенных данных
		/// </summary>
		public int Age
		{
			get
			{
				return _localAge;
			}
			set
			{
				CheckAge(value);
				_localAge = value;
			}
		}


		/// <summary>
		/// Метод возвращающий и принимающий гендер персоны
		/// </summary>
		public GenderType Gender
		{
			get
			{
				return _localGender;
			}
			set
			{
				switch (value)
				{
					case GenderType.Male:
						{
							_localGender = GenderType.Male;
							break;
						}
					case GenderType.Female:
						{
							_localGender = GenderType.Female;
							break;
						}
					case GenderType.Unknown:
						{
							_localGender = GenderType.Unknown;
							break;
						}
					default:
						{
							throw new Exception("Такого гендера не существует");
						}
				}
			}
		}


		/// <summary>
		/// Метод позволяющий получить информацию о Персоне
		/// </summary>
		/// <returns>Строка типа "Имя: ; Фамилия: ; Возраст: ; Пол: "</returns>
		public string Info() => $"Имя: {_localName};" +
							   $" Фамилия: {_localSecondName}; " +
							   $"Возраст: {_localAge};" +
							   $" Пол: {_localGender}";


		//TODO: Почему не конструктор? (теперь конструктор)
		/// <summary>
		/// Конструктор для создания объекта типа Person 
		/// с полным набором информации
		/// </summary>
		/// <param name="name">Имя персоны</param>
		/// <param name="secondName">Фамилия персоны</param>
		/// <param name="age">Возраст персоны</param>
		/// <param name="gender">Пол персоны</param>
		public Person(string name, string secondName,
			int age, GenderType gender)
		{
			//TODO: проверки (все проверки в полях класса)
			Name = name;
			SecondName = secondName;
			Age = age;
			Gender = gender;
		}


		/// <summary>
		/// Функция приводящая имена и фамилии к правильному виду
		/// </summary>
		/// <param name="name">Либо имя, либо фамилия</param>
		/// <returns>Строка содержащая слово с первой заглавной буквой, 
		/// если слова разделены через тире, 
		/// все слова начинаются с большой буквы </returns>
		public static string CorrectName(string name)
		{
			string nameTmp = "";
			string outputName = "";

			string[] subString =
				name.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);

			foreach (string subTmp in subString)
			{
				for (int i = 0; i < subTmp.Length; i++)
				{
					if (subTmp.Length > 1)
					{
						nameTmp = subTmp.Substring(0, 1).ToUpper() +
							subTmp.Substring(1, subTmp.Length - 1).ToLower();
					}
					else
					{
						nameTmp = subTmp.ToUpper();
					}
				}

				if (outputName.Length == 0)
				{
					outputName += nameTmp;
				}
				else
				{
					outputName += "-" + nameTmp;
				}
			}
			return outputName;
		}


		/// <summary>
		/// Функция проверяющая имена и фамилии на наличиие ошибок, 
		/// если ошибка возникает, выдает соответствующее исключение
		/// </summary>
		/// <param name="name">Либо имя, либо фамилия</param>
		/// <returns>false- если ошибок нет. </returns>
		public static bool CheckName(string name)
		{
			CheckNamelength(name);
			CheckNamePattern(name);
			CheckQuantityName(name);	
			return false;
		}


		/// <summary>
		/// Функция проверяющая имена и фамилии на наличие запрещенного количества
		/// составных частей
		/// </summary>
		/// <param name="name">Либо имя, либо фамилия</param>
		/// <exception cref="Недопустимо использование более {allowQuantity}
		/// составных частей имени или фамилии!"></exception>
		private static void CheckQuantityName(string name)
		{
			string[] subString = name.Split('-');
			int allowQuantity = 2;

			if (subString.Length > allowQuantity)
			{
				string mistakeInfoTmp = $"Недопустимо использование " +
					$"более {allowQuantity} составных частей имени или фамилии!";
				throw new FormatException(mistakeInfoTmp);
			}
			
			//TODO: (v)
		}


		/// <summary>
		/// Функция проверяющая имена и фамилии на выход за допустымые размеры
		/// </summary>
		/// <param name="name">Либо имя, либо фамилия</param>
		/// <exception cref="Недопустимый размер имени или фамилии!"></exception>
		private static void CheckNamelength(string name)
		{
			int nameMin = 2;
			int nameMax = 30;

			if (name.Length < nameMin || name.Length > nameMax)
			{
				string mistakeInfoTmp = "Недопустимый размер имени или фамилии!";
				throw new FormatException(mistakeInfoTmp);
			}

			//TODO: (v)
		}


		/// <summary>
		/// Функция проверяющая имена и фамилии на наличие запрещенных симоволов
		/// </summary>
		/// <param name="name">Либо имя, либо фамилия</param>
		/// <exception cref="Имя и Фамилия могут содержать только буквы!">
		/// </exception>
		private static void CheckNamePattern(string name)
		{
			string pattern = @"[^a-zа-яё-]";
			Regex reg = new Regex(pattern, RegexOptions.IgnoreCase);
			Match mat = reg.Match(name);

			if (mat.Success)
			{
				string mistakeInfoTmp = "Имя и Фамилия могут содержать только буквы!";
				throw new FormatException(mistakeInfoTmp);
			}
			//TODO: (v)
		}


		/// <summary>
		/// Функция проверяющая указанный возраст на выход 
		/// из разрешенного диапазона
		/// </summary>
		/// <param name="age">Возраст</param>
		/// <exception cref="Возраст должен быть в диапазоне [MinAge-MaxAge]">
		/// </exception>
		public void CheckAge(int age)
		{
			//TODO: Дубль (убран)
			if (age < _localMinAge || age > _localMaxAge)
			{
				string mistakeInfoTmp = $"Возраст должен быть в диапазоне" +
					$" [{_localMinAge}-{_localMaxAge}]";
				throw new FormatException(mistakeInfoTmp);
			}
		}
	}
}
