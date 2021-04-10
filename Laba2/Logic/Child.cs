using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Laba2.Logic
{
	//TODO:  XML комментарий
	public class Child : Person
	{
		private Adult _localMother;
		private Adult _localFather;
		private StudyPlaceType _localStudyPlaceType;
		private string _localStudyPlaceName;


		//TODO:  XML комментарий
		public override int MinAge => 0;


		//TODO:  XML комментарий
		public override int MaxAge => 17;


		//TODO:  XML комментарий
		public Adult Mother
		{
			//TODO: автосвойство
			get
			{
				return _localMother;
			}
			set
			{
				_localMother = value;
			}
		}


		//TODO:  XML комментарий
		public Adult Father
		{
			//TODO: автосвойство
			get
			{
				return _localFather;
			}
			set
			{
				_localFather = value;
			}
		}


		//TODO:  XML комментарий
		public StudyPlaceType StudyPlace
		{
			//TODO: автосвойство
			get
			{
				return _localStudyPlaceType;
			}
			set
			{
				_localStudyPlaceType = value;
			}
		}


		//TODO:  XML комментарий
		public string StudyPlaceName
		{
			//TODO: автосвойство
			get
			{
				return _localStudyPlaceName;
			}
			set
			{
				_localStudyPlaceName = value;
			}
		}

		//TODO: null не безопасно
		//TODO:  XML комментарий
		public Child() : this("Неизвестно", "Неизвестно", 0, GenderType.Unknown,
			null, null, StudyPlaceType.Kindergarten, null) { }



		//TODO: XML комментарий
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


		//TODO:  XML комментарий
		public override string Info()
		{
			return $"Имя: {Name};" +
					$" Фамилия: {SecondName}; " +
					$" Возраст: {Age};" +
					$" Пол: {Gender};" + "\n" +
					CheckParents() + 
					CheckStudyPlace();
		}


		//TODO:  XML комментарий
		private string CheckParents()
		{
			string infoAboutParents="";

			if(_localMother != null)
			{
				infoAboutParents = $" Мать: {_localMother.Name} " +
					$"{_localMother.SecondName}" + "\n";
			}

			if(_localFather !=null)
			{
				infoAboutParents += $" Отец: {_localFather.Name} " +
					$"{_localFather.SecondName}" + "\n"; ;
			}

			if (infoAboutParents == "")
			{
				infoAboutParents = " Сирота" + "\n"; ;
			}

			return infoAboutParents;
		}


		//TODO:  XML комментарий
		private string CheckStudyPlace()
		{
			switch(_localStudyPlaceType)
			{
				case StudyPlaceType.Kindergarten:
				{
					return $" Обучается в детском саду {_localStudyPlaceName}";
				}
				case StudyPlaceType.School:
				{
					return $" Обучается в школе {_localStudyPlaceName}";
				}
				default:
				{
					return $" Сведений об обучении нет";
				}
			}
		}
	}
}
