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
using DBGenerator1;



namespace newKursBd
{
	public partial class Form2 : Form
	{
		Bitmap image;
		Dictionary<int, Bitmap> images;
		bool isImage;
		Random random;
		private string _connectionString = null;
		Form3 addElemForm;
		Form4 dogCompForm;
		SearchForm SF;
		public static NpgsqlConnection conn;

		List<int> districtIDs = new List<int>();
		List<int> bankIDs = new List<int>();
		List<int> cityIDs = new List<int>();
		List<int> venueIDs = new List<int>();
		List<int> ownerIDs = new List<int>();
		List<int> breedIDs = new List<int>();
		List<int> clubIDs = new List<int>();
		List<int> dogIDs = new List<int>();
		List<int> competitionIDs = new List<int>();
		List<int> participationIDs = new List<int>();
		List<int> awardIDs = new List<int>();
		List<int> regionIDs = new List<int>();
		
		public Form2(string connect)
		{
			InitializeComponent();
			_connectionString = connect;
			random = new Random();
		}	

		public async Task<string> GenerateAllTablesAsync(string connString)
		{
			return await Task.Run(() =>
			{
				// id полей таблиц
				List<int> clubIDs = new List<int>();
				List<int> competitionIDs = new List<int>();
				List<int> dogIDs = new List<int>();
				List<int> participatoinIDs = new List<int>();
				List<int> awardingIDs = new List<int>();
				List<int> breedIDs = new List<int>();
				List<int> ownerIDs = new List<int>();
				List<int> districtIDs = new List<int>();
				List<int> cityIDs = new List<int>();
				List<int> regionIDs = new List<int>();
				List<int> bankIDs = new List<int>();
				List<int> venueIDs = new List<int>();
				List<int> awardIDs = new List<int>();

				//индесы дли листов с id
				int clubIndex = 0;
				int competitionIndex = 0;
				int dogIndex = 0;
				int participatoinIndex = 0;
				int awardingIndex = 0;
				int breedIndex = 0;
				int ownerIndex = 0;
				int districtIndex = 0;
				int cityIndex = 0;
				int regionIndex = 0;
				int bankIndex = 0;
				int venueIndex = 0;
				int awardIndex = 0;

				using (var conn = new NpgsqlConnection(connString))
				{
					// генерация справочников
					string[] data = Generator.GenerateFullDirectory("bank");
					for (int i = 0; i < data.Count(); i++)
					{
						DBFunctions.InsertValueIntoTable("bank", "bank", data[i], connString);
					}
					DataTable dt = DBFunctions.SelectIDsFromTable("bank_id", "bank", connString);
					var firstArray = dt.Rows.Cast<DataRow>().Select(x => x.ItemArray[0]);
					foreach (int i in firstArray)
					{
						if (!bankIDs.Contains(i))
						{
							bankIDs.Add(i);
						}
					}


					data = Generator.GenerateFullDirectory("venue");
					for (int i = 0; i < data.Count(); i++)
					{
						DBFunctions.InsertValueIntoTable("venue", "venue", data[i], connString);
					}
					dt = DBFunctions.SelectIDsFromTable("venue_id", "venue", connString);
					firstArray = dt.Rows.Cast<DataRow>().Select(x => x.ItemArray[0]);
					foreach (int i in firstArray)
					{
						if (!venueIDs.Contains(i))
						{
							venueIDs.Add(i);
						}
					}


					data = Generator.GenerateFullDirectory("award");
					for (int i = 0; i < data.Count(); i++)
					{
						DBFunctions.InsertValueIntoTable("award_name", "award", data[i], connString);
					}
					dt = DBFunctions.SelectIDsFromTable("award_id", "award", connString);
					firstArray = dt.Rows.Cast<DataRow>().Select(x => x.ItemArray[0]);
					foreach (int i in firstArray)
					{
						if (!awardIDs.Contains(i))
						{
							awardIDs.Add(i);
						}
					}


					data = Generator.GenerateFullDirectory("region");
					for (int i = 0; i < data.Count(); i++)
					{
						DBFunctions.InsertValueIntoTable("region", "region", data[i], connString);
					}
					dt = DBFunctions.SelectIDsFromTable("region_id", "region", connString);
					firstArray = dt.Rows.Cast<DataRow>().Select(x => x.ItemArray[0]);
					foreach (int i in firstArray)
					{
						if (!regionIDs.Contains(i))
						{
							regionIDs.Add(i);
						}
					}


					data = Generator.GenerateFullDirectory("breed");
					for (int i = 0; i < data.Count(); i++)
					{
						DBFunctions.InsertValueIntoTable("breed", "breed", data[i], connString);
					}
					dt = DBFunctions.SelectIDsFromTable("breed_id", "breed", connString);
					firstArray = dt.Rows.Cast<DataRow>().Select(x => x.ItemArray[0]);
					foreach (int i in firstArray)
					{
						if (!breedIDs.Contains(i))
						{
							breedIDs.Add(i);
						}
					}


					data = Generator.GenerateFullDirectory("distr");
					for (int i = 0; i < data.Count(); i++)
					{
						DBFunctions.InsertValueIntoTable("district_name", "district", data[i], connString);
					}
					dt = DBFunctions.SelectIDsFromTable("district_id", "district", connString);
					firstArray = dt.Rows.Cast<DataRow>().Select(x => x.ItemArray[0]);
					foreach (int i in firstArray)
					{
						if (!breedIDs.Contains(i))
						{
							breedIDs.Add(i);
						}
					}


					//таблицы 
					//добавить region надо
					data = Generator.GenerateFullDirectory("city");
					for (int i = 0; i < data.Count(); i++)
					{
						DBFunctions.InsertValueIntoTable("city", "city", data[i], connString);
					}
					dt = DBFunctions.SelectIDsFromTable("city_id", "city", connString);
					firstArray = dt.Rows.Cast<DataRow>().Select(x => x.ItemArray[0]);
					foreach (int i in firstArray)
					{
						if (!cityIDs.Contains(i))
						{
							cityIDs.Add(i);
						}
					}
				}


				return "Генерация записей завершена";
			});
		}

				

		private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{

			NpgsqlDataReader dr = null;

			if (tabControl1.SelectedIndex == 13)
			{
				button1.Enabled = false;
				button15.Enabled = false;
				button16.Enabled = false;
				button17.Enabled = false;
				button18.Enabled = false;
			}
			else
			{
				button1.Enabled = true;
				button15.Enabled = true;
				button16.Enabled = true;
				button17.Enabled = true;
				button18.Enabled = true;
			}
			LoadTable(tabControl1.SelectedIndex);
		}

