using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DBGenerator1
{
	public static class Generator
	{
		public static string[] MSurnames { get; private set; }
		public static string[] MNames { get; private set; }
		public static string[] MMidnames { get; private set; }
		public static string[] FSurnames { get; private set; }
		public static string[] FNames { get; private set; }
		public static string[] FMidnames { get; private set; }
		public static string[] MDogName { get; private set; }
		public static string[] FDogName { get; private set; }
		public static string[] Cities { get; private set; }
		public static string[] Banks { get; private set; }
		public static string[] Addresses { get; private set; }
		public static string[] Venues { get; private set; }
		public static string[] ClubNames { get; private set; }
		public static string[] Awards { get; private set; }
		public static string[] Regions { get; private set; }
		public static string[] Breeds { get; private set; }
		public static string[] Distrs { get; private set; }
		public static string[] ComptName { get; private set; }

		static Random random = new Random();
		static public bool isFilesLoaded = false; // загружены ли все файлы для генерации

		static Generator()
		{
			try
			{
				MSurnames = File.ReadAllLines(@"files\мфамилии.txt", Encoding.UTF8);
				MNames = File.ReadAllLines(@"files\мимена.txt", Encoding.UTF8);
				MMidnames = File.ReadAllLines(@"files\мотчества.txt", Encoding.UTF8);
				FSurnames = File.ReadAllLines(@"files\жфамилии.txt", Encoding.UTF8);
				FNames = File.ReadAllLines(@"files\жимена.txt", Encoding.UTF8);
				FMidnames = File.ReadAllLines(@"files\жотчества.txt", Encoding.UTF8);
				MDogName = File.ReadAllLines(@"files\мклички.txt", Encoding.UTF8);
				FDogName = File.ReadAllLines(@"files\жклички.txt", Encoding.UTF8);
				Cities = File.ReadAllLines(@"files\города.txt", Encoding.UTF8);
				Banks = File.ReadAllLines(@"files\банки.txt", Encoding.UTF8);
				Addresses = File.ReadAllLines(@"files\Адреса.txt", Encoding.UTF8);
				Venues = File.ReadAllLines(@"files\место проведения.txt", Encoding.UTF8);
				ClubNames = File.ReadAllLines(@"files\Названия_клубов.txt", Encoding.UTF8);
				Awards = File.ReadAllLines(@"files\награды.txt", Encoding.UTF8);
				Regions = File.ReadAllLines(@"files\области.txt", Encoding.UTF8);
				Breeds = File.ReadAllLines(@"files\породы.txt", Encoding.UTF8);
				Distrs = File.ReadAllLines(@"files\районы.txt", Encoding.UTF8);
				ComptName = File.ReadAllLines(@"files\названия_соревнований.txt", Encoding.UTF8);
				isFilesLoaded = true;
			}
			catch (Exception ex)
			{
				isFilesLoaded = false;
				MessageBox.Show(ex.ToString());
			}
		}

		public static string[] GenerateFullName(bool sex)
		{
			if (!isFilesLoaded) return null;

			string[] fullName = new string[3];
			if (!sex) // Женщина
			{
				fullName[0] = FSurnames[random.Next(0, FSurnames.Count())];
				fullName[1] = FNames[random.Next(0, FNames.Count())];
				fullName[2] = FMidnames[random.Next(0, FMidnames.Count())];

				return fullName;
			}

			//мужчина
			fullName[0] = MSurnames[random.Next(0, MSurnames.Count())];
			fullName[1] = MNames[random.Next(0, MNames.Count())];
			fullName[2] = MMidnames[random.Next(0, MMidnames.Count())];

			return fullName;
		}

		public static string GenerateDogName(bool sex)
		{
			if (!isFilesLoaded) return null;

			string DogName = null;
			if (!sex) // сучка
			{
				DogName = FDogName[random.Next(0, FDogName.Count())];
				return DogName;
			}

			//кабель
			DogName = MDogName[random.Next(0, MDogName.Count())];
			return DogName;
		}
		public static string GenerateLine(string lineName)
		{
			if (!isFilesLoaded) return null;

			string generatedLine;
			switch (lineName)
			{
				case "city":
					generatedLine = Cities[random.Next(0, Cities.Count())];
					break;
				case "bank":
					generatedLine = Banks[random.Next(0, Banks.Count())];
					break;
				case "address":
					generatedLine = Addresses[random.Next(0, Addresses.Count())];
					break;
				case "venue":
					generatedLine = Venues[random.Next(0, Venues.Count())];
					break;
				case "award":
					generatedLine = Awards[random.Next(0, Awards.Count())];
					break;
				case "clubNames":
					generatedLine = ClubNames[random.Next(0, ClubNames.Count())];
					break;
				case "comptName":
					generatedLine = ComptName[random.Next(0, ComptName.Count())];
					break;
				case "region":
					generatedLine = Regions[random.Next(0, Regions.Count())];
					break;
				case "breed":
					generatedLine = Breeds[random.Next(0, Breeds.Count())];
					break;
				case "district":
					generatedLine = Distrs[random.Next(0, Distrs.Count())];
					break;

				default:
					generatedLine = null;
					break;
			}
			return generatedLine;
		}

		public static string[] GenerateFullDirectory(string directoryName)
		{
			if (!isFilesLoaded) return null;

			List<string> directory = new List<string>();
			switch (directoryName)
			{
				case "city":
					foreach (var line in Cities)
					{
						directory.Add(line);
					}
					break;
				case "bank":
					foreach (var line in Banks)
					{
						directory.Add(line);
					}
					break;
				case "venue":
					foreach (var line in Venues)
					{
						directory.Add(line);
					}
					break;
				case "award":
					foreach (var line in Awards)
					{
						directory.Add(line);
					}
					break;
				case "region":
					foreach (var line in Regions)
					{
						directory.Add(line);
					}
					break;
				case "breed":
					foreach (var line in Breeds)
					{
						directory.Add(line);
					}
					break;
				case "district":
					foreach (var line in Distrs)
					{
						directory.Add(line);
					}
					break;

				default:
					directory = null;
					break;
			}
			return directory.ToArray();
		}

		public static string GeneratePhoneNumber()
		{
			if (!isFilesLoaded) return null;

			string number = random.Next(1000, 10000).ToString();
			number += random.Next(10000, 100000).ToString();
			return number;
		}
	}
}
