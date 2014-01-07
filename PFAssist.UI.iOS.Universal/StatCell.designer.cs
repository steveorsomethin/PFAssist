// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace PFAssist.UI.iOS.Universal
{
	[Register ("StatCell")]
	partial class StatCell
	{
		[Outlet]
		MonoTouch.UIKit.UILabel lblStatType { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtModifier { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtScore { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtTempAdjust { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtTempModifier { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (lblStatType != null) {
				lblStatType.Dispose ();
				lblStatType = null;
			}

			if (txtModifier != null) {
				txtModifier.Dispose ();
				txtModifier = null;
			}

			if (txtScore != null) {
				txtScore.Dispose ();
				txtScore = null;
			}

			if (txtTempAdjust != null) {
				txtTempAdjust.Dispose ();
				txtTempAdjust = null;
			}

			if (txtTempModifier != null) {
				txtTempModifier.Dispose ();
				txtTempModifier = null;
			}
		}
	}
}
