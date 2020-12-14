using CleanCodeLabb3_Pizzeria.Data;
using System;
using System.Collections.Generic;

namespace CleanCodeLabb3_Pizzeria.Models
{
    public class ResourceProvider : IObservable<OutgoingResources>
    {
        public ResourceProvider()
        {
            observers = new List<IObserver<OutgoingResources>>();
        }

        private List<IObserver<OutgoingResources>> observers;

        public IDisposable Subscribe(IObserver<OutgoingResources> observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);
            return new Unsubscriber(observers, observer);
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<OutgoingResources>> _observers;
            private IObserver<OutgoingResources> _observer;

            public Unsubscriber(List<IObserver<OutgoingResources>> observers, IObserver<OutgoingResources> observer)
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

        public void TrackCost(Nullable<OutgoingResources> cost)
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