		private void LoadTable(int index)
		{
			NpgsqlDataReader dr = null;
			try
			{
				switch (index)
				{
					case 0: //открытие вкладки клубы

						DataTable dt = DBFunctions.SelectAllFieldsFromTable("all_club_view", _connectionString);
						if (dt != null)
						{
							ClubdataGridView.DataSource = dt;

						}
						Clubpageslabel.Text = "Количество записей: " + ClubdataGridView.Rows.Count;
						ClubdataGridView.Columns[0].HeaderText = "id Клуба";
						ClubdataGridView.Columns[1].HeaderText = "Название клуба";
						ClubdataGridView.Columns[2].HeaderText = "Район";
						ClubdataGridView.Columns[3].HeaderText = "Адрес";
						ClubdataGridView.Columns[4].HeaderText = "Номер телефона";
						ClubdataGridView.Columns[5].HeaderText = "Год открытия";
						ClubdataGridView.Columns[6].HeaderText = "Вступ. взнос";
						ClubdataGridView.Columns[7].HeaderText = "№ лицензии";
						ClubdataGridView.Columns[8].HeaderText = "Дата окончания лицензии";
						break;


					case 1:    //открытие вкладки соревнования
						dt = DBFunctions.SelectAllFieldsFromTable("all_comp_view", _connectionString);
						if (dt != null)
						{
							COMPdataGridView.DataSource = dt;

						}
						COMPpageslabel.Text = "Количество записей: " + COMPdataGridView.Rows.Count;
						COMPdataGridView.Columns[0].HeaderText = "id Соревнования";
						COMPdataGridView.Columns[1].HeaderText = "Название соревнования";
						COMPdataGridView.Columns[2].HeaderText = "Банк расчётного счёта";
						COMPdataGridView.Columns[3].HeaderText = "Расчётный счёт";
						COMPdataGridView.Columns[4].HeaderText = "Город";
						COMPdataGridView.Columns[5].HeaderText = "Место проведения";
						COMPdataGridView.Columns[6].HeaderText = "Дата соревнования";
						COMPdataGridView.Columns[7].HeaderText = "Взнос за участие (руб)";
						COMPdataGridView.Columns[8].HeaderText = "Количество зрителей (тыс)";
						break;

					case 2:    //открытие вкладки собаки
						dt = DBFunctions.SelectAllFieldsFromTable("dog_view", _connectionString);
						if (dt != null)
						{
							DogdataGridView.DataSource = dt;

						}
						Dogpageslabel.Text = "Количество записей: " + DogdataGridView.Rows.Count;
						DogdataGridView.Columns[0].HeaderText = "id Собаки ";
						DogdataGridView.Columns[1].HeaderText = "Кличка";
						DogdataGridView.Columns[2].HeaderText = "Хозяин";
						DogdataGridView.Columns[3].HeaderText = "Порода";
						DogdataGridView.Columns[4].HeaderText = "Клуб";
						DogdataGridView.Columns[5].HeaderText = "Год рождения";
						DogdataGridView.Columns[6].HeaderText = "Стоимость (руб)";
						DogdataGridView.Columns[7].HeaderText = "Фото";
						break;

						images = new Dictionary<int, Bitmap>();
						foreach (DataGridViewRow dataGridViewRow in DogdataGridView.Rows)
						{
							if (dataGridViewRow.Index != -1)
							{
								System.IO.MemoryStream myMemStream = new System.IO.MemoryStream((byte[])DogdataGridView[7, dataGridViewRow.Index].Value);
								images[Int32.Parse(DogdataGridView[0, dataGridViewRow.Index].Value.ToString())] = new Bitmap(myMemStream);
								System.Drawing.Image fullsizeImage = System.Drawing.Image.FromStream(myMemStream);
								System.Drawing.Image newImage = fullsizeImage.GetThumbnailImage(50, 50, null, IntPtr.Zero);
								System.IO.MemoryStream myResult = new System.IO.MemoryStream();
								newImage.Save(myResult, System.Drawing.Imaging.ImageFormat.Jpeg);
								DogdataGridView[6, dataGridViewRow.Index].Value = myResult.ToArray();
								myMemStream.Close();
								myResult.Close();
							}
						}
					case 3: //открытие вкладки участие
						dt = DBFunctions.SelectAllFieldsFromTable("part_view", _connectionString);
						if (dt != null)
						{
							ParticdataGridView.DataSource = dt;

						}
						Particpageslabel.Text = "Количество записей: " + ParticdataGridView.Rows.Count;
						ParticdataGridView.Columns[0].HeaderText = "id Участника";
						ParticdataGridView.Columns[1].HeaderText = "Кличка собаки";
						ParticdataGridView.Columns[2].HeaderText = "Порода";
						ParticdataGridView.Columns[3].HeaderText = "Хозяин";
						ParticdataGridView.Columns[4].HeaderText = "Клуб";
						ParticdataGridView.Columns[5].HeaderText = "Название соревнования";
						ParticdataGridView.Columns[6].HeaderText = "Город";
						ParticdataGridView.Columns[7].HeaderText = "Место проведения";
						ParticdataGridView.Columns[8].HeaderText = "Дата проведения";
						break;
					case 4:    //открытие вкладки награждение
						dt = DBFunctions.SelectAllFieldsFromTable("awarding_view", _connectionString);
						if (dt != null)
						{
							AwardingdataGridView.DataSource = dt;

						}
						Awardingpageslabel.Text = "Количество записей: " + AwardingdataGridView.Rows.Count;
						AwardingdataGridView.Columns[0].HeaderText = "id Участника";
						AwardingdataGridView.Columns[1].HeaderText = "Кличка собаки";
						AwardingdataGridView.Columns[2].HeaderText = "Порода";
						AwardingdataGridView.Columns[3].HeaderText = "Хозяин";
						AwardingdataGridView.Columns[4].HeaderText = "Клуб";
						AwardingdataGridView.Columns[5].HeaderText = "Название соревнования";
						AwardingdataGridView.Columns[6].HeaderText = "Название награды";
						AwardingdataGridView.Columns[7].HeaderText = "Денежный эквивалент (руб)";
						break;
					case 5: //открытие вкладки породы
						dt = DBFunctions.SelectAllFieldsFromTable("breed", _connectionString);
						if (dt != null)
						{
							BreeddataGridView.DataSource = dt;

						}
						Breedpageslabel.Text = "Количество записей: " + BreeddataGridView.Rows.Count;
						BreeddataGridView.Columns[0].HeaderText = "id Породы";
						BreeddataGridView.Columns[1].HeaderText = "Название породы";
						break;
					case 6: //открытие вкладки хозяева
						dt = DBFunctions.SelectAllFieldsFromTable("owner", _connectionString);
						if (dt != null)
						{
							OwnerdataGridView.DataSource = dt;

						}
						Ownerpageslabel.Text = "Количество записей: " + OwnerdataGridView.Rows.Count;
						OwnerdataGridView.Columns[0].HeaderText = "id Хозяина";
						OwnerdataGridView.Columns[1].HeaderText = "Фамилия";
						OwnerdataGridView.Columns[2].HeaderText = "Имя";
						OwnerdataGridView.Columns[3].HeaderText = "Отчество";
						OwnerdataGridView.Columns[4].HeaderText = "Адрес";
						OwnerdataGridView.Columns[5].HeaderText = "Номер телефона";
						break;
					case 7: //открытие вкладки райны
						dt = DBFunctions.SelectAllFieldsFromTable("district", _connectionString);
						if (dt != null)
						{
							DistrdataGridView.DataSource = dt;

						}
						Distrpageslabel.Text = "Количество записей: " + DistrdataGridView.Rows.Count;
						DistrdataGridView.Columns[0].HeaderText = "id Района";
						DistrdataGridView.Columns[1].HeaderText = "Название района";

						break;
					case 8: //открытие вкладки города
						dt = DBFunctions.SelectAllFieldsFromTable("city_view", _connectionString);
						if (dt != null)
						{
							CitydataGridView.DataSource = dt;

						}
						Citypageslabel.Text = "Количество записей: " + CitydataGridView.Rows.Count;
						CitydataGridView.Columns[0].HeaderText = "id Города";
						CitydataGridView.Columns[1].HeaderText = "Название города";
						CitydataGridView.Columns[2].HeaderText = "Область";
						break;
					case 9: //открытие вкладки области
						dt = DBFunctions.SelectAllFieldsFromTable("region", _connectionString);
						if (dt != null)
						{
							RegdataGridView.DataSource = dt;

						}
						Regpageslabel.Text = "Количество записей: " + RegdataGridView.Rows.Count;
						RegdataGridView.Columns[0].HeaderText = "id Области";
						RegdataGridView.Columns[1].HeaderText = "Название области";
						break;
					case 10: //открытие вкладки банки
						dt = DBFunctions.SelectAllFieldsFromTable("bank", _connectionString);
						if (dt != null)
						{
							BankdataGridView.DataSource = dt;

						}
						Bankpageslabel.Text = "Количество записей: " + BankdataGridView.Rows.Count;
						BankdataGridView.Columns[0].HeaderText = "id Банка";
						BankdataGridView.Columns[1].HeaderText = "Название Банка";
						break;
					case 11: //открытие вкладки место проведения соревнования
						dt = DBFunctions.SelectAllFieldsFromTable("venue", _connectionString);
						if (dt != null)
						{
							VenuedataGridView.DataSource = dt;

						}
						Venuepageslabel.Text = "Количество записей: " + VenuedataGridView.Rows.Count;
						VenuedataGridView.Columns[0].HeaderText = "id Места проведения";
						VenuedataGridView.Columns[1].HeaderText = "Название места проведения";
						break;
					case 12: //открытие вкладки награды
						dt = DBFunctions.SelectAllFieldsFromTable("award", _connectionString);
						if (dt != null)
						{
							AwarddataGridView.DataSource = dt;

						}
						Awardpageslabel.Text = "Количество записей: " + AwarddataGridView.Rows.Count;
						AwarddataGridView.Columns[0].HeaderText = "id Награды";
						AwarddataGridView.Columns[1].HeaderText = "Название награды";
						AwarddataGridView.Columns[2].HeaderText = "Денежный эквивалент (руб)";
						break;
				}
			}
			catch
			{
				if (dr == null) return;
				if (!dr.IsClosed) dr.Close();
			}
		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			for (int i = 1; i < 9; i++)
			{
				this.ClubdataGridView.Rows.Add();
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{

		}
		
		private void button13_Click(object sender, EventArgs e)
		{

		}

		private void button15_Click_1(object sender, EventArgs e)
		{
			addElemForm = new Form3(_connectionString, tabControl1.SelectedIndex);
			addElemForm.ShowDialog();
			LoadTable(tabControl1.SelectedIndex);
		}

		private void button17_Click_1(object sender, EventArgs e)
		{
			int ID = 0;
			switch (tabControl1.SelectedIndex)
			{
				case 0: //клубы
					{
						if (ClubdataGridView.SelectedRows.Count != 1)
						{
							MessageBox.Show("Выберите один элемент для редактирования!", "Error!");
							return;
						}

						ID = Convert.ToInt32(ClubdataGridView.SelectedRows[0].Cells[0].Value);
					}
					break;
				case 1://соревнования 
					{
						if (COMPdataGridView.SelectedRows.Count != 1)
						{
							MessageBox.Show("Выберите один элемент для редактирования!", "Error!");
							return;
						}

						ID = Convert.ToInt32(COMPdataGridView.SelectedRows[0].Cells[0].Value);
					}
					break;
				case 2://собаки  
					{
						if (DogdataGridView.SelectedRows.Count != 1)
						{
							MessageBox.Show("Выберите один элемент для редактирования!", "Error!");
							return;
						}

						ID = Convert.ToInt32(DogdataGridView.SelectedRows[0].Cells[0].Value);
					}
					break;
				case 3://участие   
					{
						if (ParticdataGridView.SelectedRows.Count != 1)
						{
							MessageBox.Show("Выберите один элемент для редактирования!", "Error!");
							return;
						}

						ID = Convert.ToInt32(ParticdataGridView.SelectedRows[0].Cells[0].Value);
					}
					break;
				case 4://награждение   
					{
						if (AwardingdataGridView.SelectedRows.Count != 1)
						{
							MessageBox.Show("Выберите один элемент для редактирования!", "Error!");
							return;
						}

						ID = Convert.ToInt32(AwardingdataGridView.SelectedRows[0].Cells[0].Value);
					}
					break;
				case 5://породы 
					{
						if (BreeddataGridView.SelectedRows.Count != 1)
						{
							MessageBox.Show("Выберите один элемент для редактирования!", "Error!");
							return;
						}

						ID = Convert.ToInt32(BreeddataGridView.SelectedRows[0].Cells[0].Value);
					}
					break;
				case 6://хозяева   
					{
						if (OwnerdataGridView.SelectedRows.Count != 1)
						{
							MessageBox.Show("Выберите один элемент для редактирования!", "Error!");
							return;
						}

						ID = Convert.ToInt32(OwnerdataGridView.SelectedRows[0].Cells[0].Value);
					}
					break;
				case 7://районы   
					{
						if (DistrdataGridView.SelectedRows.Count != 1)
						{
							MessageBox.Show("Выберите один элемент для редактирования!", "Error!");
							return;
						}

						ID = Convert.ToInt32(DistrdataGridView.SelectedRows[0].Cells[0].Value);
					}
					break;
				case 8://города  
					{
						if (CitydataGridView.SelectedRows.Count != 1)
						{
							MessageBox.Show("Выберите один элемент для редактирования!", "Error!");
							return;
						}

						ID = Convert.ToInt32(CitydataGridView.SelectedRows[0].Cells[0].Value);
					}
					break;
				case 9://области  
					{
						if (RegdataGridView.SelectedRows.Count != 1)
						{
							MessageBox.Show("Выберите один элемент для редактирования!", "Error!");
							return;
						}

						ID = Convert.ToInt32(RegdataGridView.SelectedRows[0].Cells[0].Value);
					}
					break;
				case 10://банки   
					{
						if (BankdataGridView.SelectedRows.Count != 1)
						{
							MessageBox.Show("Выберите один элемент для редактирования!", "Error!");
							return;
						}

						ID = Convert.ToInt32(BankdataGridView.SelectedRows[0].Cells[0].Value);
					}
					break;
				case 11://место  
					{
						if (VenuedataGridView.SelectedRows.Count != 1)
						{
							MessageBox.Show("Выберите один элемент для редактирования!", "Error!");
							return;
						}

						ID = Convert.ToInt32(VenuedataGridView.SelectedRows[0].Cells[0].Value);
					}
					break;
				case 12://награды   
					{
						if (AwarddataGridView.SelectedRows.Count != 1)
						{
							MessageBox.Show("Выберите один элемент для редактирования!", "Error!");
							return;
						}

						ID = Convert.ToInt32(AwarddataGridView.SelectedRows[0].Cells[0].Value);
					}
					break;
			}
			addElemForm = new Form3(_connectionString, tabControl1.SelectedIndex, ID, true);
			addElemForm.ShowDialog();
			LoadTable(tabControl1.SelectedIndex);
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
		{

		}

		private void button20_Click(object sender, EventArgs e)
		{

		}

		private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void toolStripComboBox1_Click(object sender, EventArgs e)
		{

		}

		private void button18_Click(object sender, EventArgs e)
		{
			dogCompForm.Show();
		}

		private void button16_Click(object sender, EventArgs e)
		{

			switch (tabControl1.SelectedIndex)
			{
				case 0://клубы
					if (ClubdataGridView.SelectedRows.Count == 0) return;
					if (MessageBox.Show("Данное удаление может повлечь за собой удаление данных из таблицы Собаки, Участие, Награждение ", "", MessageBoxButtons.YesNo) == DialogResult.No) return;
					
					if (ClubdataGridView.SelectedRows.Count == DBFunctions.SelectRowsCountFromTable("club", _connectionString))
					{
						chooseallcheckBox.Checked = false;
						DBFunctions.ClearTableCascade("club", _connectionString);
					}
					else
					{
						for (int i=0; i< ClubdataGridView.SelectedRows.Count; i++)
						{
							DBFunctions.DeleteLineFromTable("club", $"club_id = {ClubdataGridView.SelectedRows[i].Cells[0].Value}", _connectionString);
						}
					}
					break;
			   case 1:// соревнования
					if (COMPdataGridView.SelectedRows.Count == 0) return;
					if (MessageBox.Show("Данное удаление может повлечь за собой удаление данных из таблицы Участие и Награждение ", "", MessageBoxButtons.YesNo) == DialogResult.No) return;

					if (COMPdataGridView.SelectedRows.Count == DBFunctions.SelectRowsCountFromTable("competition", _connectionString))
					{
						chooseallcheckBox.Checked = false;
						DBFunctions.ClearTableCascade("competition", _connectionString);
					}
					else
					{
						for (int i = 0; i < COMPdataGridView.SelectedRows.Count; i++)
						{
							DBFunctions.DeleteLineFromTable("competition", $"competition_id = {COMPdataGridView.SelectedRows[i].Cells[0].Value}", _connectionString);
						}
					}
					break;
				case 2:// собаки
					if (DogdataGridView.SelectedRows.Count == 0) return;
					if (MessageBox.Show("Данное удаление может повлечь за собой удаление данных из таблицы Участие и Награждение ", "", MessageBoxButtons.YesNo) == DialogResult.No) return;

					if (DogdataGridView.SelectedRows.Count == DBFunctions.SelectRowsCountFromTable("dog", _connectionString))
					{
						chooseallcheckBox.Checked = false;
						DBFunctions.ClearTableCascade("dog", _connectionString);
					}
					else
					{
						for (int i = 0; i < DogdataGridView.SelectedRows.Count; i++)
						{
							DBFunctions.DeleteLineFromTable("dog", $"dog_id = {DogdataGridView.SelectedRows[i].Cells[0].Value}", _connectionString);
						}
					}
					break;
				case 3:// участие
					if (ParticdataGridView.SelectedRows.Count == 0) return;
					if (MessageBox.Show("Данное удаление может повлечь за собой удаление данных из таблицы Награждение ", "", MessageBoxButtons.YesNo) == DialogResult.No) return;

					if (ParticdataGridView.SelectedRows.Count == DBFunctions.SelectRowsCountFromTable("participation", _connectionString))
					{
						chooseallcheckBox.Checked = false;
						DBFunctions.ClearTableCascade("participation", _connectionString);
					}
					else
					{
						for (int i = 0; i < ParticdataGridView.SelectedRows.Count; i++)
						{
							DBFunctions.DeleteLineFromTable("participation", $"participant_id = {ParticdataGridView.SelectedRows[i].Cells[0].Value}", _connectionString);
						}
					}
					break;
				case 4:// награждение
					if (AwardingdataGridView.SelectedRows.Count == 0) return;
					if (MessageBox.Show("Хотите удалить данную запись? ", "", MessageBoxButtons.YesNo) == DialogResult.No) return;

					if (AwardingdataGridView.SelectedRows.Count == DBFunctions.SelectRowsCountFromTable("awarding", _connectionString))
					{
						chooseallcheckBox.Checked = false;
						DBFunctions.ClearTableCascade("awarding", _connectionString);
					}
					else
					{
						for (int i = 0; i < AwardingdataGridView.SelectedRows.Count; i++)
						{
							DBFunctions.DeleteLineFromTable("awarding", $"awarding_id = {AwardingdataGridView.SelectedRows[i].Cells[0].Value}", _connectionString);
						}
					}
					break;
				case 5:// породы
					if (BreeddataGridView.SelectedRows.Count == 0) return;
					if (MessageBox.Show("Данное удаление может повлечь за собой удаление данных из таблицы Собаки, Участие, Награждение  ", "", MessageBoxButtons.YesNo) == DialogResult.No) return;

					if (BreeddataGridView.SelectedRows.Count == DBFunctions.SelectRowsCountFromTable("breed", _connectionString))
					{
						chooseallcheckBox.Checked = false;
						DBFunctions.ClearTableCascade("breed", _connectionString);
					}
					else
					{
						for (int i = 0; i < BreeddataGridView.SelectedRows.Count; i++)
						{
							DBFunctions.DeleteLineFromTable("breed", $"breed_id = {BreeddataGridView.SelectedRows[i].Cells[0].Value}", _connectionString);
						}
					}
					break;
				case 6:// хозяева
					if (OwnerdataGridView.SelectedRows.Count == 0) return;
					if (MessageBox.Show("Данное удаление может повлечь за собой удаление данных из таблицы Собаки, Участие, Награждение ", "", MessageBoxButtons.YesNo) == DialogResult.No) return;

					if (OwnerdataGridView.SelectedRows.Count == DBFunctions.SelectRowsCountFromTable("owner", _connectionString))
					{
						chooseallcheckBox.Checked = false;
						DBFunctions.ClearTableCascade("owner", _connectionString);
					}
					else
					{
						for (int i = 0; i < OwnerdataGridView.SelectedRows.Count; i++)
						{
							DBFunctions.DeleteLineFromTable("owner", $"owner_id = {OwnerdataGridView.SelectedRows[i].Cells[0].Value}", _connectionString);
						}
					}
					break;
				case 7:// районы
					if (DistrdataGridView.SelectedRows.Count == 0) return;
					if (MessageBox.Show("Данное удаление может повлечь за собой удаление данных из таблицы Клубы, Собаки, Участие, Награждение ", "", MessageBoxButtons.YesNo) == DialogResult.No) return;

					if (DistrdataGridView.SelectedRows.Count == DBFunctions.SelectRowsCountFromTable("district", _connectionString))
					{
						chooseallcheckBox.Checked = false;
						DBFunctions.ClearTableCascade("district", _connectionString);
					}
					else
					{
						for (int i = 0; i < DistrdataGridView.SelectedRows.Count; i++)
						{
							DBFunctions.DeleteLineFromTable("district", $"district_id = {DistrdataGridView.SelectedRows[i].Cells[0].Value}", _connectionString);
						}
					}
					break;
				case 8:// города
					if (CitydataGridView.SelectedRows.Count == 0) return;
					if (MessageBox.Show("Данное удаление может повлечь за собой удаление данных из таблицы Соревнования, Участие, Награждение ", "", MessageBoxButtons.YesNo) == DialogResult.No) return;

					if (CitydataGridView.SelectedRows.Count == DBFunctions.SelectRowsCountFromTable("city", _connectionString))
					{
						chooseallcheckBox.Checked = false;
						DBFunctions.ClearTableCascade("city", _connectionString);
					}
					else
					{
						for (int i = 0; i < CitydataGridView.SelectedRows.Count; i++)
						{
							DBFunctions.DeleteLineFromTable("city", $"city_id = {CitydataGridView.SelectedRows[i].Cells[0].Value}", _connectionString);
						}
					}
					break;
				case 9:// области
					if (RegdataGridView.SelectedRows.Count == 0) return;
					if (MessageBox.Show("Данное удаление может повлечь за собой удаление данных из таблицы Города, Соревнования, Участие, Награждение ", "", MessageBoxButtons.YesNo) == DialogResult.No) return;

					if (RegdataGridView.SelectedRows.Count == DBFunctions.SelectRowsCountFromTable("region", _connectionString))
					{
						chooseallcheckBox.Checked = false;
						DBFunctions.ClearTableCascade("region", _connectionString);
					}
					else
					{
						for (int i = 0; i < RegdataGridView.SelectedRows.Count; i++)
						{
							DBFunctions.DeleteLineFromTable("region", $"region_id = {RegdataGridView.SelectedRows[i].Cells[0].Value}", _connectionString);
						}
					}
					break;
				case 10:// банки
					if (BankdataGridView.SelectedRows.Count == 0) return;
					if (MessageBox.Show("Данное удаление может повлечь за собой удаление данных из таблицы Соревнования, Участие, Награждение ", "", MessageBoxButtons.YesNo) == DialogResult.No) return;

					if (BankdataGridView.SelectedRows.Count == DBFunctions.SelectRowsCountFromTable("bank", _connectionString))
					{
						chooseallcheckBox.Checked = false;
						DBFunctions.ClearTableCascade("bank", _connectionString);
					}
					else
					{
						for (int i = 0; i < BankdataGridView.SelectedRows.Count; i++)
						{
							DBFunctions.DeleteLineFromTable("bank", $"bank_id = {BankdataGridView.SelectedRows[i].Cells[0].Value}", _connectionString);
						}
					}
					break;
				case 11:// место проведения
					if (VenuedataGridView.SelectedRows.Count == 0) return;
					if (MessageBox.Show("Данное удаление может повлечь за собой удаление данных из таблицы Соревнования, Участие, Награждение ", "", MessageBoxButtons.YesNo) == DialogResult.No) return;

					if (VenuedataGridView.SelectedRows.Count == DBFunctions.SelectRowsCountFromTable("venue", _connectionString))
					{
						chooseallcheckBox.Checked = false;
						DBFunctions.ClearTableCascade("venue", _connectionString);
					}
					else
					{
						for (int i = 0; i < VenuedataGridView.SelectedRows.Count; i++)
						{
							DBFunctions.DeleteLineFromTable("venue", $"venue_id = {VenuedataGridView.SelectedRows[i].Cells[0].Value}", _connectionString);
						}
					}
					break;
				case 12:// награды
					if (AwarddataGridView.SelectedRows.Count == 0) return;
					if (MessageBox.Show("Данное удаление может повлечь за собой удаление данных из таблицы Награждение ", "", MessageBoxButtons.YesNo) == DialogResult.No) return;

					if (AwarddataGridView.SelectedRows.Count == DBFunctions.SelectRowsCountFromTable("award", _connectionString))
					{
						chooseallcheckBox.Checked = false;
						DBFunctions.ClearTableCascade("award", _connectionString);
					}
					else
					{
						for (int i = 0; i < AwarddataGridView.SelectedRows.Count; i++)
						{
							DBFunctions.DeleteLineFromTable("award", $"award_id = {AwarddataGridView.SelectedRows[i].Cells[0].Value}", _connectionString);
						}
					}
					break;
			}
			LoadTable(tabControl1.SelectedIndex);

		}

		private void DogdataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{

		}

		private void Form2_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}

		private void chooseallcheckBox_CheckedChanged(object sender, EventArgs e)
		{
			switch (tabControl1.SelectedIndex)
			{
				case 0://клубы
					if (ClubdataGridView.SelectedRows.Count == ClubdataGridView.Rows.Count)
					{
						ClubdataGridView.ClearSelection();
					}
					else if (chooseallcheckBox.Checked)
					{
						ClubdataGridView.SelectAll();
					}
					break;
				case 1://соревнования
					if (COMPdataGridView.SelectedRows.Count == COMPdataGridView.Rows.Count)
					{
						COMPdataGridView.ClearSelection();
					}
					else if (chooseallcheckBox.Checked)
					{
						COMPdataGridView.SelectAll();
					}
					break;
				case 2://собаки
					if (DogdataGridView.SelectedRows.Count == DogdataGridView.Rows.Count)
					{
						DogdataGridView.ClearSelection();
					}
					else if (chooseallcheckBox.Checked)
					{
						DogdataGridView.SelectAll();
					}
					break;
				case 3://участие
					if (ParticdataGridView.SelectedRows.Count == ParticdataGridView.Rows.Count)
					{
						ParticdataGridView.ClearSelection();
					}
					else if (chooseallcheckBox.Checked)
					{
						ParticdataGridView.SelectAll();
					}
					break;
				case 4://награждение
					if (AwardingdataGridView.SelectedRows.Count == AwardingdataGridView.Rows.Count)
					{
						AwardingdataGridView.ClearSelection();
					}
					else if (chooseallcheckBox.Checked)
					{
						AwardingdataGridView.SelectAll();
					}
					break;
				case 5://породы
					if (BreeddataGridView.SelectedRows.Count == BreeddataGridView.Rows.Count)
					{
						BreeddataGridView.ClearSelection();
					}
					else if (chooseallcheckBox.Checked)
					{
						BreeddataGridView.SelectAll();
					}
					break;
				case 6://хозяева
					if (OwnerdataGridView.SelectedRows.Count == OwnerdataGridView.Rows.Count)
					{
						OwnerdataGridView.ClearSelection();
					}
					else if (chooseallcheckBox.Checked)
					{
						OwnerdataGridView.SelectAll();
					}
					break;
				case 7://районы
					if (DistrdataGridView.SelectedRows.Count == DistrdataGridView.Rows.Count)
					{
						DistrdataGridView.ClearSelection();
					}
					else if (chooseallcheckBox.Checked)
					{
						DistrdataGridView.SelectAll();
					}
					break;
				case 8://города
					if (CitydataGridView.SelectedRows.Count == CitydataGridView.Rows.Count)
					{
						CitydataGridView.ClearSelection();
					}
					else if (chooseallcheckBox.Checked)
					{
						CitydataGridView.SelectAll();
					}
					break;
				case 9://области
					if (RegdataGridView.SelectedRows.Count == RegdataGridView.Rows.Count)
					{
						RegdataGridView.ClearSelection();
					}
					else if (chooseallcheckBox.Checked)
					{
						RegdataGridView.SelectAll();
					}
					break;
				case 10://банки
					if (BankdataGridView.SelectedRows.Count == BankdataGridView.Rows.Count)
					{
						BankdataGridView.ClearSelection();
					}
					else if (chooseallcheckBox.Checked)
					{
						BankdataGridView.SelectAll();
					}
					break;
				case 11://место
					if (VenuedataGridView.SelectedRows.Count == VenuedataGridView.Rows.Count)
					{
						VenuedataGridView.ClearSelection();
					}
					else if (chooseallcheckBox.Checked)
					{
						VenuedataGridView.SelectAll();
					}
					break;
				case 12://награды 
					if (AwarddataGridView.SelectedRows.Count == AwarddataGridView.Rows.Count)
					{
						AwarddataGridView.ClearSelection();
					}
					else if (chooseallcheckBox.Checked)
					{
						AwarddataGridView.SelectAll();
					}
					break;
			}
		}

		private void DogdataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				DataGridViewTextBoxCell cell = (DataGridViewTextBoxCell)DogdataGridView.Rows[e.RowIndex].Cells[0]; 

				Form4 dogcompt = new Form4((int)cell.Value, _connectionString);
				dogcompt.ShowDialog();
			}
			catch (Exception)
			{
			}
		}

