using System;
using System.Reactive.Linq;

namespace PFAssist.UI.iOS.Universal
{
	public static class ObservableExtensions
	{
		public static IObservable<int> ParseInt(this IObservable<String> observable)
		{
			return observable.Where (s => {
				int intVal;

				return int.TryParse (s, out intVal);
			})
			.Select(s => int.Parse(s));
		}

		public static IObservable<String> String<T>(this IObservable<T> observable)
		{
			return observable.Select (i => i.ToString ());
		}
	}
}

