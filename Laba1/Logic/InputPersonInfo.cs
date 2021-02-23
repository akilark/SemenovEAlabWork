using System;
using System.Text.RegularExpressions;

namespace Laba1.Logic
{
	class InputPersonInfo
	{
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
		/// Функция проверяющая имена и фамилии на наличиие ошибок
		/// </summary>
		/// <param name="name">Либо имя, либо фамилия</param>
		/// <returns>Кортеж типа bool, string
		/// item1:
		/// false- если ошибок нет. 
		/// true- если ошибок нет. 
		/// item2: строка с ошибками для вывода пользователю</returns>
		public static Tuple<bool, string> CheckName(string name)
		{
			string mistakeInfo = "";
			bool outputFlag = false;

			Tuple<bool, string> doubleName = CheckQuantityName(name);
			Tuple<bool, string> nameLength = CheckNamelength(name);
			Tuple<bool, string> namePattern = CheckNamePattern(name);

			if (doubleName.Item1 || nameLength.Item1 || namePattern.Item1)
			{
				outputFlag = true;
				mistakeInfo = namePattern.Item2 + nameLength.Item2 + doubleName.Item2;
			}


			Tuple<bool, string> outputTuple = Tuple.Create(outputFlag, mistakeInfo);

			return outputTuple;
		}


		/// <summary>
		/// Функция проверяющая имена и фамилии на наличие запрещенного количества
		/// составных частей
		/// </summary>
		/// <param name="name">Либо имя, либо фамилия</param>
		/// <returns>Кортеж типа bool, string
		/// item1:
		/// false- если всё в пределах нормы. 
		/// true- если количество составных частей превышает разрешенное 
		/// item2: строка с ошибкой для вывода пользователю</returns>
		private static Tuple<bool, string> CheckQuantityName(string name)
		{
			string[] subString = name.Split('-');
			bool flagTmp = true;
			string mistakeInfoTmp = "";
			int allowQuantity = 2;

			if (subString.Length <= allowQuantity)
			{
				flagTmp = false;
			}
			else
			{
				mistakeInfoTmp = $"Недопустимо использование более {allowQuantity} " +
					"составных частей имени или фамилии!";
			}

			Tuple<bool, string> outputTuple = Tuple.Create(flagTmp, mistakeInfoTmp);

			return outputTuple;
		}


		/// <summary>
		/// Функция проверяющая имена и фамилии на выход за допустымые размеры
		/// </summary>
		/// <param name="name">Либо имя, либо фамилия</param>
		/// <returns>Кортеж типа bool, string
		/// item1:
		/// false- если размер имени (фамилии) в пределах нормы. 
		/// true- если выход за границы допустымых размеров 
		/// item2: строка с ошибкой для вывода пользователю</returns>
		private static Tuple<bool, string> CheckNamelength(string name)
		{
			bool flagTmp = true;
			string mistakeInfoTmp = "";
			int nameMin = 2;
			int nameMax = 30;

			if (name.Length >= nameMin && name.Length <= nameMax)
			{
				flagTmp = false;
			}
			else
			{
				mistakeInfoTmp = "Недопустимый размер имени или фамилии!";
			}

			Tuple<bool, string> outputTuple = Tuple.Create(flagTmp, mistakeInfoTmp);

			return outputTuple;
		}


		/// <summary>
		/// Функция проверяющая имена и фамилии на наличие запрещенных симоволов
		/// </summary>
		/// <param name="name">Либо имя, либо фамилия</param>
		/// <returns>Кортеж типа bool, string
		/// item1:
		/// false- если запрещенных символов нет. 
		/// true- если запрещенные символ есть 
		/// item2: строка с ошибкой для вывода пользователю</returns>
		private static Tuple<bool, string> CheckNamePattern(string name)
		{
			bool flagTmp = true;
			string mistakeInfoTmp = "";
			string pattern = @"[^a-zа-я-]";
			Regex reg = new Regex(pattern, RegexOptions.IgnoreCase);
			Match mat = reg.Match(name);

			if (mat.Success)
			{
				mistakeInfoTmp = "Имя и Фамилия могут содержать только буквы!";
			}
			else
			{
				flagTmp = false;
			}

			Tuple<bool, string> outputTuple = Tuple.Create(flagTmp, mistakeInfoTmp);

			return outputTuple;
		}


		/// <summary>
		/// Функция проверяющая указанный возраст на выход 
		/// из разрешенного диапазона
		/// </summary>
		/// <param name="age">Возраст</param>
		/// <returns>Кортеж типа bool, string
		/// item1:
		/// false- если попадает в диапазон. 
		/// true- если не попадает в диапазон 
		/// item2: строка с ошибкой для вывода пользователю</returns>
		public static Tuple<bool, string> CheckAge(int age)
		{
			bool ageMistakeFlag;
			string mistakeInfo = "";
			int ageMin = 1;
			int ageMax = 114;

			if (age < ageMin || age > ageMax)
			{
				ageMistakeFlag = true;
				mistakeInfo = $"Возраст должен быть в диапазоне" +
					$" [{ageMin}-{ageMax}]";
			}
			else
			{
				ageMistakeFlag = false;
			}

			Tuple<bool, string> outputTuple =
				Tuple.Create(ageMistakeFlag, mistakeInfo);

			return outputTuple;
		}
	}
}
