using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace PFAssist.UI.iOS.Universal
{
	public partial class StatCell : UITableViewCell
	{
		public static readonly UINib Nib = UINib.FromName ("StatCell", NSBundle.MainBundle);
		public static readonly NSString Key = new NSString ("StatCell");

		public StatCell (IntPtr handle) : base (handle)
		{
		}

		public static StatCell Create ()
		{
			return (StatCell)Nib.Instantiate (null, null) [0];
		}
	}
}

