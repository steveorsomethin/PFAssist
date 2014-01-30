using System;
using PFAssist.Core;
using ReactiveUI;
using System.Reflection;

namespace PFAssist.UI.iOS
{
	public class CharacterDetailViewModel : ReactiveObject
	{
		public ReactiveList<FieldInfo> Attributes {
			get;
			private set;
		}

		public CharacterDetailViewModel ()
		{

		}
	}
}

