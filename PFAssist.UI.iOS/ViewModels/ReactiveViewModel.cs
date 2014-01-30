using System;
using ReactiveUI;
using PFAssist.Core;

namespace PFAssist.UI.iOS
{
	public abstract class ReactiveViewModel<T> : ReactiveObject
	{
		public string Description {
			get;
			protected set;
		}

		public IReactiveValue<T> Data {
			get;
			protected set;
		}

		public ReactiveViewModel (string description, IReactiveValue<T> dataSource)
		{
			this.Description = description;
			dataSource.Subscribe (this.Data);
		}
	}

	public class CalculatedValueViewModel : ReactiveViewModel<Int32>
	{
		public CalculatedValueViewModel(string description, IReactiveValue<Int32> dataSource)
			: base (description, dataSource)
		{
		}
	}

	public class StringValueViewModel : ReactiveViewModel<String>
	{
		public StringValueViewModel(string description, IReactiveValue<String> dataSource)
			: base (description, dataSource)
		{
		}
	}
}

