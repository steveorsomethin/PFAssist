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
	[Register ("DataViewController")]
	partial class DataViewController
	{
		[Outlet]
		MonoTouch.UIKit.UILabel dataLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITableView dataTable { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (dataLabel != null) {
				dataLabel.Dispose ();
				dataLabel = null;
			}

			if (dataTable != null) {
				dataTable.Dispose ();
				dataTable = null;
			}
		}
	}
}
