using Laba3.Logic;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Laba4GUI
{
	public class WorkWithFiles
	{
		private string _path;
		private XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Worker>));

		public WorkWithFiles(string path)
		{
			_path = path;
		}


		public List<Worker> ReadFileInfo()
		{
			if (File.Exists(_path) == false)
			{
				using (FileStream fs = new FileStream(_path, FileMode.Create))
				{
					xmlSerializer.Serialize(fs,new List<Worker>());
				}
			}
			using (FileStream fs = new FileStream(_path, FileMode.OpenOrCreate))
			{
				return (List<Worker>)xmlSerializer.Deserialize(fs); 			
			}
		}
		
		public void rewriteFile(List<Worker> workerList)
		{
			using (FileStream fs = new FileStream(_path, FileMode.Create))
			{
				xmlSerializer.Serialize(fs, workerList);
			}
		}
	}
}
