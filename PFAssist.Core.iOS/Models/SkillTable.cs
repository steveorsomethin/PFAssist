using System;
using System.Collections.Generic;
using System.Reactive.Linq;

namespace PFAssist.Core
{
	// Generated via a script
	public enum SkillType
	{
		Acrobatics,
		Appraise,
		Bluff,
		Climb,
		Craft1,
		Craft2,
		Craft3,
		Diplomacy,
		DisableDevice,
		Disguise,
		EscapeArtist,
		Fly,
		HandleAnimal,
		Heal,
		Intimidate,
		Arcana,
		Dungeoneering,
		Engineering,
		Geography,
		History,
		Local,
		Nature,
		Nobility,
		Planes,
		Religion,
		Linguistics,
		Perception,
		Perform1,
		Perform2,
		Profession1,
		Profession2,
		Ride,
		SenseMotive,
		SleightofHand,
		Spellcraft,
		Stealth,
		Survival,
		Swim,
		UseMagicDevice
	}

	public class Skill : Dictionary<CharacterClasses, bool>
	{
		public readonly SkillType SkillType;
		public readonly StatType StatType;
		public readonly bool Untrained;
		public readonly ReactiveValue<int> Ranks = new ReactiveValue<int> ();
		public readonly ReactiveValue<int> MiscellaneousModifier = new ReactiveValue<int> ();
		public readonly ReactiveValue<Stat> Stat = new ReactiveValue<Stat> ();
		public readonly CalculatedReactiveValue<int> AbilityModifier = new CalculatedReactiveValue<int> ();
		public readonly CalculatedReactiveValue<int> Trained = new CalculatedReactiveValue<int> ();
		public readonly CalculatedReactiveValue<int> Total = new CalculatedReactiveValue<int> ();
		public readonly CalculatedReactiveValue<bool> IsActive = new CalculatedReactiveValue<bool> ();
		public readonly CalculatedReactiveValue<CharacterClasses> Class1 = new CalculatedReactiveValue<CharacterClasses> ();
		public readonly CalculatedReactiveValue<CharacterClasses> Class2 = new CalculatedReactiveValue<CharacterClasses> ();
		public readonly CalculatedReactiveValue<CharacterClasses> Class3 = new CalculatedReactiveValue<CharacterClasses> ();

		public Skill (SkillType skillType, StatType statType, bool untrained, params CharacterClasses[] classes)
		{
			SkillType = skillType;
			StatType = statType;
			Untrained = untrained;

			foreach (var c in classes) {
				this [c] = true;
			}

			Observable.CombineLatest (
				Class1,
				Class2,
				Class3,
				Ranks,
				(c1, c2, c3, r) => this [c1] || this [c2] || this [c3])
				.Subscribe (IsActive);

			Ranks.Select (r => {
				if ((r > 0 || untrained) && Stat.Value != null) {
					var stat = Stat.Value;
					return stat.TempModifier.Value > 0 ? stat.TempModifier.Value : stat.Modifier.Value;
				}

				return 0;
			})
			.Subscribe (AbilityModifier);

			Observable.CombineLatest (IsActive, Ranks, (ia, r) => r > 0 && ia ? 3 : 0).Subscribe (Trained);

			Observable.CombineLatest (
				Ranks,
				MiscellaneousModifier,
				AbilityModifier,
				Trained,
				IsActive,
				(r, m, a, t, ia) => ia ? r + m + a + t : 0)
				.Subscribe (Total);
		}

		public new bool this [CharacterClasses key] {
			get {
				bool result;
				return this.TryGetValue (key, out result) ? result : false;
			}
			set { this.Add (key, value); }
		}
	}

	public class SkillTable : Dictionary<SkillType, Skill>
	{
		public readonly CalculatedReactiveValue<CharacterClasses> Class1 = new CalculatedReactiveValue<CharacterClasses> ();
		public readonly CalculatedReactiveValue<CharacterClasses> Class2 = new CalculatedReactiveValue<CharacterClasses> ();
		public readonly CalculatedReactiveValue<CharacterClasses> Class3 = new CalculatedReactiveValue<CharacterClasses> ();
		private readonly Stats Stats;

