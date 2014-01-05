using System;
using NUnit.Framework;

namespace PFAssist.Core.Tests.iOS
{
	[TestFixture]
	public class CharacterTests
	{
		[Test]
		public void DexChangesAffectArmorClass ()
		{
			var character = new Character ();
			var acDex = character.ArmorClass.Dexterity;

			character.PrimaryStats.Dexterity.Modifier.OverrideWith (15);

			Assert.AreEqual (acDex.Value, 15);
		}

		[Test]
		public void DexChangesAffectInitiative ()
		{
			var character = new Character ();
			var initDex = character.Initiative.Dexterity;

			character.PrimaryStats.Dexterity.Modifier.OverrideWith (15);

			Assert.AreEqual (initDex.Value, 15);
		}

		[Test]
		public void WisdomAffectsMonkArmorClass ()
		{
			var character = new Character ();
			var acMisc = character.ArmorClass.Miscellaneous;

			character.Class1.Value = CharacterClasses.Monk;

			character.PrimaryStats.Wisdom.Modifier.OverrideWith (15);

			Assert.AreEqual (acMisc.Value, 15);
		}

		[Test]
		public void WisdomDoesntAffectOtherArmorClass ()
		{
			var character = new Character ();
			var acMisc = character.ArmorClass.Miscellaneous;

			character.PrimaryStats.Wisdom.Modifier.OverrideWith (15);

			Assert.AreNotEqual (acMisc.Value, 15);
		}

		[Test]
		public void ClassesAffectBaseFortitude ()
		{
			var character = new Character ();

			character.Class1.Value = CharacterClasses.Monk;
			character.Level1.Value = 5;

			Assert.AreEqual (character.Saves.Fortitude.BaseModifier.Value, 4);

			character.Class2.Value = CharacterClasses.Alchemist;
			character.Level2.Value = 5;

			Assert.AreEqual (character.Saves.Fortitude.BaseModifier.Value, 8);

			character.Class3.Value = CharacterClasses.Antipaladin;
			character.Level3.Value = 5;

			Assert.AreEqual (character.Saves.Fortitude.BaseModifier.Value, 12);
		}

		[Test]
		public void ClassesAffectBaseReflex ()
		{
			var character = new Character ();

			character.Class1.Value = CharacterClasses.Monk;
			character.Level1.Value = 5;

			Assert.AreEqual (character.Saves.Reflex.BaseModifier.Value, 4);

			character.Class2.Value = CharacterClasses.Alchemist;
			character.Level2.Value = 5;

			Assert.AreEqual (character.Saves.Reflex.BaseModifier.Value, 8);

			character.Class3.Value = CharacterClasses.Antipaladin;
			character.Level3.Value = 5;

			Assert.AreEqual (character.Saves.Reflex.BaseModifier.Value, 9);
		}

		[Test]
		public void ClassesAffectBaseWill ()
		{
			var character = new Character ();

			character.Class1.Value = CharacterClasses.Monk;
			character.Level1.Value = 5;

			Assert.AreEqual (character.Saves.Will.BaseModifier.Value, 4);

			character.Class2.Value = CharacterClasses.Alchemist;
			character.Level2.Value = 5;

			Assert.AreEqual (character.Saves.Will.BaseModifier.Value, 5);

			character.Class3.Value = CharacterClasses.Antipaladin;
			character.Level3.Value = 5;

			Assert.AreEqual (character.Saves.Will.BaseModifier.Value, 9);
		}

		[Test]
		public void ClassesAffectAttackBonus ()
		{
			var character = new Character ();

			character.Class1.Value = CharacterClasses.Monk;
			character.Level1.Value = 5;

			Assert.AreEqual (character.AttackBonus.One.Value, 3);

			character.Class2.Value = CharacterClasses.Alchemist;
			character.Level2.Value = 5;

			Assert.AreEqual (character.AttackBonus.One.Value, 6);
			Assert.AreEqual (character.AttackBonus.Two.Value, 1);

			character.Class3.Value = CharacterClasses.Antipaladin;
			character.Level3.Value = 5;

			Assert.AreEqual (character.AttackBonus.One.Value, 11);
			Assert.AreEqual (character.AttackBonus.Two.Value, 6);
			Assert.AreEqual (character.AttackBonus.Three.Value, 1);
			Assert.AreEqual (character.AttackBonus.Four.Value, 0);
		}
	}
}
