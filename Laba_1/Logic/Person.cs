

namespace Laba_1.Logic
{
	class Person
	{
		private string _localName;
		private string _localSecondName;
		private int _localAge;
		private GenderType _localGender = GenderType.Unknown;



		/// <summary>
		/// Метод позволяющий получить информацию о Персоне
		/// </summary>
		/// <returns>Строка типа "Имя: ; Фамилия: ; Возраст: ; Пол: "</returns>
		public string GetInfo()
		{
			return $"Имя: {_localName}; Фамилия: {_localSecondName}; " +
				$"Возраст: {_localAge}; Пол: {_localGender}";
		}

		/// <summary>
		/// Метод позволяющий добавить к созданному объекта класса Person информацию о поле класса "Name"
		/// </summary>
		/// <param name="name">Имя персоны</param>
		public void AddName(string name)
		{
			_localName = name;
		}

		/// <summary>
		/// Метод позволяющий добавить к созданному объекта класса Person информацию о поле класса "SecondName"
		/// </summary>
		/// <param name="secondName">Фамилия персоны</param>
		public void AddSecondName(string secondName)
		{
			_localSecondName = secondName;
		}

		/// <summary>
		/// Метод позволяющий добавить к созданному объекта класса Person информацию о поле класса "Age"
		/// </summary>
		/// <param name="age">Возраст персоны</param>
		public void AddAge(int age)
		{
			_localAge = age;
		}
		/// <summary>
		/// Метод позволяющий добавить к созданному объекта класса Person информацию о поле класса "Gender"
		/// </summary>
		/// <param name="gender">Пол персоны</param>
		public void AddGender(GenderType gender)
		{
			_localGender = gender;
		}
		
	}
}
