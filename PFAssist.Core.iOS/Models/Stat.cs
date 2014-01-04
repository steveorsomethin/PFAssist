using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace PFAssist.Core
{
	public enum StatType
	{
		Strength,
		Dexterity,
		Constitution,
		Intelligence,
		Wisdom,
		Charisma
	}

	public class Stat
	{
		public StatType Type { get; protected set; }

		public ReactiveValue<int> Score { get; protected set; }

		public CalculatedReactiveValue<int> Modifier { get; protected set; }

		public ReactiveValue<int> TempAdjust { get; protected set; }

		public CalculatedReactiveValue<int> TempModifier { get; protected set; }

		public Stat (StatType type)
		{
			this.Type = type;
			this.Score = new ReactiveValue<int> ();
			this.Modifier = new CalculatedReactiveValue<int> ();
			this.TempAdjust = new ReactiveValue<int> ();
			this.TempModifier = new CalculatedReactiveValue<int> ();

			this.Score.Select (s => (s - 10) / 2).Subscribe (this.Modifier);
			this.Score.Zip (this.TempAdjust, (s, t) => (s + t - 10) / 2).Subscribe (this.TempModifier);
		}
	}
}

