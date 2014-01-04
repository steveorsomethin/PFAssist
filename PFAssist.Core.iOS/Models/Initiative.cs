using System;
using System.Reactive.Linq;

namespace PFAssist.Core
{
	public class Initiative
	{
		public readonly ReactiveValue<int> Miscellaneous = new ReactiveValue<int> ();
		public readonly CalculatedReactiveValue<int> Stats = new CalculatedReactiveValue<int> ();
		public readonly CalculatedReactiveValue<int> Total = new CalculatedReactiveValue<int> ();

		public Initiative ()
		{
			Observable.CombineLatest (
				Miscellaneous,
				Stats,
				(m, s) => m + s)
				.Subscribe (Total);
		}
	}
}

