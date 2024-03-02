using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using System.IO;
using System.Diagnostics;
using NpgsqlTypes;
using System.Text.RegularExpressions;
using System.Drawing.Imaging;

namespace newKursBd
{
	public partial class Form3 : Form
	{
		Bitmap image;
		bool isImage;
		byte[] bytes;
		bool isPhoto;
		private static string _connectionString = null;
		private string dogNickNameFromForm4 = null;
		int tabindex;
		int rowID;
		public bool isEditing;
		public static NpgsqlConnection conn;

		public Dictionary<string, int> OwnerNamesAndIDs = new Dictionary<string, int>();
		public Dictionary<string, int> BreedNamesAndIDs = new Dictionary<string, int>();
		public Dictionary<string, int> ClubNamesAndIDs = new Dictionary<string, int>();
		public Dictionary<string, int> RegionNamesAndIDs = new Dictionary<string, int>();
		public Dictionary<string, int> DistrNamesAndIDs = new Dictionary<string, int>();
		public Dictionary<string, int> BankNamesAndIDs = new Dictionary<string, int>();
		public Dictionary<string, int> CityNamesAndIDs = new Dictionary<string, int>();
		public Dictionary<string, int> VenueNamesAndIDs = new Dictionary<string, int>();
		public Dictionary<string, int> NameDogNamesAndIDs = new Dictionary<string, int>();
		public Dictionary<string, int> NameCompNamesAndIDs = new Dictionary<string, int>();
		public Dictionary<string, int> NameAwardNamesAndIDs = new Dictionary<string, int>();
		public Dictionary<string, int> ParNamesAndIDs = new Dictionary<string, int>();
		public Dictionary<string, int> DogNamesAndIDs = new Dictionary<string, int>();


		public Form3(string connect, int tabindex, int rowID = -1, bool ed = false, string dogNickname = null)
		{
			InitializeComponent();
			_connectionString = connect;
			isEditing = ed;
			this.tabindex = tabindex;
			this.rowID = rowID;
			tabControl1.SelectedIndex = tabindex;
			if (isEditing)
			{
				this.Text = "Редактирование  элемента";
			}
			else { this.Text = "Добавление  элемента"; }

			dogNickNameFromForm4 = dogNickname;
		}

		class DBCon
		{

			public static NpgsqlConnection con = new NpgsqlConnection(_connectionString);
			public static NpgsqlCommand cmd = default(NpgsqlCommand);
			public static string sql = string.Empty;

		}
		public Image StrToImg(string StrImg)
		{
			byte[] arraying = Convert.FromBase64String(StrImg);
			Image imageStr = Image.FromStream(new MemoryStream(arraying));
			return imageStr;
		}
		private void label2_Click(object sender, EventArgs e)
		{

		}

		private void button4_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		private void tabControl1_Selected(object sender, TabControlEventArgs e)
		{

		}

