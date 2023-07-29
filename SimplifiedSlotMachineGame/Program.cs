using SimplifiedSlotMachineGame.Models.Class.SlotMachineGames;
using SimplifiedSlotMachineGame.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace SimplifiedSlotMachineGame
{
    class Program
    {
        static void Main(string[] args)
        {
			Console.WriteLine("Welcome to the Slot Machine Game!");
			Console.Write("Enter the deposit amount: ");
			double depositAmount = double.Parse(Console.ReadLine());

			ISlotMachineGame slotMachine = new SlotMachineGame(depositAmount);

			while (slotMachine.Balance > 0)
			{
				slotMachine.Play();
			}
		}
    }
}