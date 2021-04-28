using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba3.Logic
{
	public interface IWage
	{
		//TODO: Money

		int AmountMoney { get;}

		string NameOFTypeWageCounter { get; }
		
		int PriceOfWork{ get; set; }

		DateTime Date { get; set; }

		int WorkDaysInMonth { get; }

		int WorkHours { get; set; }

		void CalculateAmountMoney();

		int AllowToWorkHoursInDay { get; set; }
	}
}
