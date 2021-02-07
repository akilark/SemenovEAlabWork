

namespace Laba_1.Logic
{
	class Person
	{
		private string _localName;
		private string _localSecondName;
		private int _localAge;
		private GenderType _localGender = GenderType.Unknown;


		

		public string GetInfo()
		{
			return $"Имя: {_localName}; Фамилия: {_localSecondName}; " +
				$"Возраст: {_localAge}; Пол: {_localGender}";
		}


		public void AddName(string name)
		{
			_localName = name;
		}

		public void AddSecondName(string secondName)
		{
			_localSecondName = secondName;
		}

		public void AddAge(int age)
		{
			_localAge = age;
		}

		public void AddGender(GenderType gender)
		{
			_localGender = gender;
		}
		
	}
}
