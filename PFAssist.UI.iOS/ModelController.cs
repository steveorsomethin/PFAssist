using System;
using System.Collections.Generic;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using PFAssist.Core;

namespace PFAssist.UI.iOS
{
	public class ModelController : UIPageViewControllerDataSource
	{
		readonly List<Character> pageData;

		public ModelController ()
		{
			var char1 = new Character ();
			var char2 = new Character ();
			var char3 = new Character ();

			char1.Name.Value = "Frodo";
			char2.Name.Value = "Aragorn";
			char3.Name.Value = "Gandalf";

			pageData = new List<Character>() {
				char1,
				char2,
				char3
			};
		}

		public DataViewController GetViewController (int index, UIStoryboard storyboard)
		{
			if (index >= pageData.Count)
				return null;

			// Create a new view controller and pass suitable data.
			var dataViewController = (DataViewController)storyboard.InstantiateViewController ("DataViewController");
			dataViewController.DataObject = pageData [index];

			return dataViewController;
		}

		public int IndexOf (DataViewController viewController)
		{
			return pageData.IndexOf (viewController.DataObject);
		}

		public override UIViewController GetNextViewController (UIPageViewController pageViewController, UIViewController referenceViewController)
		{
			int index = IndexOf ((DataViewController)referenceViewController);

			if (index == -1 || index == pageData.Count - 1)
				return null;

			return GetViewController (index + 1, referenceViewController.Storyboard);
		}

		public override UIViewController GetPreviousViewController (UIPageViewController pageViewController, UIViewController referenceViewController)
		{
			int index = IndexOf ((DataViewController)referenceViewController);

			if (index == -1 || index == 0)
				return null;

			return GetViewController (index - 1, referenceViewController.Storyboard);
		}
	}
}

