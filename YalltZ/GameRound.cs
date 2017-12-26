using System;
using System.Collections.Generic;
using System.Text;

namespace YalltZ
{
    class GameRound
    {
        public Player P1;
        public Player P2;
        private int RollRound;

        public GameRound(Player player1, Player player2)
        {
            P1 = player1;
            P2 = player2;

            RollRound = 0;
        }

        public void StartRound()
        {
            RunRound(!P1.IsActive ? P2 : P1);
        }

        private void RunRound(Player player)
        {
            Console.WriteLine("Player " + player.Name+"'s turn!");

            while (RollRound < 3)
            {
                string response = "";

                StringBuilder currentDice = new StringBuilder();

                // Roll Dice
                player.RollDice();
                Console.WriteLine("Rolling dice!");

                foreach (var dice in player.Dice)
                {
                    currentDice.Append(dice.Value + " ");
                }

                // Select Keepers
                Console.WriteLine("Current Dice: " + currentDice);
                Console.WriteLine("Type keep or roll in order - roll keep roll roll keep");
                response = Console.ReadLine();

                string[] responseSplit = response.Split(' ');

                for (var i = 0; i < responseSplit.Length; i++)
                {
                    player.Dice[i].Hold = !responseSplit[i].ToLower().Equals("roll");
                }

                // increment RollRound
                RollRound++;
            }

            // Show possibilities and decide a score
            Console.WriteLine(DisplayAllPossibilities());

            bool setScore = false;
            while (!setScore)
            {
                setScore = SetScore(Console.ReadLine(), player);
            }
        }

        private bool SetScore(string v, Player player)
        {
            v = v.Trim();
            switch (v.ToLower())
            {
                case "ones":
                {
                    if (player.GameCard.Ones == -1)
                    {
                        player.GameCard.Ones = GetDiceValue(v.ToLower(), player);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                case "twos":
                {
                    if (player.GameCard.Twos == -1)
                    {
                        player.GameCard.Twos = GetDiceValue(v.ToLower(), player);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                case "threes":
                {
                    if (player.GameCard.Threes == -1)
                    {
                        player.GameCard.Threes = GetDiceValue(v.ToLower(), player);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                case "fours":
                {
                    if (player.GameCard.Fours == -1)
                    {
                        player.GameCard.Fours = GetDiceValue(v.ToLower(), player);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                case "fives":
                {
                    if (player.GameCard.Fives == -1)
                    {
                        player.GameCard.Fives = GetDiceValue(v.ToLower(), player);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                case "sixes":
                {
                    if (player.GameCard.Sixes == -1)
                    {
                        player.GameCard.Sixes = GetDiceValue(v.ToLower(), player);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                    default: return false;
            }
        }

        private int GetDiceValue(string v, Player player)
        {
            // v equals number that we're looking for
            int total = 0;
            int match = 0;

            if (v == "ones")
                match = 1;
            if (v == "twos")
                match = 2;
            if (v == "threes")
                match = 3;
            if (v == "fours")
                match = 4;
            if (v == "fives")
                match = 5;
            if (v == "sixes")
                match = 6;

            foreach (Dice d in player.Dice)
            {
                if (d.Value == match)
                    total += d.Value;
            }

            return total;
        }

        private string DisplayAllPossibilities()
        {
            return
                "Ones " +
                "Twos " +
                "Threes " +
                "Fours " +
                "Fives " +
                "Sixes " +
                "3oak " +
                "4oak " +
                "Small " +
                "Large " +
                "FH " +
                "Yalltz " +
                "Chance ";
        }
    }
}
