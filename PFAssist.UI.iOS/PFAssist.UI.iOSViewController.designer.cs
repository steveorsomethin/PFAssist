// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace PFAssist.UI.iOS
{
	[Register ("PFAssist_UI_iOSViewController")]
	partial class PFAssist_UI_iOSViewController
	{
		[Outlet]
		MonoTouch.UIKit.UITableView tblMain { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtInitiative { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (tblMain != null) {
				tblMain.Dispose ();
				tblMain = null;
			}

			if (txtInitiative != null) {
				txtInitiative.Dispose ();
				txtInitiative = null;
			}
		}
	}
}
