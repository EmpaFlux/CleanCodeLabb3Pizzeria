using System;
using System.IO;

namespace CleanCodeLabb3_Pizzeria
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayText displayText = new DisplayText(new ReadConsole());
            displayText.DisplayMenu();
            //using (StringReader test = new StringReader("1" + Environment.NewLine + "2" + Environment.NewLine + "4"))
            //{
            //    Console.SetIn(test);
            //    DisplayText displayText = new DisplayText(new ReadConsole());
            //    displayText.DisplayMenu();
            //}
        }
    }
}
