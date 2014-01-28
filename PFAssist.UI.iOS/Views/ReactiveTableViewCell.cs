using System;
using ReactiveUI.Cocoa;
using ReactiveUI;

namespace PFAssist.UI.iOS.Views
{
	public abstract class ReactiveTableViewCell<TViewModel> : ReactiveTableViewCell, IViewFor<TViewModel>
		where TViewModel : class
	{
		private TViewModel viewModel;

		protected ReactiveTableViewCell (IntPtr handle) : base (handle)
		{
		}

		public abstract void BindToViewModel ();

		#region IViewFor implementation

		public TViewModel ViewModel {
			get {
				return this.viewModel;
			}
			set {
				this.RaiseAndSetIfChanged (ref this.viewModel, value, "ViewModel");
			}
		}

		#endregion

		#region IViewFor implementation

		object IViewFor.ViewModel {
			get {
				return this.viewModel;
			}
			set {
				this.RaiseAndSetIfChanged (ref this.viewModel, value as TViewModel, "ViewModel");
			}
		}

		#endregion
	}
}

