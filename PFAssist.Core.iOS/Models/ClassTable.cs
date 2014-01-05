using System;
using System.Collections.Generic;

namespace PFAssist.Core
{
	public class ClassTable : Dictionary<int, LevelInfo>
	{
		public ClassTable (params LevelInfo[] levelInfos)
		{
			foreach (var levelInfo in levelInfos) {
				this [levelInfo.Level.Value] = levelInfo;
			}
		}
	}

	public class ClassTables : Dictionary<CharacterClasses, ClassTable>
	{
		public static readonly ClassTables Tables;

		static ClassTables ()
		{
			Tables = new ClassTables ();

			// Generated via a script
			Tables [CharacterClasses.Alchemist] = new ClassTable (
				new LevelInfo (1, 0, 0, 0, 0, 2, 2, 0),
				new LevelInfo (2, 1, 0, 0, 0, 3, 3, 0),
				new LevelInfo (3, 2, 0, 0, 0, 3, 3, 1),
				new LevelInfo (4, 3, 0, 0, 0, 4, 4, 1),
				new LevelInfo (5, 3, 0, 0, 0, 4, 4, 1),
				new LevelInfo (6, 4, 0, 0, 0, 5, 5, 2),
				new LevelInfo (7, 5, 0, 0, 0, 5, 5, 2),
				new LevelInfo (8, 6, 1, 0, 0, 6, 6, 2),
				new LevelInfo (9, 6, 1, 0, 0, 6, 6, 3),
				new LevelInfo (10, 7, 2, 0, 0, 7, 7, 3),
				new LevelInfo (11, 8, 3, 0, 0, 7, 7, 3),
				new LevelInfo (12, 9, 4, 0, 0, 8, 8, 4),
				new LevelInfo (13, 9, 4, 0, 0, 8, 8, 4),
				new LevelInfo (14, 10, 5, 0, 0, 9, 9, 4),
				new LevelInfo (15, 11, 6, 1, 0, 9, 9, 5),
				new LevelInfo (16, 12, 7, 2, 0, 10, 10, 5),
				new LevelInfo (17, 12, 7, 2, 0, 10, 10, 5),
				new LevelInfo (18, 13, 8, 3, 0, 11, 11, 6),
				new LevelInfo (19, 14, 9, 4, 0, 11, 11, 6),
				new LevelInfo (20, 15, 10, 5, 0, 12, 12, 6)
			);

			Tables [CharacterClasses.Antipaladin] = new ClassTable (
				new LevelInfo (1, 1, 0, 0, 0, 2, 0, 2),
				new LevelInfo (2, 2, 0, 0, 0, 3, 0, 3),
				new LevelInfo (3, 3, 0, 0, 0, 3, 1, 3),
				new LevelInfo (4, 4, 0, 0, 0, 4, 1, 4),
				new LevelInfo (5, 5, 0, 0, 0, 4, 1, 4),
				new LevelInfo (6, 6, 1, 0, 0, 5, 2, 5),
				new LevelInfo (7, 7, 2, 0, 0, 5, 2, 5),
				new LevelInfo (8, 8, 3, 0, 0, 6, 2, 6),
				new LevelInfo (9, 9, 4, 0, 0, 6, 3, 6),
				new LevelInfo (10, 10, 5, 0, 0, 7, 3, 7),
				new LevelInfo (11, 11, 6, 1, 0, 7, 3, 7),
				new LevelInfo (12, 12, 7, 2, 0, 8, 4, 8),
				new LevelInfo (13, 13, 8, 3, 0, 8, 4, 8),
				new LevelInfo (14, 14, 9, 4, 0, 9, 4, 9),
				new LevelInfo (15, 15, 10, 5, 0, 9, 5, 9),
				new LevelInfo (16, 16, 11, 6, 1, 10, 5, 10),
				new LevelInfo (17, 17, 12, 7, 2, 10, 5, 10),
				new LevelInfo (18, 18, 13, 8, 3, 11, 6, 11),
				new LevelInfo (19, 19, 14, 9, 4, 11, 6, 11),
				new LevelInfo (20, 20, 15, 10, 5, 12, 6, 12)
			);

			Tables [CharacterClasses.Barbarian] = new ClassTable (
				new LevelInfo (1, 1, 0, 0, 0, 2, 0, 0),
				new LevelInfo (2, 2, 0, 0, 0, 3, 0, 0),
				new LevelInfo (3, 3, 0, 0, 0, 3, 1, 1),
				new LevelInfo (4, 4, 0, 0, 0, 4, 1, 1),
				new LevelInfo (5, 5, 0, 0, 0, 4, 1, 1),
				new LevelInfo (6, 6, 1, 0, 0, 5, 2, 2),
				new LevelInfo (7, 7, 2, 0, 0, 5, 2, 2),
				new LevelInfo (8, 8, 3, 0, 0, 6, 2, 2),
				new LevelInfo (9, 9, 4, 0, 0, 6, 3, 3),
				new LevelInfo (10, 10, 5, 0, 0, 7, 3, 3),
				new LevelInfo (11, 11, 6, 1, 0, 7, 3, 3),
				new LevelInfo (12, 12, 7, 2, 0, 8, 4, 4),
				new LevelInfo (13, 13, 8, 3, 0, 8, 4, 4),
				new LevelInfo (14, 14, 9, 4, 0, 9, 4, 4),
				new LevelInfo (15, 15, 10, 5, 0, 9, 5, 5),
				new LevelInfo (16, 16, 11, 6, 1, 10, 5, 5),
				new LevelInfo (17, 17, 12, 7, 2, 10, 5, 5),
				new LevelInfo (18, 18, 13, 8, 3, 11, 6, 6),
				new LevelInfo (19, 19, 14, 9, 4, 11, 6, 6),
				new LevelInfo (20, 20, 15, 10, 5, 12, 6, 6)
			);

			Tables [CharacterClasses.Bard] = new ClassTable (
				new LevelInfo (1, 0, 0, 0, 0, 0, 2, 2),
				new LevelInfo (2, 1, 0, 0, 0, 0, 3, 3),
				new LevelInfo (3, 2, 0, 0, 0, 1, 3, 3),
				new LevelInfo (4, 3, 0, 0, 0, 1, 4, 4),
				new LevelInfo (5, 3, 0, 0, 0, 1, 4, 4),
				new LevelInfo (6, 4, 0, 0, 0, 2, 5, 5),
				new LevelInfo (7, 5, 0, 0, 0, 2, 5, 5),
				new LevelInfo (8, 6, 1, 0, 0, 2, 6, 6),
				new LevelInfo (9, 6, 1, 0, 0, 3, 6, 6),
				new LevelInfo (10, 7, 2, 0, 0, 3, 7, 7),
				new LevelInfo (11, 8, 3, 0, 0, 3, 7, 7),
				new LevelInfo (12, 9, 4, 0, 0, 4, 8, 8),
				new LevelInfo (13, 9, 4, 0, 0, 4, 8, 8),
				new LevelInfo (14, 10, 5, 0, 0, 4, 9, 9),
				new LevelInfo (15, 11, 6, 1, 0, 5, 9, 9),
				new LevelInfo (16, 12, 7, 2, 0, 5, 10, 10),
				new LevelInfo (17, 12, 7, 2, 0, 5, 10, 10),
				new LevelInfo (18, 13, 8, 3, 0, 6, 11, 11),
				new LevelInfo (19, 14, 9, 4, 0, 6, 11, 11),
				new LevelInfo (20, 15, 10, 5, 0, 6, 12, 12)
			);

			Tables [CharacterClasses.Cavalier] = new ClassTable (
				new LevelInfo (1, 1, 0, 0, 0, 2, 0, 0),
				new LevelInfo (2, 2, 0, 0, 0, 3, 0, 0),
				new LevelInfo (3, 3, 0, 0, 0, 3, 1, 1),
				new LevelInfo (4, 4, 0, 0, 0, 4, 1, 1),
				new LevelInfo (5, 5, 0, 0, 0, 4, 1, 1),
				new LevelInfo (6, 6, 1, 0, 0, 5, 2, 2),
				new LevelInfo (7, 7, 2, 0, 0, 5, 2, 2),
				new LevelInfo (8, 8, 3, 0, 0, 6, 2, 2),
				new LevelInfo (9, 9, 4, 0, 0, 6, 3, 3),
				new LevelInfo (10, 10, 5, 0, 0, 7, 3, 3),
				new LevelInfo (11, 11, 6, 1, 0, 7, 3, 3),
				new LevelInfo (12, 12, 7, 2, 0, 8, 4, 4),
				new LevelInfo (13, 13, 8, 3, 0, 8, 4, 4),
				new LevelInfo (14, 14, 9, 4, 0, 9, 4, 4),
				new LevelInfo (15, 15, 10, 5, 0, 9, 5, 5),
				new LevelInfo (16, 16, 11, 6, 1, 10, 5, 5),
				new LevelInfo (17, 17, 12, 7, 2, 10, 5, 5),
				new LevelInfo (18, 18, 13, 8, 3, 11, 6, 6),
				new LevelInfo (19, 19, 14, 9, 4, 11, 6, 6),
				new LevelInfo (20, 20, 15, 10, 5, 12, 6, 6)
			);

			Tables [CharacterClasses.Cleric] = new ClassTable (
				new LevelInfo (1, 0, 0, 0, 0, 2, 0, 2),
				new LevelInfo (2, 1, 0, 0, 0, 3, 0, 3),
				new LevelInfo (3, 2, 0, 0, 0, 3, 1, 3),
				new LevelInfo (4, 3, 0, 0, 0, 4, 1, 4),
				new LevelInfo (5, 3, 0, 0, 0, 4, 1, 4),
				new LevelInfo (6, 4, 0, 0, 0, 5, 2, 5),
				new LevelInfo (7, 5, 0, 0, 0, 5, 2, 5),
				new LevelInfo (8, 6, 1, 0, 0, 6, 2, 6),
				new LevelInfo (9, 6, 1, 0, 0, 6, 3, 6),
				new LevelInfo (10, 7, 2, 0, 0, 7, 3, 7),
				new LevelInfo (11, 8, 3, 0, 0, 7, 3, 7),
				new LevelInfo (12, 9, 4, 0, 0, 8, 4, 8),
				new LevelInfo (13, 9, 4, 0, 0, 8, 4, 8),
				new LevelInfo (14, 10, 5, 0, 0, 9, 4, 9),
				new LevelInfo (15, 11, 6, 1, 0, 9, 5, 9),
				new LevelInfo (16, 12, 7, 2, 0, 10, 5, 10),
				new LevelInfo (17, 12, 7, 2, 0, 10, 5, 10),
				new LevelInfo (18, 13, 8, 3, 0, 11, 6, 11),
				new LevelInfo (19, 14, 9, 4, 0, 11, 6, 11),
				new LevelInfo (20, 15, 10, 5, 0, 12, 6, 12)
			);

			Tables [CharacterClasses.Druid] = new ClassTable (
				new LevelInfo (1, 0, 0, 0, 0, 2, 0, 2),
				new LevelInfo (2, 1, 0, 0, 0, 3, 0, 3),
				new LevelInfo (3, 2, 0, 0, 0, 3, 1, 3),
				new LevelInfo (4, 3, 0, 0, 0, 4, 1, 4),
				new LevelInfo (5, 3, 0, 0, 0, 4, 1, 4),
				new LevelInfo (6, 4, 0, 0, 0, 5, 2, 5),
				new LevelInfo (7, 5, 0, 0, 0, 5, 2, 5),
				new LevelInfo (8, 6, 1, 0, 0, 6, 2, 6),
				new LevelInfo (9, 6, 1, 0, 0, 6, 3, 6),
				new LevelInfo (10, 7, 2, 0, 0, 7, 3, 7),
				new LevelInfo (11, 8, 3, 0, 0, 7, 3, 7),
				new LevelInfo (12, 9, 4, 0, 0, 8, 4, 8),
				new LevelInfo (13, 9, 4, 0, 0, 8, 4, 8),
				new LevelInfo (14, 10, 5, 0, 0, 9, 4, 9),
				new LevelInfo (15, 11, 6, 1, 0, 9, 5, 9),
				new LevelInfo (16, 12, 7, 2, 0, 10, 5, 10),
				new LevelInfo (17, 12, 7, 2, 0, 10, 5, 10),
				new LevelInfo (18, 13, 8, 3, 0, 11, 6, 11),
				new LevelInfo (19, 14, 9, 4, 0, 11, 6, 11),
				new LevelInfo (20, 15, 10, 5, 0, 12, 6, 12)
			);

			Tables [CharacterClasses.Fighter] = new ClassTable (
				new LevelInfo (1, 1, 0, 0, 0, 2, 0, 0),
				new LevelInfo (2, 2, 0, 0, 0, 3, 0, 0),
				new LevelInfo (3, 3, 0, 0, 0, 3, 1, 1),
				new LevelInfo (4, 4, 0, 0, 0, 4, 1, 1),
				new LevelInfo (5, 5, 0, 0, 0, 4, 1, 1),
				new LevelInfo (6, 6, 1, 0, 0, 5, 2, 2),
				new LevelInfo (7, 7, 2, 0, 0, 5, 2, 2),
				new LevelInfo (8, 8, 3, 0, 0, 6, 2, 2),
				new LevelInfo (9, 9, 4, 0, 0, 6, 3, 3),
				new LevelInfo (10, 10, 5, 0, 0, 7, 3, 3),
				new LevelInfo (11, 11, 6, 1, 0, 7, 3, 3),
				new LevelInfo (12, 12, 7, 2, 0, 8, 4, 4),
				new LevelInfo (13, 13, 8, 3, 0, 8, 4, 4),
				new LevelInfo (14, 14, 9, 4, 0, 9, 4, 4),
				new LevelInfo (15, 15, 10, 5, 0, 9, 5, 5),
				new LevelInfo (16, 16, 11, 6, 1, 10, 5, 5),
				new LevelInfo (17, 17, 12, 7, 2, 10, 5, 5),
				new LevelInfo (18, 18, 13, 8, 3, 11, 6, 6),
				new LevelInfo (19, 19, 14, 9, 4, 11, 6, 6),
				new LevelInfo (20, 20, 15, 10, 5, 12, 6, 6)
			);

			Tables [CharacterClasses.Gunslinger] = new ClassTable (
				new LevelInfo (1, 1, 0, 0, 0, 2, 2, 0),
				new LevelInfo (2, 2, 0, 0, 0, 3, 3, 0),
				new LevelInfo (3, 3, 0, 0, 0, 3, 3, 1),
				new LevelInfo (4, 4, 0, 0, 0, 4, 4, 1),
				new LevelInfo (5, 5, 0, 0, 0, 4, 4, 1),
				new LevelInfo (6, 6, 1, 0, 0, 5, 5, 2),
				new LevelInfo (7, 7, 2, 0, 0, 5, 5, 2),
				new LevelInfo (8, 8, 3, 0, 0, 6, 6, 2),
				new LevelInfo (9, 9, 4, 0, 0, 6, 6, 3),
				new LevelInfo (10, 10, 5, 0, 0, 7, 7, 3),
				new LevelInfo (11, 11, 6, 1, 0, 7, 7, 3),
				new LevelInfo (12, 12, 7, 2, 0, 8, 8, 4),
				new LevelInfo (13, 13, 8, 3, 0, 8, 8, 4),
				new LevelInfo (14, 14, 9, 4, 0, 9, 9, 4),
				new LevelInfo (15, 15, 10, 5, 0, 9, 9, 5),
				new LevelInfo (16, 16, 11, 6, 1, 10, 10, 5),
				new LevelInfo (17, 17, 12, 7, 2, 10, 10, 5),
				new LevelInfo (18, 18, 13, 8, 3, 11, 11, 6),
				new LevelInfo (19, 19, 14, 9, 4, 11, 11, 6),
				new LevelInfo (20, 20, 15, 10, 5, 12, 12, 6)
			);

			Tables [CharacterClasses.Inquisitor] = new ClassTable (
				new LevelInfo (1, 0, 0, 0, 0, 2, 0, 2),
				new LevelInfo (2, 1, 0, 0, 0, 3, 0, 3),
				new LevelInfo (3, 2, 0, 0, 0, 3, 1, 3),
				new LevelInfo (4, 3, 0, 0, 0, 4, 1, 4),
				new LevelInfo (5, 3, 0, 0, 0, 4, 1, 4),
				new LevelInfo (6, 4, 0, 0, 0, 5, 2, 5),
				new LevelInfo (7, 5, 0, 0, 0, 5, 2, 5),
				new LevelInfo (8, 6, 1, 0, 0, 6, 2, 6),
				new LevelInfo (9, 6, 1, 0, 0, 6, 3, 6),
				new LevelInfo (10, 7, 2, 0, 0, 7, 3, 7),
				new LevelInfo (11, 8, 3, 0, 0, 7, 3, 7),
				new LevelInfo (12, 9, 4, 0, 0, 8, 4, 8),
				new LevelInfo (13, 9, 4, 0, 0, 8, 4, 8),
				new LevelInfo (14, 10, 5, 0, 0, 9, 4, 9),
				new LevelInfo (15, 11, 6, 1, 0, 9, 5, 9),
				new LevelInfo (16, 12, 7, 2, 0, 10, 5, 10),
				new LevelInfo (17, 12, 7, 2, 0, 10, 5, 10),
				new LevelInfo (18, 13, 8, 3, 0, 11, 6, 11),
				new LevelInfo (19, 14, 9, 4, 0, 11, 6, 11),
				new LevelInfo (20, 15, 10, 5, 0, 12, 6, 12)
			);

			Tables [CharacterClasses.Magus] = new ClassTable (
				new LevelInfo (1, 0, 0, 0, 0, 2, 0, 2),
				new LevelInfo (2, 1, 0, 0, 0, 3, 0, 3),
				new LevelInfo (3, 2, 0, 0, 0, 3, 1, 3),
				new LevelInfo (4, 3, 0, 0, 0, 4, 1, 4),
				new LevelInfo (5, 3, 0, 0, 0, 4, 1, 4),
				new LevelInfo (6, 4, 0, 0, 0, 5, 2, 5),
				new LevelInfo (7, 5, 0, 0, 0, 5, 2, 5),
				new LevelInfo (8, 6, 1, 0, 0, 6, 2, 6),
				new LevelInfo (9, 6, 1, 0, 0, 6, 3, 6),
				new LevelInfo (10, 7, 2, 0, 0, 7, 3, 7),
				new LevelInfo (11, 8, 3, 0, 0, 7, 3, 7),
				new LevelInfo (12, 9, 4, 0, 0, 8, 4, 8),
				new LevelInfo (13, 9, 4, 0, 0, 8, 4, 8),
				new LevelInfo (14, 10, 5, 0, 0, 9, 4, 9),
				new LevelInfo (15, 11, 6, 1, 0, 9, 5, 9),
				new LevelInfo (16, 12, 7, 2, 0, 10, 5, 10),
				new LevelInfo (17, 12, 7, 2, 0, 10, 5, 10),
				new LevelInfo (18, 13, 8, 3, 0, 11, 6, 11),
				new LevelInfo (19, 14, 9, 4, 0, 11, 6, 11),
				new LevelInfo (20, 15, 10, 5, 0, 12, 6, 12)
			);

			Tables [CharacterClasses.Monk] = new ClassTable (
				new LevelInfo (1, 0, 0, 0, 0, 2, 2, 2),
				new LevelInfo (2, 1, 0, 0, 0, 3, 3, 3),
				new LevelInfo (3, 2, 0, 0, 0, 3, 3, 3),
				new LevelInfo (4, 3, 0, 0, 0, 4, 4, 4),
				new LevelInfo (5, 3, 0, 0, 0, 4, 4, 4),
				new LevelInfo (6, 4, 0, 0, 0, 5, 5, 5),
				new LevelInfo (7, 5, 0, 0, 0, 5, 5, 5),
				new LevelInfo (8, 6, 1, 0, 0, 6, 6, 6),
				new LevelInfo (9, 6, 1, 0, 0, 6, 6, 6),
				new LevelInfo (10, 7, 2, 0, 0, 7, 7, 7),
				new LevelInfo (11, 8, 3, 0, 0, 7, 7, 7),
				new LevelInfo (12, 9, 4, 0, 0, 8, 8, 8),
				new LevelInfo (13, 9, 4, 0, 0, 8, 8, 8),
				new LevelInfo (14, 10, 5, 0, 0, 9, 9, 9),
				new LevelInfo (15, 11, 6, 1, 0, 9, 9, 9),
				new LevelInfo (16, 12, 7, 2, 0, 10, 10, 10),
				new LevelInfo (17, 12, 7, 2, 0, 10, 10, 10),
				new LevelInfo (18, 13, 8, 3, 0, 11, 11, 11),
				new LevelInfo (19, 14, 9, 4, 0, 11, 11, 11),
				new LevelInfo (20, 15, 10, 5, 0, 12, 12, 12)
			);

			Tables [CharacterClasses.Oracle] = new ClassTable (
				new LevelInfo (1, 0, 0, 0, 0, 0, 0, 2),
				new LevelInfo (2, 1, 0, 0, 0, 0, 0, 3),
				new LevelInfo (3, 2, 0, 0, 0, 1, 1, 3),
				new LevelInfo (4, 3, 0, 0, 0, 1, 1, 4),
				new LevelInfo (5, 3, 0, 0, 0, 1, 1, 4),
				new LevelInfo (6, 4, 0, 0, 0, 2, 2, 5),
				new LevelInfo (7, 5, 0, 0, 0, 2, 2, 5),
				new LevelInfo (8, 6, 1, 0, 0, 2, 2, 6),
				new LevelInfo (9, 6, 1, 0, 0, 3, 3, 6),
				new LevelInfo (10, 7, 2, 0, 0, 3, 3, 7),
				new LevelInfo (11, 8, 3, 0, 0, 3, 3, 7),
				new LevelInfo (12, 9, 4, 0, 0, 4, 4, 8),
				new LevelInfo (13, 9, 4, 0, 0, 4, 4, 8),
				new LevelInfo (14, 10, 5, 0, 0, 4, 4, 9),
				new LevelInfo (15, 11, 6, 1, 0, 5, 5, 9),
				new LevelInfo (16, 12, 7, 2, 0, 5, 5, 10),
				new LevelInfo (17, 12, 7, 2, 0, 5, 5, 10),
				new LevelInfo (18, 13, 8, 3, 0, 6, 6, 11),
				new LevelInfo (19, 14, 9, 4, 0, 6, 6, 11),
				new LevelInfo (20, 15, 10, 5, 0, 6, 6, 12)
			);

			Tables [CharacterClasses.Paladin] = new ClassTable (
				new LevelInfo (1, 1, 0, 0, 0, 2, 0, 2),
				new LevelInfo (2, 2, 0, 0, 0, 3, 0, 3),
				new LevelInfo (3, 3, 0, 0, 0, 3, 1, 3),
				new LevelInfo (4, 4, 0, 0, 0, 4, 1, 4),
				new LevelInfo (5, 5, 0, 0, 0, 4, 1, 4),
				new LevelInfo (6, 6, 1, 0, 0, 5, 2, 5),
				new LevelInfo (7, 7, 2, 0, 0, 5, 2, 5),
				new LevelInfo (8, 8, 3, 0, 0, 6, 2, 6),
				new LevelInfo (9, 9, 4, 0, 0, 6, 3, 6),
				new LevelInfo (10, 10, 5, 0, 0, 7, 3, 7),
				new LevelInfo (11, 11, 6, 1, 0, 7, 3, 7),
				new LevelInfo (12, 12, 7, 2, 0, 8, 4, 8),
				new LevelInfo (13, 13, 8, 3, 0, 8, 4, 8),
				new LevelInfo (14, 14, 9, 4, 0, 9, 4, 9),
				new LevelInfo (15, 15, 10, 5, 0, 9, 5, 9),
				new LevelInfo (16, 16, 11, 6, 1, 10, 5, 10),
				new LevelInfo (17, 17, 12, 7, 2, 10, 5, 10),
				new LevelInfo (18, 18, 13, 8, 3, 11, 6, 11),
				new LevelInfo (19, 19, 14, 9, 4, 11, 6, 11),
				new LevelInfo (20, 20, 15, 10, 5, 12, 6, 12)
			);

			Tables [CharacterClasses.Ranger] = new ClassTable (
				new LevelInfo (1, 1, 0, 0, 0, 2, 2, 0),
				new LevelInfo (2, 2, 0, 0, 0, 3, 3, 0),
				new LevelInfo (3, 3, 0, 0, 0, 3, 3, 1),
				new LevelInfo (4, 4, 0, 0, 0, 4, 4, 1),
				new LevelInfo (5, 5, 0, 0, 0, 4, 4, 1),
				new LevelInfo (6, 6, 1, 0, 0, 5, 5, 2),
				new LevelInfo (7, 7, 2, 0, 0, 5, 5, 2),
				new LevelInfo (8, 8, 3, 0, 0, 6, 6, 2),
				new LevelInfo (9, 9, 4, 0, 0, 6, 6, 3),
				new LevelInfo (10, 10, 5, 0, 0, 7, 7, 3),
				new LevelInfo (11, 11, 6, 1, 0, 7, 7, 3),
				new LevelInfo (12, 12, 7, 2, 0, 8, 8, 4),
				new LevelInfo (13, 13, 8, 3, 0, 8, 8, 4),
				new LevelInfo (14, 14, 9, 4, 0, 9, 9, 4),
				new LevelInfo (15, 15, 10, 5, 0, 9, 9, 5),
				new LevelInfo (16, 16, 11, 6, 1, 10, 10, 5),
				new LevelInfo (17, 17, 12, 7, 2, 10, 10, 5),
				new LevelInfo (18, 18, 13, 8, 3, 11, 11, 6),
				new LevelInfo (19, 19, 14, 9, 4, 11, 11, 6),
				new LevelInfo (20, 20, 15, 10, 5, 12, 12, 6)
			);

			Tables [CharacterClasses.Rogue] = new ClassTable (
				new LevelInfo (1, 0, 0, 0, 0, 0, 2, 0),
				new LevelInfo (2, 1, 0, 0, 0, 0, 3, 0),
				new LevelInfo (3, 2, 0, 0, 0, 1, 3, 1),
				new LevelInfo (4, 3, 0, 0, 0, 1, 4, 1),
				new LevelInfo (5, 3, 0, 0, 0, 1, 4, 1),
				new LevelInfo (6, 4, 0, 0, 0, 2, 5, 2),
				new LevelInfo (7, 5, 0, 0, 0, 2, 5, 2),
				new LevelInfo (8, 6, 1, 0, 0, 2, 6, 2),
				new LevelInfo (9, 6, 1, 0, 0, 3, 6, 3),
				new LevelInfo (10, 7, 2, 0, 0, 3, 7, 3),
				new LevelInfo (11, 8, 3, 0, 0, 3, 7, 3),
				new LevelInfo (12, 9, 4, 0, 0, 4, 8, 4),
				new LevelInfo (13, 9, 4, 0, 0, 4, 8, 4),
				new LevelInfo (14, 10, 5, 0, 0, 4, 9, 4),
				new LevelInfo (15, 11, 6, 1, 0, 5, 9, 5),
				new LevelInfo (16, 12, 7, 2, 0, 5, 10, 5),
				new LevelInfo (17, 12, 7, 2, 0, 5, 10, 5),
				new LevelInfo (18, 13, 8, 3, 0, 6, 11, 6),
				new LevelInfo (19, 14, 9, 4, 0, 6, 11, 6),
				new LevelInfo (20, 15, 10, 5, 0, 6, 12, 6)
			);

			Tables [CharacterClasses.Sorcerer] = new ClassTable (
				new LevelInfo (1, 0, 0, 0, 0, 0, 0, 2),
				new LevelInfo (2, 1, 0, 0, 0, 0, 0, 3),
				new LevelInfo (3, 1, 0, 0, 0, 1, 1, 3),
				new LevelInfo (4, 2, 0, 0, 0, 1, 1, 4),
				new LevelInfo (5, 2, 0, 0, 0, 1, 1, 5),
				new LevelInfo (6, 3, 0, 0, 0, 2, 2, 5),
				new LevelInfo (7, 3, 0, 0, 0, 2, 2, 5),
				new LevelInfo (8, 4, 0, 0, 0, 2, 2, 6),
				new LevelInfo (9, 4, 0, 0, 0, 3, 3, 6),
				new LevelInfo (10, 5, 0, 0, 0, 3, 3, 7),
				new LevelInfo (11, 5, 0, 0, 0, 3, 3, 7),
				new LevelInfo (12, 6, 1, 0, 0, 4, 4, 8),
				new LevelInfo (13, 6, 1, 0, 0, 4, 4, 8),
				new LevelInfo (14, 7, 2, 0, 0, 4, 4, 9),
				new LevelInfo (15, 7, 2, 0, 0, 5, 5, 9),
				new LevelInfo (16, 8, 3, 0, 0, 5, 5, 10),
				new LevelInfo (17, 8, 3, 0, 0, 5, 5, 10),
				new LevelInfo (18, 9, 4, 0, 0, 6, 6, 11),
				new LevelInfo (19, 9, 4, 0, 0, 6, 6, 11),
				new LevelInfo (20, 10, 5, 0, 0, 6, 6, 12)
			);

			Tables [CharacterClasses.Summoner] = new ClassTable (
				new LevelInfo (1, 0, 0, 0, 0, 0, 0, 2),
				new LevelInfo (2, 1, 0, 0, 0, 0, 0, 3),
				new LevelInfo (3, 2, 0, 0, 0, 1, 1, 3),
				new LevelInfo (4, 3, 0, 0, 0, 1, 1, 4),
				new LevelInfo (5, 3, 0, 0, 0, 1, 1, 4),
				new LevelInfo (6, 4, 0, 0, 0, 2, 2, 5),
				new LevelInfo (7, 5, 0, 0, 0, 2, 2, 5),
				new LevelInfo (8, 6, 1, 0, 0, 2, 2, 6),
				new LevelInfo (9, 6, 1, 0, 0, 3, 3, 6),
				new LevelInfo (10, 7, 2, 0, 0, 3, 3, 7),
				new LevelInfo (11, 8, 3, 0, 0, 3, 3, 7),
				new LevelInfo (12, 9, 4, 0, 0, 4, 4, 8),
				new LevelInfo (13, 9, 4, 0, 0, 4, 4, 8),
				new LevelInfo (14, 10, 5, 0, 0, 4, 4, 9),
				new LevelInfo (15, 11, 6, 1, 0, 5, 5, 9),
				new LevelInfo (16, 12, 7, 2, 0, 5, 5, 10),
				new LevelInfo (17, 12, 7, 2, 0, 5, 5, 10),
				new LevelInfo (18, 13, 8, 3, 0, 6, 6, 11),
				new LevelInfo (19, 14, 9, 4, 0, 6, 6, 11),
				new LevelInfo (20, 15, 10, 5, 0, 6, 6, 12)
			);

			Tables [CharacterClasses.Witch] = new ClassTable (
				new LevelInfo (1, 0, 0, 0, 0, 0, 0, 2),
				new LevelInfo (2, 1, 0, 0, 0, 0, 0, 3),
				new LevelInfo (3, 1, 0, 0, 0, 1, 1, 3),
				new LevelInfo (4, 2, 0, 0, 0, 1, 1, 4),
				new LevelInfo (5, 2, 0, 0, 0, 1, 1, 4),
				new LevelInfo (6, 3, 0, 0, 0, 2, 2, 5),
				new LevelInfo (7, 3, 0, 0, 0, 2, 2, 5),
				new LevelInfo (8, 4, 0, 0, 0, 2, 2, 6),
				new LevelInfo (9, 4, 0, 0, 0, 3, 3, 6),
				new LevelInfo (10, 5, 0, 0, 0, 3, 3, 7),
				new LevelInfo (11, 5, 0, 0, 0, 3, 3, 7),
				new LevelInfo (12, 6, 1, 0, 0, 4, 4, 8),
				new LevelInfo (13, 6, 1, 0, 0, 4, 4, 8),
				new LevelInfo (14, 7, 2, 0, 0, 4, 4, 9),
				new LevelInfo (15, 7, 2, 0, 0, 5, 5, 9),
				new LevelInfo (16, 8, 3, 0, 0, 5, 5, 10),
				new LevelInfo (17, 8, 3, 0, 0, 5, 5, 10),
				new LevelInfo (18, 9, 4, 0, 0, 6, 6, 11),
				new LevelInfo (19, 9, 4, 0, 0, 6, 6, 11),
				new LevelInfo (20, 10, 5, 0, 0, 6, 6, 12)
			);

			Tables [CharacterClasses.Wizard] = new ClassTable (
				new LevelInfo (1, 0, 0, 0, 0, 0, 0, 2),
				new LevelInfo (2, 1, 0, 0, 0, 0, 0, 3),
				new LevelInfo (3, 1, 0, 0, 0, 1, 1, 3),
				new LevelInfo (4, 2, 0, 0, 0, 1, 1, 4),
				new LevelInfo (5, 2, 0, 0, 0, 1, 1, 4),
				new LevelInfo (6, 3, 0, 0, 0, 2, 2, 5),
				new LevelInfo (7, 3, 0, 0, 0, 2, 2, 5),
				new LevelInfo (8, 4, 0, 0, 0, 2, 2, 6),
				new LevelInfo (9, 4, 0, 0, 0, 3, 3, 6),
				new LevelInfo (10, 5, 0, 0, 0, 3, 3, 7),
				new LevelInfo (11, 5, 0, 0, 0, 3, 3, 7),
				new LevelInfo (12, 6, 1, 0, 0, 4, 4, 8),
				new LevelInfo (13, 6, 1, 0, 0, 4, 4, 8),
				new LevelInfo (14, 7, 2, 0, 0, 4, 4, 9),
				new LevelInfo (15, 7, 2, 0, 0, 5, 5, 9),
				new LevelInfo (16, 8, 3, 0, 0, 5, 5, 10),
				new LevelInfo (17, 8, 3, 0, 0, 5, 5, 10),
				new LevelInfo (18, 9, 4, 0, 0, 6, 6, 11),
				new LevelInfo (19, 9, 4, 0, 0, 6, 6, 11),
				new LevelInfo (20, 10, 5, 0, 0, 6, 6, 12)
			);
		}
	}
}

