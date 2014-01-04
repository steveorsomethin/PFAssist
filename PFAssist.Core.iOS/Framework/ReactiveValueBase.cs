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
			return this._output.Subscribe (observer);
		}

		#endregion

		#region IObserver implementation

		public void OnCompleted ()
		{
			this._input.OnCompleted ();
		}

		public void OnError (Exception error)
		{
			this._input.OnError (error);
		}

		public void OnNext (T value)
		{
			this._input.OnNext (value);
		}

		#endregion

		protected ISubject<T> _input;
		protected ISubject<T> _output;

		public T Value {
			get { return this.First (); }
			protected set { this._input.OnNext (value); }
		}

		public ReactiveValueBase ()
		{
			this._input = new BehaviorSubject<T> (default(T));
			this._output = new BehaviorSubject<T> (default(T));
		}
	}
}

