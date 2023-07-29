using Models.Enum;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Class.Symbols
{
	public class AppleSymbol : ISymbol
	{
		public char GetSymbol() => SymbolHelper.ConvertSymbol(SymbolEnum.Apple);
		public double GetCoefficient() => 0.4;
		public double GetProbability() => 0.45;
	}
}
