using System;
using System.Collections.Generic;
using System.Text;

namespace lab1
{
    public class Room
    {
        //public override string ToString() => "0";
        private readonly char symbol;

        public Room(char symbol) => this.symbol = symbol;

        public override string ToString() => symbol.ToString();

    }
}
