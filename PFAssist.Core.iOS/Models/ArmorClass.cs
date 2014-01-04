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

		public CalculatedReactiveValue<int> FlatFootedTotal { get; protected set; }

		public CalculatedReactiveValue<int> TouchTotal { get; protected set; }

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
			this.FlatFootedTotal = new CalculatedReactiveValue<int> ();
			this.TouchTotal = new CalculatedReactiveValue<int> ();
			this.Total = new CalculatedReactiveValue<int> ();

			Observable.CombineLatest (
				this.Armor,
				this.Shield,
				this.Deflection,
				this.Size,
				this.NaturalArmor,
				this.Miscellaneous,
				(a, s, d, si, n, m) => 10 + a + s + d + si + n + m)
				.Subscribe (this.FlatFootedTotal);

			Observable.CombineLatest (
				this.Deflection,
				this.Miscellaneous,
				this.Stats,
				this.Size,
				(d, m, st, si) => 10 + d + m + st + si)
				.Subscribe (this.TouchTotal);

			Observable.CombineLatest (
				this.Armor,
				this.Shield,
				this.NaturalArmor,
				this.TouchTotal,
				(a, s, n, t) => a + s + n + t)
				.Subscribe (this.Total);
		}
	}
}

