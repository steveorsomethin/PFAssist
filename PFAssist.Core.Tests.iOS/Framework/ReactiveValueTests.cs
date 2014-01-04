using System;
using NUnit.Framework;
using PFAssist.Core;
using System.Reactive.Subjects;
using System.Reactive.Linq;

namespace PFAssist.Core.Tests.iOS
{
	[TestFixture]
	public class ReactiveValueTests
	{
		[Test]
		public void DownstreamValuesUpdate ()
		{
			var val = new ReactiveValue<int> ();
			var calc = new CalculatedReactiveValue<int> ();

			val.Subscribe (calc);

			val.Value = 50;

			Assert.AreEqual (calc.Value, 50);
		}

		[Test]
		public void MutualSubscriptionsDontDeadlock ()
		{
			var val = new ReactiveValue<int> ();
			var calc = new CalculatedReactiveValue<int> ();

			val.Subscribe (calc);
			calc.Subscribe (val);

			val.Value = 50;

			Assert.AreEqual (calc.Value, 50);

			val.Value = 100;

			Assert.AreEqual (calc.Value, 100);
		}

		[Test]
		public void CalculatedValuesAreOverridable ()
		{
			var val = new ReactiveValue<int> ();
			var calc = new CalculatedReactiveValue<int> ();

			val.Subscribe (calc);

			val.Value = 50;

			Assert.AreEqual (calc.Value, 50);

			calc.OverrideWith (100);

			Assert.AreEqual (calc.Value, 100);
			Assert.True (calc.IsOverridden.Value);
		}

		[Test]
		public void OverriddenValuesRevertCorrectly ()
		{
			var val = new ReactiveValue<int> ();
			var calc = new CalculatedReactiveValue<int> ();

			val.Subscribe (calc);

			val.Value = 50;

			Assert.AreEqual (calc.Value, 50);

			calc.OverrideWith (100);

			Assert.AreEqual (calc.Value, 100);
			Assert.True (calc.IsOverridden.Value);

			calc.IsOverridden.Value = false;

			Assert.AreEqual (calc.Value, 50);
		}
	}
}
