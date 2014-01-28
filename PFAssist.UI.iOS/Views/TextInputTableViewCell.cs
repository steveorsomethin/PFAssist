using System;
using ReactiveUI.Cocoa;
using MonoTouch.UIKit;
using System.Drawing;

namespace PFAssist.UI.iOS
{
	public class TextInputTableViewCell<TViewModel> : ReactiveTableViewCell<TViewModel>
		where TViewModel : class
	{
		public UITextView TextView {
			get;
			private set;
		}

		public TextInputTableViewCell (IntPtr handle)
			: base (handle)
		{
			TextView = new UITextView (new RectangleF (150f, 0f, 150f, 32f));
		}

		#region implemented abstract members of ReactiveTableViewCell

		public override void BindToViewModel ()
		{
			throw new NotImplementedException ();
		}

		#endregion
	}
}

