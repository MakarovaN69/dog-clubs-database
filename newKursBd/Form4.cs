using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace newKursBd
{
	public partial class Form4 : Form
	{
		private string _connectionString = null;
		private int _dogId = 0;
		private int _comp = 0;
		private string dogName = null;
		private bool isDateSorted = false;
		private bool isVenueSorted = false;
		DateTime dt1, dt2;
		private string dogCompatitions = "SELECT competition.competition_id, compet_name, bank.bank, pay_account, city.city, " +
			"venue.venue, date_event, partic_fee, number_viewers " +
			"FROM competition " +
			"INNER JOIN bank ON  competition.bank_id=bank.bank_id " +
			"INNER JOIN city ON competition.city_id=city.city_id " +
			"INNER JOIN venue ON competition.venue_id= venue.venue_id " +
			"INNER JOIN participation ON competition.competition_id = participation.competition_id " +
			"INNER JOIN dog ON  participation.dog_id= dog.dog_id " +
			"WHERE dog.dog_id = {0} " +
			"{1} ";// + // AND ....
				   //"{2} ";
		public Dictionary<string, int> VenueNamesAndIDs = new Dictionary<string, int>();
		public Dictionary<string, int> NameDogNamesAndIDs = new Dictionary<string, int>();

		public Form4(int dogID, string connString)
		{
			InitializeComponent();
			_connectionString = connString;
			_dogId = dogID;
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void Form4_Load(object sender, EventArgs e)
		{
			
			NameDogNamesAndIDs.Clear();
			DataTable dt = DBFunctions.Read("SELECT dog_id, dog.nickname FROM dog ORDER BY dog.nickname", _connectionString);
			var IDs = dt.Rows.Cast<DataRow>().Select(x => x.ItemArray[0]).ToArray();
			var names = dt.Rows.Cast<DataRow>().Select(x => x.ItemArray[1]).ToArray();

			for (int i = 0; i < IDs.Count(); i++)
			{
				try
				{
					NameDogNamesAndIDs.Add(names[i].ToString(), (int)IDs[i]);
				}
				catch (Exception) { }
			}

			dogNicknameComboBox.Items.AddRange(NameDogNamesAndIDs.Keys.ToArray());


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

			VenueNamecomboBox.Items.AddRange(VenueNamesAndIDs.Keys.ToArray());

			UpdateDefaultData();
			DefaultLoadTable();
		}

		private void UpdateDefaultData()
        {
			DataTable dt = DBFunctions.SpecifitSelectFieldsFromTable("SELECT dog_id, nickname, concat (owner.surname, ' ', owner.name, ' ', owner.midname) ownerfullName, breed.breed, club.club_name, year_birth, price, foto FROM dog " +
				"INNER JOIN owner ON  dog.owner_id = owner.owner_id " +
				"INNER JOIN breed ON  dog.breed_id = breed.breed_id " +
				"INNER JOIN club ON  dog.club_id = club.club_id " +
				$"WHERE dog_id = {_dogId}" +
				"ORDER BY dog_id ASC", _connectionString);

			var stringArr = dt.Rows[0].ItemArray.Select(x => x.ToString()).ToArray();
			//label1.Text = "Кличка: " + stringArr[1];
			dogNicknameComboBox.SelectedItem = stringArr[1];
			dogName = stringArr[1];
			label2.Text = "ФИО Хозяина: " + stringArr[2];
			label3.Text = "Порода: " + stringArr[3];
			label4.Text = "Клуб: " + stringArr[4];
			label5.Text = "Год рождения: " + stringArr[5];
			label6.Text = "Стоимость: " + stringArr[6];


			label10.Text = "Количество записей основной таблицы: " + DBFunctions.SelectRowsCountFromTable($"dog WHERE dog_id = {_dogId}", _connectionString);
		}

		private void DefaultLoadTable()
		{
			string cmd = String.Format(dogCompatitions, _dogId, "ORDER BY competition.competition_id ASC ");
			DataTable dt = DBFunctions.SpecifitSelectFieldsFromTable(cmd, _connectionString);
			if (dt != null)
			{
				dataGridView1.DataSource = dt;

				dataGridView1.BackgroundColor = Color.White;
				SetColumnNames("");
			}
		}

		private void SetColumnNames(string whereAnd)
		{
			if (dataGridView1.Columns.Count == 9)
			{
				dataGridView1.ClearSelection();
				dataGridView1.Columns[0].HeaderText = "id Соревнования";
				dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
				dataGridView1.Columns[1].HeaderText = "Название совервнования";
				dataGridView1.Columns[2].HeaderText = "Банк расчётного счёта";
				dataGridView1.Columns[3].HeaderText = "Расчётный счёт";
				dataGridView1.Columns[4].HeaderText = "Город";
				dataGridView1.Columns[5].HeaderText = "Место проведения";
				dataGridView1.Columns[6].HeaderText = "Дата проведения";
				dataGridView1.Columns[7].HeaderText = "Взнос за участие (руб)";
				dataGridView1.Columns[8].HeaderText = "Количество зрителей (тыс)";
			}

			label8.Text = "Количество полей: " + dataGridView1.Rows.Count;
			string cmd = String.Format(dogCompatitions, _dogId, whereAnd);
			cmd = cmd.Replace("competition.competition_id, compet_name, bank.bank, pay_account, city.city, " +
			"venue.venue, date_event, partic_fee, number_viewers", "SUM(partic_fee)");
			cmd = cmd.Replace("ORDER BY competition.competition_id ASC", "");
			label7.Text = "Общая сумма взноса\n(денежный эквивалент): " + DBFunctions.SelectLineFromTable(cmd, _connectionString);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			string whereAnd = $"AND date_event BETWEEN '{dateTimePicker1.Value.Year}-{dateTimePicker1.Value.Month}-{dateTimePicker1.Value.Day}' " +
			$"AND '{dateTimePicker2.Value.Year}-{dateTimePicker2.Value.Month}-{dateTimePicker2.Value.Day}' ";
			if (VenueNamecomboBox.SelectedItem != null)
			{
				VenueNamesAndIDs.TryGetValue(VenueNamecomboBox.Text, out int venueID);
				whereAnd += $" AND venue.venue_id = {venueID} ";
			}
			whereAnd += " GROUP BY competition.competition_id, bank.bank, city.city, venue.venue, date_event ORDER BY competition.date_event ASC ";
			dt1 = dateTimePicker1.Value;
			dt2 = dateTimePicker2.Value;

			string cmd = String.Format(dogCompatitions, _dogId, whereAnd);
			DataTable dt = DBFunctions.SpecifitSelectFieldsFromTable(cmd, _connectionString);
			if (dt != null)
			{
				dataGridView1.DataSource = dt;

				dataGridView1.BackgroundColor = Color.White;
				whereAnd = whereAnd.Replace("GROUP BY competition.competition_id, bank.bank, city.city, venue.venue, date_event ORDER BY competition.date_event ASC", "");
				SetColumnNames(whereAnd);
			}

			isDateSorted = true;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			CancelFilters();
		}

		private void CancelFilters()
        {
			DefaultLoadTable();
			isDateSorted = false;
			isVenueSorted = false;
			dateTimePicker1.Value = DateTime.Today;
			dateTimePicker2.Value = DateTime.Today;
			VenueNamecomboBox.SelectedItem = null;
		}

		private void button4_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void chooseallcheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (dataGridView1.SelectedRows.Count == dataGridView1.Rows.Count)
			{
				dataGridView1.ClearSelection();
			}
			else
			{
				dataGridView1.SelectAll();
			}
		}

		private void button16_Click(object sender, EventArgs e)
		{
			if (dataGridView1.SelectedRows.Count == 0) return;
			if (MessageBox.Show("Данное удаление может повлечь за собой удаление данных из таблицы Участие и Награждение ", "", MessageBoxButtons.YesNo) == DialogResult.No) return;

			for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
			{
				DBFunctions.DeleteLineFromTable("participation", $"competition_id = {dataGridView1.SelectedRows[i].Cells[0].Value} AND dog_id = {_dogId}", _connectionString);
			}

			DefaultLoadTable();
			isDateSorted = false;
			isVenueSorted = false;
		}

		private void button15_Click(object sender, EventArgs e)
		{
			Form3 addElemForm = new Form3(_connectionString, 3, dogNickname: dogName);
			addElemForm.ShowDialog();

			DefaultLoadTable();
			isDateSorted = false;
			isVenueSorted = false;
		}

		private void label8_Click(object sender, EventArgs e)
		{

		}

		private void VenueNamecomboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			string cmd = "";
			if (isDateSorted)
			{
				string whereAnd = $" AND date_event BETWEEN '{dt1.Year}-{dt1.Month}-{dt1.Day}' " +
			$"AND '{dt2.Year}-{dt2.Month}-{dt2.Day}' ";

				if (VenueNamecomboBox.SelectedItem != null)
				{
					VenueNamesAndIDs.TryGetValue(VenueNamecomboBox.Text, out int venueID);
					whereAnd += $" AND venue.venue_id = {venueID} GROUP BY competition.competition_id, bank.bank, city.city, venue.venue, date_event";
				}

				cmd = String.Format(dogCompatitions, _dogId, whereAnd);
			}
			else if (VenueNamecomboBox.SelectedItem != null)
			{
				VenueNamesAndIDs.TryGetValue(VenueNamecomboBox.Text, out int venueID);
				cmd = String.Format(dogCompatitions, _dogId, $" AND venue.venue_id = {venueID} GROUP BY competition.competition_id, bank.bank, city.city, venue.venue, date_event");
			}

			DataTable dt = DBFunctions.SpecifitSelectFieldsFromTable(cmd, _connectionString);
			if (dt != null)
			{
				dataGridView1.DataSource = dt;

				dataGridView1.BackgroundColor = Color.White;
				SetColumnNames("");
			}
		}

        private void dogNicknameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
			NameDogNamesAndIDs.TryGetValue(dogNicknameComboBox.Text, out _dogId);
			UpdateDefaultData();
			CancelFilters();
		}

        private void button17_Click(object sender, EventArgs e)
		{
			if (dataGridView1.SelectedRows.Count != 1)
			{
				MessageBox.Show("Выберите один элемент для редактирования!", "Error!");
				return;
			}

			int ID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
			Form3 addElemForm = new Form3(_connectionString, 3, Convert.ToInt32(DBFunctions.SelectLineFromTable($"SELECT participant_id FROM participation WHERE dog_id = {_dogId} AND competition_id = {ID} LIMIT 1", _connectionString)), true, dogName);
			addElemForm.ShowDialog();

			DefaultLoadTable();
			isDateSorted = false;
			isVenueSorted = false;
		}
	}
}
