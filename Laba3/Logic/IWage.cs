using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba3.Logic
{
	public interface IWage
	{

		int Amountmoney();

		string NameOFTypeWageCounter { get; set; }
		
		int PriceOfWork{ get; set; }

		
	}
}
