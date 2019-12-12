using System;
using System.Collections.Generic;
using System.Text;

namespace YalltZ.Desktop.Shared
{
    public class GameRound
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
            RunRound(P1);

            RollRound = 0;

            RunRound(P2);
        }

        private void RunRound(Player player)
        {
            Console.Clear();
            Console.WriteLine("Player " + player.Name+"'s turn!\n");

            while (RollRound < 3)
            {
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
                Console.WriteLine("Type k for keep or r for roll in order - r k r r k");
                var response = Console.ReadLine();

                string[] responseSplit = response.Split(' ');

                for (var i = 0; i < responseSplit.Length; i++)
                {
                    player.Dice[i].Hold = !responseSplit[i].ToLower().Equals("r");
                }

                // increment RollRound
                RollRound++;

                if (RollRound == 3)
                    break;
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
                case "3oak":
                {
                    if(player.GameCard.ThreeOfAKind == -1)
                    {
                        player.GameCard.ThreeOfAKind = SumOfAllDice(3, player);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    }
                case "4oak":
                    {
                        if (player.GameCard.FourOfAKind == -1)
                        {
                            player.GameCard.FourOfAKind = SumOfAllDice(4, player);
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                case "c":
                    {
                        if (player.GameCard.Chance == -1)
                        {
                            player.GameCard.Chance = SumOfAllDice(5, player);
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                case "s":
                    {
                        if (player.GameCard.SmallStraight == -1)
                        {
                            player.GameCard.SmallStraight = CheckSmallStraight(player);
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                case "l":
                    {
                        if (player.GameCard.LargeStraight == -1)
                        {
                            player.GameCard.LargeStraight = CheckLargeStraight(player);
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                case "fh":
                    {
                        if (player.GameCard.FullHouse == -1)
                        {
                            player.GameCard.FullHouse = CheckFullHouse(player);
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                case "y":
                    {
                        if (player.GameCard.Yalltz == -1)
                        {
                            player.GameCard.Yalltz = CheckYalltz(player);
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

        private int CheckLargeStraight(Player player)
        {
            // return 40 if conditions are met
            int ones = 0;
            int twos = 0;
            int threes = 0;
            int fours = 0;
            int fives = 0;
            int sixes = 0;

            foreach (Dice d in player.Dice)
            {
                // check if it matches
                if (d.Value == 1)
                    ones++;
                if (d.Value == 2)
                    twos++;
                if (d.Value == 3)
                    threes++;
                if (d.Value == 4)
                    fours++;
                if (d.Value == 5)
                    fives++;
                if (d.Value == 6)
                    sixes++;
            }

            if (ones > 0 && twos > 0 && threes > 0 && fours > 0 && fives > 0)
            {
                return 40;
            }

            if (sixes > 0 && twos > 0 && threes > 0 && fours > 0 && fives > 0)
            {
                return 40;
            }

            return 0;
        }

        private int CheckSmallStraight(Player player)
        {
            // return 30 if conditions are met
            int ones = 0;
            int twos = 0;
            int threes = 0;
            int fours = 0;
            int fives = 0;
            int sixes = 0;

            foreach (Dice d in player.Dice)
            {
                // check if it matches
                if (d.Value == 1)
                    ones++;
                if (d.Value == 2)
                    twos++;
                if (d.Value == 3)
                    threes++;
                if (d.Value == 4)
                    fours++;
                if (d.Value == 5)
                    fives++;
                if (d.Value == 6)
                    sixes++;
            }

            if (ones > 0 && twos > 0 && threes > 0 && fours > 0)
            {
                return 30;
            }

            if (fives > 0 && twos > 0 && threes > 0 && fours > 0)
            {
                return 30;
            }

            if (fives > 0 && sixes > 0 && threes > 0 && fours > 0)
            {
                return 30;
            }

            return 0;
        }

        private int CheckFullHouse(Player player)
        {
            // return 25 if conditions are met
            int ones = 0;
            int twos = 0;
            int threes = 0;
            int fours = 0;
            int fives = 0;
            int sixes = 0;

            foreach (Dice d in player.Dice)
            {
                // check if it matches
                if (d.Value == 1)
                    ones++;
                if (d.Value == 2)
                    twos++;
                if (d.Value == 3)
                    threes++;
                if (d.Value == 4)
                    fours++;
                if (d.Value == 5)
                    fives++;
                if (d.Value == 6)
                    sixes++;
            }

            if(ones==3 || twos == 3 || threes == 3 || fours == 3 || fives == 3 || sixes == 3)
            {
                if (ones == 2 || twos == 2 || threes == 2 || fours == 2 || fives == 2 || sixes == 2)
                {
                    return 25;
                }
            }

            return 0;
        }

        private int CheckYalltz(Player player)
        {
            int tempDie = 0;
            int count = 0;

            foreach(Dice d in player.Dice)
            {
                if (tempDie != d.Value)
                    tempDie = d.Value;
                else
                    count++;
            }

            return (count == 5 ? 50 : 0);
        }

        private int SumOfAllDice(int slotIdentifier, Player player)
        {
            // v is either 3 for 3oak, 4 for 4oak, or 5 for chance
            int chance = 0;
            int total = 0;
            int ones = 0;
            int twos = 0;
            int threes = 0;
            int fours = 0;
            int fives = 0;
            int sixes = 0;

            bool match3oak = false;
            bool match4oak = false;

            foreach (Dice d in player.Dice)
            {
                // if it's not chance
                if (slotIdentifier != 5)
                {
                    // check if it matches
                    if (d.Value == 1)
                        ones++;
                    if (d.Value == 2)
                        twos++;
                    if (d.Value == 3)
                        threes++;
                    if (d.Value == 4)
                        fours++;
                    if (d.Value == 5)
                        fives++;
                    if (d.Value == 6)
                        sixes++;
                }
                else
                {
                    chance += d.Value;
                }
            }

            if (slotIdentifier == 3)
            {
                if (ones > 2)
                    match3oak = true;
                if (twos > 2)
                    match3oak = true;
                if (threes > 2)
                    match3oak = true;
                if (fours > 2)
                    match3oak = true;
                if (fives > 2)
                    match3oak = true;
                if (sixes > 2)
                    match3oak = true;

                if (!match3oak)
                    total = 0;
                else
                    total = chance;
            }

            if (slotIdentifier == 4)
            {
                if (ones > 3)
                    match4oak = true;
                if (twos > 3)
                    match4oak = true;
                if (threes > 3)
                    match4oak = true;
                if (fours > 3)
                    match4oak = true;
                if (fives > 3)
                    match4oak = true;
                if (sixes > 3)
                    match4oak = true;

                if (!match4oak)
                    total = 0;
                else
                    total = chance;
            }

            if (slotIdentifier == 5)
                return chance;

            return total;
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
            return "Choose one: "+
                "Ones " +
                "Twos " +
                "Threes " +
                "Fours " +
                "Fives " +
                "Sixes " +
                "3oak " +
                "4oak " +
                "S " +
                "L " +
                "FH " +
                "Y " +
                "C ";
        }
    }
}
