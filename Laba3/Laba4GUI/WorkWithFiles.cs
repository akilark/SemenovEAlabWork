using Laba3.Logic;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Laba4GUI
{
	/// <summary>
	/// Класс для работы с файлами
	/// </summary>
	public class WorkWithFiles
	{
		/// <summary>
		/// Поле класса хранящее путь к файлу
		/// </summary>
		private readonly string _path;

		/// <summary>
		/// Поле класса хранящее тип сериалазиции
		/// </summary>
		private readonly XmlSerializer _xmlSerializer = 
			new XmlSerializer(typeof(List<Worker>));

		/// <summary>
		/// Конструктор класса с 1 параметром
		/// </summary>
		/// <param name="path">Путь к файлу</param>
		public WorkWithFiles(string path)
		{
			_path = path;
		}

		/// <summary>
		/// Метод позволяющий получить список работников из XML файла
		/// </summary>
		/// <returns>Лист работников</returns>
		public List<Worker> ReadFileInfo()
		{
			using (FileStream fs = new FileStream(_path, FileMode.OpenOrCreate))
			{
				return (List<Worker>)_xmlSerializer.Deserialize(fs); 			
			}
		}
		
		//TODO: RSDN naming
		/// <summary>
		/// Метод для переписывания данных в файл
		/// </summary>
		/// <param name="workerList">Лист работников,
		/// который необходимо записать в файл</param>
		public void rewriteFile(List<Worker> workerList)
		{
			using (FileStream fs = new FileStream(_path, FileMode.Create))
			{
				_xmlSerializer.Serialize(fs, workerList);
			}
		}
	}
}
