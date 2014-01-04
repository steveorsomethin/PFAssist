using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace PFAssist.Core
{
	public class CalculatedReactiveValue<T> : ReactiveValueBase<T>
	{
		public ReactiveValue<bool> IsOverridden { get; protected set; }

		private ISubject<T> _overrideValues;

		public void OverrideWith (T value)
		{
			this.IsOverridden.Value = true;
			this._overrideValues.OnNext (value);
		}

		public CalculatedReactiveValue () : base ()
		{
			this._overrideValues = new BehaviorSubject<T> (default(T));
			this.IsOverridden = new ReactiveValue<bool> ();

			this.IsOverridden
				.Select ((b) => b ? this._overrideValues : this._inputValues)
				.Switch ()
				.DistinctUntilChanged ()
				.Subscribe (this._outputValues);
		}
	}
}

