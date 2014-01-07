using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using PFAssist.Core;
using System.Reactive.Linq;
using MonoTouch.ObjCRuntime;
using System.Reactive.Concurrency;

namespace PFAssist.UI.iOS.Universal
{
	public partial class StatCell : UITableViewCell
	{
		public static readonly UINib Nib = UINib.FromName ("StatCell", NSBundle.MainBundle);
		public static readonly NSString Key = new NSString ("StatCell");
		public ReactiveValue<Stat> Stat = new ReactiveValue<Stat> ();

		public StatCell (IntPtr handle) : base (handle)
		{
		}

		private void Initialize ()
		{
			txtModifier.Enabled = false;
			txtTempModifier.Enabled = false;

			Stat.Where (s => s != null).Subscribe (stat => {
				lblStatType.Text = stat.Type.ToString();
				txtScore.TwoWayBindIntValue(stat.Score);
				txtModifier.TwoWayBindIntValue(stat.Modifier);
				txtTempAdjust.TwoWayBindIntValue(stat.TempAdjust);
				txtTempModifier.TwoWayBindIntValue(stat.TempModifier);
			});

			txtScore.ShouldReturn += (textField) => { 
				textField.ResignFirstResponder();
				return true; 
			};

			txtTempAdjust.ShouldReturn += (textField) => { 
				textField.ResignFirstResponder();
				return true; 
			};
		}

		public static StatCell Create ()
		{
			StatCell cell = (StatCell)Nib.Instantiate (null, null) [0];
			cell.Initialize ();
			return cell;
		}
	}
}