		private void Initialize ()
		{
			foreach (var pair in this) {
				var skill = pair.Value;
				var stat = Stats.Lookup [skill.StatType];

				skill.Stat.Value = stat;

				Observable.CombineLatest (
					stat.Modifier,
					stat.TempModifier,
					(m, t) => t > 0 ? t : m)
					.Subscribe (skill.AbilityModifier);

				Class1.Subscribe (skill.Class1);
				Class2.Subscribe (skill.Class2);
				Class3.Subscribe (skill.Class3);
			}
		}

		public SkillTable (Stats stats)
		{
			this.Stats = stats;

			// Generated via a script
			this [SkillType.Acrobatics] = new Skill (SkillType.Acrobatics, StatType.Dexterity, true,
				CharacterClasses.Barbarian,
				CharacterClasses.Bard,
				CharacterClasses.Gunslinger,
				CharacterClasses.Monk,
				CharacterClasses.Rogue);

			this [SkillType.Appraise] = new Skill (SkillType.Appraise, StatType.Intelligence, true,
				CharacterClasses.Alchemist,
				CharacterClasses.Bard,
				CharacterClasses.Cleric,
				CharacterClasses.Rogue,
				CharacterClasses.Sorcerer,
				CharacterClasses.Wizard);

			this [SkillType.Bluff] = new Skill (SkillType.Bluff, StatType.Charisma, true,
				CharacterClasses.Antipaladin,
				CharacterClasses.Bard,
				CharacterClasses.Cavalier,
				CharacterClasses.Gunslinger,
				CharacterClasses.Inquisitor,
				CharacterClasses.Rogue,
				CharacterClasses.Sorcerer);

			this [SkillType.Climb] = new Skill (SkillType.Climb, StatType.Strength, true,
				CharacterClasses.Barbarian,
				CharacterClasses.Bard,
				CharacterClasses.Cavalier,
				CharacterClasses.Druid,
				CharacterClasses.Fighter,
				CharacterClasses.Gunslinger,
				CharacterClasses.Inquisitor,
				CharacterClasses.Magus,
				CharacterClasses.Monk,
				CharacterClasses.Ranger,
				CharacterClasses.Rogue);

			this [SkillType.Craft1] = new Skill (SkillType.Craft1, StatType.Intelligence, true,
				CharacterClasses.Alchemist,
				CharacterClasses.Antipaladin,
				CharacterClasses.Barbarian,
				CharacterClasses.Bard,
				CharacterClasses.Cavalier,
				CharacterClasses.Cleric,
				CharacterClasses.Druid,
				CharacterClasses.Fighter,
				CharacterClasses.Gunslinger,
				CharacterClasses.Inquisitor,
				CharacterClasses.Magus,
				CharacterClasses.Monk,
				CharacterClasses.Oracle,
				CharacterClasses.Paladin,
				CharacterClasses.Ranger,
				CharacterClasses.Rogue,
				CharacterClasses.Sorcerer,
				CharacterClasses.Summoner,
				CharacterClasses.Witch,
				CharacterClasses.Wizard);

			this [SkillType.Craft2] = new Skill (SkillType.Craft2, StatType.Intelligence, true,
				CharacterClasses.Alchemist,
				CharacterClasses.Antipaladin,
				CharacterClasses.Barbarian,
				CharacterClasses.Bard,
				CharacterClasses.Cavalier,
				CharacterClasses.Cleric,
				CharacterClasses.Druid,
				CharacterClasses.Fighter,
				CharacterClasses.Gunslinger,
				CharacterClasses.Inquisitor,
				CharacterClasses.Magus,
				CharacterClasses.Monk,
				CharacterClasses.Oracle,
				CharacterClasses.Paladin,
				CharacterClasses.Ranger,
				CharacterClasses.Rogue,
				CharacterClasses.Sorcerer,
				CharacterClasses.Summoner,
				CharacterClasses.Witch,
				CharacterClasses.Wizard);

			this [SkillType.Craft3] = new Skill (SkillType.Craft3, StatType.Intelligence, true,
				CharacterClasses.Alchemist,
				CharacterClasses.Antipaladin,
				CharacterClasses.Barbarian,
				CharacterClasses.Bard,
				CharacterClasses.Cavalier,
				CharacterClasses.Cleric,
				CharacterClasses.Druid,
				CharacterClasses.Fighter,
				CharacterClasses.Gunslinger,
				CharacterClasses.Inquisitor,
				CharacterClasses.Magus,
				CharacterClasses.Monk,
				CharacterClasses.Oracle,
				CharacterClasses.Paladin,
				CharacterClasses.Ranger,
				CharacterClasses.Rogue,
				CharacterClasses.Sorcerer,
				CharacterClasses.Summoner,
				CharacterClasses.Witch,
				CharacterClasses.Wizard);

			this [SkillType.Diplomacy] = new Skill (SkillType.Diplomacy, StatType.Charisma, true,
				CharacterClasses.Bard,
				CharacterClasses.Cavalier,
				CharacterClasses.Cleric,
				CharacterClasses.Inquisitor,
				CharacterClasses.Oracle,
				CharacterClasses.Paladin,
				CharacterClasses.Rogue);

			this [SkillType.DisableDevice] = new Skill (SkillType.DisableDevice, StatType.Dexterity, false,
				CharacterClasses.Alchemist,
				CharacterClasses.Rogue);

			this [SkillType.Disguise] = new Skill (SkillType.Disguise, StatType.Charisma, true,
				CharacterClasses.Antipaladin,
				CharacterClasses.Bard,
				CharacterClasses.Inquisitor,
				CharacterClasses.Rogue);

			this [SkillType.EscapeArtist] = new Skill (SkillType.EscapeArtist, StatType.Dexterity, true,
				CharacterClasses.Bard,
				CharacterClasses.Monk,
				CharacterClasses.Rogue);

			this [SkillType.Fly] = new Skill (SkillType.Fly, StatType.Dexterity, true,
				CharacterClasses.Alchemist,
				CharacterClasses.Druid,
				CharacterClasses.Magus,
				CharacterClasses.Sorcerer,
				CharacterClasses.Summoner,
				CharacterClasses.Witch,
				CharacterClasses.Wizard);

			this [SkillType.HandleAnimal] = new Skill (SkillType.HandleAnimal, StatType.Charisma, false,
				CharacterClasses.Antipaladin,
				CharacterClasses.Barbarian,
				CharacterClasses.Cavalier,
				CharacterClasses.Druid,
				CharacterClasses.Fighter,
				CharacterClasses.Gunslinger,
				CharacterClasses.Paladin,
				CharacterClasses.Ranger,
				CharacterClasses.Summoner);

			this [SkillType.Heal] = new Skill (SkillType.Heal, StatType.Wisdom, true,
				CharacterClasses.Alchemist,
				CharacterClasses.Cleric,
				CharacterClasses.Druid,
				CharacterClasses.Gunslinger,
				CharacterClasses.Inquisitor,
				CharacterClasses.Oracle,
				CharacterClasses.Paladin,
				CharacterClasses.Ranger,
				CharacterClasses.Witch);

			this [SkillType.Intimidate] = new Skill (SkillType.Intimidate, StatType.Charisma, true,
				CharacterClasses.Antipaladin,
				CharacterClasses.Barbarian,
				CharacterClasses.Bard,
				CharacterClasses.Cavalier,
				CharacterClasses.Fighter,
				CharacterClasses.Gunslinger,
				CharacterClasses.Inquisitor,
				CharacterClasses.Magus,
				CharacterClasses.Monk,
				CharacterClasses.Ranger,
				CharacterClasses.Rogue,
				CharacterClasses.Sorcerer,
				CharacterClasses.Witch);

			this [SkillType.Arcana] = new Skill (SkillType.Arcana, StatType.Intelligence, false,
				CharacterClasses.Alchemist,
				CharacterClasses.Bard,
				CharacterClasses.Cleric,
				CharacterClasses.Inquisitor,
				CharacterClasses.Magus,
				CharacterClasses.Sorcerer,
				CharacterClasses.Witch,
				CharacterClasses.Wizard);

			this [SkillType.Dungeoneering] = new Skill (SkillType.Dungeoneering, StatType.Intelligence, false,
				CharacterClasses.Bard,
				CharacterClasses.Fighter,
				CharacterClasses.Inquisitor,
				CharacterClasses.Magus,
				CharacterClasses.Ranger,
				CharacterClasses.Rogue,
				CharacterClasses.Summoner,
				CharacterClasses.Wizard);

			this [SkillType.Engineering] = new Skill (SkillType.Engineering, StatType.Intelligence, false,
				CharacterClasses.Bard,
				CharacterClasses.Fighter,
				CharacterClasses.Gunslinger,
				CharacterClasses.Summoner,
				CharacterClasses.Wizard);

			this [SkillType.Geography] = new Skill (SkillType.Geography, StatType.Intelligence, false,
				CharacterClasses.Bard,
				CharacterClasses.Druid,
				CharacterClasses.Ranger,
				CharacterClasses.Summoner,
				CharacterClasses.Wizard);

			this [SkillType.History] = new Skill (SkillType.History, StatType.Intelligence, false,
				CharacterClasses.Bard,
				CharacterClasses.Cleric,
				CharacterClasses.Monk,
				CharacterClasses.Oracle,
				CharacterClasses.Summoner,
				CharacterClasses.Witch,
				CharacterClasses.Wizard);

			this [SkillType.Local] = new Skill (SkillType.Local, StatType.Intelligence, false,
				CharacterClasses.Bard,
				CharacterClasses.Gunslinger,
				CharacterClasses.Rogue,
				CharacterClasses.Summoner,
				CharacterClasses.Wizard);

			this [SkillType.Nature] = new Skill (SkillType.Nature, StatType.Intelligence, false,
				CharacterClasses.Barbarian,
				CharacterClasses.Bard,
				CharacterClasses.Druid,
				CharacterClasses.Inquisitor,
				CharacterClasses.Ranger,
				CharacterClasses.Summoner,
				CharacterClasses.Witch,
				CharacterClasses.Wizard);

			this [SkillType.Nobility] = new Skill (SkillType.Nobility, StatType.Intelligence, false,
				CharacterClasses.Bard,
				CharacterClasses.Cleric,
				CharacterClasses.Paladin,
				CharacterClasses.Summoner,
				CharacterClasses.Wizard);

			this [SkillType.Planes] = new Skill (SkillType.Planes, StatType.Intelligence, false,
				CharacterClasses.Bard,
				CharacterClasses.Cleric,
				CharacterClasses.Inquisitor,
				CharacterClasses.Magus,
				CharacterClasses.Oracle,
				CharacterClasses.Summoner,
				CharacterClasses.Witch,
				CharacterClasses.Wizard);

			this [SkillType.Religion] = new Skill (SkillType.Religion, StatType.Intelligence, false,
				CharacterClasses.Antipaladin,
				CharacterClasses.Bard,
				CharacterClasses.Cleric,
				CharacterClasses.Inquisitor,
				CharacterClasses.Monk,
				CharacterClasses.Oracle,
				CharacterClasses.Paladin,
				CharacterClasses.Summoner,
				CharacterClasses.Wizard);

			this [SkillType.Linguistics] = new Skill (SkillType.Linguistics, StatType.Intelligence, false,
				CharacterClasses.Bard,
				CharacterClasses.Cleric,
				CharacterClasses.Rogue,
				CharacterClasses.Summoner,
				CharacterClasses.Wizard);

			this [SkillType.Perception] = new Skill (SkillType.Perception, StatType.Wisdom, true,
				CharacterClasses.Alchemist,
				CharacterClasses.Barbarian,
				CharacterClasses.Bard,
				CharacterClasses.Druid,
				CharacterClasses.Gunslinger,
				CharacterClasses.Inquisitor,
				CharacterClasses.Monk,
				CharacterClasses.Ranger,
				CharacterClasses.Rogue);

			this [SkillType.Perform1] = new Skill (SkillType.Perform1, StatType.Charisma, true,
				CharacterClasses.Bard,
				CharacterClasses.Monk,
				CharacterClasses.Rogue);

			this [SkillType.Perform2] = new Skill (SkillType.Perform2, StatType.Charisma, true,
				CharacterClasses.Bard,
				CharacterClasses.Monk,
				CharacterClasses.Rogue);

			this [SkillType.Profession1] = new Skill (SkillType.Profession1, StatType.Wisdom, false,
				CharacterClasses.Alchemist,
				CharacterClasses.Antipaladin,
				CharacterClasses.Bard,
				CharacterClasses.Cavalier,
				CharacterClasses.Cleric,
				CharacterClasses.Druid,
				CharacterClasses.Fighter,
				CharacterClasses.Gunslinger,
				CharacterClasses.Inquisitor,
				CharacterClasses.Magus,
				CharacterClasses.Monk,
				CharacterClasses.Oracle,
				CharacterClasses.Paladin,
				CharacterClasses.Ranger,
				CharacterClasses.Rogue,
				CharacterClasses.Sorcerer,
				CharacterClasses.Summoner,
				CharacterClasses.Witch,
				CharacterClasses.Wizard);

			this [SkillType.Profession2] = new Skill (SkillType.Profession2, StatType.Wisdom, false,
				CharacterClasses.Alchemist,
				CharacterClasses.Antipaladin,
				CharacterClasses.Bard,
				CharacterClasses.Cavalier,
				CharacterClasses.Cleric,
				CharacterClasses.Druid,
				CharacterClasses.Fighter,
				CharacterClasses.Gunslinger,
				CharacterClasses.Inquisitor,
				CharacterClasses.Magus,
				CharacterClasses.Monk,
				CharacterClasses.Oracle,
				CharacterClasses.Paladin,
				CharacterClasses.Ranger,
				CharacterClasses.Rogue,
				CharacterClasses.Sorcerer,
				CharacterClasses.Summoner,
				CharacterClasses.Witch,
				CharacterClasses.Wizard);

			this [SkillType.Ride] = new Skill (SkillType.Ride, StatType.Dexterity, true,
				CharacterClasses.Antipaladin,
				CharacterClasses.Barbarian,
				CharacterClasses.Cavalier,
				CharacterClasses.Druid,
				CharacterClasses.Fighter,
				CharacterClasses.Gunslinger,
				CharacterClasses.Inquisitor,
				CharacterClasses.Magus,
				CharacterClasses.Monk,
				CharacterClasses.Paladin,
				CharacterClasses.Ranger,
				CharacterClasses.Summoner);

			this [SkillType.SenseMotive] = new Skill (SkillType.SenseMotive, StatType.Wisdom, true,
				CharacterClasses.Antipaladin,
				CharacterClasses.Bard,
				CharacterClasses.Cavalier,
				CharacterClasses.Cleric,
				CharacterClasses.Inquisitor,
				CharacterClasses.Monk,
				CharacterClasses.Oracle,
				CharacterClasses.Paladin,
				CharacterClasses.Rogue);

			this [SkillType.SleightofHand] = new Skill (SkillType.SleightofHand, StatType.Dexterity, false,
				CharacterClasses.Alchemist,
				CharacterClasses.Bard,
				CharacterClasses.Gunslinger,
				CharacterClasses.Rogue);

			this [SkillType.Spellcraft] = new Skill (SkillType.Spellcraft, StatType.Intelligence, false,
				CharacterClasses.Alchemist,
				CharacterClasses.Antipaladin,
				CharacterClasses.Bard,
				CharacterClasses.Cleric,
				CharacterClasses.Druid,
				CharacterClasses.Inquisitor,
				CharacterClasses.Magus,
				CharacterClasses.Oracle,
				CharacterClasses.Paladin,
				CharacterClasses.Ranger,
				CharacterClasses.Sorcerer,
				CharacterClasses.Summoner,
				CharacterClasses.Witch,
				CharacterClasses.Wizard);

			this [SkillType.Stealth] = new Skill (SkillType.Stealth, StatType.Dexterity, true,
				CharacterClasses.Antipaladin,
				CharacterClasses.Bard,
				CharacterClasses.Inquisitor,
				CharacterClasses.Monk,
				CharacterClasses.Ranger,
				CharacterClasses.Rogue);

			this [SkillType.Survival] = new Skill (SkillType.Survival, StatType.Wisdom, true,
				CharacterClasses.Alchemist,
				CharacterClasses.Barbarian,
				CharacterClasses.Druid,
				CharacterClasses.Fighter,
				CharacterClasses.Gunslinger,
				CharacterClasses.Inquisitor,
				CharacterClasses.Ranger);

			this [SkillType.Swim] = new Skill (SkillType.Swim, StatType.Strength, true,
				CharacterClasses.Barbarian,
				CharacterClasses.Cavalier,
				CharacterClasses.Druid,
				CharacterClasses.Fighter,
				CharacterClasses.Gunslinger,
				CharacterClasses.Inquisitor,
				CharacterClasses.Magus,
				CharacterClasses.Monk,
				CharacterClasses.Ranger,
				CharacterClasses.Rogue);

			this [SkillType.UseMagicDevice] = new Skill (SkillType.UseMagicDevice, StatType.Charisma, false,
				CharacterClasses.Alchemist,
				CharacterClasses.Bard,
				CharacterClasses.Magus,
				CharacterClasses.Rogue,
				CharacterClasses.Sorcerer,
				CharacterClasses.Summoner,
				CharacterClasses.Witch);

			this.Initialize ();
		}
	}
}

