using SimplifiedSlotMachineGame.Models.Enum;
using SimplifiedSlotMachineGame.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplifiedSlotMachineGame.Models.Class.Symbols
{
	public class AppleSymbol : ISymbol
	{
		public char GetSymbol() => SymbolHelper.ConvertSymbol(SymbolEnum.Apple);
		public double GetCoefficient() => 0.4;
		public double GetProbability() => 0.45;
	}
}
