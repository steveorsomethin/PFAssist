using System;
using MonoTouch.UIKit;
using PFAssist.Core;
using System.Reactive.Linq;
using System.Reactive;

namespace PFAssist.UI.iOS.Universal
{
	public static class UITextFieldExtensions
	{
		public static IObservable<String> GetTextChanges (this UITextField textField)
		{
			return Observable.FromEventPattern (
				ev => textField.EditingChanged += ev,
				ev => textField.EditingChanged -= ev)
					.Select (e => textField.Text);
		}

		public static void TwoWayBindIntValue (this UITextField textField, IReactiveValue<int> source)
		{
			source.String().Subscribe (s => textField.InvokeOnMainThread (() => textField.Text = s));
			textField.GetTextChanges().ParseInt().Subscribe(source);
		}
	}
}

