using System;
using System.Reactive.Linq;

namespace PFAssist.Core
{
	public class CombatBonus
	{
		public readonly CalculatedReactiveValue<int> BaseAttackBonus = new CalculatedReactiveValue<int> ();
		public readonly CalculatedReactiveValue<int> Strength = new CalculatedReactiveValue<int> ();
		public readonly CalculatedReactiveValue<int> Dexterity = new CalculatedReactiveValue<int> ();
		public readonly CalculatedReactiveValue<int> Size = new CalculatedReactiveValue<int> ();
		public readonly CalculatedReactiveValue<int> ManeuverBonus = new CalculatedReactiveValue<int> ();
		public readonly CalculatedReactiveValue<int> DefenseBonus = new CalculatedReactiveValue<int> ();

		public CombatBonus ()
		{
			Observable.CombineLatest (BaseAttackBonus, Strength, Size, (b, st, si) => b + st + si)
				.Subscribe (ManeuverBonus);

			Observable.CombineLatest (
				BaseAttackBonus,
				Strength,
				Size,
				Dexterity,
				(b, st, si, d) => 10 + b + st + si + d)
				.Subscribe (DefenseBonus);
		}
	}
}

