using System;
using System.Collections.Generic;
using System.Reactive.Subjects;

namespace FitnessClientLibrary.Common
{
    public class ObservableProperty<T> : IObservable<T>, IDisposable
    {
        //private readonly ReusableCompositeDisposable _disposables;
        private readonly ISubject<T> _observable;
        private T _value;
        private bool _disposed;

        /// <summary>
        /// Constructs an ObservableProperty object, which offers an observable and the latest value of the observable.
        /// </summary>
        /// <param name="initialValue">The initial value of the property.</param>
        public ObservableProperty(T initialValue = default(T))
        {
            _value = initialValue;
            // Initial/latest value is send to subscriper
            _observable = new BehaviorSubject<T>(initialValue);
        }

        /// <summary>
        /// The last provided value from the Observable.
        /// </summary>
        public T Value
        {
            get
            {
                //Contract.Requires<ObjectDisposedException>(!IsDisposed(), "Object has already been disposed.");
                if (Exception != null)
                {
                    throw Exception;
                }
                return _value;
            }
            set
            {
                //Contract.Requires<ObjectDisposedException>(!IsDisposed(), "Object has already been disposed.");
                if (Exception != null)
                {
                    throw Exception;
                }
                if (IsDisposed())
                    return;

                var oldvalue = Value;
                if (!EqualityComparer<T>.Default.Equals(oldvalue, value))
                {
                    _value = value;
                    _observable.OnNext(value);
                }
            }
        }

        /// <summary>
        /// Returns the Exception which has been provided by the Observable; normally
        /// steps should be taken to ensure that Observables provided to OAPH should
        /// never complete or fail.
        /// </summary>
        public Exception Exception { get; private set; }

        public IDisposable Subscribe(IObserver<T> observer)
        {
            return _observable.Subscribe(observer);
        }

        public IDisposable Subscribe(Action<T> onChange)
        {
            return _observable.Subscribe(onChange);
        }

        public bool IsDisposed()
        {
            return _disposed;
        }

        public void Dispose()
        {
            if (_disposed)
                return;

            _value = default(T);
            _observable.OnCompleted();
            _disposed = true;
        }
    }
}
