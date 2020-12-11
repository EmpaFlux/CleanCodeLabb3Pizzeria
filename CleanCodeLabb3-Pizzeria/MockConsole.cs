using System;
using System.Collections.Generic;
using System.Text;

namespace CleanCodeLabb3_Pizzeria
{
    public class MockConsole : IConsole
    {
        public void Clear()
        {
            
        }

        public char ReadKey()
        {
            return '0';
        }
    }
}
