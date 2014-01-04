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

			stat.Scores.OnNext (15);

			Assert.AreEqual (stat.Modifiers.First (), 2);
		}

		[Test]
		public void TempAdjustAndScoreUpdatesTempModifier ()
		{
			var stat = new Stat (StatType.Strength);

			stat.Scores.OnNext (15);
			stat.TempAdjusts.OnNext (5);

			Assert.AreEqual (stat.TempModifiers.First (), 5);
		}
	}
}
