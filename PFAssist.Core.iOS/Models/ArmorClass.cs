using System;
using System.Reactive.Linq;

namespace PFAssist.Core
{
	public class ArmorClass
	{
		public ReactiveValue<int> Armor { get; protected set; }

		public ReactiveValue<int> Shield { get; protected set; }

		public ReactiveValue<int> Deflection { get; protected set; }

		public ReactiveValue<int> NaturalArmor { get; protected set; }

		public ReactiveValue<int> Miscellaneous { get; protected set; }

		public CalculatedReactiveValue<int> Stats { get; protected set; }

		public CalculatedReactiveValue<int> Size { get; protected set; }

		public CalculatedReactiveValue<int> Total { get; protected set; }

		public ArmorClass ()
		{
			this.Armor = new ReactiveValue<int> ();
			this.Shield = new ReactiveValue<int> ();
			this.Deflection = new ReactiveValue<int> ();
			this.NaturalArmor = new ReactiveValue<int> ();
			this.Miscellaneous = new ReactiveValue<int> ();
			this.Stats = new CalculatedReactiveValue<int> ();
			this.Size = new CalculatedReactiveValue<int> ();
			this.Total = new CalculatedReactiveValue<int> ();

			Observable.CombineLatest (
				this.Armor,
				this.Shield,
				this.Deflection,
				this.NaturalArmor,
				this.Miscellaneous,
				this.Stats,
				this.Size,
				(a, s, d, n, m, st, si) => 10 + a + s + d + n + m + st + si)
				.Subscribe (this.Total);
		}
	}
}

