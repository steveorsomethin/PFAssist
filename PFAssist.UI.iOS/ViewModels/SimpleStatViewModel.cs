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
}

