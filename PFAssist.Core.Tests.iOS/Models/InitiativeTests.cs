using System;
using NUnit.Framework;

namespace PFAssist.Core.Tests.iOS
{
	[TestFixture]
	public class InitiativeTests
	{
		[Test]
		public void FieldsSumCorrectly ()
		{
			var init = new Initiative ();

			Assert.AreEqual (init.Total.Value, 0);

			init.Stats.OverrideWith (5);

			Assert.AreEqual (init.Total.Value, 5);

			init.Miscellaneous.Value = 5;

			Assert.AreEqual (init.Total.Value, 10);
		}
	}
}
