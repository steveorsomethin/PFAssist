using System;
using PFAssist.Core;
using MonoTouch.Foundation;
using ReactiveUI.Cocoa;
using ReactiveUI;
using MonoTouch.UIKit;

namespace PFAssist.UI.iOS
{
	public class SimpleStatViewModel
	{
		public String Description;
		public CalculatedReactiveValue<int> Data = new CalculatedReactiveValue<int>();

		public SimpleStatViewModel(String description, IReactiveValue<int> dataSource)
		{
			Description = description;
			dataSource.Subscribe (Data);
		}
	}

	[Register("SimpleStatCell")]
	public class SimpleStatCell : ReactiveTableViewCell, IViewFor<SimpleStatViewModel>
	{
		SimpleStatViewModel vm;

		SimpleStatViewModel IViewFor<SimpleStatViewModel>.ViewModel {
			get {
				return vm;
			}
			set {
				vm = value;
			}
		}

		public object ViewModel {
			get {
				return vm;
			}
			set {
				vm = (SimpleStatViewModel)value;
			}
		}

		public UILabel DescriptionTextLabel {
			get {
				return (UILabel)this.ViewWithTag (1);
			}
		}

		public UILabel DataTextLabel {
			get {
				return (UILabel)this.ViewWithTag (2);
			}
		}

		public void BindToViewModel()
		{
			DescriptionTextLabel.Text = vm.Description;
			vm.Data.BindTo (DataTextLabel, (d) => d.Text);
		}

		public SimpleStatCell(IntPtr handle) : base(handle)
		{
		}
	}
}

