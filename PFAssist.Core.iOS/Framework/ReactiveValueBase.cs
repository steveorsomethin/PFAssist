using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace PFAssist.Core
{
	public abstract class ReactiveValueBase<T> : IReactiveValue<T>
	{

		#region IObservable implementation

		public IDisposable Subscribe (IObserver<T> observer)
		{
			return this._outputValues.Subscribe (observer);
		}

		#endregion

		#region IObserver implementation

		public void OnCompleted ()
		{
			this._inputValues.OnCompleted ();
		}

		public void OnError (Exception error)
		{
			this._inputValues.OnError (error);
		}

		public void OnNext (T value)
		{
			this._inputValues.OnNext (value);
		}

		#endregion

		protected ISubject<T> _inputValues;
		protected ISubject<T> _outputValues;

		public T Value {
			get { return this.First (); }
			protected set { this._inputValues.OnNext (value); }
		}

		public ReactiveValueBase ()
		{
			this._inputValues = new BehaviorSubject<T> (default(T));
			this._outputValues = new BehaviorSubject<T> (default(T));
		}
	}
}

