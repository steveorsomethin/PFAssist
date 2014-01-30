using System;
using ReactiveUI;

namespace PFAssist.UI.iOS
{
	public class ReactiveViewController<T> : ReactiveUI.Cocoa.ReactiveViewController, IViewFor<T>
		where T : class
	{
		private T viewModel;

		public ReactiveViewController (IntPtr handle)
			: base (handle)
		{
		}

		#region IViewFor implementation

		public T ViewModel {
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
				this.RaiseAndSetIfChanged (ref this.viewModel, value as T, "ViewModel");
			}
		}

		#endregion
	}
	
}
