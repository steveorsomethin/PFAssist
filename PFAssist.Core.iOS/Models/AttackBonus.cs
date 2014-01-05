using System;
using System.Reactive.Linq;

namespace PFAssist.Core
{
	public class AttackBonus
	{
		public readonly CalculatedReactiveValue<int> One = new CalculatedReactiveValue<int> ();
		public readonly CalculatedReactiveValue<int> Two = new CalculatedReactiveValue<int> ();
		public readonly CalculatedReactiveValue<int> Three = new CalculatedReactiveValue<int> ();
		public readonly CalculatedReactiveValue<int> Four = new CalculatedReactiveValue<int> ();

		public AttackBonus ()
		{
			One.Where (b => b > 5).Select (b => b - 5).Subscribe (Two);
			One.Where (b => b > 10).Select (b => b - 10).Subscribe (Three);
			One.Where (b => b > 15).Select (b => b - 15).Subscribe (Four);
		}
	}
}

