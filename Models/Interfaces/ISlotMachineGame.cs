using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces
{
	public interface ISlotMachineGame
	{
		double Deposit { get; }
		double Balance { get; }
		void Play();
	}
}
