using System;
using System.Reactive.Linq;

namespace PFAssist.Core
{
	public class Initiative
	{
		public ReactiveValue<int> Miscellaneous { get; protected set; }

		public CalculatedReactiveValue<int> Stats { get; protected set; }

		public CalculatedReactiveValue<int> Total { get; protected set; }

		public Initiative ()
		{
			this.Miscellaneous = new ReactiveValue<int> ();
			this.Stats = new CalculatedReactiveValue<int> ();
			this.Total = new CalculatedReactiveValue<int> ();

			Observable.CombineLatest (
				this.Miscellaneous,
				this.Stats,
				(m, s) => m + s)
				.Subscribe (this.Total);
		}
	}
}

