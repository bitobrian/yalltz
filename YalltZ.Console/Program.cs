using System;
using System.Collections.Generic;
using YalltZ.Shared;

namespace YalltZ.ConsoleApp
{
    class Program
    {
        static bool WinConditionMet = false;

        static void Main()
        {
            Console.WriteLine("YalltZ!");

            List<Player> playerList = new List<Player>
            {
                new Player("Tacos"),
                new Player("Beerz")
            };

            playerList[0].IsActive = true;

            while (!WinConditionMet)
            {
                GameRound gameRound = new GameRound(playerList[0], playerList[1]);

                Console.WriteLine(DisplayStats(playerList[0]));

                Console.WriteLine("Press any key to start round");
                Console.ReadKey();

                gameRound.StartRound();

                foreach (Player p in playerList)
                {
                    WinConditionMet = p.GameCard.HasWon();
                }
            }
        }

        private static string DisplayStats(Player player)
        {
            Console.Clear();

            string output = "";

            output += "**********************************";
            output += "\n** Player "+player.Name;
            output += "\n** 1s: " + player.GameCard.Ones;
            output += "\n** 2s: " + player.GameCard.Twos;
            output += "\n** 3s: " + player.GameCard.Threes;
            output += "\n** 4s: " + player.GameCard.Fours;
            output += "\n** 5s: " + player.GameCard.Fives;
            output += "\n** 6s: " + player.GameCard.Sixes;
            output += "\n**********************************";
            output += "\n** 3OAK: " + player.GameCard.ThreeOfAKind;
            output += "\n** 4OAK: " + player.GameCard.FourOfAKind;
            output += "\n** Small: " + player.GameCard.SmallStraight;
            output += "\n** Large: " + player.GameCard.LargeStraight;
            output += "\n** Full: " + player.GameCard.FullHouse;
            output += "\n** Yalltz: " + player.GameCard.Yalltz;
            output += "\n** Chance: " + player.GameCard.Chance;
            output += "\n**********************************";
            output += "\n** Total: " + player.GameCard.GetTotal()+ "\n";

            return output;
        }
    }
}
