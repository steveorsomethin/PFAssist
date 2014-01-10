using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using ReactiveUI;
using ReactiveUI.Cocoa;
using PFAssist.Core;
using System.Reactive.Linq;

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

	public partial class PFAssist_UI_iOSViewController : UIViewController
	{
		Character character = new Character ();

		ReactiveTableViewSource tableDataSource;

		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		public PFAssist_UI_iOSViewController (IntPtr handle) : base (handle)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();

			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			this.tblMain.Source = tableDataSource = new ReactiveTableViewSource (this.tblMain);

			tableDataSource.Data = new ReactiveList<TableSectionInformation<UITableViewCell>>(new [] {
				MakeSection("ARMOR", new ReactiveList<SimpleStatViewModel> (new [] {
					new SimpleStatViewModel("AC", character.ArmorClass.Total),
					new SimpleStatViewModel("Touch", character.ArmorClass.TouchTotal),
					new SimpleStatViewModel("Flat Footed", character.ArmorClass.FlatFootedTotal)
				})),
				MakeSection("SAVES", new ReactiveList<SimpleStatViewModel> (new [] {
					new SimpleStatViewModel("Fortitude", character.Saves.Fortitude.Total),
					new SimpleStatViewModel("Reflex", character.Saves.Reflex.Total),
					new SimpleStatViewModel("will", character.Saves.Will.Total)
				}))
			});

			character.Initiative.Total.BindTo (txtInitiative, (t) => t.Text);

			Observable.Interval (TimeSpan.FromSeconds (1))
				.Select(t => (int)t)
				.Subscribe (t => InvokeOnMainThread(() => character.PrimaryStats.Dexterity.Score.Value = t + 15));
		}

		private TableSectionInformation<UITableViewCell> MakeSection(String headerText, ReactiveList<SimpleStatViewModel> statCellList)
		{
			var headerInfo = new TableSectionInformation<UITableViewCell> (statCellList, new NSString("SimpleStatCell"), 40.0f, (cell) => {
				var sCell = (SimpleStatCell)cell;
				sCell.BindToViewModel();
			});

			headerInfo.Header = new TableSectionHeader (() => {
				var header = new UITableViewHeaderFooterView ();
				header.TextLabel.Text = headerText;
				header.ContentView.BackgroundColor = new UIColor(0.9f, 0.9f, 0.9f, 1.0f);
				return header;
			}, 50.0f);

			return headerInfo;
		}
	}
}

