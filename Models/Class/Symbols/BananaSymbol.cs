using Models.Enum;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Class.Symbols
{
	public class BananaSymbol : ISymbol
	{
		public char GetSymbol() => SymbolHelper.ConvertSymbol(SymbolEnum.Banana);
		public double GetCoefficient() => 0.6;
		public double GetProbability() => 0.35;
	}
}
