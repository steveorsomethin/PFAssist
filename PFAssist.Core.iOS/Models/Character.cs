using System;

namespace PFAssist.Core.iOS
{
	public enum Size
	{
		Small = 0,
		Medium = 1,
		Large = 2
	}

	public enum CharacterClass
	{
		// TODO: Fill this out
		Fighter
	}

	public enum Alignment
	{
		// TODO: Fill this out
		Neutral
	}

	public enum Race
	{
		// TODO: Fill this out
		Human
	}

	public enum Deity
	{
		// TODO: Fill this out
		Dickus
	}

	public enum Gender
	{
		// TODO: Fill this out
		Male,
		Female,
		Other
	}

	public class Character
	{
		// Fluff fields
		public readonly ReactiveValue<String> Name = new ReactiveValue<String> ();
		public readonly ReactiveValue<Alignment> Alignment = new ReactiveValue<Alignment> ();
		public readonly ReactiveValue<Race> Race = new ReactiveValue<Race> ();
		public readonly ReactiveValue<Deity> Deity = new ReactiveValue<Deity> ();
		public readonly ReactiveValue<String> Player = new ReactiveValue<String> ();
		public readonly ReactiveValue<Gender> Gender = new ReactiveValue<Gender> ();
		public readonly ReactiveValue<int> Age = new ReactiveValue<int> ();
		public readonly ReactiveValue<int> Height = new ReactiveValue<int> ();
		public readonly ReactiveValue<int> Weight = new ReactiveValue<int> ();
		public readonly ReactiveValue<String> Hair = new ReactiveValue<String> ();
		public readonly ReactiveValue<String> Eyes = new ReactiveValue<String> ();
		public readonly ReactiveValue<String> Homeland = new ReactiveValue<String> ();
		// Fields that affect downstream values
		public readonly ReactiveValue<Size> Size = new ReactiveValue<Size> ();
		public readonly ReactiveValue<CharacterClass> Class1 = new ReactiveValue<CharacterClass> ();
		public readonly ReactiveValue<int> Level1 = new ReactiveValue<int> ();
		public readonly ReactiveValue<CharacterClass> Class2 = new ReactiveValue<CharacterClass> ();
		public readonly ReactiveValue<int> Level2 = new ReactiveValue<int> ();
		public readonly ReactiveValue<CharacterClass> Class3 = new ReactiveValue<CharacterClass> ();
		public readonly ReactiveValue<int> Level3 = new ReactiveValue<int> ();
		// Composed bits
		public Stats PrimaryStats = new Stats();

		public Character ()
		{
		}
	}
}

