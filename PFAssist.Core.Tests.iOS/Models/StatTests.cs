using System;
using NUnit.Framework;
using PFAssist.Core;
using System.Reactive.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;

namespace PFAssist.Core.Tests.iOS
{
	[TestFixture]
	public class StatTests
	{
		[Test]
		public void ScoreUpdatesModifier ()
		{
			var stat = new Stat (StatType.Strength);

			stat.Score.Value = 15;

			Assert.AreEqual (stat.Modifier.Value, 2);
		}

		[Test]
		public void TempAdjustAndScoreUpdatesTempModifier ()
		{
			var stat = new Stat (StatType.Strength);

			stat.Score.Value = 15;
			stat.TempAdjust.Value = 5;

			Assert.AreEqual (stat.TempModifier.Value, 5);
		}
	}
}
