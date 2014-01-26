using System;
using ReactiveUI.Cocoa;
using MonoTouch.Foundation;
using System.Drawing;
using MonoTouch.UIKit;
using ReactiveUI;

namespace PFAssist.UI.iOS
{
	[Register("StatSummaryViewCell")]
	public class StatSummaryViewCell : ReactiveTableViewCell
	{
		private ReactiveTableViewSource TableViewSource;

		public UIImageView SummaryImage {
			get;
			private set;
		}

		public UITableView SummaryTable {
			get;
			private set;
		}

		public StatSummaryViewCell (IntPtr handle) : base (handle)
		{
			// Style the image for this cell
			this.SummaryImage = new UIImageView(new RectangleF(3f, 3f, 64f, 64f));
			this.SummaryImage.Image = new UIImage ("UI-Background-Parchment.png");

			// Style the table for this cell
			this.SummaryTable = new UITableView (new RectangleF (70f, 0f, 230f, 128f));
			this.SummaryTable.Source = TableViewSource = new ReactiveTableViewSource (this.SummaryTable);

			// Add the table to this cell
			this.ContentView.AddSubviews (new UIView[] {
				SummaryImage,
				SummaryTable
			});

			// TODO: Setup the TableViewSource for this cell
		}
	}
}

