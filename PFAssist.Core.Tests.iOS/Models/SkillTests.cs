using System;
using NUnit.Framework;

namespace PFAssist.Core.Tests.iOS
{
	[TestFixture]
	public class SkillTests
	{
		[Test]
		public void ClassesAffectIsActive ()
		{
			var skill = new Skill (SkillType.Acrobatics, StatType.Dexterity, true, CharacterClasses.Monk);

			skill.Ranks.Value = 5;

			Assert.False (skill.IsActive.Value);

			skill.Class1.OverrideWith (CharacterClasses.Monk);

			Assert.True (skill.IsActive.Value);

			skill.Class1.OverrideWith (CharacterClasses.Alchemist);

			Assert.False (skill.IsActive.Value);
		}

		[Test]
		public void SourcesAffectTotal ()
		{
			var skill = new Skill (SkillType.Acrobatics, StatType.Dexterity, true, CharacterClasses.Monk);

			skill.Class1.OverrideWith (CharacterClasses.Monk);
			skill.Ranks.Value = 5;

			Assert.AreEqual (skill.Total.Value, 8);

			skill.AbilityModifier.OverrideWith (3);

			Assert.AreEqual (skill.Total.Value, 11);

			skill.MiscellaneousModifier.Value = 5;

			Assert.AreEqual (skill.Total.Value, 16);
		}

		[Test]
		public void UntrainedAffectsTotal ()
		{
			var skill = new Skill (SkillType.Acrobatics, StatType.Dexterity, false, CharacterClasses.Monk);
			var stat = new Stat (StatType.Dexterity);

			stat.Score.Value = 15;
			stat.TempAdjust.Value = 1;

			skill.Stat.Value = stat;

			skill.Class1.OverrideWith (CharacterClasses.Monk);

			Assert.AreEqual (skill.Total.Value, 0);

			skill.MiscellaneousModifier.Value = 5;

			Assert.AreEqual (skill.Total.Value, 5);

			skill.Ranks.Value = 5;

			Assert.AreEqual (skill.Total.Value, 16);
		}
	}
}
