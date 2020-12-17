using System;

namespace laba1
{
	class lab1
	{
		static void Main(string[] args)
		{
			Person Tom = new Person();
			Person Alexey = new Person("Alexey");
			Person Petr = new Person("Petr", "Ivanov");
			Person Alfred = new Person("Alfred", "Sweaty", 16);
			Person Gleb = new Person("Gleb", "Tirikov", 27, genderType.men);

			Tom.GetInfo();
			Alexey.GetInfo();
			Petr.GetInfo();
			Alfred.GetInfo();
			Gleb.GetInfo();
		}
	}
	class Person
	{
		public string first_name;
		public string second_name;
		public int? age;
		public genderType gender;
		public Person() { first_name = "Undefined"; second_name = "Undefined"; age = null; gender = 0; }
		public Person(string fn) { first_name = fn; second_name = "Undefined"; age = null; gender = 0; }
		public Person(string fn, string sn) { first_name = fn; second_name = sn; age = null; gender = 0; }
		public Person(string fn, string sn, int ag) { first_name = fn; second_name = sn; age = ag; gender = 0; }
		public Person(string fn, string sn, int ag, genderType gen) { first_name = fn; second_name = sn; age = ag; gender = gen; }


		public void GetInfo()
		{
			Console.WriteLine($"Имя: {first_name} Фамилия: {second_name} Возраст: {age} Пол: {gender}");
		}
	}
	enum genderType
	{
		Undefined,
		men,
		woman
	}
}
