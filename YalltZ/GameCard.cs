using System;
using System.Collections.Generic;
using System.Text;

namespace YalltZ
{
    class GameCard
    {
        public int Ones { get; set; } = -1;
        public int Twos { get; set; } = -1;
        public int Threes { get; set; } = -1;
        public int Fours { get; set; } = -1;
        public int Fives { get; set; } = -1;
        public int Sixes { get; set; } = -1;
        public int ThreeOfAKind { get; set; } = -1;
        public int FourOfAKind { get; set; } = -1;
        public int SmallStraight { get; set; } = -1;
        public int LargeStraight { get; set; } = -1;
        public int FullHouse { get; set; } = -1;
        public int Yalltz { get; set; } = -1;
        public int Chance { get; set; } = -1;

        public bool CheckWin()
        {
            if (Ones != -1 &&
                Twos != -1 &&
                Threes != -1 &&
                Fours != -1 &&
                Fives != -1 &&
                Sixes != -1 &&
                ThreeOfAKind != -1 &&
                FourOfAKind != -1 &&
                SmallStraight != -1 &&
                LargeStraight != -1 &&
                FullHouse != -1 &&
                Yalltz != -1 &&
                Chance != -1)
                return true;
           
            return false;
        }

        public int GetTotal()
        {
            int total = 0;

            List<int> propList = new List<int>();
            propList.Add(Ones);
            propList.Add(Twos);
            propList.Add(Threes);
            propList.Add(Fours);
            propList.Add(Fives);
            propList.Add(Sixes);
            propList.Add(ThreeOfAKind);
            propList.Add(FourOfAKind);
            propList.Add(SmallStraight);
            propList.Add(LargeStraight);
            propList.Add(FullHouse);
            propList.Add(Yalltz);
            propList.Add(Chance);

            foreach(int i in propList)
            {
                if (i > 0)
                    total += i;
            }

            return total;
        }
    }
}
