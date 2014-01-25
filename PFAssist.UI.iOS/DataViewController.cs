using System;
using MonoTouch.UIKit;
using PFAssist.Core;
using ReactiveUI.Cocoa;
using ReactiveUI;
using MonoTouch.Foundation;

namespace PFAssist.UI.iOS
{
	public partial class DataViewController : UIViewController
	{
		public DataViewController (IntPtr handle) : base (handle)
		{
		}

		public Character DataObject {
			get;
			set;
		}

		public ReactiveTableViewSource TableViewSource {
			get;
			private set;
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

			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);

			dataLabel.Text = DataObject.Name.Value;

			dataTable.Source = TableViewSource = new ReactiveTableViewSource (this.dataTable);
			TableViewSource.Data = new ReactiveList<TableSectionInformation<UITableViewCell>>(new [] {
				MakeSection("ARMOR", new ReactiveList<SimpleStatViewModel> (new [] {
					new SimpleStatViewModel("Armor", DataObject.ArmorClass.Total),
					new SimpleStatViewModel("Touch", DataObject.ArmorClass.TouchTotal),
					new SimpleStatViewModel("Flat Footed", DataObject.ArmorClass.FlatFootedTotal)
				})),
				MakeSection("SAVES", new ReactiveList<SimpleStatViewModel> (new [] {
					new SimpleStatViewModel("Fortitude", DataObject.Saves.Fortitude.Total),
					new SimpleStatViewModel("Reflex", DataObject.Saves.Reflex.Total),
					new SimpleStatViewModel("Will", DataObject.Saves.Will.Total)
				})),
				MakeSection("ATTACK", new ReactiveList<SimpleStatViewModel> (new [] {
					new SimpleStatViewModel("1st Base Attack", DataObject.AttackBonus.One),
					new SimpleStatViewModel("2nd Base Attack", DataObject.AttackBonus.Two),
					new SimpleStatViewModel("3rd Base Attack", DataObject.AttackBonus.Three),
					new SimpleStatViewModel("4th Base Attack", DataObject.AttackBonus.Four)
				})),
				MakeSection("ATTACK", new ReactiveList<SimpleStatViewModel> (new [] {
					new SimpleStatViewModel("1st Base Attack", DataObject.AttackBonus.One),
					new SimpleStatViewModel("2nd Base Attack", DataObject.AttackBonus.Two),
					new SimpleStatViewModel("3rd Base Attack", DataObject.AttackBonus.Three),
					new SimpleStatViewModel("4th Base Attack", DataObject.AttackBonus.Four)
				})),

				// Duplicating this section to verify that scrolling works
				MakeSection("ATTACK", new ReactiveList<SimpleStatViewModel> (new [] {
					new SimpleStatViewModel("1st Base Attack", DataObject.AttackBonus.One),
					new SimpleStatViewModel("2nd Base Attack", DataObject.AttackBonus.Two),
					new SimpleStatViewModel("3rd Base Attack", DataObject.AttackBonus.Three),
					new SimpleStatViewModel("4th Base Attack", DataObject.AttackBonus.Four)
				})),
				MakeSection("ATTACK", new ReactiveList<SimpleStatViewModel> (new [] {
					new SimpleStatViewModel("1st Base Attack", DataObject.AttackBonus.One),
					new SimpleStatViewModel("2nd Base Attack", DataObject.AttackBonus.Two),
					new SimpleStatViewModel("3rd Base Attack", DataObject.AttackBonus.Three),
					new SimpleStatViewModel("4th Base Attack", DataObject.AttackBonus.Four)
				})),
				MakeSection("ATTACK", new ReactiveList<SimpleStatViewModel> (new [] {
					new SimpleStatViewModel("1st Base Attack", DataObject.AttackBonus.One),
					new SimpleStatViewModel("2nd Base Attack", DataObject.AttackBonus.Two),
					new SimpleStatViewModel("3rd Base Attack", DataObject.AttackBonus.Three),
					new SimpleStatViewModel("4th Base Attack", DataObject.AttackBonus.Four)
				})),
				MakeSection("ATTACK", new ReactiveList<SimpleStatViewModel> (new [] {
					new SimpleStatViewModel("1st Base Attack", DataObject.AttackBonus.One),
					new SimpleStatViewModel("2nd Base Attack", DataObject.AttackBonus.Two),
					new SimpleStatViewModel("3rd Base Attack", DataObject.AttackBonus.Three),
					new SimpleStatViewModel("4th Base Attack", DataObject.AttackBonus.Four)
				})),
				MakeSection("ATTACK", new ReactiveList<SimpleStatViewModel> (new [] {
					new SimpleStatViewModel("1st Base Attack", DataObject.AttackBonus.One),
					new SimpleStatViewModel("2nd Base Attack", DataObject.AttackBonus.Two),
					new SimpleStatViewModel("3rd Base Attack", DataObject.AttackBonus.Three),
					new SimpleStatViewModel("4th Base Attack", DataObject.AttackBonus.Four)
				})),
				MakeSection("ATTACK", new ReactiveList<SimpleStatViewModel> (new [] {
					new SimpleStatViewModel("1st Base Attack", DataObject.AttackBonus.One),
					new SimpleStatViewModel("2nd Base Attack", DataObject.AttackBonus.Two),
					new SimpleStatViewModel("3rd Base Attack", DataObject.AttackBonus.Three),
					new SimpleStatViewModel("4th Base Attack", DataObject.AttackBonus.Four)
				})),
				MakeSection("ATTACK", new ReactiveList<SimpleStatViewModel> (new [] {
					new SimpleStatViewModel("1st Base Attack", DataObject.AttackBonus.One),
					new SimpleStatViewModel("2nd Base Attack", DataObject.AttackBonus.Two),
					new SimpleStatViewModel("3rd Base Attack", DataObject.AttackBonus.Three),
					new SimpleStatViewModel("4th Base Attack", DataObject.AttackBonus.Four)
				})),
				MakeSection("ATTACK", new ReactiveList<SimpleStatViewModel> (new [] {
					new SimpleStatViewModel("1st Base Attack", DataObject.AttackBonus.One),
					new SimpleStatViewModel("2nd Base Attack", DataObject.AttackBonus.Two),
					new SimpleStatViewModel("3rd Base Attack", DataObject.AttackBonus.Three),
					new SimpleStatViewModel("4th Base Attack", DataObject.AttackBonus.Four)
				}))
			});

			dataTable.BackgroundColor = UIColor.Clear;
		}

		private TableSectionInformation<UITableViewCell> MakeSection(String headerText, ReactiveList<SimpleStatViewModel> statCellList)
		{
			var sectionInfo = new TableSectionInformation<UITableViewCell> (statCellList, new NSString("SimpleStatViewCell"), 40.0f, (cell) => {
				var sCell = (SimpleStatViewCell)cell;
				sCell.BindToViewModel();
			});

			sectionInfo.Header = new TableSectionHeader (() => {
				var header = new UITableViewHeaderFooterView ();
				header.TextLabel.Text = headerText;
				header.TextLabel.TextColor = UIColor.White;
				header.BackgroundColor = UIColor.Clear;
				header.BackgroundView = new UIView();
				return header;
			}, 50.0f);

			return sectionInfo;
		}
	}
}

