using System;
using MonoTouch.Foundation;
using ReactiveUI.Cocoa;
using ReactiveUI;
using MonoTouch.UIKit;
using System.Drawing;

namespace PFAssist.UI.iOS
{
	[Register("EditableViewCell")]
	public class EditableViewCell : ReactiveTableViewCell, IViewFor<SimpleStatViewModel>
	{
		// Fields
		private SimpleStatViewModel viewModel;

		// Properties
		public UITextView TextView {
			get;
			private set;
		}

		// Constructors
		public EditableViewCell (IntPtr handle) : base(handle)
		{
			TextView = new UITextView (new RectangleF (150f, 0f, 150f, 43f));
			ContentView.AddSubview (TextView);
		}

		// Methods
		public void BindToViewModel() {
			TextLabel.Text = viewModel.Description;
			viewModel.Data.BindTo (TextView, d => d.Text);
		}

		#region IViewFor<T> implementation

		public SimpleStatViewModel ViewModel {
			get {
				return viewModel;
			}
			set {
				viewModel = value;
			}
		}

		#endregion

		#region IViewFor implementation

		object IViewFor.ViewModel {
			get {
				return viewModel;
			}
			set {
				viewModel = value as SimpleStatViewModel;
			}
		}

		#endregion
	}
}

