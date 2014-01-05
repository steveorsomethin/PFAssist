using System;
using System.Reactive.Linq;
using System.Collections.Generic;

namespace PFAssist.Core
{
	public enum Sizes
	{
		Colossal = -8,
		Gargantuan = -4,
		Huge = -2,
		Large = -1,
		Medium = 0,
		Small = 1,
		Tiny = 2,
		Diminutive = 4,
		Fine = 8
	}

	public enum CharacterClasses
	{
		None,
		Alchemist,
		Antipaladin,
		Barbarian,
		Bard,
		Cavalier,
		Cleric,
		Druid,
		Fighter,
		Gunslinger,
		Inquisitor,
		Magus,
		Monk,
		Oracle,
		Paladin,
		Ranger,
		Rogue,
		Sorcerer,
		Summoner,
		Witch,
		Wizard
	}

	public enum Alignments
	{
		// TODO: Fill this out
		Neutral
	}

	public enum Races
	{
		// TODO: Fill this out
		Human
	}

	public enum Deities
	{
		// TODO: Fill this out
		Dickus
	}

	public enum Genders
	{
		Male,
		Female,
		Other
	}

	public class Character
	{
		// Fluff fields
		public readonly ReactiveValue<String> Name = new ReactiveValue<String> ();
		public readonly ReactiveValue<Alignments> Alignment = new ReactiveValue<Alignments> ();
		public readonly ReactiveValue<Races> Race = new ReactiveValue<Races> ();
		public readonly ReactiveValue<Deities> Deity = new ReactiveValue<Deities> ();
		public readonly ReactiveValue<String> Player = new ReactiveValue<String> ();
		public readonly ReactiveValue<Genders> Gender = new ReactiveValue<Genders> ();
		public readonly ReactiveValue<int> Age = new ReactiveValue<int> ();
		public readonly ReactiveValue<int> Height = new ReactiveValue<int> ();
		public readonly ReactiveValue<int> Weight = new ReactiveValue<int> ();
		public readonly ReactiveValue<String> Hair = new ReactiveValue<String> ();
		public readonly ReactiveValue<String> Eyes = new ReactiveValue<String> ();
		public readonly ReactiveValue<String> Homeland = new ReactiveValue<String> ();
		// Fields that affect downstream values
		public readonly ReactiveValue<Sizes> Size = new ReactiveValue<Sizes> ();
		public readonly ReactiveValue<CharacterClasses> Class1 = new ReactiveValue<CharacterClasses> ();
		public readonly ReactiveValue<int> Level1 = new ReactiveValue<int> ();
		public readonly ReactiveValue<LevelInfo> LevelInfo1 = new ReactiveValue<LevelInfo> ();
		public readonly ReactiveValue<CharacterClasses> Class2 = new ReactiveValue<CharacterClasses> ();
		public readonly ReactiveValue<int> Level2 = new ReactiveValue<int> ();
		public readonly ReactiveValue<LevelInfo> LevelInfo2 = new ReactiveValue<LevelInfo> ();
		public readonly ReactiveValue<CharacterClasses> Class3 = new ReactiveValue<CharacterClasses> ();
		public readonly ReactiveValue<int> Level3 = new ReactiveValue<int> ();
		public readonly ReactiveValue<LevelInfo> LevelInfo3 = new ReactiveValue<LevelInfo> ();
		// Composed bits
		public readonly Stats PrimaryStats = new Stats ();
		public readonly Saves Saves = new Saves ();
		public readonly ArmorClass ArmorClass = new ArmorClass ();
		public readonly Initiative Initiative = new Initiative ();

		public Character ()
		{
			// Armor class/Initiative
			Size.Select (s => (int)s).Subscribe (ArmorClass.Size);

			PrimaryStats.Dexterity.Modifier.Subscribe (ArmorClass.Dexterity);
			PrimaryStats.Dexterity.Modifier.Subscribe (Initiative.Dexterity);

			PrimaryStats.Constitution.Modifier.Subscribe (Saves.Fortitude.AbilityModifier);
			PrimaryStats.Dexterity.Modifier.Subscribe (Saves.Reflex.AbilityModifier);
			PrimaryStats.Wisdom.Modifier.Subscribe (Saves.Will.AbilityModifier);

			Observable.CombineLatest (
				PrimaryStats.Wisdom.Modifier,
				Class1,
				Class2,
				Class3,
				(w, c1, c2, c3) => {
					var monk = CharacterClasses.Monk;

					return c1 == monk || c2 == monk || c3 == monk ? w : 0;
				})
				.Subscribe (ArmorClass.Miscellaneous);

			Func<CharacterClasses, int, LevelInfo> levelInfoSelector = (c, l) => {
				ClassTable classTable;
				if (ClassTables.Tables.TryGetValue (c, out classTable)) {
					LevelInfo levelInfo;
					if (classTable.TryGetValue (l, out levelInfo)) {
						return levelInfo;
					}
				}

				return LevelInfo.Default;
			};

			//Level info
			Observable.CombineLatest (Class1, Level1, levelInfoSelector).Subscribe (LevelInfo1);
			Observable.CombineLatest (Class2, Level2, levelInfoSelector).Subscribe (LevelInfo2);
			Observable.CombineLatest (Class3, Level3, levelInfoSelector).Subscribe (LevelInfo3);

			// Saves
			Observable.CombineLatest (
				LevelInfo1.SelectMany (l => l.BaseFortitude),
				LevelInfo2.SelectMany (l => l.BaseFortitude),
				LevelInfo3.SelectMany (l => l.BaseFortitude),
				(f1, f2, f3) => f1 + f2 + f3)
				.Subscribe (Saves.Fortitude.BaseModifier);

			Observable.CombineLatest (
				LevelInfo1.SelectMany (l => l.BaseReflex),
				LevelInfo2.SelectMany (l => l.BaseReflex),
				LevelInfo3.SelectMany (l => l.BaseReflex),
				(r1, r2, r3) => r1 + r2 + r3)
				.Subscribe (Saves.Reflex.BaseModifier);

			Observable.CombineLatest (
				LevelInfo1.SelectMany (l => l.BaseWill),
				LevelInfo2.SelectMany (l => l.BaseWill),
				LevelInfo3.SelectMany (l => l.BaseWill),
				(w1, w2, w3) => w1 + w2 + w3)
				.Subscribe (Saves.Will.BaseModifier);
		}
	}
}

