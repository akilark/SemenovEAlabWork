using System;


namespace Laba1.Logic
{
	public class Person
	{
		private string _localName;
		private string _localSecondName;
		private int _localAge;
		private GenderType _localGender = GenderType.Unknown;


		/// <summary>
		/// Метод возвращающий имя персоны
		/// </summary>
		public string Name => _localName;

		/// <summary>
		/// Метод возвращающий фамилию персоны
		/// </summary>
		public string SecondName => _localSecondName;

		/// <summary>
		/// Метод возвращающий возраст персоны
		/// </summary>
		public int Age => _localAge;

		/// <summary>
		/// Метод возвращающий гендер персоны
		/// </summary>
		public GenderType Gender => _localGender;


		/// <summary>
		/// Метод позволяющий получить информацию о Персоне
		/// </summary>
		/// <returns>Строка типа "Имя: ; Фамилия: ; Возраст: ; Пол: "</returns>
		public string Info() => $"Имя: {_localName};" +
							   $" Фамилия: {_localSecondName}; " +
							   $"Возраст: {_localAge};" +
							   $" Пол: {_localGender}";


		/// <summary>
		/// Метод позволяющий добавить к созданному объекта класса Person 
		/// информацию о полях класса
		/// </summary>
		/// <param name="name">Имя персоны</param>
		/// <param name="secondName">Фамилия персоны</param>
		/// <param name="age">Возраст персоны</param>
		/// <param name="gender">Пол персоны</param>
		public void AddInfo(string name, string secondName,
			int age, GenderType gender)
		{
			_localName = name;
			_localSecondName = secondName;
			_localAge = age;
			_localGender = gender;
		}



	}
}
