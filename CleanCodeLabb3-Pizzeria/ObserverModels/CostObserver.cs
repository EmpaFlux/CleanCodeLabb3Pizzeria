using CleanCodeLabb3_Pizzeria.Data;
using System;

namespace CleanCodeLabb3_Pizzeria.Models
{

    public class CostObserver : IObserver<OutgoingCost>
    {
        private IDisposable unsubscriber;
        private string instName;

        public CostObserver(string name)
        {
            this.instName = name;
        }

        public string Name
        { get { return this.instName; } }

        public virtual void Subscribe(IObservable<OutgoingCost> provider)
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

        public virtual void OnNext(OutgoingCost value)
        {
            Console.WriteLine($"{1} New total cost is {0}", value.ObserverCost, this.Name);
        }

        public virtual void Unsubscribe()
        {
            unsubscriber.Dispose();
        }
    }
}