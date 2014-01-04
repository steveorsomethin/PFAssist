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

		public readonly ReactiveValue<int> Score = new ReactiveValue<int> ();
		public readonly CalculatedReactiveValue<int> Modifier = new CalculatedReactiveValue<int> ();
		public readonly ReactiveValue<int> TempAdjust = new ReactiveValue<int> ();
		public readonly CalculatedReactiveValue<int> TempModifier = new CalculatedReactiveValue<int> ();

		public Stat (StatType type)
		{
			this.Type = type;

			this.Score.Select (s => (s - 10) / 2).Subscribe (this.Modifier);
			this.Score.Zip (this.TempAdjust, (s, t) => (s + t - 10) / 2).Subscribe (this.TempModifier);
		}
	}

	public class Stats
	{
		public readonly Stat Strength = new Stat (StatType.Strength);
		public readonly Stat Dexterity = new Stat (StatType.Dexterity);
		public readonly Stat Constitution = new Stat (StatType.Constitution);
		public readonly Stat Intelligence = new Stat (StatType.Intelligence);
		public readonly Stat Wisdom = new Stat (StatType.Wisdom);
		public readonly Stat Charisma = new Stat (StatType.Charisma);
	}
}

