using System;
using System.Reactive.Subjects;

namespace PFAssist.Core
{
	public interface IReactiveValue<T> : ISubject<T>
	{
		T Value { get; }
	}
}

