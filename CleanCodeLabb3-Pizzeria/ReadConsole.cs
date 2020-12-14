using System;
using System.Collections.Generic;
using System.Text;

namespace CleanCodeLabb3_Pizzeria
{
    class ReadConsole : IConsole
    {
        public void Clear()
        {
            Console.Clear();
        }

        public char ReadKey()
        {
            return Console.ReadKey().KeyChar;
        }
    }
}
