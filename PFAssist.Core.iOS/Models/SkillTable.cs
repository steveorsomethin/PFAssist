using System;
using System.Collections.Generic;

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

		public Skill (SkillType skillType, StatType statType, params CharacterClasses[] classes)
		{
			SkillType = skillType;
			StatType = statType;

			foreach (var c in classes) {
				this [c] = true;
			}
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
		public static SkillTable Table;

		static SkillTable ()
		{
			Table = new SkillTable ();
		}

		public SkillTable ()
		{
			// Generated via a script
			this [SkillType.Acrobatics] = new Skill (SkillType.Acrobatics, StatType.Dexterity,
				CharacterClasses.Barbarian,
				CharacterClasses.Bard,
				CharacterClasses.Gunslinger,
				CharacterClasses.Monk,
				CharacterClasses.Rogue);

			this [SkillType.Appraise] = new Skill (SkillType.Appraise, StatType.Intelligence,
				CharacterClasses.Alchemist,
				CharacterClasses.Bard,
				CharacterClasses.Cleric,
				CharacterClasses.Rogue,
				CharacterClasses.Sorcerer,
				CharacterClasses.Wizard);

			this [SkillType.Bluff] = new Skill (SkillType.Bluff, StatType.Charisma,
				CharacterClasses.Antipaladin,
				CharacterClasses.Bard,
				CharacterClasses.Cavalier,
				CharacterClasses.Gunslinger,
				CharacterClasses.Inquisitor,
				CharacterClasses.Rogue,
				CharacterClasses.Sorcerer);

			this [SkillType.Climb] = new Skill (SkillType.Climb, StatType.Strength,
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

			this [SkillType.Craft1] = new Skill (SkillType.Craft1, StatType.Intelligence,
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

			this [SkillType.Craft2] = new Skill (SkillType.Craft2, StatType.Intelligence,
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

			this [SkillType.Craft3] = new Skill (SkillType.Craft3, StatType.Intelligence,
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

			this [SkillType.Diplomacy] = new Skill (SkillType.Diplomacy, StatType.Charisma,
				CharacterClasses.Bard,
				CharacterClasses.Cavalier,
				CharacterClasses.Cleric,
				CharacterClasses.Inquisitor,
				CharacterClasses.Oracle,
				CharacterClasses.Paladin,
				CharacterClasses.Rogue);

			this [SkillType.DisableDevice] = new Skill (SkillType.DisableDevice, StatType.Dexterity,
				CharacterClasses.Alchemist,
				CharacterClasses.Rogue);

			this [SkillType.Disguise] = new Skill (SkillType.Disguise, StatType.Charisma,
				CharacterClasses.Antipaladin,
				CharacterClasses.Bard,
				CharacterClasses.Inquisitor,
				CharacterClasses.Rogue);

			this [SkillType.EscapeArtist] = new Skill (SkillType.EscapeArtist, StatType.Dexterity,
				CharacterClasses.Bard,
				CharacterClasses.Monk,
				CharacterClasses.Rogue);

			this [SkillType.Fly] = new Skill (SkillType.Fly, StatType.Dexterity,
				CharacterClasses.Alchemist,
				CharacterClasses.Druid,
				CharacterClasses.Magus,
				CharacterClasses.Sorcerer,
				CharacterClasses.Summoner,
				CharacterClasses.Witch,
				CharacterClasses.Wizard);

			this [SkillType.HandleAnimal] = new Skill (SkillType.HandleAnimal, StatType.Charisma,
				CharacterClasses.Antipaladin,
				CharacterClasses.Barbarian,
				CharacterClasses.Cavalier,
				CharacterClasses.Druid,
				CharacterClasses.Fighter,
				CharacterClasses.Gunslinger,
				CharacterClasses.Paladin,
				CharacterClasses.Ranger,
				CharacterClasses.Summoner);

			this [SkillType.Heal] = new Skill (SkillType.Heal, StatType.Wisdom,
				CharacterClasses.Alchemist,
				CharacterClasses.Cleric,
				CharacterClasses.Druid,
				CharacterClasses.Gunslinger,
				CharacterClasses.Inquisitor,
				CharacterClasses.Oracle,
				CharacterClasses.Paladin,
				CharacterClasses.Ranger,
				CharacterClasses.Witch);

			this [SkillType.Intimidate] = new Skill (SkillType.Intimidate, StatType.Charisma,
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

			this [SkillType.Arcana] = new Skill (SkillType.Arcana, StatType.Intelligence,
				CharacterClasses.Alchemist,
				CharacterClasses.Bard,
				CharacterClasses.Cleric,
				CharacterClasses.Inquisitor,
				CharacterClasses.Magus,
				CharacterClasses.Sorcerer,
				CharacterClasses.Witch,
				CharacterClasses.Wizard);

			this [SkillType.Dungeoneering] = new Skill (SkillType.Dungeoneering, StatType.Intelligence,
				CharacterClasses.Bard,
				CharacterClasses.Fighter,
				CharacterClasses.Inquisitor,
				CharacterClasses.Magus,
				CharacterClasses.Ranger,
				CharacterClasses.Rogue,
				CharacterClasses.Summoner,
				CharacterClasses.Wizard);

			this [SkillType.Engineering] = new Skill (SkillType.Engineering, StatType.Intelligence,
				CharacterClasses.Bard,
				CharacterClasses.Fighter,
				CharacterClasses.Gunslinger,
				CharacterClasses.Summoner,
				CharacterClasses.Wizard);

			this [SkillType.Geography] = new Skill (SkillType.Geography, StatType.Intelligence,
				CharacterClasses.Bard,
				CharacterClasses.Druid,
				CharacterClasses.Ranger,
				CharacterClasses.Summoner,
				CharacterClasses.Wizard);

			this [SkillType.History] = new Skill (SkillType.History, StatType.Intelligence,
				CharacterClasses.Bard,
				CharacterClasses.Cleric,
				CharacterClasses.Monk,
				CharacterClasses.Oracle,
				CharacterClasses.Summoner,
				CharacterClasses.Witch,
				CharacterClasses.Wizard);

			this [SkillType.Local] = new Skill (SkillType.Local, StatType.Intelligence,
				CharacterClasses.Bard,
				CharacterClasses.Gunslinger,
				CharacterClasses.Rogue,
				CharacterClasses.Summoner,
				CharacterClasses.Wizard);

			this [SkillType.Nature] = new Skill (SkillType.Nature, StatType.Intelligence,
				CharacterClasses.Barbarian,
				CharacterClasses.Bard,
				CharacterClasses.Druid,
				CharacterClasses.Inquisitor,
				CharacterClasses.Ranger,
				CharacterClasses.Summoner,
				CharacterClasses.Witch,
				CharacterClasses.Wizard);

			this [SkillType.Nobility] = new Skill (SkillType.Nobility, StatType.Intelligence,
				CharacterClasses.Bard,
				CharacterClasses.Cleric,
				CharacterClasses.Paladin,
				CharacterClasses.Summoner,
				CharacterClasses.Wizard);

			this [SkillType.Planes] = new Skill (SkillType.Planes, StatType.Intelligence,
				CharacterClasses.Bard,
				CharacterClasses.Cleric,
				CharacterClasses.Inquisitor,
				CharacterClasses.Magus,
				CharacterClasses.Oracle,
				CharacterClasses.Summoner,
				CharacterClasses.Witch,
				CharacterClasses.Wizard);

			this [SkillType.Religion] = new Skill (SkillType.Religion, StatType.Intelligence,
				CharacterClasses.Antipaladin,
				CharacterClasses.Bard,
				CharacterClasses.Cleric,
				CharacterClasses.Inquisitor,
				CharacterClasses.Monk,
				CharacterClasses.Oracle,
				CharacterClasses.Paladin,
				CharacterClasses.Summoner,
				CharacterClasses.Wizard);

			this [SkillType.Linguistics] = new Skill (SkillType.Linguistics, StatType.Intelligence,
				CharacterClasses.Bard,
				CharacterClasses.Cleric,
				CharacterClasses.Rogue,
				CharacterClasses.Summoner,
				CharacterClasses.Wizard);

			this [SkillType.Perception] = new Skill (SkillType.Perception, StatType.Wisdom,
				CharacterClasses.Alchemist,
				CharacterClasses.Barbarian,
				CharacterClasses.Bard,
				CharacterClasses.Druid,
				CharacterClasses.Gunslinger,
				CharacterClasses.Inquisitor,
				CharacterClasses.Monk,
				CharacterClasses.Ranger,
				CharacterClasses.Rogue);

			this [SkillType.Perform1] = new Skill (SkillType.Perform1, StatType.Charisma,
				CharacterClasses.Bard,
				CharacterClasses.Monk,
				CharacterClasses.Rogue);

			this [SkillType.Perform2] = new Skill (SkillType.Perform2, StatType.Charisma,
				CharacterClasses.Bard,
				CharacterClasses.Monk,
				CharacterClasses.Rogue);

			this [SkillType.Profession1] = new Skill (SkillType.Profession1, StatType.Wisdom,
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

			this [SkillType.Profession2] = new Skill (SkillType.Profession2, StatType.Wisdom,
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

			this [SkillType.Ride] = new Skill (SkillType.Ride, StatType.Dexterity,
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

			this [SkillType.SenseMotive] = new Skill (SkillType.SenseMotive, StatType.Wisdom,
				CharacterClasses.Antipaladin,
				CharacterClasses.Bard,
				CharacterClasses.Cavalier,
				CharacterClasses.Cleric,
				CharacterClasses.Inquisitor,
				CharacterClasses.Monk,
				CharacterClasses.Oracle,
				CharacterClasses.Paladin,
				CharacterClasses.Rogue);

			this [SkillType.SleightofHand] = new Skill (SkillType.SleightofHand, StatType.Dexterity,
				CharacterClasses.Alchemist,
				CharacterClasses.Bard,
				CharacterClasses.Gunslinger,
				CharacterClasses.Rogue);

			this [SkillType.Spellcraft] = new Skill (SkillType.Spellcraft, StatType.Intelligence,
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

			this [SkillType.Stealth] = new Skill (SkillType.Stealth, StatType.Dexterity,
				CharacterClasses.Antipaladin,
				CharacterClasses.Bard,
				CharacterClasses.Inquisitor,
				CharacterClasses.Monk,
				CharacterClasses.Ranger,
				CharacterClasses.Rogue);

			this [SkillType.Survival] = new Skill (SkillType.Survival, StatType.Wisdom,
				CharacterClasses.Alchemist,
				CharacterClasses.Barbarian,
				CharacterClasses.Druid,
				CharacterClasses.Fighter,
				CharacterClasses.Gunslinger,
				CharacterClasses.Inquisitor,
				CharacterClasses.Ranger);

			this [SkillType.Swim] = new Skill (SkillType.Swim, StatType.Strength,
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

			this [SkillType.UseMagicDevice] = new Skill (SkillType.UseMagicDevice, StatType.Charisma,
				CharacterClasses.Alchemist,
				CharacterClasses.Bard,
				CharacterClasses.Magus,
				CharacterClasses.Rogue,
				CharacterClasses.Sorcerer,
				CharacterClasses.Summoner,
				CharacterClasses.Witch);
		}
	}
}

