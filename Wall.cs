using System;
using System.Collections.Generic;
using System.Text;

namespace lab1
{
    public class Wall
    {
        private readonly char symbol;

        public Wall(char symbol) => this.symbol = symbol;

        public override string ToString() => symbol.ToString();

    }
}
