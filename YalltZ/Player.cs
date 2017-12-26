using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YalltZ
{
    class Player
    {
        public string Name { get; set; }
        public GameCard GameCard = new GameCard();
        public List<Dice> Dice = new List<Dice>();
        public bool IsActive;

        public Player(string name)
        {
            Name = name;

            for (var i = 0; i < 5; i++)
            {
                Dice.Add(new Dice());
            }
        }

        public void RollDice()
        {
            int count = 0;
            foreach (Dice d in Dice.ToList())
            {
                if (!d.Hold)
                {
                    Dice[count] = new Dice();
                }

                count++;
            }
        }
    }
}
