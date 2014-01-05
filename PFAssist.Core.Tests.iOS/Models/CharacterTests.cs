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

			character.PrimaryStats.Dexterity.Modifier.OverrideWith(15);

			Assert.AreEqual (acDex.Value, 15);
		}

		[Test]
		public void DexChangesAffectInitiative ()
		{
			var character = new Character ();
			var initDex = character.Initiative.Dexterity;

			character.PrimaryStats.Dexterity.Modifier.OverrideWith(15);

			Assert.AreEqual (initDex.Value, 15);
		}

		[Test]
		public void WisdomAffectsMonkArmorClass ()
		{
			var character = new Character ();
			var acMisc = character.ArmorClass.Miscellaneous;

			character.Class1.Value = CharacterClasses.Monk;

			character.PrimaryStats.Wisdom.Modifier.OverrideWith(15);

			Assert.AreEqual (acMisc.Value, 15);
		}

		[Test]
		public void WisdomDoesntAffectOtherArmorClass ()
		{
			var character = new Character ();
			var acMisc = character.ArmorClass.Miscellaneous;

			character.PrimaryStats.Wisdom.Modifier.OverrideWith(15);

			Assert.AreNotEqual (acMisc.Value, 15);
		}
	}
}
