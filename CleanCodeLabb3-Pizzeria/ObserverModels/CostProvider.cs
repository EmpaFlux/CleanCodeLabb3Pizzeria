using CleanCodeLabb3_Pizzeria.Data;
using System;
using System.Collections.Generic;

namespace CleanCodeLabb3_Pizzeria.Models
{
    public class CostProvider : IObservable<OutgoingCost>
    {
        public CostProvider()
        {
            observers = new List<IObserver<OutgoingCost>>();
        }

        private List<IObserver<OutgoingCost>> observers;

        public IDisposable Subscribe(IObserver<OutgoingCost> observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);
            return new Unsubscriber(observers, observer);
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<OutgoingCost>> _observers;
            private IObserver<OutgoingCost> _observer;

            public Unsubscriber(List<IObserver<OutgoingCost>> observers, IObserver<OutgoingCost> observer)
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

        public void TrackCost(Nullable<OutgoingCost> cost)
        {
            foreach (var observer in observers)
            {
                if (cost == null)
                    observer.OnError(new ProviderUnknownException());
                else
                    observer.OnNext(cost.Value);
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