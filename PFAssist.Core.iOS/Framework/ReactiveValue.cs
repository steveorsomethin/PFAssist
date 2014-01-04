using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace PFAssist.Core
{
	public class ReactiveValue<T> : ReactiveValueBase<T>
	{
		public new T Value {
			get { return this.First (); }
			set { this._input.OnNext (value); }
		}

		public ReactiveValue () : base ()
		{
			this._input.DistinctUntilChanged ().Subscribe (this._output);
		}
	}
}

