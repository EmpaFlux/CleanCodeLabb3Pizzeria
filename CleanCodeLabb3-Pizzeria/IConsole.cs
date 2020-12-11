using System;
using System.Collections.Generic;
using System.Text;

namespace CleanCodeLabb3_Pizzeria
{
    public interface IConsole
    {
        public char ReadKey();
        public void Clear();
    }
}
