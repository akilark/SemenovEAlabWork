namespace Laba2.Logic
{
	/// <summary>
	/// Класс позволяющий хранить информацию о молодой персоне, 
	/// выводить эту информацию и проверять ее на наличие ошибок при введении.
	/// </summary>
	public class Child : PersonBase
	{
		/// <summary>
		/// Метод возвращающий минимально возможный возраст персоны 
		/// </summary>
		public override int MinAge => 0;


		/// <summary>
		/// Метод возвращающий максимально возможный возраст персоны 
		/// </summary>
		public override int MaxAge => 17;


		/// <summary>
		/// Метод возвращающий и принимающий мать персоны  
		/// </summary>
		public Adult Mother { get; set; }
		//TODO: автосвойство(v)


		/// <summary>
		/// Метод возвращающий и принимающий отца персоны  
		/// </summary>
		public Adult Father { get; set; }
		//TODO: автосвойство(v)


		/// <summary>
		/// Метод возвращающий и принимающий место обучения персоны  
		/// </summary>
		public StudyPlaceType StudyPlace { get; set; }
		//TODO: автосвойство(v)


		/// <summary>
		/// Метод возвращающий и принимающий название места обучения персоны
		/// </summary>
		public string StudyPlaceName { get; set; }
		//TODO: автосвойство(v)


		//TODO: null не безопасно(V)
		/// <summary>
		/// Конструктор для создания объекта типа Child с дефолтными полями
		/// </summary>
		public Child() : this("Неизвестно", "Неизвестно", 0, GenderType.Unknown,
			null, null, StudyPlaceType.Kindergarten, "Неизвестно") { }



		/// <summary>
		/// Конструктор для создания объекта типа Child
		/// с полным набором информации
		/// </summary>
		/// <param name="name">Имя персоны</param>
		/// <param name="secondName">Фамилия персоны</param>
		/// <param name="age">Возраст персоны</param>
		/// <param name="gender">Пол персоны</param>
		/// <param name="mother">Мать персоны</param>
		/// <param name="father">Отец персоны</param>
		/// <param name="studyPlace">Тип места обучения</param>
		/// /// <param name="studyPlaceName">Название места обучения</param>
		public Child(string name, string secondName,
			int age, GenderType gender, Adult mother, Adult father,
			StudyPlaceType studyPlace, string studyPlaceName) : 
			base(name, secondName, age, gender)
		{
			Mother = mother;
			Father = father;
			StudyPlace = studyPlace;
			StudyPlaceName = studyPlaceName;

			if (mother != null && father !=null)
			{
				mother.AddPartner(father);
			}
		}


		/// <summary>
		/// Метод позволяющий получить информацию о Персоне
		/// </summary>
		/// <returns>Строка типа "Имя: ; Фамилия: ; Возраст: ; Пол: ;
		/// родители ; место обучения"</returns>
		public override string Info()
		{
			return $"Имя: {Name};" +
					$" Фамилия: {SecondName}; " +
					$" Возраст: {Age};" +
					$" Пол: {Gender};" + "\n" +
					CheckParents() + 
					CheckStudyPlace();
		}


		/// <summary>
		/// Метод вывода информации о завершении обучения
		/// </summary>
		/// <returns> Сколько лет до выпускного в школе </returns>
		public string Graduate()
		{
			return $"Выпускной в школе через {18-Age}";
		}


		/// <summary>
		/// Метод проверки информации о родителях
		/// </summary>
		/// <returns>Строка информации о родителях</returns>
		private string CheckParents()
		{
			string infoAboutParents="";

			if(Mother != null)
			{
				infoAboutParents = $" Мать: {Mother.Name} " +
					$"{Mother.SecondName}" + "\n";
			}

			if(Father != null)
			{
				infoAboutParents += $" Отец: {Father.Name} " +
					$"{Father.SecondName}" + "\n"; ;
			}

			if (infoAboutParents == "")
			{
				infoAboutParents = " Сирота" + "\n"; ;
			}

			return infoAboutParents;
		}


		/// <summary>
		/// Метод проверки информации о месте обучения
		/// </summary>
		/// <returns>Строка информации о месте обучения</returns>
		private string CheckStudyPlace()
		{
			switch(StudyPlace)
			{
				case StudyPlaceType.Kindergarten:
				{
					return $" Обучается в детском саду {StudyPlaceName}";
				}
				case StudyPlaceType.School:
				{
					return $" Обучается в школе {StudyPlaceName}";
				}
				default:
				{
					return $" Сведений об обучении нет";
				}
			}
		}
	}
}
