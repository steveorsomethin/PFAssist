using System;
using NUnit.Framework;

namespace PFAssist.Core.Tests.iOS
{
	[TestFixture]
	public class SaveTests
	{
		[Test]
		public void SourcesUpdateTotal ()
		{
			var save = new Save (SaveType.Reflex);

			save.MagicModifier.Value = 5;
			save.MiscellaneousModifier.Value = 5;
			save.TempModifier.Value = 5;

			save.AbilityModifier.OverrideWith (2);
			save.BaseModifier.OverrideWith (9);

			Assert.AreEqual (save.Total.Value, 26);
		}
	}
}