		private void LoadPage(int index)
		{
			switch (index)
			{
				case 0:
					DistrNamesAndIDs.Clear();
					DataTable dt = DBFunctions.Read("SELECT district_id, district_name FROM district ORDER BY district_name", _connectionString);
					var IDs = dt.Rows.Cast<DataRow>().Select(x => x.ItemArray[0]).ToArray();
					var names = dt.Rows.Cast<DataRow>().Select(x => x.ItemArray[1]).ToArray();

					for (int i = 0; i < IDs.Count(); i++)
					{
						try
						{
							DistrNamesAndIDs.Add(names[i].ToString(), (int)IDs[i]);
						}
						catch (Exception) { }
					}


					CubDictrcomboBox.Items.AddRange(DistrNamesAndIDs.Keys.ToArray());

					break;
				case 1:

					BankNamesAndIDs.Clear();
					dt = DBFunctions.Read("SELECT bank_id, bank FROM bank ORDER BY bank", _connectionString);
					IDs = dt.Rows.Cast<DataRow>().Select(x => x.ItemArray[0]).ToArray();
					names = dt.Rows.Cast<DataRow>().Select(x => x.ItemArray[1]).ToArray();


					for (int i = 0; i < IDs.Count(); i++)
					{
						try
						{
							BankNamesAndIDs.Add(names[i].ToString(), (int)IDs[i]);
						}
						catch (Exception) { }
					}


					COMPbankcomboBox.Items.AddRange(BankNamesAndIDs.Keys.ToArray());

					CityNamesAndIDs.Clear();
					dt = DBFunctions.Read("SELECT city_id, city FROM city ORDER BY city", _connectionString);
					IDs = dt.Rows.Cast<DataRow>().Select(x => x.ItemArray[0]).ToArray();
					names = dt.Rows.Cast<DataRow>().Select(x => x.ItemArray[1]).ToArray();


					for (int i = 0; i < IDs.Count(); i++)
					{
						try
						{
							CityNamesAndIDs.Add(names[i].ToString(), (int)IDs[i]);
						}
						catch (Exception) { }
					}


					COMPcitycomboBox.Items.AddRange(CityNamesAndIDs.Keys.ToArray());

					VenueNamesAndIDs.Clear();
					dt = DBFunctions.Read("SELECT venue_id, venue FROM venue ORDER BY venue", _connectionString);
					IDs = dt.Rows.Cast<DataRow>().Select(x => x.ItemArray[0]).ToArray();
					names = dt.Rows.Cast<DataRow>().Select(x => x.ItemArray[1]).ToArray();


					for (int i = 0; i < IDs.Count(); i++)
					{
						try
						{
							VenueNamesAndIDs.Add(names[i].ToString(), (int)IDs[i]);
						}
						catch (Exception) { }
					}


					COMPvenuecomboBox.Items.AddRange(VenueNamesAndIDs.Keys.ToArray());
					break;
				case 2:
					//DBCon.con.Open();

					BreedNamesAndIDs.Clear();
					dt = DBFunctions.Read("SELECT breed_id, breed FROM breed  ORDER BY breed", _connectionString);
					IDs = dt.Rows.Cast<DataRow>().Select(x => x.ItemArray[0]).ToArray();
					names = dt.Rows.Cast<DataRow>().Select(x => x.ItemArray[1]).ToArray();


					for (int i = 0; i < IDs.Count(); i++)
					{
						try
						{
							BreedNamesAndIDs.Add(names[i].ToString(), (int)IDs[i]);
						}
						catch (Exception) { }
					}

					DogBreedcomboBox.Items.AddRange(BreedNamesAndIDs.Keys.ToArray());

					ClubNamesAndIDs.Clear();
					dt = DBFunctions.Read("SELECT club_id, club_name FROM club ORDER BY club_name", _connectionString);
					IDs = dt.Rows.Cast<DataRow>().Select(x => x.ItemArray[0]).ToArray();
					names = dt.Rows.Cast<DataRow>().Select(x => x.ItemArray[1]).ToArray();


					for (int i = 0; i < IDs.Count(); i++)
					{
						try
						{
							ClubNamesAndIDs.Add(names[i].ToString(), (int)IDs[i]);
						}
						catch (Exception) { }
					}


					DogClubcomboBox.Items.AddRange(ClubNamesAndIDs.Keys.ToArray());


					OwnerNamesAndIDs.Clear();

					dt = DBFunctions.Read("SELECT owner_id, concat (surname, ' ', name, ' ', midname) \"FullName\" FROM owner ORDER BY \"FullName\"", _connectionString);
					IDs = dt.Rows.Cast<DataRow>().Select(x => x.ItemArray[0]).ToArray();
					names = dt.Rows.Cast<DataRow>().Select(x => x.ItemArray[1]).ToArray();

					for (int i = 0; i < IDs.Count(); i++)
					{
						try
						{
							OwnerNamesAndIDs.Add(names[i].ToString(), (int)IDs[i]);
						}
						catch (Exception) { }
					}

					DogOwnercomboBox.Items.AddRange(OwnerNamesAndIDs.Keys.ToArray());
					//DBCon.con.Close();
					break;

				case 8:
					RegionNamesAndIDs.Clear();
					dt = DBFunctions.Read("SELECT region_id, region FROM region ORDER BY region", _connectionString);
					IDs = dt.Rows.Cast<DataRow>().Select(x => x.ItemArray[0]).ToArray();
					names = dt.Rows.Cast<DataRow>().Select(x => x.ItemArray[1]).ToArray();

					for (int i = 0; i < IDs.Count(); i++)
					{
						try
						{
							RegionNamesAndIDs.Add(names[i].ToString(), (int)IDs[i]);
						}
						catch (Exception) { }
					}

					CityRegcomboBox.Items.AddRange(RegionNamesAndIDs.Keys.ToArray());
					break;

				case 3:

					NameDogNamesAndIDs.Clear();
					dt = DBFunctions.Read("SELECT dog_id, nickname FROM dog  ORDER BY nickname", _connectionString);
					IDs = dt.Rows.Cast<DataRow>().Select(x => x.ItemArray[0]).ToArray();
					names = dt.Rows.Cast<DataRow>().Select(x => x.ItemArray[1]).ToArray();


					for (int i = 0; i < IDs.Count(); i++)
					{
						try
						{
							NameDogNamesAndIDs.Add(names[i].ToString(), (int)IDs[i]);
						}
						catch (Exception) { }
					}


					ParNDogcomboBox.Items.AddRange(NameDogNamesAndIDs.Keys.ToArray());

					//если добавление для определенной собаки
					if (dogNickNameFromForm4 != null)
					{
						ParNDogcomboBox.SelectedItem = dogNickNameFromForm4;
						ParNDogcomboBox.Enabled = false;
					}


					NameCompNamesAndIDs.Clear();
					dt = DBFunctions.Read("SELECT competition_id, compet_name FROM competition ORDER BY compet_name", _connectionString);
					IDs = dt.Rows.Cast<DataRow>().Select(x => x.ItemArray[0]).ToArray();
					names = dt.Rows.Cast<DataRow>().Select(x => x.ItemArray[1]).ToArray();

					for (int i = 0; i < IDs.Count(); i++)
					{
						try
						{
							NameCompNamesAndIDs.Add(names[i].ToString(), (int)IDs[i]);
						}
						catch (Exception) { }
					}


					ParNCompcomboBox.Items.AddRange(NameCompNamesAndIDs.Keys.ToArray());

					break;
				case 4:
					ParNamesAndIDs.Clear();
					dt = DBFunctions.Read("SELECT participant_id, dog.nickname FROM participation " +
						"INNER JOIN dog ON  participation.dog_id=dog.dog_id ORDER BY dog.nickname", _connectionString);
					IDs = dt.Rows.Cast<DataRow>().Select(x => x.ItemArray[0]).ToArray();
					names = dt.Rows.Cast<DataRow>().Select(x => x.ItemArray[1]).ToArray();

					for (int i = 0; i < IDs.Count(); i++)
					{
						try
						{
							ParNamesAndIDs.Add(names[i].ToString(), (int)IDs[i]);
						}
						catch (Exception) { }
					}

					AwardingDcomboBox.Items.AddRange(ParNamesAndIDs.Keys.ToArray());



					NameAwardNamesAndIDs.Clear();
					dt = DBFunctions.Read("SELECT award_id, award_name FROM award ORDER BY award_name", _connectionString);
					IDs = dt.Rows.Cast<DataRow>().Select(x => x.ItemArray[0]).ToArray();
					names = dt.Rows.Cast<DataRow>().Select(x => x.ItemArray[1]).ToArray();

					for (int i = 0; i < IDs.Count(); i++)
					{
						try
						{
							NameAwardNamesAndIDs.Add(names[i].ToString(), (int)IDs[i]);
						}
						catch (Exception) { }
					}

					AwardingNAcomboBox.Items.AddRange(NameAwardNamesAndIDs.Keys.ToArray());
					break;
			}
			if (isEditing == true)
				switch (tabControl1.SelectedIndex)
				{
					case 2:
						DBCon.con.Open();
						DataTable dt = DBFunctions.Read("SELECT nickname, breed.breed, concat (owner.surname, ' ', owner.name, ' ', owner.midname) ownerfullName, club.club_name, year_birth, price, foto FROM dog " +
									   "INNER JOIN owner ON  dog.owner_id=owner.owner_id " +
									   "INNER JOIN breed ON  dog.breed_id = breed.breed_id " +
									   "INNER JOIN club ON  dog.club_id = club.club_id WHERE dog_id = " + rowID, _connectionString);
						var arrayForFindImage = dt.Rows[0].ItemArray.Select(x => x).ToArray();

						DogNameTextBox.Text = arrayForFindImage[0].ToString();
						DogBreedcomboBox.SelectedItem = arrayForFindImage[1].ToString();
						DogOwnercomboBox.SelectedItem = arrayForFindImage[2].ToString();
						DogClubcomboBox.SelectedItem = arrayForFindImage[3].ToString();
						DogYearnumericUpDown.Value = Convert.ToInt32(arrayForFindImage[4]);
						DogPricenumericUpDown.Value = Convert.ToInt32(arrayForFindImage[5]);

						isImage = isPhoto;
						try
						{
							using (var ms = new MemoryStream((byte[])arrayForFindImage[6]))
							{
								image = new Bitmap(ms);
							}

							pictureBoxPhoto.Image = image;
						}
						catch (Exception ex)
						{
							image = null;
							pictureBoxPhoto.Image = null;

						}

						DBCon.con.Close();
						break;
					case 1:
						dt = DBFunctions.Read("SELECT compet_name, bank.bank, pay_account, city.city, venue.venue, date_event, partic_fee, number_viewers FROM competition " +
							"INNER JOIN bank ON  competition.bank_id = bank.bank_id " +
							"INNER JOIN city ON  competition.city_id = city.city_id " +
							"INNER JOIN venue ON  competition.venue_id = venue.venue_id WHERE competition_id = " + rowID, _connectionString);
						var stringArr = dt.Rows[0].ItemArray.Select(x => x.ToString()).ToArray();
						COPMnametextBox.Text = stringArr[0];
						COMPbankcomboBox.SelectedItem = stringArr[1];
						COMPpaytextBox.Text = stringArr[2];
						COMPcitycomboBox.SelectedItem = stringArr[3];
						COMPvenuecomboBox.SelectedItem = stringArr[4];
						CompdateTimePicker.Value = Convert.ToDateTime(stringArr[5]);
						COMPfeenumericUpDown.Value = Convert.ToInt32(stringArr[6]);
						COMPviewersnumericUpDown.Value = Convert.ToInt32(stringArr[7]);
						break;
					case 0:
						dt = DBFunctions.Read("SELECT club_name, district.district_name, address, number, year_opened, ent_fee, licences, end_licences FROM club " +
							"INNER JOIN district ON club.district_id = district.district_id " +
							"WHERE club_id = " + rowID, _connectionString);
						stringArr = dt.Rows[0].ItemArray.Select(x => x.ToString()).ToArray();
						ClubNametextBox.Text = stringArr[0];
						CubDictrcomboBox.SelectedItem = stringArr[1];
						ClubAddresstextBox.Text = stringArr[2];
						ClubNumbertextBox.Text = stringArr[3];
						ClubOpennumericUpDown.Value = Convert.ToInt32(stringArr[4]);
						ClubEntnumericUpDown.Value = Convert.ToInt32(stringArr[5]);
						ClubLicencestextBox.Text = stringArr[6];
						ClubEndLicdateTimePicker.Value = Convert.ToDateTime(stringArr[7]);
						break;
					case 3:
						dt = DBFunctions.Read("SELECT dog.nickname, competition.compet_name FROM participation " +
							"INNER JOIN dog ON dog.dog_id = participation.dog_id " +
							"INNER JOIN competition ON competition.competition_id = participation.competition_id " +
							"WHERE participant_id =" + rowID, _connectionString);
						stringArr = dt.Rows[0].ItemArray.Select(x => x.ToString()).ToArray();
						ParNDogcomboBox.SelectedItem = stringArr[0];
						ParNCompcomboBox.SelectedItem = stringArr[1];
						break;
					case 4:
						dt = DBFunctions.Read("SELECT dog.nickname, award.award_name, competition.compet_name  FROM awarding " +
							"INNER JOIN participation ON participation.participant_id = awarding.participant_id " +
							"INNER JOIN award ON award.award_id = awarding.award_id " +
							"INNER JOIN dog ON dog.dog_id = participation.dog_id " +
							"INNER JOIN competition ON participation.competition_id=competition.competition_id " +
							"WHERE awarding.participant_id =" + rowID, _connectionString);
						stringArr = dt.Rows[0].ItemArray.Select(x => x.ToString()).ToArray();
						AwardingDcomboBox.SelectedItem = stringArr[0];
						AwardingNAcomboBox.SelectedItem = stringArr[1];
						AwardingCompcomboBox.SelectedItem = stringArr[2];
						break;
					case 5:
						dt = DBFunctions.Read("SELECT breed FROM breed " +
							"WHERE breed_id =" + rowID, _connectionString);
						stringArr = dt.Rows[0].ItemArray.Select(x => x.ToString()).ToArray();
						BreedNametextBox.Text = stringArr[0];
						break;
					case 6:
						dt = DBFunctions.Read("SELECT surname, name, midname, address, number FROM owner " +
							"WHERE owner_id =" + rowID, _connectionString);
						stringArr = dt.Rows[0].ItemArray.Select(x => x.ToString()).ToArray();
						OwnerSurnametextBox.Text = stringArr[0];
						OwnerNametextBox.Text = stringArr[1];
						OwnerMidnametextBox.Text = stringArr[2];
						OwnerAddresstextBox.Text = stringArr[3];
						OwnerNumbertextBox.Text = stringArr[4];
						break;
					case 7:
						dt = DBFunctions.Read("SELECT district_name FROM district " +
							"WHERE district_id =" + rowID, _connectionString);
						stringArr = dt.Rows[0].ItemArray.Select(x => x.ToString()).ToArray();
						DistrNametextBox.Text = stringArr[0];
						break;
					case 8:
						dt = DBFunctions.Read("SELECT city, region.region FROM city " +
							"INNER JOIN region ON  city.region_id=region.region_id " +
							"WHERE city_id =" + rowID, _connectionString);
						stringArr = dt.Rows[0].ItemArray.Select(x => x.ToString()).ToArray();
						CityNametextBox.Text = stringArr[0];
						CityRegcomboBox.SelectedItem = stringArr[1];
						break;
					case 9:
						dt = DBFunctions.Read("SELECT region FROM region " +
							"WHERE region_id =" + rowID, _connectionString);
						stringArr = dt.Rows[0].ItemArray.Select(x => x.ToString()).ToArray();
						RegionNametextBox.Text = stringArr[0];
						break;
					case 10:
						dt = DBFunctions.Read("SELECT bank FROM bank " +
							"WHERE bank_id =" + rowID, _connectionString);
						stringArr = dt.Rows[0].ItemArray.Select(x => x.ToString()).ToArray();
						BankNametextBox.Text = stringArr[0];
						break;
					case 11:
						dt = DBFunctions.Read("SELECT venue FROM venue " +
							"WHERE venue_id =" + rowID, _connectionString);
						stringArr = dt.Rows[0].ItemArray.Select(x => x.ToString()).ToArray();
						VenueNametextBox.Text = stringArr[0];
						break;
					case 12:
						dt = DBFunctions.Read("SELECT award_name, cash_eq FROM award " +
							"WHERE award_id =" + rowID, _connectionString);
						stringArr = dt.Rows[0].ItemArray.Select(x => x.ToString()).ToArray();
						AwardNametextBox.Text = stringArr[0];
						AwardCashnumericUpDown.Value = Convert.ToInt32(stringArr[1]);
						break;
				}
		}
		private void DogNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar != (char)Keys.Back)
			{
				string Symbol = e.KeyChar.ToString();

				if (!Regex.Match(Symbol, @"[а-яА-Я-\s]").Success)
				{
					e.Handled = true;
				}
			}
		}

		private void AwardNametextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar != (char)Keys.Back)
			{
				string Symbol = e.KeyChar.ToString();

				if (!Regex.Match(Symbol, @"[а-яА-Я-\s]").Success)
				{
					e.Handled = true;
				}
			}
		}

		private void VenueNametextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar != (char)Keys.Back)
			{
				string Symbol = e.KeyChar.ToString();

				if (!Regex.Match(Symbol, @"[а-яА-Я-\s]").Success)
				{
					e.Handled = true;
				}
			}
		}
		private void BreedNametextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar != (char)Keys.Back)
			{
				string Symbol = e.KeyChar.ToString();

				if (!Regex.Match(Symbol, @"[а-яА-Я-\s]").Success)
				{
					e.Handled = true;
				}
			}
		}

		private void BankNametextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar != (char)Keys.Back)
			{
				string Symbol = e.KeyChar.ToString();

				if (!Regex.Match(Symbol, @"[а-яА-Я-\s]").Success)
				{
					e.Handled = true;
				}
			}
		}

		private void RegionNametextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar != (char)Keys.Back)
			{
				string Symbol = e.KeyChar.ToString();

				if (!Regex.Match(Symbol, @"[а-яА-Я-\s]").Success)
				{
					e.Handled = true;
				}
			}
		}
		private void CityNametextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar != (char)Keys.Back)
			{
				string Symbol = e.KeyChar.ToString();

				if (!Regex.Match(Symbol, @"[а-яА-Я-\s]").Success)
				{
					e.Handled = true;
				}
			}
		}
		private void DistrNametextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar != (char)Keys.Back)
			{
				string Symbol = e.KeyChar.ToString();

				if (!Regex.Match(Symbol, @"[а-яА-Я-\s]").Success)
				{
					e.Handled = true;
				}
			}
		}

		private void OwnerSurnametextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar != (char)Keys.Back)
			{
				string Symbol = e.KeyChar.ToString();

				if (!Regex.Match(Symbol, @"[а-яА-Я-\s]").Success)
				{
					e.Handled = true;
				}
			}
		}
		private void OwnerNametextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar != (char)Keys.Back)
			{
				string Symbol = e.KeyChar.ToString();

				if (!Regex.Match(Symbol, @"[а-яА-Я-\s]").Success)
				{
					e.Handled = true;
				}
			}
		}
		private void OwnerMidnametextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar != (char)Keys.Back)
			{
				string Symbol = e.KeyChar.ToString();

				if (!Regex.Match(Symbol, @"[а-яА-Я-\s]").Success)
				{
					e.Handled = true;
				}
			}
		}
		private void ClubNametextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar != (char)Keys.Back)
			{
				string Symbol = e.KeyChar.ToString();

				if (!Regex.Match(Symbol, @"[а-яА-Я-\s]").Success)
				{
					e.Handled = true;
				}
			}
		}
		private void OwnerNumbertextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar != (char)Keys.Back)
			{
				char num = e.KeyChar;
				if (!Char.IsDigit(num) || OwnerNumbertextBox.Text.Length == 9)
				{
					e.Handled = true;
				}
			}
		}
		private void ClubNumbertextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar != (char)Keys.Back)
			{
				char num = e.KeyChar;
				if (!Char.IsDigit(num) || ClubNumbertextBox.Text.Length == 9)
				{
					e.Handled = true;
				}
			}
		}
		private void ClubLicencestextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar != (char)Keys.Back)
			{
				char num = e.KeyChar;
				if (!Char.IsDigit(num) || ClubLicencestextBox.Text.Length == 6)
				{
					e.Handled = true;
				}
			}
		}
		private void COPMnametextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar != (char)Keys.Back)
			{
				string Symbol = e.KeyChar.ToString();

				if (!Regex.Match(Symbol, @"[а-яА-Я-\s]").Success)
				{
					e.Handled = true;
				}
			}
		}
		private void COMPpaytextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar != (char)Keys.Back)
			{
				char num = e.KeyChar;
				if (!Char.IsDigit(num) || COMPpaytextBox.Text.Length == 4)
				{
					e.Handled = true;
				}
			}
		}

		//ДОБАВИТЬ ФОТО
		private void DogButton_Click(object sender, EventArgs e)
		{
			DBCon.con.Open();
			bool isOk = true;
			bool isOk2 = true;
			string error = "";
			if (DogNameTextBox.Text == "")
			{
				isOk = false;
				isOk2 = false;
				error += "Поле 'кличка' не может быть пустым.";
				DBCon.con.Close();
			}
			if (DogOwnercomboBox.SelectedIndex == -1)
			{
				isOk = false;
				isOk2 = false;
				error += "\nНе выбран хозяин";
				DBCon.con.Close();
			}
			if (DogBreedcomboBox.SelectedIndex == -1)
			{
				isOk = false;
				isOk2 = false;
				error += "\nНе выбрана порода";
				DBCon.con.Close();
			}
			if (DogClubcomboBox.SelectedIndex == -1)
			{
				isOk = false;
				isOk2 = false;
				error += "\nНе выбран клуб";
				DBCon.con.Close();
			}
			if (isOk)
			{
				try
				{
					OwnerNamesAndIDs.TryGetValue(DogOwnercomboBox.Text, out int ownerID);
					BreedNamesAndIDs.TryGetValue(DogBreedcomboBox.Text, out int breedID);
					ClubNamesAndIDs.TryGetValue(DogClubcomboBox.Text, out int clubID);


					if (isEditing == false)
					{
						DBCon.sql = "INSERT INTO public.dog(nickname, owner_id, breed_id, club_id, year_birth, price, foto) " +
							$"VALUES ('{DogNameTextBox.Text}', @owner_id, @breed_id, @club_id, @year_birth, @price, @foto)";
						DBCon.cmd = new NpgsqlCommand(DBCon.sql, DBCon.con);
						DBCon.cmd.Parameters.AddWithValue("owner_id", ownerID);
						DBCon.cmd.Parameters.AddWithValue("breed_id", breedID);
						DBCon.cmd.Parameters.AddWithValue("club_id", clubID);
						DBCon.cmd.Parameters.AddWithValue("year_birth", Convert.ToInt32(DogYearnumericUpDown.Value));
						DBCon.cmd.Parameters.AddWithValue("price", Convert.ToInt32(DogPricenumericUpDown.Value));
						ImageConverter converter = new ImageConverter();
						DBCon.cmd.Parameters.AddWithValue("foto", NpgsqlTypes.NpgsqlDbType.Bytea, (byte[])converter.ConvertTo(image, typeof(byte[])));
						DBCon.cmd.ExecuteNonQuery();

						MessageBox.Show("Добавлено!", "Добавление", MessageBoxButtons.OK, MessageBoxIcon.Information);
						DBCon.con.Close();
						this.Close();
					}
					else
					{


						DBCon.sql = $"UPDATE public.dog SET nickname=@nickname, owner_id=@owner_id, breed_id=@breed_id, club_id=@club_id, year_birth=@year_birth, price=@price, foto=@foto " +
							"WHERE dog_id = " + rowID;
						DBCon.cmd = new NpgsqlCommand(DBCon.sql, DBCon.con);
						DBCon.cmd.Parameters.AddWithValue("nickname", DogNameTextBox.Text);
						DBCon.cmd.Parameters.AddWithValue("owner_id", ownerID);
						DBCon.cmd.Parameters.AddWithValue("breed_id", breedID);
						DBCon.cmd.Parameters.AddWithValue("club_id", clubID);
						DBCon.cmd.Parameters.AddWithValue("year_birth", Convert.ToInt32(DogYearnumericUpDown.Value));
						DBCon.cmd.Parameters.AddWithValue("price", Convert.ToInt32(DogPricenumericUpDown.Value));
						ImageConverter converter = new ImageConverter();
						DBCon.cmd.Parameters.AddWithValue("foto", NpgsqlTypes.NpgsqlDbType.Bytea, (byte[])converter.ConvertTo(image, typeof(byte[])));
						DBCon.cmd.ExecuteNonQuery();

						MessageBox.Show("Изменено!", "Редактирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
						DBCon.con.Close();
						this.Close();
					}

				}
				catch (NpgsqlException ne)
				{
					MessageBox.Show(ne.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				finally
				{
					DBCon.con.Close();
				}

			}
			else
			{
				MessageBox.Show(error, "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void COMPbutton_Click(object sender, EventArgs e)
		{
			DBCon.con.Open();
			bool isOk = true;
			bool isOk2 = true;
			string error = "";
			if (COPMnametextBox.Text == "")
			{
				isOk = false;
				isOk2 = false;
				error += "Поле 'название соревнования' не может быть пустым.";
				DBCon.con.Close();
			}
			if (COMPbankcomboBox.SelectedIndex == -1)
			{
				isOk = false;
				isOk2 = false;
				error += "\nНе выбран банк";
				DBCon.con.Close();
			}
			if (COMPpaytextBox.Text == "")
			{
				isOk = false;
				isOk2 = false;
				error += "Поле 'расчётный счёт' не может быть пустым.";
				DBCon.con.Close();
			}
			if (COMPcitycomboBox.SelectedIndex == -1)
			{
				isOk = false;
				isOk2 = false;
				error += "\nНе выбран город";
				DBCon.con.Close();
			}
			if (COMPvenuecomboBox.SelectedIndex == -1)
			{
				isOk = false;
				isOk2 = false;
				error += "\nНе выбрано место проведения соревнования";
				DBCon.con.Close();
			}
			if (isOk)
			{
				try
				{
					BankNamesAndIDs.TryGetValue(COMPbankcomboBox.Text, out int bankID);
					CityNamesAndIDs.TryGetValue(COMPcitycomboBox.Text, out int cityID);
					VenueNamesAndIDs.TryGetValue(COMPvenuecomboBox.Text, out int venueID);

					if (isEditing == false)
					{
						DBCon.sql = "INSERT INTO public.competition (compet_name, bank_id, pay_account, city_id, venue_id, date_event, partic_fee, number_viewers) " +
						"VALUES (@compet_name, @bank_id, @pay_account, @city_id, @venue_id, @date_event, @partic_fee, @number_viewers)";
						DBCon.cmd = new NpgsqlCommand(DBCon.sql, DBCon.con);
						DBCon.cmd.Parameters.AddWithValue("compet_name", COPMnametextBox.Text);
						DBCon.cmd.Parameters.AddWithValue("bank_id", bankID);
						DBCon.cmd.Parameters.AddWithValue("pay_account", Int32.Parse(COMPpaytextBox.Text));
						DBCon.cmd.Parameters.AddWithValue("city_id", cityID);
						DBCon.cmd.Parameters.AddWithValue("venue_id", venueID);
						DBCon.cmd.Parameters.AddWithValue("date_event", NpgsqlTypes.NpgsqlDbType.Date, CompdateTimePicker.Value);
						DBCon.cmd.Parameters.AddWithValue("partic_fee", Convert.ToInt32(COMPfeenumericUpDown.Value));
						DBCon.cmd.Parameters.AddWithValue("number_viewers", Convert.ToInt32(COMPviewersnumericUpDown.Value));
						DBCon.cmd.ExecuteNonQuery();

						MessageBox.Show("Добавлено!", "Добавление", MessageBoxButtons.OK, MessageBoxIcon.Information);
						DBCon.con.Close();
						this.Close();

					}
					else
					{
						DBCon.sql = "UPDATE public.competition SET compet_name=@compet_name, bank_id=@bank_id, pay_account=@pay_account, city_id=@city_id, venue_id=@venue_id, date_event=@date_event, partic_fee=@partic_fee, number_viewers=@number_viewers " +
							"WHERE competition_id = " + rowID;
						DBCon.cmd = new NpgsqlCommand(DBCon.sql, DBCon.con);
						DBCon.cmd.Parameters.AddWithValue("compet_name", COPMnametextBox.Text);
						DBCon.cmd.Parameters.AddWithValue("bank_id", bankID);
						DBCon.cmd.Parameters.AddWithValue("pay_account", Int32.Parse(COMPpaytextBox.Text));
						DBCon.cmd.Parameters.AddWithValue("city_id", cityID);
						DBCon.cmd.Parameters.AddWithValue("venue_id", venueID);
						DBCon.cmd.Parameters.AddWithValue("date_event", NpgsqlTypes.NpgsqlDbType.Date, CompdateTimePicker.Value);
						DBCon.cmd.Parameters.AddWithValue("partic_fee", Convert.ToInt32(COMPfeenumericUpDown.Value));
						DBCon.cmd.Parameters.AddWithValue("number_viewers", Convert.ToInt32(COMPviewersnumericUpDown.Value));
						DBCon.cmd.ExecuteNonQuery();

						MessageBox.Show("Изменено!", "Редактирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
						DBCon.con.Close();
						this.Close();
					}

				}
				catch (NpgsqlException ne)
				{
					MessageBox.Show(ne.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				finally
				{
					DBCon.con.Close();
				}

			}
			else
			{
				MessageBox.Show(error, "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void ClubButton_Click(object sender, EventArgs e)
		{
			DBCon.con.Open();
			bool isOk = true;
			bool isOk2 = true;
			string error = "";
			if (ClubNametextBox.Text == "")
			{
				isOk = false;
				isOk2 = false;
				error += "Поле 'название клуба' не может быть пустым.";
				DBCon.con.Close();
			}
			if (CubDictrcomboBox.SelectedIndex == -1)
			{
				isOk = false;
				isOk2 = false;
				error += "\nНе выбран район";
				DBCon.con.Close();
			}
			if (ClubAddresstextBox.Text == "")
			{
				isOk = false;
				isOk2 = false;
				error += "Поле 'адрес' не может быть пустым.";
				DBCon.con.Close();
			}
			if (ClubNumbertextBox.Text == "")
			{
				isOk = false;
				isOk2 = false;
				error += "Поле 'номер' не может быть пустым.";
				DBCon.con.Close();
			}
			if (ClubLicencestextBox.Text == "")
			{
				isOk = false;
				isOk2 = false;
				error += "Поле 'номер лицензии' не может быть пустым.";
				DBCon.con.Close();
			}
			if (isOk)
			{
				try
				{
					DistrNamesAndIDs.TryGetValue(CubDictrcomboBox.Text, out int distrID);

					if (isEditing == false)
					{
						DBCon.sql = "INSERT INTO public.club(club_name, district_id, address, number, year_opened, ent_fee, licences, end_licences) " +
						"VALUES (@club_name, @district_id, @address, @number, @year_opened, @ent_fee, @licences, @end_licences)";
						DBCon.cmd = new NpgsqlCommand(DBCon.sql, DBCon.con);
						DBCon.cmd.Parameters.AddWithValue("club_name", ClubNametextBox.Text);
						DBCon.cmd.Parameters.AddWithValue("district_id", distrID);
						DBCon.cmd.Parameters.AddWithValue("address", ClubAddresstextBox.Text);
						DBCon.cmd.Parameters.AddWithValue("number", Int32.Parse(ClubNumbertextBox.Text));
						DBCon.cmd.Parameters.AddWithValue("year_opened", Convert.ToInt32(ClubOpennumericUpDown.Value));
						DBCon.cmd.Parameters.AddWithValue("ent_fee", Convert.ToInt32(ClubEntnumericUpDown.Value));
						DBCon.cmd.Parameters.AddWithValue("licences", Int32.Parse(ClubLicencestextBox.Text));
						DBCon.cmd.Parameters.AddWithValue("end_licences", NpgsqlTypes.NpgsqlDbType.Date, ClubEndLicdateTimePicker.Value);
						DBCon.cmd.ExecuteNonQuery();

						MessageBox.Show("Добавлено!", "Добавление", MessageBoxButtons.OK, MessageBoxIcon.Information);
						DBCon.con.Close();
						this.Close();
					}
					else
					{
						DBCon.sql = "UPDATE public.club SET club_name=@club_name, district_id=@district_id, address=@address, number=@number, year_opened=@year_opened, ent_fee=@ent_fee, licences=@licences, end_licences=@end_licences " +
									"WHERE club_id = " + rowID;
						DBCon.cmd = new NpgsqlCommand(DBCon.sql, DBCon.con);
						DBCon.cmd.Parameters.AddWithValue("club_name", ClubNametextBox.Text);
						DBCon.cmd.Parameters.AddWithValue("district_id", distrID);
						DBCon.cmd.Parameters.AddWithValue("address", ClubAddresstextBox.Text);
						DBCon.cmd.Parameters.AddWithValue("number", Int32.Parse(ClubNumbertextBox.Text));
						DBCon.cmd.Parameters.AddWithValue("year_opened", Convert.ToInt32(ClubOpennumericUpDown.Value));
						DBCon.cmd.Parameters.AddWithValue("ent_fee", Convert.ToInt32(ClubEntnumericUpDown.Value));
						DBCon.cmd.Parameters.AddWithValue("licences", Int32.Parse(ClubLicencestextBox.Text));
						DBCon.cmd.Parameters.AddWithValue("end_licences", NpgsqlTypes.NpgsqlDbType.Date, ClubEndLicdateTimePicker.Value);
						DBCon.cmd.ExecuteNonQuery();

						MessageBox.Show("Изменено!", "Редактирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
						DBCon.con.Close();
						this.Close();
					}
				}
				catch (NpgsqlException ne)
				{
					MessageBox.Show(ne.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				finally
				{
					DBCon.con.Close();
				}

			}
			else
			{
				MessageBox.Show(error, "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}
		private void BreedButton_Click(object sender, EventArgs e)
		{
			DBCon.con.Open();
			bool isOk = true;
			bool isOk2 = true;
			string error = "";
			if (BreedNametextBox.Text == "")
			{
				isOk = false;
				isOk2 = false;
				error += "Поле 'название породы' не может быть пустым.";
				DBCon.con.Close();


			}
			if (isOk)
			{
				try
				{
					if (isEditing == false)
					{
						DBCon.sql = "INSERT INTO public.breed (breed) VALUES (@breed)";
						DBCon.cmd = new NpgsqlCommand(DBCon.sql, DBCon.con);
						DBCon.cmd.Parameters.AddWithValue("breed", BreedNametextBox.Text);
						DBCon.cmd.ExecuteNonQuery();


						MessageBox.Show("Добавлено!", "Добавление", MessageBoxButtons.OK, MessageBoxIcon.Information);
						DBCon.con.Close();
						this.Close();
					}
					else
					{
						DBCon.sql = "UPDATE public.breed SET breed=@breed " +
									"WHERE breed_id = " + rowID;
						DBCon.cmd = new NpgsqlCommand(DBCon.sql, DBCon.con);
						DBCon.cmd.Parameters.AddWithValue("breed", BreedNametextBox.Text);
						MessageBox.Show("Изменено!", "Редактирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
						DBCon.cmd.ExecuteNonQuery();
						DBCon.con.Close();
						this.Close();
					}
				}
				catch (NpgsqlException ne)
				{
					MessageBox.Show(ne.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				finally
				{
					DBCon.con.Close();
				}

			}
			else
			{
				MessageBox.Show(error, "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void OwnerButton_Click(object sender, EventArgs e)
		{
			DBCon.con.Open();
			bool isOk = true;
			bool isOk2 = true;
			string error = "";
			if (OwnerSurnametextBox.Text == "")
			{
				isOk = false;
				isOk2 = false;
				error += "Поле 'фамилия' не может быть пустым.";
				DBCon.con.Close();
			}
			if (OwnerNametextBox.Text == "")
			{
				isOk = false;
				isOk2 = false;
				error += "Поле 'имя' не может быть пустым.";
				DBCon.con.Close();
			}
			if (OwnerMidnametextBox.Text == "")
			{
				isOk = false;
				isOk2 = false;
				error += "Поле 'отчесто' не может быть пустым.";
				DBCon.con.Close();
			}
			if (OwnerAddresstextBox.Text == "")
			{
				isOk = false;
				isOk2 = false;
				error += "Поле 'адрес' не может быть пустым.";
				DBCon.con.Close();
			}
			if (OwnerNumbertextBox.Text == "")
			{
				isOk = false;
				isOk2 = false;
				error += "Поле 'номер' не может быть пустым.";
				DBCon.con.Close();
			}
			if (isOk)
			{
				try
				{
					if (isEditing == false)
					{
						DBCon.sql = "INSERT INTO public.owner(surname, name, midname, address, number) " +
						"VALUES (@surname, @name, @midname, @address, @number)";
						DBCon.cmd = new NpgsqlCommand(DBCon.sql, DBCon.con);
						DBCon.cmd.Parameters.AddWithValue("surname", OwnerSurnametextBox.Text);
						DBCon.cmd.Parameters.AddWithValue("name", OwnerNametextBox.Text);
						DBCon.cmd.Parameters.AddWithValue("midname", OwnerMidnametextBox.Text);
						DBCon.cmd.Parameters.AddWithValue("address", OwnerAddresstextBox.Text);
						DBCon.cmd.Parameters.AddWithValue("number", Int32.Parse(OwnerNumbertextBox.Text));
						DBCon.cmd.ExecuteNonQuery();


						MessageBox.Show("Добавлено!", "Добавление", MessageBoxButtons.OK, MessageBoxIcon.Information);
						DBCon.con.Close();
						this.Close();
					}
					else
					{
						DBCon.sql = "UPDATE public.owner SET surname=@surname, name=@name, midname=@midname, address=@address, number=@number " +
									"WHERE owner_id = " + rowID;
						DBCon.cmd = new NpgsqlCommand(DBCon.sql, DBCon.con);
						DBCon.cmd.Parameters.AddWithValue("surname", OwnerSurnametextBox.Text);
						DBCon.cmd.Parameters.AddWithValue("name", OwnerNametextBox.Text);
						DBCon.cmd.Parameters.AddWithValue("midname", OwnerMidnametextBox.Text);
						DBCon.cmd.Parameters.AddWithValue("address", OwnerAddresstextBox.Text);
						DBCon.cmd.Parameters.AddWithValue("number", Int32.Parse(OwnerNumbertextBox.Text));

						MessageBox.Show("Изменено!", "Редактирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
						DBCon.cmd.ExecuteNonQuery();
						DBCon.con.Close();
						this.Close();
					}
				}
				catch (NpgsqlException ne)
				{
					MessageBox.Show(ne.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				finally
				{
					DBCon.con.Close();
				}

			}
			else
			{
				MessageBox.Show(error, "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}

		private void DictrButton_Click(object sender, EventArgs e)
		{
			DBCon.con.Open();
			bool isOk = true;
			bool isOk2 = true;
			string error = "";
			if (DistrNametextBox.Text == "")
			{
				isOk = false;
				isOk2 = false;
				error += "Поле 'название района' не может быть пустым.";
				DBCon.con.Close();
			}
			if (isOk)
			{
				try
				{
					if (isEditing == false)
					{
						DBCon.sql = "INSERT INTO public.district(district_name) " +
						"VALUES (@district_name)";
						DBCon.cmd = new NpgsqlCommand(DBCon.sql, DBCon.con);
						DBCon.cmd.Parameters.AddWithValue("district_name", DistrNametextBox.Text);
						DBCon.cmd.ExecuteNonQuery();


						MessageBox.Show("Добавлено!", "Добавление", MessageBoxButtons.OK, MessageBoxIcon.Information);
						DBCon.con.Close();
						this.Close();

					}
					else
					{
						DBCon.sql = "UPDATE public.district SET district_name=@district_name " +
									"WHERE district_id = " + rowID;
						DBCon.cmd = new NpgsqlCommand(DBCon.sql, DBCon.con);
						DBCon.cmd.Parameters.AddWithValue("district_name", DistrNametextBox.Text);

						MessageBox.Show("Изменено!", "Редактирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
						DBCon.cmd.ExecuteNonQuery();
						DBCon.con.Close();
						this.Close();
					}
				}
				catch (NpgsqlException ne)
				{
					MessageBox.Show(ne.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				finally
				{
					DBCon.con.Close();
				}

			}
			else
			{
				MessageBox.Show(error, "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void CityButton_Click(object sender, EventArgs e)
		{
			DBCon.con.Open();
			bool isOk = true;
			bool isOk2 = true;
			string error = "";
			if (CityNametextBox.Text == "")
			{
				isOk = false;
				isOk2 = false;
				error += "Поле 'название города' не может быть пустым.";
				DBCon.con.Close();
			}
			if (CityRegcomboBox.SelectedIndex == -1)
			{
				isOk = false;
				isOk2 = false;
				error += "\nНе выбрана область";
				DBCon.con.Close();
			}
			if (isOk)
			{
				try
				{
					RegionNamesAndIDs.TryGetValue(CityRegcomboBox.Text, out int regionID);

					if (isEditing == false)
					{
						DBCon.sql = "INSERT INTO public.city(city, region_id) " +
						"VALUES (@city, @region_id)";
						DBCon.cmd = new NpgsqlCommand(DBCon.sql, DBCon.con);
						DBCon.cmd.Parameters.AddWithValue("city", CityNametextBox.Text);
						DBCon.cmd.Parameters.AddWithValue("region_id", regionID);
						DBCon.cmd.ExecuteNonQuery();

						MessageBox.Show("Добавлено!", "Добавление", MessageBoxButtons.OK, MessageBoxIcon.Information);
						DBCon.con.Close();
						this.Close();
					}
					else
					{
						DBCon.sql = "UPDATE public.city SET city=@city, region_id=@region_id " +
									"WHERE city_id = " + rowID;
						DBCon.cmd = new NpgsqlCommand(DBCon.sql, DBCon.con);
						DBCon.cmd.Parameters.AddWithValue("city", CityNametextBox.Text);
						DBCon.cmd.Parameters.AddWithValue("region_id", regionID);

						MessageBox.Show("Изменено!", "Редактирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
						DBCon.cmd.ExecuteNonQuery();
						DBCon.con.Close();
						this.Close();
					}
				}
				catch (NpgsqlException ne)
				{
					MessageBox.Show(ne.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				finally
				{
					DBCon.con.Close();
				}

			}
			else
			{
				MessageBox.Show(error, "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}

		private void RigButton_Click(object sender, EventArgs e)
		{
			DBCon.con.Open();
			bool isOk = true;
			bool isOk2 = true;
			string error = "";
			if (RegionNametextBox.Text == "")
			{
				isOk = false;
				isOk2 = false;
				error += "Поле 'название области' не может быть пустым.";
				DBCon.con.Close();
			}
			if (isOk)
			{
				try
				{
					if (isEditing == false)
					{
						DBCon.sql = "INSERT INTO public.region(region) " +
												"VALUES (@region)";
						DBCon.cmd = new NpgsqlCommand(DBCon.sql, DBCon.con);
						DBCon.cmd.Parameters.AddWithValue("region", RegionNametextBox.Text);
						DBCon.cmd.ExecuteNonQuery();


						MessageBox.Show("Добавлено!", "Добавление", MessageBoxButtons.OK, MessageBoxIcon.Information);
						DBCon.con.Close();
						this.Close();
					}
					else
					{
						DBCon.sql = "UPDATE public.region SET region=@region " +
									"WHERE region_id = " + rowID;
						DBCon.cmd = new NpgsqlCommand(DBCon.sql, DBCon.con);
						DBCon.cmd.Parameters.AddWithValue("region", RegionNametextBox.Text);

						MessageBox.Show("Изменено!", "Редактирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
						DBCon.cmd.ExecuteNonQuery();
						DBCon.con.Close();
						this.Close();
					}
				}
				catch (NpgsqlException ne)
				{
					MessageBox.Show(ne.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				finally
				{
					DBCon.con.Close();
				}

			}
			else
			{
				MessageBox.Show(error, "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}

		private void BankButton_Click(object sender, EventArgs e)
		{
			DBCon.con.Open();
			bool isOk = true;
			bool isOk2 = true;
			string error = "";
			if (BankNametextBox.Text == "")
			{
				isOk = false;
				isOk2 = false;
				error += "Поле 'название банка' не может быть пустым.";
				DBCon.con.Close();
			}
			if (isOk)
			{
				try
				{
					if (isEditing == false)
					{
						DBCon.sql = "INSERT INTO public.bank(bank) " +
												"VALUES (@bank)";
						DBCon.cmd = new NpgsqlCommand(DBCon.sql, DBCon.con);
						DBCon.cmd.Parameters.AddWithValue("bank", BankNametextBox.Text);
						DBCon.cmd.ExecuteNonQuery();


						MessageBox.Show("Добавлено!", "Добавление", MessageBoxButtons.OK, MessageBoxIcon.Information);
						DBCon.con.Close();
						this.Close();
					}
					else
					{
						DBCon.sql = "UPDATE public.bank SET bank=@bank " +
									"WHERE bank_id = " + rowID;
						DBCon.cmd = new NpgsqlCommand(DBCon.sql, DBCon.con);
						DBCon.cmd.Parameters.AddWithValue("bank", BankNametextBox.Text);

						MessageBox.Show("Изменено!", "Редактирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
						DBCon.cmd.ExecuteNonQuery();
						DBCon.con.Close();
						this.Close();
					}
				}
				catch (NpgsqlException ne)
				{
					MessageBox.Show(ne.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				finally
				{
					DBCon.con.Close();
				}

			}
			else
			{
				MessageBox.Show(error, "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}

		private void VenueButton_Click(object sender, EventArgs e)
		{
			DBCon.con.Open();
			bool isOk = true;
			bool isOk2 = true;
			string error = "";
			if (VenueNametextBox.Text == "")
			{
				isOk = false;
				isOk2 = false;
				error += "Поле 'место проведения соревнования' не может быть пустым.";
				DBCon.con.Close();
			}
			if (isOk)
			{
				try
				{
					if (isEditing == false)
					{
						DBCon.sql = "INSERT INTO public.venue(venue) " +
						"VALUES (@venue)";
						DBCon.cmd = new NpgsqlCommand(DBCon.sql, DBCon.con);
						DBCon.cmd.Parameters.AddWithValue("venue", VenueNametextBox.Text);
						DBCon.cmd.ExecuteNonQuery();


						MessageBox.Show("Добавлено!", "Добавление", MessageBoxButtons.OK, MessageBoxIcon.Information);
						DBCon.con.Close();
						this.Close();
					}
					else
					{
						DBCon.sql = "UPDATE public.venue SET venue=@venue " +
									"WHERE venue_id = " + rowID;
						DBCon.cmd = new NpgsqlCommand(DBCon.sql, DBCon.con);
						DBCon.cmd.Parameters.AddWithValue("venue", VenueNametextBox.Text);

						MessageBox.Show("Изменено!", "Редактирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
						DBCon.cmd.ExecuteNonQuery();
						DBCon.con.Close();
						this.Close();
					}
				}
				catch (NpgsqlException ne)
				{
					MessageBox.Show(ne.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				finally
				{
					DBCon.con.Close();
				}

			}
			else
			{
				MessageBox.Show(error, "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}

		private void AwardBtton_Click(object sender, EventArgs e)
		{
			DBCon.con.Open();
			bool isOk = true;
			bool isOk2 = true;
			string error = "";
			if (AwardNametextBox.Text == "")
			{
				isOk = false;
				isOk2 = false;
				error += "Поле 'награды' не может быть пустым.";
				DBCon.con.Close();
			}
			if (isOk)
			{
				try
				{
					if (isEditing == false)
					{
						DBCon.sql = "INSERT INTO public.award(award_name, cash_eq) " +
						"VALUES (@award_name, @cash_eq)";
						DBCon.cmd = new NpgsqlCommand(DBCon.sql, DBCon.con);
						DBCon.cmd.Parameters.AddWithValue("award_name", AwardNametextBox.Text);
						DBCon.cmd.Parameters.AddWithValue("cash_eq", Convert.ToInt32(AwardCashnumericUpDown.Value));
						DBCon.cmd.ExecuteNonQuery();


						MessageBox.Show("Добавлено!", "Добавление", MessageBoxButtons.OK, MessageBoxIcon.Information);
						DBCon.con.Close();
						this.Close();
					}
					else
					{
						DBCon.sql = "UPDATE public.award SET award_name=@award_name, cash_eq=@cash_eq " +
									"WHERE award_id = " + rowID;
						DBCon.cmd = new NpgsqlCommand(DBCon.sql, DBCon.con);
						DBCon.cmd.Parameters.AddWithValue("award_name", AwardNametextBox.Text);
						DBCon.cmd.Parameters.AddWithValue("cash_eq", Convert.ToInt32(AwardCashnumericUpDown.Value));

						MessageBox.Show("Изменено!", "Редактирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
						DBCon.cmd.ExecuteNonQuery();
						DBCon.con.Close();
						this.Close();
					}
				}
				catch (NpgsqlException ne)
				{
					MessageBox.Show(ne.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				finally
				{
					DBCon.con.Close();
				}

			}
			else
			{
				MessageBox.Show(error, "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}


		}

		private void PartButton_Click(object sender, EventArgs e)
		{
			DBCon.con.Open();
			bool isOk = true;
			bool isOk2 = true;
			string error = "";

			if (ParNDogcomboBox.SelectedIndex == -1)
			{
				isOk = false;
				isOk2 = false;
				error += "\nНе выбрана кличка";
				DBCon.con.Close();
			}
			if (ParNCompcomboBox.SelectedIndex == -1)
			{
				isOk = false;
				isOk2 = false;
				error += "\nНе выбрано соревнование";
				DBCon.con.Close();
			}
			if (isOk)
			{
				try
				{
					NameDogNamesAndIDs.TryGetValue(ParNDogcomboBox.Text, out int dogID);
					NameCompNamesAndIDs.TryGetValue(ParNCompcomboBox.Text, out int compID);

					if (isEditing == false)
					{
						DBCon.sql = "INSERT INTO public.participation(dog_id, competition_id) " +
						"VALUES (@dog_id, @competition_id)";
						DBCon.cmd = new NpgsqlCommand(DBCon.sql, DBCon.con);
						DBCon.cmd.Parameters.AddWithValue("dog_id", dogID);
						DBCon.cmd.Parameters.AddWithValue("competition_id", compID);
						DBCon.cmd.ExecuteNonQuery();

						MessageBox.Show("Добавлено!", "Добавление", MessageBoxButtons.OK, MessageBoxIcon.Information);
						DBCon.con.Close();
					}
					else
					{
						DBCon.sql = $"UPDATE  public.participation SET dog_id=@dog_id, competition_id=@competition_id " +
							"WHERE participant_id = " + rowID;
						DBCon.cmd = new NpgsqlCommand(DBCon.sql, DBCon.con);
						DBCon.cmd.Parameters.AddWithValue("dog_id", dogID);
						DBCon.cmd.Parameters.AddWithValue("competition_id", compID);
						DBCon.cmd.ExecuteNonQuery();

						MessageBox.Show("Изменено!", "Редактирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
						DBCon.con.Close();
					}



					this.Close();

				}
				catch (NpgsqlException ne)
				{
					MessageBox.Show(ne.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				finally
				{
					DBCon.con.Close();
				}

			}
			else
			{
				MessageBox.Show(error, "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}

		private void AwardingButton_Click(object sender, EventArgs e)
		{
			DBCon.con.Open();
			bool isOk = true;
			bool isOk2 = true;
			string error = "";

			if (AwardingDcomboBox.SelectedIndex == -1)
			{
				isOk = false;
				isOk2 = false;
				error += "\nНе выбрана кличка";
				DBCon.con.Close();
			}
			if (AwardingCompcomboBox.SelectedIndex == -1)
			{
				isOk = false;
				isOk2 = false;
				error += "\nНе выбрано соревнование";
				DBCon.con.Close();
			}
			if (AwardingNAcomboBox.SelectedIndex == -1)
			{
				isOk = false;
				isOk2 = false;
				error += "\nНе выбрана награда";
				DBCon.con.Close();
			}
			if (isOk)
			{
				try
				{
					ParNamesAndIDs.TryGetValue(AwardingDcomboBox.Text, out int parID);
					//NameCompNamesAndIDs.TryGetValue(AwardingCompcomboBox.Text, out int compID);
					NameAwardNamesAndIDs.TryGetValue(AwardingNAcomboBox.Text, out int awardID);

					if (isEditing == false)
					{

						DBCon.sql = "INSERT INTO public.awarding(participant_id, award_id) " +
						"VALUES (@participant_id, @award_id)";
						DBCon.cmd = new NpgsqlCommand(DBCon.sql, DBCon.con);
						DBCon.cmd.Parameters.AddWithValue("participant_id", parID);
						DBCon.cmd.Parameters.AddWithValue("award_id", awardID);
						DBCon.cmd.ExecuteNonQuery();

						MessageBox.Show("Добавлено!", "Добавление", MessageBoxButtons.OK, MessageBoxIcon.Information);
						DBCon.con.Close();
					}
					else
					{
						DBCon.sql = $"UPDATE  public.awarding SET participant_id=@participant_id, award_id=@award_id " +
							"WHERE awarding_id = " + rowID;
						DBCon.cmd = new NpgsqlCommand(DBCon.sql, DBCon.con);
						DBCon.cmd.Parameters.AddWithValue("participant_id", parID);
						DBCon.cmd.Parameters.AddWithValue("award_id", awardID);
						DBCon.cmd.ExecuteNonQuery();

						MessageBox.Show("Изменено!", "Редактирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
						DBCon.con.Close();
					}

					this.Close();
				}
				catch (NpgsqlException ne)
				{
					MessageBox.Show(ne.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				finally
				{
					DBCon.con.Close();
				}

			}
			else
			{
				MessageBox.Show(error, "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		private void button3_Click(object sender, EventArgs e)
		{
			DogNameTextBox.Clear();
			DogBreedcomboBox.SelectedIndex = -1;
			DogOwnercomboBox.SelectedIndex = -1;
			DogYearnumericUpDown.Value = 2017;
			DogClubcomboBox.SelectedIndex = -1;
			DogPricenumericUpDown.Value = 1000;
		}

		private void button6_Click(object sender, EventArgs e)
		{
			COPMnametextBox.Clear();
			COMPbankcomboBox.SelectedIndex = -1;
			COMPpaytextBox.Clear();
			COMPcitycomboBox.SelectedIndex = -1;
			COMPvenuecomboBox.SelectedIndex = -1;
			CompdateTimePicker.Value = DateTime.Today;
			COMPfeenumericUpDown.Value = 500;
			COMPviewersnumericUpDown.Value = 100;
		}

		private void button8_Click(object sender, EventArgs e)
		{
			ClubNametextBox.Clear();
			CubDictrcomboBox.SelectedIndex = -1;
			ClubAddresstextBox.Clear();
			ClubNumbertextBox.Clear();
			ClubOpennumericUpDown.Value = 1950;
			ClubEntnumericUpDown.Value = 500;
			ClubLicencestextBox.Clear();
			ClubEndLicdateTimePicker.Value = DateTime.Today;

		}

		private void button10_Click(object sender, EventArgs e)
		{
			BreedNametextBox.Clear();
		}

		private void button12_Click(object sender, EventArgs e)
		{
			OwnerSurnametextBox.Clear();
			OwnerNametextBox.Clear();
			OwnerMidnametextBox.Clear();
			OwnerAddresstextBox.Clear();
			OwnerNumbertextBox.Clear();
		}

		private void button14_Click(object sender, EventArgs e)
		{
			DistrNametextBox.Clear();

		}

		private void button18_Click(object sender, EventArgs e)
		{
			CityNametextBox.Clear();
			CityRegcomboBox.SelectedIndex = -1;

		}

		private void button16_Click(object sender, EventArgs e)
		{
			RegionNametextBox.Clear();
		}

		private void button20_Click(object sender, EventArgs e)
		{
			BankNametextBox.Clear();

		}

		private void button22_Click(object sender, EventArgs e)
		{
			VenueNametextBox.Clear();

		}

		private void button24_Click(object sender, EventArgs e)
		{
			AwardNametextBox.Clear();
			AwardCashnumericUpDown.Value = 1000;
		}



		private void AddFotobutton_Click(object sender, EventArgs e)
		{

			OpenFileDialog openDialog = new OpenFileDialog();
			openDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
			if (openDialog.ShowDialog() == DialogResult.OK)
			{
				try
				{
					image = new Bitmap(openDialog.FileName);
					isImage = true;
					using (var ms = new MemoryStream())
					{
						image.Save(ms, ImageFormat.Jpeg);
						bytes = ms.ToArray();
					}
					pictureBoxPhoto.Image = image;
				}
				catch
				{
					DialogResult result = MessageBox.Show("Невозможно открыть выбранный файл",
					"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void DeleteFotobutton_Click(object sender, EventArgs e)
		{
			image = null;
			isImage = false;
			pictureBoxPhoto.Image = null;
			//if (pictureBoxPhoto.Image != null)
			//{
			//	pictureBoxPhoto.Image = null;
			//}

		}

		private void tabPage8_Click(object sender, EventArgs e)
		{

		}

		private void ParNDogcomboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			NameDogNamesAndIDs.TryGetValue(ParNDogcomboBox.Text, out int dogID);
			DBCon.con.Open();
			DataTable dt = DBFunctions.Read("SELECT breed.breed, concat (owner.surname, ' ', owner.name, ' ', owner.midname) ownerfullName, club.club_name FROM dog INNER JOIN owner ON  dog.owner_id=owner.owner_id " +
				"INNER JOIN breed ON  dog.breed_id = breed.breed_id " +
				"INNER JOIN club ON  dog.club_id = club.club_id WHERE dog_id = " + dogID, _connectionString);
			var stringArr = dt.Rows[0].ItemArray.Select(x => x.ToString()).ToArray();
			ParBreedtextBox.Text = stringArr[0];
			ParOwnertextBox.Text = stringArr[1];
			ParClubtextBox.Text = stringArr[2];
			DBCon.con.Close();

		}

		private void ParNCompcomboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			NameCompNamesAndIDs.TryGetValue(ParNCompcomboBox.Text, out int compID);
			DBCon.con.Open();
			DataTable dt = DBFunctions.Read("SELECT   city.city, venue.venue, date_event FROM competition " +
			   "INNER JOIN city ON  competition.city_id = city.city_id " +
			   "INNER JOIN venue ON  competition.venue_id = venue.venue_id " +
			   "WHERE competition_id = " + compID, _connectionString);
			var stringArr = dt.Rows[0].ItemArray.Select(x => x.ToString()).ToArray();
			ParCitytextBox.Text = stringArr[0];
			ParVenuetextBox.Text = stringArr[1];
			ParDatetextBox.Text = stringArr[2].Substring(0, 10);
			DBCon.con.Close();
		}

		private void AwardingDcomboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			NameDogNamesAndIDs.TryGetValue(AwardingDcomboBox.Text, out int dogID);
			ParNamesAndIDs.TryGetValue(AwardingDcomboBox.Text, out int parID);
			DBCon.con.Open();
			DataTable dt = DBFunctions.Read("SELECT breed.breed, concat (owner.surname, ' ', owner.name, ' ', owner.midname) ownerfullName, club.club_name FROM participation " +
				"INNER JOIN dog ON  participation.dog_id = dog.dog_id " +
				"INNER JOIN owner ON  dog.owner_id = owner.owner_id " +
				"INNER JOIN breed ON  dog.breed_id = breed.breed_id " +
				"INNER JOIN club ON  dog.club_id = club.club_id WHERE participant_id  = " + parID, _connectionString);
			var stringArr = dt.Rows[0].ItemArray.Select(x => x.ToString()).ToArray();
			AwardingNBreedtextBox.Text = stringArr[0];
			AwardingNOwnertextBox.Text = stringArr[1];
			AwardingNClubtextBox.Text = stringArr[2];

			NameCompNamesAndIDs.Clear();
			dt = DBFunctions.Read("SELECT competition.competition_id, competition.compet_name FROM participation " +
				"INNER JOIN competition ON  participation.competition_id=competition.competition_id WHERE participant_id = " + parID, _connectionString);
			var IDs = dt.Rows.Cast<DataRow>().Select(x => x.ItemArray[0]).ToArray();
			var names = dt.Rows.Cast<DataRow>().Select(x => x.ItemArray[1]).ToArray();

			try
			{
				for (int i = 0; i < IDs.Count(); i++)
				{
					NameCompNamesAndIDs.Add(names[i].ToString(), (int)IDs[i]);
				}
			}
			catch (Exception) { }

			AwardingCompcomboBox.Items.AddRange(NameCompNamesAndIDs.Keys.ToArray());
			DBCon.con.Close();

		}

		private void AwardingCompcomboBox_SelectedIndexChanged(object sender, EventArgs e)
		{


		}

		private void AwardingNAcomboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			NameAwardNamesAndIDs.TryGetValue(AwardingNAcomboBox.Text, out int awardID);
			DBCon.con.Open();
			DataTable dt = DBFunctions.Read("SELECT award.cash_eq FROM award WHERE award.award_id = " + awardID, _connectionString);
			var stringArr = dt.Rows[0].ItemArray.Select(x => x.ToString()).ToArray();
			AwardingCashtextBox.Text = stringArr[0];

			DBCon.con.Close();
		}

		private void Form3_Load(object sender, EventArgs e)
		{
			LoadPage(tabControl1.SelectedIndex);
		}

		private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
			tabControl1.SelectedIndex = tabindex;

		}
	}
}