		private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			
		}

		private void Form2_Load(object sender, EventArgs e)
		{
			LoadTable(0);
		}

		private async void button1_Click(object sender, EventArgs e)
		{
			if (!Generator.isFilesLoaded)
            {
				MessageBox.Show("Недостаточно файлов данных для генерации");
				return;
            }

			string msg = await Generation(tabControl1.SelectedIndex);
			LoadTable(tabControl1.SelectedIndex);
			MessageBox.Show(msg);
		}

		private async Task<string> Generation(int index)
		{
			return await Task.Run(() =>
			{
				string msg = "Генерация записей завершена";

				switch (index)
				{
					case 0: //открытие вкладки клубы
						{
							DataTable dt = DBFunctions.SelectIDsFromTable("district_id", "district", _connectionString);
							var firstArray = dt.Rows.Cast<DataRow>().Select(x => x.ItemArray[0]);
							foreach (int i in firstArray)
							{
								districtIDs.Add(i);
							}

							if (districtIDs.Count == 0 || Generator.ClubNames == null)
							{
								msg = "Недостаточно данных из внешних таблиц для генерации";
								break;
							}

							DateTime dateFee = DateTime.Today;
							for (int i = 0, j = 0; i < Generator.ClubNames.Count() * 2; i++, j++)
							{
								if (j == Generator.ClubNames.Count())
								{
									j = 0;
								}

								int districtIndex = random.Next(0, districtIDs.Count);

								dateFee = dateFee.AddDays(random.Next(0, 410)); // 04-22-2022, а нужно 2022-04-22
								DBFunctions.InsertValuesIntoTable("public.club( club_name, district_id, address, \"number\", year_opened, ent_fee, licences, end_licences)",
									$"'{Generator.ClubNames[j]}', '{districtIDs[districtIndex]}', '{Generator.GenerateLine("address")}', '{Generator.GeneratePhoneNumber()}', {random.Next(DateTime.Today.Year - 70, DateTime.Today.Year - 5)}, " +
									$" {random.Next(500, 5001)}, {random.Next(100000, 1000000)}, '{dateFee.Year}-{dateFee.Month}-{dateFee.Day}'", _connectionString);

								dateFee = DateTime.Today;
							}
						}
						break;
					case 1:    //открытие вкладки соревнования
						{
							DataTable dt = DBFunctions.SelectIDsFromTable("bank_id", "bank", _connectionString);
							var firstArray = dt.Rows.Cast<DataRow>().Select(x => x.ItemArray[0]);
							foreach (int i in firstArray)
							{
								bankIDs.Add(i);
							}

							dt = DBFunctions.SelectIDsFromTable("city_id", "city", _connectionString);
							firstArray = dt.Rows.Cast<DataRow>().Select(x => x.ItemArray[0]);
							foreach (int i in firstArray)
							{
								cityIDs.Add(i);
							}

							dt = DBFunctions.SelectIDsFromTable("venue_id", "venue", _connectionString);
							firstArray = dt.Rows.Cast<DataRow>().Select(x => x.ItemArray[0]);
							foreach (int i in firstArray)
							{
								venueIDs.Add(i);
							}

							if (bankIDs.Count == 0 || cityIDs.Count == 0 || venueIDs.Count == 0 || Generator.ComptName == null)
							{
								msg = "Недостаточно данных из внешних таблиц для генерации";
								break;
							}

							DateTime dateEvent = DateTime.Today;
							for (int i = 0, j = 0; i < Generator.ComptName.Count() * 2; i++, j++)
							{
								if (j == Generator.ComptName.Count())
								{
									j = 0;
								}

								int bandIndex = random.Next(0, bankIDs.Count);
								int cityIndex = random.Next(0, cityIDs.Count);
								int venueIndex = random.Next(0, venueIDs.Count);

								dateEvent = dateEvent.AddDays(random.Next(0, 900)); // 04-22-2022, а нужно 2022-04-22
								DBFunctions.InsertValuesIntoTable("public.competition(compet_name, bank_id, pay_account, city_id, venue_id, date_event, partic_fee, number_viewers)",
									$"'{Generator.ComptName[j]}', '{bankIDs[bandIndex]}', '{random.Next(1000, 10000)}', '{cityIDs[cityIndex]}', {venueIDs[venueIndex]}, " +
									$" '{dateEvent.Year}-{dateEvent.Month}-{dateEvent.Day}', {random.Next(500, 5001)}, {random.Next(100, 1001)}", _connectionString);

								dateEvent = DateTime.Today;
							}
						}
						break;

					case 2:    //открытие вкладки собаки
						{
							bool sex = false;

							DataTable dt = DBFunctions.SelectIDsFromTable("owner_id", "owner", _connectionString);
							var firstArray = dt.Rows.Cast<DataRow>().Select(x => x.ItemArray[0]);
							foreach (int i in firstArray)
							{
								ownerIDs.Add(i);
							}

							dt = DBFunctions.SelectIDsFromTable("breed_id", "breed", _connectionString);
							firstArray = dt.Rows.Cast<DataRow>().Select(x => x.ItemArray[0]);
							foreach (int i in firstArray)
							{
								breedIDs.Add(i);
							}

							dt = DBFunctions.SelectIDsFromTable("club_id", "club", _connectionString);
							firstArray = dt.Rows.Cast<DataRow>().Select(x => x.ItemArray[0]);
							foreach (int i in firstArray)
							{
								clubIDs.Add(i);
							}

							if (ownerIDs.Count == 0 || breedIDs.Count == 0 || clubIDs.Count == 0)
							{
								msg = "Недостаточно данных из внешних таблиц для генерации";
								break;
							}

							for (int i = 0; i < (Generator.FDogName.Count() + Generator.MDogName.Count() + Generator.MDogName.Count() / 2); i++)
							{
								int ownerIndex = random.Next(0, ownerIDs.Count);
								int breedIndex = random.Next(0, breedIDs.Count);
								int clubIndex = random.Next(0, clubIDs.Count);

								if (random.Next(0, 2) == 0)
								{
									sex = true;
								}
								else
								{
									sex = false;
								}
								string dogName = Generator.GenerateDogName(sex);

								DBFunctions.InsertValuesIntoTable("public.dog (nickname, owner_id, breed_id, club_id, year_birth, price)",
									$"'{dogName}', '{ownerIDs[ownerIndex]}', '{breedIDs[breedIndex]}', '{clubIDs[clubIndex]}', {random.Next(DateTime.Today.Year - 5, DateTime.Today.Year)}, " +
									$" {random.Next(100, 100001)}", _connectionString);
							}
						}
						break;
					case 3: //открытие вкладки участие
						{
							DataTable dt = DBFunctions.SelectIDsFromTable("dog_id", "dog", _connectionString);
							var firstArray = dt.Rows.Cast<DataRow>().Select(x => x.ItemArray[0]);
							foreach (int i in firstArray)
							{
								dogIDs.Add(i);
							}

							dt = DBFunctions.SelectIDsFromTable("competition_id", "competition", _connectionString);
							firstArray = dt.Rows.Cast<DataRow>().Select(x => x.ItemArray[0]);
							foreach (int i in firstArray)
							{
								competitionIDs.Add(i);
							}

							if (dogIDs.Count == 0 || competitionIDs.Count == 0)
							{
								msg = "Недостаточно данных из внешних таблиц для генерации";
								break;
							}

							for (int i = 0; i < 5000; i++)
							{
								int dogIndex = random.Next(0, dogIDs.Count);
								int competitionIndex = random.Next(0, competitionIDs.Count);

								DBFunctions.InsertValuesIntoTable("public.participation (dog_id, competition_id)",
									$"'{dogIDs[dogIndex]}', '{competitionIDs[competitionIndex]}'", _connectionString);
							}
						}
						break;
					case 4:    //открытие вкладки награждение
						{
							DataTable dt = DBFunctions.SelectIDsFromTable("participant_id", "participation", _connectionString);
							var firstArray = dt.Rows.Cast<DataRow>().Select(x => x.ItemArray[0]);
							foreach (int i in firstArray)
							{
								participationIDs.Add(i);
							}

							dt = DBFunctions.SelectIDsFromTable("award_id", "award", _connectionString);
							firstArray = dt.Rows.Cast<DataRow>().Select(x => x.ItemArray[0]);
							foreach (int i in firstArray)
							{
								awardIDs.Add(i);
							}

							if (participationIDs.Count == 0 || awardIDs.Count == 0)
							{
								msg = "Недостаточно данных из внешних таблиц для генерации";
								break;
							}

							for (int i = 0; i < DBFunctions.SelectRowsCountFromTable("participation", _connectionString); i++)
							{
								int participationIndex = random.Next(0, participationIDs.Count);
								int awardIndex = random.Next(0, awardIDs.Count);

								DBFunctions.InsertValuesIntoTable("public.awarding (participant_id, award_id)",
									$"'{participationIDs[participationIndex]}', '{awardIDs[awardIndex]}'", _connectionString);
							}
						}
						break;
					case 5: //открытие вкладки породы
						{
							string[] data = Generator.GenerateFullDirectory("breed");
							for (int i = 0; i < data.Count(); i++)
							{
								DBFunctions.InsertValuesIntoTable("public.breed (breed)", $"'{data[i]}'", _connectionString);
							}
						}
						break;
					case 6: //открытие вкладки хозяева
						{
							bool sex = false;

							for (int i = 0; i < random.Next(125, 425); i++)
							{
								if (random.Next(0, 2) == 0)
								{
									sex = true;
								}
								else
								{
									sex = false;
								}
								string[] fullName = Generator.GenerateFullName(sex);

								DBFunctions.InsertValuesIntoTable("public.owner (surname, name, midname, address, \"number\")",
									$"'{fullName[0]}', '{fullName[1]}', '{fullName[2]}', '{Generator.GenerateLine("address")}', {Generator.GeneratePhoneNumber()} ", _connectionString);
							}
						}
						break;
					case 7: //открытие вкладки районы
						{
							string[] data = Generator.GenerateFullDirectory("district");
							for (int i = 0; i < data.Count(); i++)
							{
								DBFunctions.InsertValuesIntoTable("public.district (district_name)", $"'{data[i]}'", _connectionString);
							}
						}
						break;
					case 8: //открытие вкладки города
						{
							DataTable dt = DBFunctions.SelectIDsFromTable("region_id", "region", _connectionString);
							var firstArray = dt.Rows.Cast<DataRow>().Select(x => x.ItemArray[0]);
							foreach (int i in firstArray)
							{
								regionIDs.Add(i);
							}

							if (regionIDs.Count == 0)
							{
								msg = "Недостаточно данных из внешних таблиц для генерации";
								break;
							}

							for (int i = 0; i < Generator.Cities.Count(); i++)
							{
								int regionIndex = random.Next(0, regionIDs.Count);

								DBFunctions.InsertValuesIntoTable("public.city (city, region_id)",
									$"'{Generator.Cities[i]}', '{regionIDs[regionIndex]}' ", _connectionString);
							}
						}
						break;
					case 9: //открытие вкладки области
						{
							string[] data = Generator.GenerateFullDirectory("region");
							for (int i = 0; i < data.Count(); i++)
							{
								DBFunctions.InsertValuesIntoTable("public.region (region)", $"'{data[i]}'", _connectionString);
							}
						}
						break;
					case 10: //открытие вкладки банки
						{
							string[] data = Generator.GenerateFullDirectory("bank");
							for (int i = 0; i < data.Count(); i++)
							{
								DBFunctions.InsertValuesIntoTable("public.bank (bank)", $"'{data[i]}'", _connectionString);
							}
						}
						break;
					case 11: //открытие вкладки место проведения соревнования
						{
							string[] data = Generator.GenerateFullDirectory("venue");
							for (int i = 0; i < data.Count(); i++)
							{
								DBFunctions.InsertValuesIntoTable("public.venue (venue)", $"'{data[i]}'", _connectionString);
							}
						}
						break;
					case 12: //открытие вкладки награды
						{
							string[] data = Generator.GenerateFullDirectory("award");
							foreach (string line in data)
							{
								string[] nameAndCash = line.Split(',', '\n', '\r');
								DBFunctions.InsertValuesIntoTable("public.award (award_name, cash_eq)", $"'{nameAndCash[0]}', '{nameAndCash[1]}'", _connectionString);
							}
						}
						break;
				}
				districtIDs.Clear();
				bankIDs.Clear();
				cityIDs.Clear();
				venueIDs.Clear();


				return msg;
			});
		}

