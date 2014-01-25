using System;

namespace PFAssist.Core.iOS
{
	public class Weapon
	{
		public readonly CalculatedReactiveValue<String> Name = new CalculatedReactiveValue<String> ();
		public readonly CalculatedReactiveValue<int> AttackBonus = new CalculatedReactiveValue<int> ();
		public readonly CalculatedReactiveValue<int> Critical = new CalculatedReactiveValue<int> ();
		public readonly CalculatedReactiveValue<int> Type = new CalculatedReactiveValue<int> ();
		public readonly CalculatedReactiveValue<int> Range = new CalculatedReactiveValue<int> ();
		public readonly CalculatedReactiveValue<int> Ammunition = new CalculatedReactiveValue<int> ();
		public readonly CalculatedReactiveValue<int> Damage = new CalculatedReactiveValue<int> ();

		public Weapon ()
		{
		}
	}
}

