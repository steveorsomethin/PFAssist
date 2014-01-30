using System;
using ReactiveUI.Cocoa;
using ReactiveUI;
using MonoTouch.Foundation;

namespace PFAssist.UI.iOS
{
	[Register("CharacterDetailViewController")]
	public partial class CharacterDetailViewController : ReactiveViewController<CharacterDetailViewModel>
	{
		public CharacterDetailViewController (IntPtr handle)
			: base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
		}
	}
}

