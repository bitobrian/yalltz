using System;
using System.Collections.Generic;

namespace YalltZ
{
    class Program
    {
        static bool WinConditionMet = false;

        static void Main(string[] args)
        {
            Console.WriteLine("YalltZ!");
            
            List<Player> playerList = new List<Player>();

            playerList.Add(new Player("Tacos"));
            playerList.Add(new Player("Beerz"));

            playerList[0].IsActive = true;

            while (!WinConditionMet)
            {
                GameRound gameRound = new GameRound(playerList[0], playerList[1]);

                Console.WriteLine("Press any key to start round");
                Console.ReadKey();

                gameRound.StartRound();

                foreach (Player p in playerList)
                {
                    if (p.GameCard.CheckWin())
                        WinConditionMet = true;
                }
            }
        }
    }
}