		private void button18_Click_1(object sender, EventArgs e)
		{
			int index = tabControl1.SelectedIndex;
			SF = new SearchForm(_connectionString, index);
			SF.ShowDialog();

			if (SF.theSearchCommand == null) return;

			LoadSearchTalbe(index, SF.theSearchCommand);
		}

		private void LoadSearchTalbe(int index, string cmd)
		{
			NpgsqlDataReader dr = null;
			try
			{
				switch (index)
				{
					case 0: //открытие вкладки клубы

						DataTable dt = DBFunctions.SpecifitSelectFieldsFromTable(cmd, _connectionString);
						if (dt != null)
						{
							ClubdataGridView.DataSource = dt;

						}
						Clubpageslabel.Text = "Количество полей: " + ClubdataGridView.Rows.Count;
						ClubdataGridView.Columns[0].HeaderText = "id Клуба";
						ClubdataGridView.Columns[1].HeaderText = "Название клуба";
						ClubdataGridView.Columns[2].HeaderText = "Район";
						ClubdataGridView.Columns[3].HeaderText = "Адрес";
						ClubdataGridView.Columns[4].HeaderText = "Номер телефона";
						ClubdataGridView.Columns[5].HeaderText = "Год открытия";
						ClubdataGridView.Columns[6].HeaderText = "Вступ. взнос";
						ClubdataGridView.Columns[7].HeaderText = "№ лицензии";
						ClubdataGridView.Columns[8].HeaderText = "Дата окончания лицензии";
						break;


					case 1:    //открытие вкладки соревнования
						dt = DBFunctions.SpecifitSelectFieldsFromTable(cmd, _connectionString);
						if (dt != null)
						{
							COMPdataGridView.DataSource = dt;

						}
						COMPpageslabel.Text = "Количество полей: " + COMPdataGridView.Rows.Count;
						COMPdataGridView.Columns[0].HeaderText = "id Соревнования";
						COMPdataGridView.Columns[1].HeaderText = "Название соревнования";
						COMPdataGridView.Columns[2].HeaderText = "Банк расчётного счёта";
						COMPdataGridView.Columns[3].HeaderText = "Расчётный счёт";
						COMPdataGridView.Columns[4].HeaderText = "Город";
						COMPdataGridView.Columns[5].HeaderText = "Место проведения";
						COMPdataGridView.Columns[6].HeaderText = "Дата соревнования";
						COMPdataGridView.Columns[7].HeaderText = "Взнос за участие (руб)";
						COMPdataGridView.Columns[8].HeaderText = "Количество зрителей (тыс)";
						break;

					case 2:    //открытие вкладки собаки
						dt = DBFunctions.SpecifitSelectFieldsFromTable(cmd, _connectionString);
						if (dt != null)
						{
							DogdataGridView.DataSource = dt;

						}
						Dogpageslabel.Text = "Количество полей: " + DogdataGridView.Rows.Count;
						DogdataGridView.Columns[0].HeaderText = "id Собаки ";
						DogdataGridView.Columns[1].HeaderText = "Кличка";
						DogdataGridView.Columns[2].HeaderText = "Хозяин";
						DogdataGridView.Columns[3].HeaderText = "Порода";
						DogdataGridView.Columns[4].HeaderText = "Клуб";
						DogdataGridView.Columns[5].HeaderText = "Год рождения";
						DogdataGridView.Columns[6].HeaderText = "Стоимость (руб)";
						DogdataGridView.Columns[7].HeaderText = "Фото";
						break;

						images = new Dictionary<int, Bitmap>();
						foreach (DataGridViewRow dataGridViewRow in DogdataGridView.Rows)
						{
							if (dataGridViewRow.Index != -1)
							{
								System.IO.MemoryStream myMemStream = new System.IO.MemoryStream((byte[])DogdataGridView[7, dataGridViewRow.Index].Value);
								images[Int32.Parse(DogdataGridView[0, dataGridViewRow.Index].Value.ToString())] = new Bitmap(myMemStream);
								System.Drawing.Image fullsizeImage = System.Drawing.Image.FromStream(myMemStream);
								System.Drawing.Image newImage = fullsizeImage.GetThumbnailImage(50, 50, null, IntPtr.Zero);
								System.IO.MemoryStream myResult = new System.IO.MemoryStream();
								newImage.Save(myResult, System.Drawing.Imaging.ImageFormat.Jpeg);
								DogdataGridView[6, dataGridViewRow.Index].Value = myResult.ToArray();
								myMemStream.Close();
								myResult.Close();
							}
						}
					case 3: //открытие вкладки участие
						dt = DBFunctions.SpecifitSelectFieldsFromTable(cmd, _connectionString);
						if (dt != null)
						{
							ParticdataGridView.DataSource = dt;

						}
						Particpageslabel.Text = "Количество полей: " + ParticdataGridView.Rows.Count;
						ParticdataGridView.Columns[0].HeaderText = "id Участника";
						ParticdataGridView.Columns[1].HeaderText = "Кличка собаки";
						ParticdataGridView.Columns[2].HeaderText = "Порода";
						ParticdataGridView.Columns[3].HeaderText = "Хозяин";
						ParticdataGridView.Columns[4].HeaderText = "Клуб";
						ParticdataGridView.Columns[5].HeaderText = "Название соревнования";
						ParticdataGridView.Columns[6].HeaderText = "Город";
						ParticdataGridView.Columns[7].HeaderText = "Место проведения";
						ParticdataGridView.Columns[8].HeaderText = "Дата проведения";
						break;
					case 4:    //открытие вкладки награждение
						dt = DBFunctions.SpecifitSelectFieldsFromTable(cmd, _connectionString);
						if (dt != null)
						{
							AwardingdataGridView.DataSource = dt;

						}
						Awardingpageslabel.Text = "Количество полей: " + AwardingdataGridView.Rows.Count;
						AwardingdataGridView.Columns[0].HeaderText = "id Участника";
						AwardingdataGridView.Columns[1].HeaderText = "Кличка собаки";
						AwardingdataGridView.Columns[2].HeaderText = "Порода";
						AwardingdataGridView.Columns[3].HeaderText = "Хозяин";
						AwardingdataGridView.Columns[4].HeaderText = "Клуб";
						AwardingdataGridView.Columns[5].HeaderText = "Название соревнования";
						AwardingdataGridView.Columns[6].HeaderText = "Название награды";
						AwardingdataGridView.Columns[7].HeaderText = "Денежный эквивалент (руб)";
						break;
					case 5: //открытие вкладки породы
						dt = DBFunctions.SpecifitSelectFieldsFromTable(cmd, _connectionString);
						if (dt != null)
						{
							BreeddataGridView.DataSource = dt;

						}
						Breedpageslabel.Text = "Количество полей: " + BreeddataGridView.Rows.Count;
						BreeddataGridView.Columns[0].HeaderText = "id Породы";
						BreeddataGridView.Columns[1].HeaderText = "Название породы";
						break;
					case 6: //открытие вкладки хозяева
						dt = DBFunctions.SpecifitSelectFieldsFromTable(cmd, _connectionString);
						if (dt != null)
						{
							OwnerdataGridView.DataSource = dt;

						}
						Ownerpageslabel.Text = "Количество полей: " + OwnerdataGridView.Rows.Count;
						OwnerdataGridView.Columns[0].HeaderText = "id Хозяина";
						OwnerdataGridView.Columns[1].HeaderText = "Фамилия";
						OwnerdataGridView.Columns[2].HeaderText = "Имя";
						OwnerdataGridView.Columns[3].HeaderText = "Отчество";
						OwnerdataGridView.Columns[4].HeaderText = "Адрес";
						OwnerdataGridView.Columns[5].HeaderText = "Номер телефона";
						break;
					case 7: //открытие вкладки райны
						dt = DBFunctions.SpecifitSelectFieldsFromTable(cmd, _connectionString);
						if (dt != null)
						{
							DistrdataGridView.DataSource = dt;

						}
						Distrpageslabel.Text = "Количество полей: " + DistrdataGridView.Rows.Count;
						DistrdataGridView.Columns[0].HeaderText = "id Района";
						DistrdataGridView.Columns[1].HeaderText = "Название района";

						break;
					case 8: //открытие вкладки города
						dt = DBFunctions.SpecifitSelectFieldsFromTable(cmd, _connectionString);
						if (dt != null)
						{
							CitydataGridView.DataSource = dt;

						}
						Citypageslabel.Text = "Количество полей: " + CitydataGridView.Rows.Count;
						CitydataGridView.Columns[0].HeaderText = "id Города";
						CitydataGridView.Columns[1].HeaderText = "Название города";
						CitydataGridView.Columns[2].HeaderText = "Область";
						break;
					case 9: //открытие вкладки области
						dt = DBFunctions.SpecifitSelectFieldsFromTable(cmd, _connectionString);
						if (dt != null)
						{
							RegdataGridView.DataSource = dt;

						}
						Regpageslabel.Text = "Количество полей: " + RegdataGridView.Rows.Count;
						RegdataGridView.Columns[0].HeaderText = "id Области";
						RegdataGridView.Columns[1].HeaderText = "Название области";
						break;
					case 10: //открытие вкладки банки
						dt = DBFunctions.SpecifitSelectFieldsFromTable(cmd, _connectionString);
						if (dt != null)
						{
							BankdataGridView.DataSource = dt;

						}
						Bankpageslabel.Text = "Количество полей: " + BankdataGridView.Rows.Count;
						BankdataGridView.Columns[0].HeaderText = "id Банка";
						BankdataGridView.Columns[1].HeaderText = "Название Банка";
						break;
					case 11: //открытие вкладки место проведения соревнования
						dt = DBFunctions.SpecifitSelectFieldsFromTable(cmd, _connectionString);
						if (dt != null)
						{
							VenuedataGridView.DataSource = dt;

						}
						Venuepageslabel.Text = "Количество полей: " + VenuedataGridView.Rows.Count;
						VenuedataGridView.Columns[0].HeaderText = "id Места проведения";
						VenuedataGridView.Columns[1].HeaderText = "Название места проведения";
						break;
					case 12: //открытие вкладки награды
						dt = DBFunctions.SpecifitSelectFieldsFromTable(cmd, _connectionString);
						if (dt != null)
						{
							AwarddataGridView.DataSource = dt;

						}
						//Awardpageslabel.Text = "Количество полей: " + AwarddataGridView.Rows.Count;
						AwarddataGridView.Columns[0].HeaderText = "id Награды";
						AwarddataGridView.Columns[1].HeaderText = "Название награды";
						AwarddataGridView.Columns[2].HeaderText = "Денежный эквивалент (руб)";
						break;
				}
			}
			catch
			{
				if (dr == null) return;
				if (!dr.IsClosed) dr.Close();
			}
		}

        private void button19_Click(object sender, EventArgs e)
        {
			LoadTable(tabControl1.SelectedIndex);
        }

		private async void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			

			string msg = await DBFunctions.ClearAllTablesAsync(_connectionString);

			LoadTable(tabControl1.SelectedIndex);

			MessageBox.Show(msg);
		}

        private void selectsButton_Click(object sender, EventArgs e)
        {
			RequestsForm RF = new RequestsForm(_connectionString);
			RF.ShowDialog();
		}

        private void одномернаяДиаграммаToolStripMenuItem_Click(object sender, EventArgs e)
        {
			Diagram1 DG1 = new Diagram1(_connectionString);
			DG1.ShowDialog();
        }

        private void столбчатаяДиаграммаToolStripMenuItem_Click(object sender, EventArgs e)
        {
			Diagram2 DG2 = new Diagram2(_connectionString);
			DG2.ShowDialog();
		}

        private void helpButton_Click(object sender, EventArgs e)
        {
			Help HF = new Help();
			HF.Show();
		}
    }
}
