using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba3.Logic
{
	public class HorlyPayment : IWage
	{
		int HoursOfWork { get; set; }

		int AmountMoney()
		{
			return HoursOfWork * PriceOfWork;
		}

		string NameOFTypeWageCounter { get; set; }

		int PriceOfWork { get; set; }
	}
}
