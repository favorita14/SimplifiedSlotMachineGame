using SimplifiedSlotMachineGame.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplifiedSlotMachineGame.Models.Class
{
	public static class SymbolHelper
	{
		public static char ConvertSymbol(SymbolEnum symbol)
		{
			return symbol switch
			{
				SymbolEnum.Apple => 'A',
				SymbolEnum.Banana => 'B',
				SymbolEnum.Pineapple => 'P',
				SymbolEnum.Wildcard => '*',
				_ => ' '
			};
		}
	}
}
