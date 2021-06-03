using System;
using System.Windows.Forms;

namespace Laba4GUI
{
	/// <summary>
	/// Класс инициирующий работы программы
	/// </summary>
	public static class Program
	{
		/// <summary>
		/// Главная точка входа для приложения.
		/// </summary>
		[STAThread]
		public static void Main()
		{		
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new StartForm());
		}
	}
}
