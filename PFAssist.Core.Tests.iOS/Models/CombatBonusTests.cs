using System;
using NUnit.Framework;

namespace PFAssist.Core.Tests.iOS
{
	[TestFixture]
	public class CombatBonusTests
	{
		[Test]
		public void SourcesUpdateManeuverBonus ()
		{
			var cb = new CombatBonus();

			cb.BaseAttackBonus.OverrideWith (23);
			cb.Strength.OverrideWith (2);
			cb.Dexterity.OverrideWith (2);
			cb.Size.OverrideWith (-1);

			Assert.AreEqual (cb.ManeuverBonus.Value, 24);
			Assert.AreEqual (cb.DefenseBonus.Value, 36);
		}
	}
}
