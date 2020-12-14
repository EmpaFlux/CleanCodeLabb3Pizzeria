using CleanCodeLabb3_Pizzeria.Data;
using System;
using System.Collections.Generic;

namespace CleanCodeLabb3_Pizzeria.Models
{
    public class PizzaProvider : IObservable<OutgoingPizzas>
    {
        public PizzaProvider()
        {
            observers = new List<IObserver<OutgoingPizzas>>();
        }

        private List<IObserver<OutgoingPizzas>> observers;

        public IDisposable Subscribe(IObserver<OutgoingPizzas> observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);
            return new Unsubscriber(observers, observer);
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<OutgoingPizzas>> _observers;
            private IObserver<OutgoingPizzas> _observer;

            public Unsubscriber(List<IObserver<OutgoingPizzas>> observers, IObserver<OutgoingPizzas> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
        }

        public void TrackPizzas(Nullable<OutgoingPizzas> pizzas)
        {
            foreach (var observer in observers)
            {
                if (pizzas == null)
                    observer.OnError(new ProviderUnknownException());
                else
                    observer.OnNext(pizzas.Value);
            }
        }

        public void EndTransmission()
        {
            foreach (var observer in observers.ToArray())
                if (observers.Contains(observer))
                    observer.OnCompleted();

            observers.Clear();
        }
    }
}