using System;
using System.Collections.Generic;
using System.Text;
using CleanCodeLabb3_Pizzeria.Data;

namespace CleanCodeLabb3_Pizzeria.Models
{

    public class PizzaObserver : IObserver<OutgoingPizzas>
    {
        private IDisposable unsubscriber;
        private string instName;

        public PizzaObserver(string name)
        {
            this.instName = name;
        }

        public string Name
        { get { return this.instName; } }

        public virtual void Subscribe(IObservable<OutgoingPizzas> provider)
        {
            if (provider != null)
                unsubscriber = provider.Subscribe(this);
        }

        public virtual void OnCompleted()
        {
            Console.WriteLine($"Data sent to {0}.", this.Name);
            this.Unsubscribe();
        }

        public virtual void OnError(Exception e)
        {
            Console.WriteLine($"{0}: A error occured.", this.Name);
        }

        public virtual void OnNext(OutgoingPizzas value)
        {
            Console.WriteLine($"{1} The pizzas are {0}", value.ObserverPizza, this.Name);
        }

        public virtual void Unsubscribe()
        {
            unsubscriber.Dispose();
        }
    }
}
