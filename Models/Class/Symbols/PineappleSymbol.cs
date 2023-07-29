using Models.Enum;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Class.Symbols
{
	public class PineappleSymbol : ISymbol
	{
		public char GetSymbol() => SymbolHelper.ConvertSymbol(SymbolEnum.Pineapple);
		public double GetCoefficient() => 0.8;
		public double GetProbability() => 0.15;
	}
}
