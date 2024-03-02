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

namespace newKursBd
{
	public partial class SearchForm : Form
	{
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

		public string theSearchCommand = null;
		private static string _connectionString = null;
		private int _tabIndex = 0;

		public SearchForm(string connString, int index)
		{
			InitializeComponent();
			_connectionString = connString;
			_tabIndex = index;
			tabControl1.SelectedIndex = index;
		}

		public static DataTable Read(string cmd, string connString)
		{
			try
			{
				using (var conn = new NpgsqlConnection(_connectionString))
				{
					conn.Open();
					DataTable dt = new DataTable();

					using (var command = new NpgsqlCommand(cmd, conn))
					{
						NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd, conn);
						da.Fill(dt);
					}
					return dt;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return null;
			}
		}

		private void label22_Click(object sender, EventArgs e)
		{

		}

		private void COMPpaytextBox_KeyPress(object sender, KeyPressEventArgs e)
		{

		}

		private void COPMnametextBox_KeyPress(object sender, KeyPressEventArgs e)
		{

		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{

		}

		private void DogNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
		{

		}

		private void label2_Click(object sender, EventArgs e)
		{

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
		private void SearchClubbutton_Click(object sender, EventArgs e)
		{
			string searchCommand = "SELECT * FROM all_club_view ";

			if (ClubNamecomboBox.SelectedItem != null)
			{
				searchCommand += $"WHERE club_name = '{ClubNamecomboBox.Text}' ";
			}
			if (CubDictrcomboBox.SelectedItem != null)
			{
				searchCommand += (searchCommand.Contains("WHERE")) ? "AND " : "WHERE ";
				searchCommand += $"district_name = '{CubDictrcomboBox.Text}' ";
			}
			if (!String.IsNullOrEmpty(ClubNumbertextBox.Text.Trim()))
			{
				searchCommand += (searchCommand.Contains("WHERE")) ? "AND " : "WHERE ";
				searchCommand += $"number = '{ClubNumbertextBox.Text.Trim()}' ";
			}
			if (checkBox1.Checked)
			{
				if (Int32.TryParse(ClubYearOpMaskedTextBox1.Text.Trim('_'), out int opyear1) && Int32.TryParse(ClubYearOpMaskedTextBox2.Text.Trim('_'), out int opyear2))
				{
					searchCommand += (searchCommand.Contains("WHERE")) ? "AND " : "WHERE ";
					searchCommand += $"year_opened >= {opyear1} AND year_opened <= {opyear2} ";
				}
				else if (Int32.TryParse(ClubYearOpMaskedTextBox1.Text.Trim('_'), out opyear1))
				{
					searchCommand += (searchCommand.Contains("WHERE")) ? "AND " : "WHERE ";
					searchCommand += $"year_opened >= {opyear1} ";
				}
				else if (Int32.TryParse(ClubYearOpMaskedTextBox2.Text.Trim('_'), out opyear2))
				{
					searchCommand += (searchCommand.Contains("WHERE")) ? "AND " : "WHERE ";
					searchCommand += $"year_opened <= {opyear2} ";
				}
			}
			if (checkBox2.Checked)
			{
				if (Int32.TryParse(maskedTextBox3.Text.Trim('_'), out int sum1) && Int32.TryParse(maskedTextBox4.Text.Trim('_'), out int sum2))
				{
					searchCommand += (searchCommand.Contains("WHERE")) ? "AND " : "WHERE ";
					searchCommand += $"ent_fee >= {sum1} AND ent_fee <= {sum2} ";
				}
				else if (Int32.TryParse(maskedTextBox3.Text.Trim('_'), out sum1))
				{
					searchCommand += (searchCommand.Contains("WHERE")) ? "AND " : "WHERE ";
					searchCommand += $"ent_fee >= {sum1} ";
				}
				else if (Int32.TryParse(maskedTextBox4.Text.Trim('_'), out sum2))
				{
					searchCommand += (searchCommand.Contains("WHERE")) ? "AND " : "WHERE ";
					searchCommand += $"ent_fee <= {sum2} ";
				}
			}
			if (ClubEndLicYNcheckBox.Checked)
			{
				searchCommand += (searchCommand.Contains("WHERE")) ? "AND " : "WHERE ";
				searchCommand += $"end_licences >= '{ClubEndLicdateTimePicker1.Value.Year}-{ClubEndLicdateTimePicker1.Value.Month}-{ClubEndLicdateTimePicker1.Value.Day}' " +
					$"AND end_licences <= '{ClubEndLicdateTimePicker2.Value.Year}-{ClubEndLicdateTimePicker2.Value.Month}-{ClubEndLicdateTimePicker2.Value.Day}' ";
			}

			theSearchCommand = searchCommand;
			this.Close();
		}

		private void LoadBoxes(int index)
		{
			switch (index)
			{
				// Клубы
				case 0:
					DistrNamesAndIDs.Clear();
					DataTable dt = Read("SELECT district_id, district_name FROM district ORDER BY district_name", _connectionString);
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

					ClubNamesAndIDs.Clear();
					dt = Read("SELECT club_id, club_name FROM club ORDER BY club_name", _connectionString);
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


					ClubNamecomboBox.Items.AddRange(ClubNamesAndIDs.Keys.ToArray());

					break;

				// Соревнования
				case 1:

					NameCompNamesAndIDs.Clear();
					dt = Read("SELECT competition_id, compet_name FROM competition ORDER BY compet_name", _connectionString);
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


					COMPNamecomboBox.Items.AddRange(NameCompNamesAndIDs.Keys.ToArray());

					BankNamesAndIDs.Clear();
					dt = Read("SELECT bank_id, bank FROM bank ORDER BY bank", _connectionString);
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
					dt = Read("SELECT city_id, city FROM city ORDER BY city", _connectionString);
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
					dt = Read("SELECT venue_id, venue FROM venue ORDER BY venue", _connectionString);
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

				// Собаки 
				case 2:

					NameDogNamesAndIDs.Clear();
					dt = Read("SELECT dog_id, dog.nickname FROM dog ORDER BY dog.nickname", _connectionString);
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


					DogNamecomboBox.Items.AddRange(NameDogNamesAndIDs.Keys.ToArray());

					BreedNamesAndIDs.Clear();
					dt = Read("SELECT breed_id, breed FROM breed  ORDER BY breed", _connectionString);
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
					dt = Read("SELECT club_id, club_name FROM club ORDER BY club_name", _connectionString);
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

					dt = Read("SELECT owner_id, concat (surname, ' ', name, ' ', midname) FullName FROM owner ORDER BY FullName", _connectionString);
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

					break;

				// Участие
				case 3:

					NameDogNamesAndIDs.Clear();
					dt = Read("SELECT dog_id, nickname FROM dog  ORDER BY nickname", _connectionString);
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


					PartDogNamecomboBox.Items.AddRange(NameDogNamesAndIDs.Keys.ToArray());

					NameCompNamesAndIDs.Clear();
					dt = Read("SELECT competition_id, compet_name FROM competition ORDER BY compet_name", _connectionString);
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


					PartCompNamecomboBox.Items.AddRange(NameCompNamesAndIDs.Keys.ToArray());

					break;

				// Награждение
				case 4:

					ParNamesAndIDs.Clear();
					dt = Read("SELECT participant_id, dog.nickname FROM participation " +
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


					AwardingDogNamecomboBox.Items.AddRange(ParNamesAndIDs.Keys.ToArray());

					NameCompNamesAndIDs.Clear();
					dt = Read("SELECT competition_id, compet_name FROM competition", _connectionString);
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


					AwardingCompNamecomboBox.Items.AddRange(NameCompNamesAndIDs.Keys.ToArray());

					NameAwardNamesAndIDs.Clear();
					dt = Read("SELECT award_id, award_name FROM award ORDER BY award_name", _connectionString);
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

				// Породы
				case 5:

					BreedNamesAndIDs.Clear();
					dt = Read("SELECT breed_id, breed FROM breed  ORDER BY breed", _connectionString);
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


					BreedNamecomboBox.Items.AddRange(BreedNamesAndIDs.Keys.ToArray());

					break;

				// Хозяева
				case 6:

					break;

				// Районы
				case 7:

					DistrNamesAndIDs.Clear();
					dt = Read("SELECT district_id, district_name FROM district ORDER BY district_name", _connectionString);
					IDs = dt.Rows.Cast<DataRow>().Select(x => x.ItemArray[0]).ToArray();
					names = dt.Rows.Cast<DataRow>().Select(x => x.ItemArray[1]).ToArray();


					for (int i = 0; i < IDs.Count(); i++)
					{
						try
						{
							DistrNamesAndIDs.Add(names[i].ToString(), (int)IDs[i]);
						}
						catch (Exception) { }
					}


					DistrNamecomboBox.Items.AddRange(DistrNamesAndIDs.Keys.ToArray());

					break;

				// Города
				case 8:

					CityNamesAndIDs.Clear();
					dt = Read("SELECT city_id, city FROM city ORDER BY city", _connectionString);
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


					CityNamecomboBox.Items.AddRange(CityNamesAndIDs.Keys.ToArray());

					RegionNamesAndIDs.Clear();
					dt = Read("SELECT region_id, region FROM region ORDER BY region", _connectionString);
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

				// Области
				case 9:

					RegionNamesAndIDs.Clear();
					dt = Read("SELECT region_id, region FROM region ORDER BY region", _connectionString);
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


					RegionNamecomboBox.Items.AddRange(RegionNamesAndIDs.Keys.ToArray());

					break;

				// Банки
				case 10:

					BankNamesAndIDs.Clear();
					dt = Read("SELECT bank_id, bank FROM bank ORDER BY bank", _connectionString);
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


					BankNamecomboBox.Items.AddRange(BankNamesAndIDs.Keys.ToArray());

					break;

				// Место
				case 11:

					VenueNamesAndIDs.Clear();
					dt = Read("SELECT venue_id, venue FROM venue ORDER BY venue", _connectionString);
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


					VenueNamecomboBox.Items.AddRange(VenueNamesAndIDs.Keys.ToArray());

					break;

				// Награды
				case 12:

					NameAwardNamesAndIDs.Clear();
					dt = Read("SELECT award_id, award_name FROM award ORDER BY award_name", _connectionString);
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


					AwardNamecomboBox.Items.AddRange(NameAwardNamesAndIDs.Keys.ToArray());

					break;
			}
		}

		private void SearchForm_Load(object sender, EventArgs e)
		{
			LoadBoxes(_tabIndex);
		}

		private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
			tabControl1.SelectedIndex = _tabIndex;
		}

		private void SearchCOMPbutton_Click(object sender, EventArgs e)
		{
			string searchCommand = "SELECT * FROM all_comp_view ";

			if (COMPNamecomboBox.SelectedItem != null)
			{
				searchCommand += $"WHERE compet_name = '{COMPNamecomboBox.Text}' ";
			}
			if (COMPbankcomboBox.SelectedItem != null)
			{
				searchCommand += (searchCommand.Contains("WHERE")) ? "AND " : "WHERE ";
				searchCommand += $"bank = '{COMPbankcomboBox.Text}' ";
			}
			if (COMPcitycomboBox.SelectedItem != null)
			{
				searchCommand += (searchCommand.Contains("WHERE")) ? "AND " : "WHERE ";
				searchCommand += $"city = '{COMPcitycomboBox.Text}' ";
			}
			if (COMPvenuecomboBox.SelectedItem != null)
			{
				searchCommand += (searchCommand.Contains("WHERE")) ? "AND " : "WHERE ";
				searchCommand += $"venue = '{COMPvenuecomboBox.Text}' ";
			}
			if (CompdateYNcheckBox.Checked)
			{
				searchCommand += (searchCommand.Contains("WHERE")) ? "AND " : "WHERE ";
				searchCommand += $"date_event >= '{CompdateTimePicker1.Value.Year}-{CompdateTimePicker1.Value.Month}-{CompdateTimePicker1.Value.Day}' " +
					$"AND date_event <= '{CompdateTimePicker2.Value.Year}-{CompdateTimePicker2.Value.Month}-{CompdateTimePicker2.Value.Day}' ";
			}
			if (checkBox3.Checked)
			{
				if (Int32.TryParse(maskedTextBox1.Text.Trim('_'), out int sum1) && Int32.TryParse(maskedTextBox2.Text.Trim('_'), out int sum2))
				{
					searchCommand += (searchCommand.Contains("WHERE")) ? "AND " : "WHERE ";
					searchCommand += $"partic_fee >= {sum1} AND partic_fee <= {sum2} ";
				}
				else if (Int32.TryParse(maskedTextBox1.Text.Trim('_'), out sum1))
				{
					searchCommand += (searchCommand.Contains("WHERE")) ? "AND " : "WHERE ";
					searchCommand += $"partic_fee >= {sum1} ";
				}
				else if (Int32.TryParse(maskedTextBox2.Text.Trim('_'), out sum2))
				{
					searchCommand += (searchCommand.Contains("WHERE")) ? "AND " : "WHERE ";
					searchCommand += $"partic_fee <= {sum2} ";
				}
			}
			if (checkBox4.Checked)
			{
				if (Int32.TryParse(maskedTextBox5.Text.Trim('_'), out int count1) && Int32.TryParse(maskedTextBox6.Text.Trim('_'), out int count2))
				{
					searchCommand += (searchCommand.Contains("WHERE")) ? "AND " : "WHERE ";
					searchCommand += $"number_viewers >= {count1} AND number_viewers <= {count2} ";
				}
				else if (Int32.TryParse(maskedTextBox5.Text.Trim('_'), out count1))
				{
					searchCommand += (searchCommand.Contains("WHERE")) ? "AND " : "WHERE ";
					searchCommand += $"number_viewers >= {count1} ";
				}
				else if (Int32.TryParse(maskedTextBox6.Text.Trim('_'), out count2))
				{
					searchCommand += (searchCommand.Contains("WHERE")) ? "AND " : "WHERE ";
					searchCommand += $"number_viewers <= {count2} ";
				}
			}

			theSearchCommand = searchCommand;
			this.Close();
		}

		private void SearchDogbutton_Click(object sender, EventArgs e)
		{
			string searchCommand = "SELECT * FROM dog_view ";

			if (DogNamecomboBox.SelectedItem != null)
			{
				searchCommand += $"WHERE nickname = '{DogNamecomboBox.Text}' ";
			}
			if (DogOwnercomboBox.SelectedItem != null)
			{
				searchCommand += (searchCommand.Contains("WHERE")) ? "AND " : "WHERE ";
				searchCommand += $"ownerfullName = '{DogOwnercomboBox.Text}' ";
			}
			if (DogBreedcomboBox.SelectedItem != null)
			{
				searchCommand += (searchCommand.Contains("WHERE")) ? "AND " : "WHERE ";
				searchCommand += $"breed = '{DogBreedcomboBox.Text}' ";
			}
			if (DogClubcomboBox.SelectedItem != null)
			{
				searchCommand += (searchCommand.Contains("WHERE")) ? "AND " : "WHERE ";
				searchCommand += $"club_name = '{DogClubcomboBox.Text}' ";
			}
			if (checkBox5.Checked)
			{
				if (Int32.TryParse(maskedTextBox7.Text.Trim('_'), out int year1) && Int32.TryParse(maskedTextBox8.Text.Trim('_'), out int year2))
				{
					searchCommand += (searchCommand.Contains("WHERE")) ? "AND " : "WHERE ";
					searchCommand += $"year_birth >= {year1} AND year_birth <= {year2} ";
				}
				else if (Int32.TryParse(maskedTextBox7.Text.Trim('_'), out year1))
				{
					searchCommand += (searchCommand.Contains("WHERE")) ? "AND " : "WHERE ";
					searchCommand += $"year_birth >= {year1} ";
				}
				else if (Int32.TryParse(maskedTextBox8.Text.Trim('_'), out year2))
				{
					searchCommand += (searchCommand.Contains("WHERE")) ? "AND " : "WHERE ";
					searchCommand += $"year_birth <= {year2} ";
				}
			}
			if (checkBox6.Checked)
			{
				if (Int32.TryParse(maskedTextBox9.Text.Trim('_'), out int sum1) && Int32.TryParse(maskedTextBox10.Text.Trim('_'), out int sum2))
				{
					searchCommand += (searchCommand.Contains("WHERE")) ? "AND " : "WHERE ";
					searchCommand += $"price >= {sum1} AND price <= {sum2} ";
				}
				else if (Int32.TryParse(maskedTextBox9.Text.Trim('_'), out sum1))
				{
					searchCommand += (searchCommand.Contains("WHERE")) ? "AND " : "WHERE ";
					searchCommand += $"price >= {sum1} ";
				}
				else if (Int32.TryParse(maskedTextBox10.Text.Trim('_'), out sum2))
				{
					searchCommand += (searchCommand.Contains("WHERE")) ? "AND " : "WHERE ";
					searchCommand += $"price <= {sum2} ";
				}
			}

			theSearchCommand = searchCommand;
			this.Close();
		}

		private void label34_Click(object sender, EventArgs e)
		{

		}

		private void SearchPartbutton_Click(object sender, EventArgs e)
		{
			string searchCommand = "SELECT * FROM part_view ";

			if (PartDogNamecomboBox.SelectedItem != null)
			{
				searchCommand += $"WHERE nickname = '{PartDogNamecomboBox.Text}' ";
			}
			if (PartCompNamecomboBox.SelectedItem != null)
			{
				searchCommand += (searchCommand.Contains("WHERE")) ? "AND " : "WHERE ";
				searchCommand += $"compet_name = '{PartCompNamecomboBox.Text}' ";
			}

			theSearchCommand = searchCommand;
			this.Close();
		}

		private void SearchAwardingbutton_Click(object sender, EventArgs e)
		{
			string searchCommand = "SELECT * FROM awarding_view ";

			if (AwardingDogNamecomboBox.SelectedItem != null)
			{
				searchCommand += $"WHERE nickname = '{AwardingDogNamecomboBox.Text}' ";
			}
			if (AwardingCompNamecomboBox.SelectedItem != null)
			{
				searchCommand += (searchCommand.Contains("WHERE")) ? "AND " : "WHERE ";
				searchCommand += $"compet_name = '{AwardingCompNamecomboBox.Text}' ";
			}
			if (AwardingNAcomboBox.SelectedItem != null)
			{
				searchCommand += (searchCommand.Contains("WHERE")) ? "AND " : "WHERE ";
				searchCommand += $"award_name = '{AwardingNAcomboBox.Text}' ";
			}

			theSearchCommand = searchCommand;
			this.Close();
		}

		private void SearchBreedbutton_Click(object sender, EventArgs e)
		{
			string searchCommand = "SELECT * FROM breed ";

			if (BreedNamecomboBox.SelectedItem != null)
			{
				BreedNamesAndIDs.TryGetValue(BreedNamecomboBox.Text, out int breedID);
				searchCommand += $"WHERE breed_id = '{breedID}' ";
			}

			theSearchCommand = searchCommand;
			this.Close();
		}

		private void SearchOwnerbutton_Click(object sender, EventArgs e)
		{
			string searchCommand = "SELECT * FROM owner ";

			if (!String.IsNullOrEmpty(OwnerSurnametextBox.Text.Trim()))
			{
				searchCommand += $"WHERE LOWER(surname) LIKE LOWER('{OwnerSurnametextBox.Text.Trim()}%') ";

			}
			if (!String.IsNullOrEmpty(OwnerNametextBox.Text.Trim()))
			{
				searchCommand += (searchCommand.Contains("WHERE")) ? "AND " : "WHERE ";
				searchCommand += $"LOWER(name)  LIKE LOWER('{OwnerNametextBox.Text.Trim()}%') ";

			}
			if (!String.IsNullOrEmpty(OwnerMidnametextBox.Text.Trim()))
			{
				searchCommand += (searchCommand.Contains("WHERE")) ? "AND " : "WHERE ";
				searchCommand += $"LOWER(midname)  LIKE LOWER('{OwnerMidnametextBox.Text.Trim()}%') ";

			}
			if (!String.IsNullOrEmpty(OwnerNumbertextBox.Text.Trim()))
			{
				searchCommand += (searchCommand.Contains("WHERE")) ? "AND " : "WHERE ";
				searchCommand += $"\"number\" = '{OwnerNumbertextBox.Text.Trim()}' ";
			}

			theSearchCommand = searchCommand;
			this.Close();
		}

		private void SearchDictrbutton_Click(object sender, EventArgs e)
		{
			string searchCommand = "SELECT * FROM district ";

			if (DistrNamecomboBox.SelectedItem != null)
			{
				DistrNamesAndIDs.TryGetValue(DistrNamecomboBox.Text, out int districtID);
				searchCommand += $"WHERE district_id = '{districtID}' ";
			}

			theSearchCommand = searchCommand;
			this.Close();
		}

		private void SearchCitybutton_Click(object sender, EventArgs e)
		{
			string searchCommand = "SELECT * FROM city_view ";

			if (CityNamecomboBox.SelectedItem != null)
			{
				searchCommand += $"WHERE city = '{CityNamecomboBox.Text}' ";
			}
			if (CityRegcomboBox.SelectedItem != null)
			{
				searchCommand += (searchCommand.Contains("WHERE")) ? "AND " : "WHERE ";
				searchCommand += $"region = '{CityRegcomboBox.Text}' ";
			}

			theSearchCommand = searchCommand;
			this.Close();
		}

		private void SearchRegbutton_Click(object sender, EventArgs e)
		{
			string searchCommand = "SELECT * FROM region ";

			if (RegionNamecomboBox.SelectedItem != null)
			{
				RegionNamesAndIDs.TryGetValue(RegionNamecomboBox.Text, out int regionID);
				searchCommand += $"WHERE region_id = '{regionID}' ";
			}

			theSearchCommand = searchCommand;
			this.Close();
		}

		private void SearchBankbutton_Click(object sender, EventArgs e)
		{
			string searchCommand = "SELECT * FROM bank ";

			if (BankNamecomboBox.SelectedItem != null)
			{
				BankNamesAndIDs.TryGetValue(BankNamecomboBox.Text, out int bankID);
				searchCommand += $"WHERE bank_id = '{bankID}' ";
			}

			theSearchCommand = searchCommand;
			this.Close();
		}

		private void SearchVenuebutton_Click(object sender, EventArgs e)
		{
			string searchCommand = "SELECT * FROM venue ";

			if (VenueNamecomboBox.SelectedItem != null)
			{
				VenueNamesAndIDs.TryGetValue(VenueNamecomboBox.Text, out int venueID);
				searchCommand += $"WHERE venue_id = '{venueID}' ";
			}

			theSearchCommand = searchCommand;
			this.Close();
		}

		private void SearchAwardbutton_Click(object sender, EventArgs e)
		{
			string searchCommand = "SELECT * FROM award ";

			if (AwardNamecomboBox.SelectedItem != null)
			{
				NameAwardNamesAndIDs.TryGetValue(AwardNamecomboBox.Text, out int venueID);
				searchCommand += $"WHERE award_id = '{venueID}' ";
			}
			if (checkBox7.Checked)
			{
				if (Int32.TryParse(maskedTextBox11.Text.Trim('_'), out int sum1) && Int32.TryParse(maskedTextBox12.Text.Trim('_'), out int sum2))
				{
					searchCommand += (searchCommand.Contains("WHERE")) ? "AND " : "WHERE ";
					searchCommand += $"cash_eq >= {sum1} AND cash_eq <= {sum2} ";
				}
				else if (Int32.TryParse(maskedTextBox11.Text.Trim('_'), out sum1))
				{
					searchCommand += (searchCommand.Contains("WHERE")) ? "AND " : "WHERE ";
					searchCommand += $"cash_eq >= {sum1} ";
				}
				else if (Int32.TryParse(maskedTextBox12.Text.Trim('_'), out sum2))
				{
					searchCommand += (searchCommand.Contains("WHERE")) ? "AND " : "WHERE ";
					searchCommand += $"cash_eq <= {sum2} ";
				}
			}

			theSearchCommand = searchCommand;
			this.Close();
		}
	}
}
