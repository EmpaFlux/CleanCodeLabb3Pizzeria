using System.Collections.Generic;

namespace CleanCodeLabb3_Pizzeria.Factories
{
    internal interface IPizzeriaFactory<T>
    {
        T Get(string name);
        List<T> Get(List<string> names);
    }
}
