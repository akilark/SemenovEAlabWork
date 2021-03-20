using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laba1.Logic;

namespace Laba2.Logic
{
	public class Child : Person
	{
		private Adult _localMother;
		private Adult _localFather;
		private StudyPlaceType _localStudyPlaceType;
		private string _localStudyPlaceName;
		public override int MinAge => 0;
		public override int MaxAge => 17;

		public Adult Mother
		{
			get
			{
				return _localMother;
			}
			private set
			{
				CheckParentsName(value);
				_localMother = value;
			}
		}


		public Adult Father
		{
			get
			{
				return _localFather;
			}
			private set
			{
				CheckParentsName(value);
				_localFather = value;
			}
		}


		public StudyPlaceType StudyPlace
		{
			get
			{
				return _localStudyPlaceType;
			}
			private set
			{
				_localStudyPlaceType = value;
			}
		}


		public string StudyPlaceName
		{
			get
			{
				return _localStudyPlaceName;
			}
			private set
			{
				_localStudyPlaceName = value;
			}
		}

		public Child() : this("Неизвестно", "Неизвестно", 0, GenderType.Unknown,
		null,null, StudyPlaceType.Kindergarten, null) { }



		//TODO: XML комментарий
		public Child(string name, string secondName,
			int age, GenderType gender, Adult mother, Adult father,
			StudyPlaceType studyPlace, string studyPlaceName) : base(name, secondName, age, gender)
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


		public override string Info()
		{
			return $"Имя: {Name};" +
					$" Фамилия: {SecondName}; " +
					$" Возраст: {Age};" +
					$" Пол: {Gender};" + "\n" +
					CheckParents()+ CheckStudyPlace();
		}

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



		private string CheckStudyPlace()
		{
			switch(_localStudyPlaceType)
			{
				case StudyPlaceType.Kindergarten:
					{
						return $"Обучается в детском саду {_localStudyPlaceName}";
					}
				case StudyPlaceType.School:
					{
						return $"Обучается в школе {_localStudyPlaceName}";
					}
				default:
					{
						return $"Сведений об обучении нет";
					}
			}
		}

		private void CheckParentsName(Adult parent)
		{
			if (parent.Name == "Неизвестно" || parent.SecondName == "Неизвестно")
			{
				throw new FormatException("Данные родителя должны быть известны!");
			}
		}
	}
}
