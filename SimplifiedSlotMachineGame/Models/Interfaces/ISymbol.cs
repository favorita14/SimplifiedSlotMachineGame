using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplifiedSlotMachineGame.Models.Interfaces
{
	public interface ISymbol
	{
		char GetSymbol();
		double GetCoefficient();
		double GetProbability();
	}
}
