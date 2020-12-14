using System;
using System.Collections.Generic;
using System.Text;

namespace CleanCodeLabb3_Pizzeria.Data
{
    public struct OutgoingResources
    {
        List<string> res;

        public OutgoingResources(List<string> resources)
        {
            this.res = resources;
        }

        public List<string> ObserverResources
        { get { return this.res; } }
    }
}
