using System;
using System.Collections.Generic;
using System.Text;

namespace YalltZ.Desktop.Shared
{
    public class Dice
    {
        public int Value { get; set; }
        public int MinValue = 1;
        public int MaxValue = 6;
        public bool Hold;

        public Dice()
        {
            Roll();
        }

        public void Roll()
        {
            var random = new Random();
            Value = random.Next(MinValue,MaxValue);
        }
    }
}
