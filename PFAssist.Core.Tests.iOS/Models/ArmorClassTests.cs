using System;
using NUnit.Framework;

namespace PFAssist.Core.Tests.iOS
{
	[TestFixture]
	public class ArmorClassTests
	{
		[Test]
		public void FieldsSumFlatFootedTotalCorrectly ()
		{
			var ac = new ArmorClass ();

			Assert.AreEqual (ac.FlatFootedTotal.Value, 10);

			ac.Armor.Value = 5;

			Assert.AreEqual (ac.FlatFootedTotal.Value, 15);

			ac.Shield.Value = 5;

			Assert.AreEqual (ac.FlatFootedTotal.Value, 20);

			ac.Deflection.Value = 5;

			Assert.AreEqual (ac.FlatFootedTotal.Value, 25);

			ac.Size.OverrideWith (5);

			Assert.AreEqual (ac.FlatFootedTotal.Value, 30);

			ac.NaturalArmor.Value = 5;

			Assert.AreEqual (ac.FlatFootedTotal.Value, 35);

			ac.Miscellaneous.Value = 5;

			Assert.AreEqual (ac.FlatFootedTotal.Value, 40);
		}

		[Test]
		public void FieldsSumTouchTotalCorrectly ()
		{
			var ac = new ArmorClass ();

			Assert.AreEqual (ac.TouchTotal.Value, 10);

			ac.Deflection.Value = 5;

			Assert.AreEqual (ac.TouchTotal.Value, 15);

			ac.Stats.OverrideWith (5);

			Assert.AreEqual (ac.TouchTotal.Value, 20);

			ac.Miscellaneous.Value = 5;

			Assert.AreEqual (ac.TouchTotal.Value, 25);
		}

		[Test]
		public void FieldsSumTotalCorrectly ()
		{
			var ac = new ArmorClass ();

			Assert.AreEqual (ac.Total.Value, 10);

			ac.Armor.Value = 5;

			Assert.AreEqual (ac.Total.Value, 15);

			ac.Shield.Value = 5;

			Assert.AreEqual (ac.Total.Value, 20);

			ac.Deflection.Value = 5;

			Assert.AreEqual (ac.Total.Value, 25);

			ac.Size.OverrideWith(5);

			Assert.AreEqual (ac.Total.Value, 30);

			ac.NaturalArmor.Value = 5;

			Assert.AreEqual (ac.Total.Value, 35);

			ac.Stats.OverrideWith (5);

			Assert.AreEqual (ac.Total.Value, 40);

			ac.Miscellaneous.Value = 5;

			Assert.AreEqual (ac.Total.Value, 45);
		}
	}
}
