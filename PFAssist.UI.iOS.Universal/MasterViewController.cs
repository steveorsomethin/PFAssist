using System;
using System.Drawing;
using System.Collections.Generic;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using PFAssist.Core;
using System.Reactive.Linq;

namespace PFAssist.UI.iOS.Universal
{
	public class Row
	{

	}

	public class Section
	{
	}

	public partial class MasterViewController : UITableViewController
	{
		DataSource dataSource;
		public Character character = new Character ();

		public MasterViewController ()
			: base (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone ? "MasterViewController_iPhone" : "MasterViewController_iPad", null)
		{
			Title = NSBundle.MainBundle.LocalizedString ("Master", "Master");

			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad) {
				PreferredContentSize = new SizeF (320f, 600f);
				ClearsSelectionOnViewWillAppear = false;
			}
			
			// Custom initialization
		}

		public DetailViewController DetailViewController {
			get;
			set;
		}

		void AddNewItem (object sender, EventArgs args)
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

			// Perform any additional setup after loading the view, typically from a nib.
			NavigationItem.LeftBarButtonItem = EditButtonItem;

			var addButton = new UIBarButtonItem (UIBarButtonSystemItem.Add, AddNewItem);
			NavigationItem.RightBarButtonItem = addButton;

			TableView.Source = dataSource = new DataSource (this);

			dataSource.Objects.AddRange(character.PrimaryStats.Lookup.Values);

			// Should be disposing the NSIndexPaths, but oh well
			TableView.InsertRows (new NSIndexPath[] { 
				NSIndexPath.FromRowSection (0, 0),
				NSIndexPath.FromRowSection (1, 0),
				NSIndexPath.FromRowSection (2, 0),
				NSIndexPath.FromRowSection (3, 0),
				NSIndexPath.FromRowSection (4, 0),
				NSIndexPath.FromRowSection (5, 0),
			}, UITableViewRowAnimation.Automatic);
		}

		class DataSource : UITableViewSource
		{
			static readonly NSString CellIdentifier = new NSString ("Cell");
			readonly List<Stat> objects = new List<Stat> ();
			readonly MasterViewController controller;

			public DataSource (MasterViewController controller)
			{
				this.controller = controller;
			}

			public List<Stat> Objects {
				get { return objects; }
			}
			// Customize the number of sections in the table view.
			public override int NumberOfSections (UITableView tableView)
			{
				return 1;
			}

			public override int RowsInSection (UITableView tableview, int section)
			{
				return objects.Count;
			}
			// Customize the appearance of table view cells.
			public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
			{
				var cell = tableView.DequeueReusableCell (CellIdentifier);
				if (cell == null) {
					var statCell = StatCell.Create ();

					statCell.Stat.Value = objects [indexPath.Row];

					cell = statCell;

					if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone)
						cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
				}

//				cell.TextLabel.Text = d.ID.ToString () + " " + d.Derp;
				
				return cell;
			}

			public override float GetHeightForRow (UITableView tableView, NSIndexPath indexPath)
			{
				return 100;
			}

			public override string TitleForHeader (UITableView tableView, int section)
			{
				return "Primary Stats";
			}

			public override bool CanEditRow (UITableView tableView, NSIndexPath indexPath)
			{
				// Return false if you do not want the specified item to be editable.
				return true;
			}

			public override void CommitEditingStyle (UITableView tableView, UITableViewCellEditingStyle editingStyle, NSIndexPath indexPath)
			{
				if (editingStyle == UITableViewCellEditingStyle.Delete) {
					// Delete the row from the data source.
					objects.RemoveAt (indexPath.Row);
					controller.TableView.DeleteRows (new NSIndexPath[] { indexPath }, UITableViewRowAnimation.Fade);
				} else if (editingStyle == UITableViewCellEditingStyle.Insert) {
					// Create a new instance of the appropriate class, insert it into the array, and add a new row to the table view.
				}
			}
			/*
			// Override to support rearranging the table view.
			public override void MoveRow (UITableView tableView, NSIndexPath sourceIndexPath, NSIndexPath destinationIndexPath)
			{
			}
			*/
			/*
			// Override to support conditional rearranging of the table view.
			public override bool CanMoveRow (UITableView tableView, NSIndexPath indexPath)
			{
				// Return false if you do not want the item to be re-orderable.
				return true;
			}
			*/
			public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
			{
//				if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone) {
//					if (controller.DetailViewController == null)
//						controller.DetailViewController = new DetailViewController ();
//
//					controller.DetailViewController.SetDetailItem (objects [indexPath.Row]);
//
//					// Pass the selected object to the new view controller.
//					controller.NavigationController.PushViewController (controller.DetailViewController, true);
//				} else {
//					controller.DetailViewController.SetDetailItem (objects [indexPath.Row]);
//				}
			}
		}
	}
}

