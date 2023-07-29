using SimplifiedSlotMachineGame.Models.Class.Symbols;
using SimplifiedSlotMachineGame.Models.Enum;
using SimplifiedSlotMachineGame.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplifiedSlotMachineGame.Models.Class.SlotMachineGames
{
	public class SlotMachineGame : ISlotMachineGame
	{
        private readonly Random random = new Random();
        private readonly List<ISymbol> symbols;

        public double Deposit { get; private set; }
        public double Balance { get; private set; }

        public SlotMachineGame(double deposit)
        {
            Deposit = deposit;
            Balance = deposit;

            symbols = new List<ISymbol>
            {
                new AppleSymbol(),
                new BananaSymbol(),
                new PineappleSymbol(),
                new WildcardSymbol()
            };
        }

        public void Play()
        {
            Console.Write("Enter the stake amount: ");
            double stakeAmount = double.Parse(Console.ReadLine());

            if (stakeAmount > Balance)
            {
                Console.WriteLine("Stake amount cannot exceed the current balance.");
                return;
            }

            char[][] grid = GenerateGrid();

            // Display the grid
            Console.WriteLine("Slot Machine Result:");
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Console.Write(grid[row][col] + " ");
                }
                Console.WriteLine();
            }

            double winAmount = CalculateWin(grid, stakeAmount);
            Balance = Balance - stakeAmount + winAmount;

            Console.WriteLine($"Win Amount: {winAmount}");
            Console.WriteLine($"Current Balance: {Balance}");

            if (Balance <= 0)
            {
                Console.WriteLine("Game Over! You ran out of money.");
            }
        }

        private char[][] GenerateGrid()
        {
            char[][] grid = new char[4][];
            for (int row = 0; row < 4; row++)
            {
                grid[row] = new char[3];
                for (int col = 0; col < 3; col++)
                {
                    double randomValue = random.NextDouble();
                    double cumulativeProbability = 0;
                    for (int i = 0; i < symbols.Count; i++)
                    {
                        cumulativeProbability += symbols[i].GetProbability();
                        if (randomValue < cumulativeProbability)
                        {
                            grid[row][col] = symbols[i].GetSymbol();
                            break;
                        }
                    }
                }
            }
            return grid;
        }

        private double CalculateWin(char[][] grid, double stakeAmount)
        {
            double winAmount = 0;
            char winningSymbol = ' ';
            for (int row = 0; row < 4; row++)
            {
                if (grid[row][0] == grid[row][1] && grid[row][1] == grid[row][2])
                {
                    winningSymbol = grid[row][0];
                    var symbol = symbols.Find(s => s.GetSymbol() == winningSymbol);
                    winAmount += (symbol.GetCoefficient() * 3) * stakeAmount;
                }
                else if((grid[row][0] == SymbolHelper.ConvertSymbol(SymbolEnum.Wildcard) && grid[row][1] == grid[row][2]) || 
                    (grid[row][0] == grid[row][2] && grid[row][1] == SymbolHelper.ConvertSymbol(SymbolEnum.Wildcard)) ||
                    (grid[row][0] == grid[row][1] && grid[row][2] == SymbolHelper.ConvertSymbol(SymbolEnum.Wildcard)))
				{
                    winningSymbol = grid[row][0];
                    if(SymbolHelper.ConvertSymbol(SymbolEnum.Wildcard) == winningSymbol)
                            winningSymbol = grid[row][1];

                    var symbol = symbols.Find(s => s.GetSymbol() == winningSymbol);
                    winAmount += (symbol.GetCoefficient() * 2) * stakeAmount;
                }
                else if (grid[row][0] == SymbolHelper.ConvertSymbol(SymbolEnum.Wildcard) && grid[row][1] == SymbolHelper.ConvertSymbol(SymbolEnum.Wildcard))
                {
                    winningSymbol = grid[row][2];
                    var symbol = symbols.Find(s => s.GetSymbol() == winningSymbol);
                    winAmount += symbol.GetCoefficient() * stakeAmount;
                }
                else if (grid[row][0] == SymbolHelper.ConvertSymbol(SymbolEnum.Wildcard) && grid[row][2] == SymbolHelper.ConvertSymbol(SymbolEnum.Wildcard))
                {
                    winningSymbol = grid[row][1];
                    var symbol = symbols.Find(s => s.GetSymbol() == winningSymbol);
                    winAmount += symbol.GetCoefficient() * stakeAmount;
                }
                else if (grid[row][1] == SymbolHelper.ConvertSymbol(SymbolEnum.Wildcard) && grid[row][2] == SymbolHelper.ConvertSymbol(SymbolEnum.Wildcard))
                {
                    winningSymbol = grid[row][0];
                    var symbol = symbols.Find(s => s.GetSymbol() == winningSymbol);
                    winAmount += symbol.GetCoefficient() * stakeAmount;
                }
            }

            //if (winningSymbol != ' ')
            //{
            //    ISymbol symbol = symbols.Find(s => s.GetSymbol() == winningSymbol);
            //    winAmount = symbol.GetCoefficient() * stakeAmount;
            //}

            return winAmount;
        }
    }
}
