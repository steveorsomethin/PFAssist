using System;
using NUnit.Framework;

namespace PFAssist.Core.Tests.iOS
{
	[TestFixture]
	public class AttackBonusTests
	{
		[Test]
		public void SourceUpdatesDownstream ()
		{
			var ab = new AttackBonus();

			ab.One.OverrideWith (3);

			Assert.AreEqual (ab.Two.Value, 0);

			ab.One.OverrideWith (6);

			Assert.AreEqual (ab.Two.Value, 1);

			ab.One.OverrideWith (23);

			Assert.AreEqual (ab.Two.Value, 18);
			Assert.AreEqual (ab.Three.Value, 13);
			Assert.AreEqual (ab.Four.Value, 8);
		}
	}
}
