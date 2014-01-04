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
		public StatType Type { get; set; }

		public ReactiveValue<int> Scores { get; set; }

		public CalculatedReactiveValue<int> Modifiers { get; set; }

		public ReactiveValue<int> TempAdjusts { get; set; }

		public CalculatedReactiveValue<int> TempModifiers { get; set; }

		public Stat (StatType type)
		{
			this.Type = type;
			this.Scores = new ReactiveValue<int> ();
			this.Modifiers = new CalculatedReactiveValue<int> ();
			this.TempAdjusts = new ReactiveValue<int> ();
			this.TempModifiers = new CalculatedReactiveValue<int> ();

			this.Initialize ();
		}

		private void Initialize ()
		{
			this.Scores.Select (s => (s - 10) / 2).Subscribe (this.Modifiers);
			this.Scores.Zip (this.TempAdjusts, (s, t) => (s + t - 10) / 2).Subscribe (this.TempModifiers);
		}
	}
}

