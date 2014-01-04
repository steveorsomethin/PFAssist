using System;
using System.Reactive.Linq;

namespace PFAssist.Core
{
	public class ArmorClass
	{
		public readonly ReactiveValue<int> Armor = new ReactiveValue<int> ();
		public readonly ReactiveValue<int> Shield = new ReactiveValue<int> ();
		public readonly ReactiveValue<int> Deflection = new ReactiveValue<int> ();
		public readonly ReactiveValue<int> NaturalArmor = new ReactiveValue<int> ();
		public readonly ReactiveValue<int> Miscellaneous = new ReactiveValue<int> ();
		public readonly CalculatedReactiveValue<int> Stats = new CalculatedReactiveValue<int> ();
		public readonly CalculatedReactiveValue<int> Size = new CalculatedReactiveValue<int> ();
		public readonly CalculatedReactiveValue<int> FlatFootedTotal = new CalculatedReactiveValue<int> ();
		public readonly CalculatedReactiveValue<int> TouchTotal = new CalculatedReactiveValue<int> ();
		public readonly CalculatedReactiveValue<int> Total = new CalculatedReactiveValue<int> ();

		public ArmorClass ()
		{
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

