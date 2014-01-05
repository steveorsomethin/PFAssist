using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Collections.Generic;

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
			Type = type;

			Score.Select (s => (s - 10) / 2).Subscribe (Modifier);
			Score.Zip (TempAdjust, (s, t) => (s + t - 10) / 2).Subscribe (TempModifier);
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
		public readonly Dictionary<StatType, Stat> Lookup = new Dictionary<StatType, Stat> ();

		public Stats ()
		{
			Lookup [StatType.Strength] = Strength;
			Lookup [StatType.Dexterity] = Dexterity;
			Lookup [StatType.Constitution] = Constitution;
			Lookup [StatType.Intelligence] = Intelligence;
			Lookup [StatType.Wisdom] = Wisdom;
			Lookup [StatType.Charisma] = Charisma;
		}
	}
}

