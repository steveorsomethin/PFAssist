using System;
using NUnit.Framework;

namespace PFAssist.Core.Tests.iOS
{
	[TestFixture]
	public class ArmorClassTests
	{
		[Test]
		public void FieldsSumCorrectly ()
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
