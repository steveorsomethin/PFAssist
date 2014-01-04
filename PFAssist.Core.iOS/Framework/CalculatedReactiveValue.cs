using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace PFAssist.Core
{
	public class CalculatedReactiveValue<T> : ReactiveValueBase<T>
	{
		public ReactiveValue<bool> IsOverridden { get; protected set; }

		private ISubject<T> _overrides;

		public void OverrideWith(T value)
		{
			this.IsOverridden.Value = true;
			this._overrides.OnNext (value);
		}

		public CalculatedReactiveValue() : base()
		{
			this._overrides = new BehaviorSubject<T> (default(T));
			this.IsOverridden = new ReactiveValue<bool> ();

			this.IsOverridden
				.Select ((b) => b ? this._overrides : this._input)
				.Switch ()
				.DistinctUntilChanged()
				.Subscribe (this._output);
		}
	}
}

