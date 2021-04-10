﻿using System;

namespace Laba2.Logic
{
	//TODO:  XML комментарий
	public class RandomPersonAtributes
	{

		//TODO:  XML комментарий
		private static Random _rand = new Random();


		//TODO:  XML комментарий
		public static void ForAdult(Adult adultTmp)
		{
			adultTmp.PasportSeries = _rand.Next(1000, 9999).ToString();
			adultTmp.PasportNumber = _rand.Next(100000, 999999).ToString();

			string[] jobs =
			{
				"Российский алюминий",
				"УГМК",
				"ГК «ТАИФ»",
				"Металлоинвест",
				"Группа ГАЗ",
				"Русснефть",
				"МегаФон",
				"Эльдорадо",
				"Евросеть",
				"Объединенная металлургическая компания",
			};

			adultTmp.Job = jobs[_rand.Next(jobs.Length)];
		}


		//TODO:  XML комментарий
		public static void Partner(Adult adultTmp)
		{

			switch (_rand.Next(1, 3))
			{
				case 1:
					{
						adultTmp.AddPartner(CreateAdult());
						break;
					}
				case 2:
					{
						adultTmp.AddPartner(null);
						break;
					}
			}
		}


		//TODO:  XML комментарий
		public static Adult CreateAdult()
		{
			Adult partnerAdult = new Adult();
			ChangePersonDataForAdult(partnerAdult);
			ForAdult(partnerAdult);
			return partnerAdult;
		}



		//TODO:  XML комментарий
		public static void ChangePersonDataForAdult(Adult adultTmp)
		{
			Person personTmp = RandomPerson.CreatePerson();
			personTmp.Age = _rand.Next(adultTmp.MinAge, adultTmp.MaxAge);
			RandomListAdultChild.TransferPersonData(personTmp, adultTmp);
		}



		//TODO:  XML комментарий
		public static void ForChild(Child childTmp)
		{
			if(childTmp.Age > 7)
			{
				childTmp.StudyPlace = StudyPlaceType.School;
			}
			else
			{
				childTmp.StudyPlace = StudyPlaceType.Kindergarten;
			}

			childTmp.StudyPlaceName = "№" + _rand.Next(1,100).ToString();

			Parents(childTmp);
		}


		//TODO:  XML комментарий
		public static void Parents(Child childTmp)
		{
			switch (_rand.Next(1, 5))
			{
				case 1:
					{
						childTmp.Mother = CreateParentValidGender(GenderType.Female);
						childTmp.Father = CreateParentValidGender(GenderType.Male);
						childTmp.Mother.AddPartner(childTmp.Father);
						break;
					}
				case 2:
					{
						childTmp.Mother = CreateParentValidGender(GenderType.Female);
						break;
					}
				case 3:
					{
						childTmp.Father = CreateParentValidGender(GenderType.Male);
						break;
					}
				case 4:
					{
						
						break;
					}
			}
		}


		//TODO:  XML комментарий
		public static Adult CreateParentValidGender(GenderType gender)
		{
			Adult adultTmp = CreateAdult();
			while (adultTmp.Gender != gender && adultTmp.Gender != GenderType.Unknown)
			{
				ChangePersonDataForAdult(adultTmp);
			}

			return adultTmp;
		}
	}
}
