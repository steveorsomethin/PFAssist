using System;

namespace PFAssist.Core
{
	public class LevelInfo
	{
		public static readonly LevelInfo Default = new LevelInfo (0, 0, 0, 0, 0, 0, 0, 0);
		//TODO: Special, Spells per day, etc
		public readonly ReactiveValue<int> Level = new ReactiveValue<int> ();
		public readonly ReactiveValue<int> BaseAttack = new ReactiveValue<int> ();
		public readonly ReactiveValue<int> BaseAttack2 = new ReactiveValue<int> ();
		public readonly ReactiveValue<int> BaseAttack3 = new ReactiveValue<int> ();
		public readonly ReactiveValue<int> BaseAttack4 = new ReactiveValue<int> ();
		public readonly ReactiveValue<int> BaseFortitude = new ReactiveValue<int> ();
		public readonly ReactiveValue<int> BaseReflex = new ReactiveValue<int> ();
		public readonly ReactiveValue<int> BaseWill = new ReactiveValue<int> ();

		public LevelInfo (
			int level,
			int baseAttack,
			int baseAttack2,
			int baseAttack3,
			int baseAttack4,
			int baseFort,
			int baseRef,
			int baseWill)
		{
			Level.Value = level;
			BaseAttack.Value = baseAttack;
			BaseAttack2.Value = baseAttack2;
			BaseAttack3.Value = baseAttack3;
			BaseAttack4.Value = baseAttack4;
			BaseFortitude.Value = baseFort;
			BaseReflex.Value = baseRef;
			BaseWill.Value = baseWill;
		}
	}
}

