using SimplifiedSlotMachineGame.Models.Enum;
using SimplifiedSlotMachineGame.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplifiedSlotMachineGame.Models.Class.Symbols
{
	public class PineappleSymbol : ISymbol
	{
		public char GetSymbol() => SymbolHelper.ConvertSymbol(SymbolEnum.Pineapple);
		public double GetCoefficient() => 0.8;
		public double GetProbability() => 0.15;
	}
}
