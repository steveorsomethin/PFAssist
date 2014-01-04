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

		public BehaviorSubject<int> Scores { get; set; }

		public BehaviorSubject<int> Modifiers { get; set; }

		public BehaviorSubject<int> TempAdjusts { get; set; }

		public BehaviorSubject<int> TempModifiers { get; set; }

		public Stat (StatType type)
		{
			this.Type = type;
			this.Scores = new BehaviorSubject<int> (0);
			this.Modifiers = new BehaviorSubject<int> (0);
			this.TempAdjusts = new BehaviorSubject<int> (0);
			this.TempModifiers = new BehaviorSubject<int> (0);

			this.Initialize ();
		}

		private void Initialize ()
		{
			this.Scores.Select (s => (s - 10) / 2).Subscribe (this.Modifiers);
			this.Scores.Zip (this.TempAdjusts, (s, t) => (s + t - 10) / 2).Subscribe (this.TempModifiers);
		}
	}
}

