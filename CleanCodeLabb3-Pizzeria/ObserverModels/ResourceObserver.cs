using System;
using System.Collections.Generic;
using System.Text;
using CleanCodeLabb3_Pizzeria.Data;

namespace CleanCodeLabb3_Pizzeria.Models
{

    public class ResourceObserver : IObserver<OutgoingResources>
    {
        private IDisposable unsubscriber;
        private string instName;

        public ResourceObserver(string name)
        {
            this.instName = name;
        }

        public string Name
        { get { return this.instName; } }

        public virtual void Subscribe(IObservable<OutgoingResources> provider)
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

        public virtual void OnNext(OutgoingResources value)
        {
            Console.WriteLine($"{1} The resources used are {0}", value.ObserverResources, this.Name);
        }

        public virtual void Unsubscribe()
        {
            unsubscriber.Dispose();
        }
    }
}
