using System;
using System.Reactive.Linq;

namespace PFAssist.Core
{
	public enum SaveType
	{
		Fortitude,
		Reflex,
		Will
	}

	public class Save
	{
		public SaveType Type { get; protected set; }

		public readonly ReactiveValue<int> MagicModifier = new ReactiveValue<int> ();
		public readonly ReactiveValue<int> MiscellaneousModifier = new ReactiveValue<int> ();
		public readonly ReactiveValue<int> TempModifier = new ReactiveValue<int> ();
		public readonly CalculatedReactiveValue<int> BaseModifier = new CalculatedReactiveValue<int> ();
		public readonly CalculatedReactiveValue<int> AbilityModifier = new CalculatedReactiveValue<int> ();
		public readonly CalculatedReactiveValue<int> Total = new CalculatedReactiveValue<int> ();

		public Save (SaveType type)
		{
			Type = type;

			Observable.CombineLatest (
				MagicModifier,
				MiscellaneousModifier,
				TempModifier,
				BaseModifier,
				AbilityModifier,
				(m, mm, t, b, a) => m + mm + t + b + a)
				.Subscribe (Total);
		}
	}

	public class Saves
	{
		public readonly Save Fortitude = new Save (SaveType.Fortitude);
		public readonly Save Reflex = new Save (SaveType.Reflex);
		public readonly Save Will = new Save (SaveType.Will);
	}
}

