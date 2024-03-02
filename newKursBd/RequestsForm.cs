using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace newKursBd
{
	public partial class RequestsForm : Form
	{
		public Dictionary<string, int> AnyNamesAndIDs1 = new Dictionary<string, int>();
		public Dictionary<string, int> AnyNamesAndIDs2 = new Dictionary<string, int>();
		public Dictionary<string, int> AnyNamesAndIDs3 = new Dictionary<string, int>();
		public Dictionary<string, int> AnyNamesAndIDs4 = new Dictionary<string, int>();
		public Dictionary<string, int> AnyNamesAndIDs5 = new Dictionary<string, int>();
		public Dictionary<string, int> AnyNamesAndIDs6 = new Dictionary<string, int>();
		private readonly string _connectionString = null;
		private int requestIndex = 0;
		public RequestsForm(string connect)
		{
			InitializeComponent();
			_connectionString = connect;
		}

		private void SelectscomboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			ClearInputData();

			switch (SelectscomboBox.SelectedIndex)
			{
				case 0:
					{
						label2.Visible = true;
						OutputcomboBox.Visible = true;

						AnyNamesAndIDs1.Clear();
						DataTable dt = DBFunctions.Read("SELECT district_id, district_name FROM district ORDER BY district_name", _connectionString);
						var IDs = dt.Rows.Cast<DataRow>().Select(x => x.ItemArray[0]).ToArray();
						var names = dt.Rows.Cast<DataRow>().Select(x => x.ItemArray[1]).ToArray();

						for (int i = 0; i < IDs.Count(); i++)
						{
							try
							{
								AnyNamesAndIDs1.Add(names[i].ToString(), (int)IDs[i]);
							}
							catch (Exception) { }
						}
						OutputcomboBox.Items.AddRange(AnyNamesAndIDs1.Keys.ToArray());
					}
					break;
				case 1:
					{
						label2.Visible = true;
						OutputcomboBox.Visible = true;
						comboBox1.Visible = true;

						AnyNamesAndIDs1.Clear();
						DataTable dt = DBFunctions.Read("SELECT breed_id, breed FROM breed  ORDER BY breed", _connectionString);
						var IDs = dt.Rows.Cast<DataRow>().Select(x => x.ItemArray[0]).ToArray();
						var names = dt.Rows.Cast<DataRow>().Select(x => x.ItemArray[1]).ToArray();
						for (int i = 0; i < IDs.Count(); i++)
						{
							try
							{
								AnyNamesAndIDs1.Add(names[i].ToString(), (int)IDs[i]);
							}
							catch (Exception) { }
						}
						OutputcomboBox.Items.AddRange(AnyNamesAndIDs1.Keys.ToArray());

						AnyNamesAndIDs2.Clear();
						dt = DBFunctions.Read("SELECT club_id, club_name FROM club ORDER BY club_name", _connectionString);
						IDs = dt.Rows.Cast<DataRow>().Select(x => x.ItemArray[0]).ToArray();
						names = dt.Rows.Cast<DataRow>().Select(x => x.ItemArray[1]).ToArray();
						for (int i = 0; i < IDs.Count(); i++)
						{
							try
							{
								AnyNamesAndIDs2.Add(names[i].ToString(), (int)IDs[i]);
							}
							catch (Exception) { }
						}
						comboBox1.Items.AddRange(AnyNamesAndIDs2.Keys.ToArray());
					}
					break;
				case 2:
				case 3:
					{
						label2.Visible = true;
						label4.Visible = true;
						label5.Visible = true;
						dateTimePicker1.Visible = true;
						dateTimePicker2.Visible = true;
					}
					break;
				case 4:
				case 5:
				case 6:
				case 7:
				case 8:
				case 11:
					break;
				case 13:
					{
						label2.Visible = true;
						InputtextBox.Visible = true;
						//label4.Visible = true;
						//label5.Visible = true;
						//dateTimePicker1.Visible = true;
						//dateTimePicker2.Visible = true;
					}
					break;
				case 15:
				case 16:
					break;
				case 9:
					{
						label2.Visible = true;
						InputtextBox.Visible = true;
					}
					break;
				case 10:
					{
						label2.Visible = true;
						InputtextBox.Visible = true;
					}
					break;
				case 12:
					{
						label2.Visible = true;
						OutputcomboBox.Visible = true;

						AnyNamesAndIDs3.Clear();
						DataTable dt = DBFunctions.Read("SELECT city_id, city FROM city ORDER BY city", _connectionString);
						var IDs = dt.Rows.Cast<DataRow>().Select(x => x.ItemArray[0]).ToArray();
						var names = dt.Rows.Cast<DataRow>().Select(x => x.ItemArray[1]).ToArray();

						for (int i = 0; i < IDs.Count(); i++)
						{
							try
							{
								AnyNamesAndIDs3.Add(names[i].ToString(), (int)IDs[i]);
							}
							catch (Exception) { }
						}
						OutputcomboBox.Items.AddRange(AnyNamesAndIDs3.Keys.ToArray());
					}
					break;
				case 14:
					{
						label2.Visible = true;
						OutputcomboBox.Visible = true;
						InputtextBox.Visible = true;

						AnyNamesAndIDs4.Clear();
						DataTable dt = DBFunctions.Read("SELECT participant_id, dog.nickname FROM participation " +
						"INNER JOIN dog ON  participation.dog_id=dog.dog_id ORDER BY dog.nickname", _connectionString);
						var IDs = dt.Rows.Cast<DataRow>().Select(x => x.ItemArray[0]).ToArray();
						var names = dt.Rows.Cast<DataRow>().Select(x => x.ItemArray[1]).ToArray();

						for (int i = 0; i < IDs.Count(); i++)
						{
							try
							{
								AnyNamesAndIDs4.Add(names[i].ToString(), (int)IDs[i]);
							}
							catch (Exception) { }
						}
						OutputcomboBox.Items.AddRange(AnyNamesAndIDs4.Keys.ToArray());
						
					}
					break;
				case 17:
					{
						label2.Visible = true;
						OutputcomboBox.Visible = true;

						AnyNamesAndIDs5.Clear();
						DataTable dt = DBFunctions.Read("SELECT owner_id, concat (surname, ' ', name, ' ', midname) \"FullName\" FROM owner ORDER BY \"FullName\"", _connectionString);
						var IDs = dt.Rows.Cast<DataRow>().Select(x => x.ItemArray[0]).ToArray();
						var names = dt.Rows.Cast<DataRow>().Select(x => x.ItemArray[1]).ToArray();

						for (int i = 0; i < IDs.Count(); i++)
						{
							try
							{
								AnyNamesAndIDs5.Add(names[i].ToString(), (int)IDs[i]);
							}
							catch (Exception) { }
						}
						OutputcomboBox.Items.AddRange(AnyNamesAndIDs5.Keys.ToArray());
					}
					break;
				case 18:
					{
						label2.Visible = true;
						OutputcomboBox.Visible = true;

						AnyNamesAndIDs3.Clear();
						DataTable dt = DBFunctions.Read("SELECT city_id, city FROM city ORDER BY city", _connectionString);
						var IDs = dt.Rows.Cast<DataRow>().Select(x => x.ItemArray[0]).ToArray();
						var names = dt.Rows.Cast<DataRow>().Select(x => x.ItemArray[1]).ToArray();

						for (int i = 0; i < IDs.Count(); i++)
						{
							try
							{
								AnyNamesAndIDs3.Add(names[i].ToString(), (int)IDs[i]);
							}
							catch (Exception) { }
						}
						OutputcomboBox.Items.AddRange(AnyNamesAndIDs3.Keys.ToArray());
					}
					break;
				case 19:
					{

					}
					break;
				case 20:
					{

					}
					break;
				case 21:
					{

					}
					break;
				case 22:
					{

					}
					break;
				case 23:
					{

					}
					break;
				case 24:
					{
						label2.Visible = true;
						OutputcomboBox.Visible = true;

						AnyNamesAndIDs6.Clear();
						DataTable dt = DBFunctions.Read("SELECT competition_id, compet_name FROM competition ORDER BY  compet_name", _connectionString);
						var IDs = dt.Rows.Cast<DataRow>().Select(x => x.ItemArray[0]).ToArray();
						var names = dt.Rows.Cast<DataRow>().Select(x => x.ItemArray[1]).ToArray();
						for (int i = 0; i < IDs.Count(); i++)
						{
							try
							{
								AnyNamesAndIDs6.Add(names[i].ToString(), (int)IDs[i]);
							}
							catch (Exception) { }
						}
						OutputcomboBox.Items.AddRange(AnyNamesAndIDs6.Keys.ToArray());
					}
					break;
			}
		}

		private void RequestsForm_Load(object sender, EventArgs e)
		{
			ClearInputData();
			SelectscomboBox.Items.Clear();

			SelectscomboBox.Items.AddRange(RequestData.queryNames);
		}

		private void ClearInputData()
		{
			OutputcomboBox.Items.Clear();
			comboBox1.Items.Clear();
			InputtextBox.Clear();
			exportToExcelButton.Enabled = false;

			label2.Visible = false;
			label4.Visible = false;
			label5.Visible = false;
			dateTimePicker1.Visible = false;
			dateTimePicker2.Visible = false;
			OutputcomboBox.Visible = false;
			InputtextBox.Visible = false;
			comboBox1.Visible = false;
		}

		private void Applybutton_Click(object sender, EventArgs e)
		{
			exportToExcelButton.Enabled = false;
			requestIndex = SelectscomboBox.SelectedIndex;
			switch (requestIndex)
			{
				case 0:
					{
						if (OutputcomboBox.SelectedItem == null) return;

						AnyNamesAndIDs1.TryGetValue(OutputcomboBox.Text, out int Id);
						string cmd = String.Format(RequestData.innerJoinWithForeignKey1, Id);

						DataTable dt = DBFunctions.SpecifitSelectFieldsFromTable(cmd, _connectionString);
						if (dt != null)
						{
							dataGridView1.DataSource = dt;

							if (dataGridView1.Columns.Count == RequestData.queryColumnsNames[requestIndex].Count())
							{
								dataGridView1.BackgroundColor = Color.White;
								dataGridView1.ClearSelection();
								dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

								for (int i = 0; i < RequestData.queryColumnsNames[requestIndex].Count(); i++)
								{
									dataGridView1.Columns[i].HeaderText = RequestData.queryColumnsNames[requestIndex][i];
								}

								exportToExcelButton.Enabled = true;
							}
						}

						CountRecordinglabel.Text = "Количество записей: " + dataGridView1.Rows.Count;
					}
					break;
				case 1:
					{
						if (OutputcomboBox.SelectedItem == null || comboBox1.SelectedItem == null) return;

						AnyNamesAndIDs1.TryGetValue(OutputcomboBox.Text, out int Id1);
						AnyNamesAndIDs2.TryGetValue(comboBox1.Text, out int Id2);
						string cmd = String.Format(RequestData.innerJoinWithForeignKey2, Id1, Id2);

						DataTable dt = DBFunctions.SpecifitSelectFieldsFromTable(cmd, _connectionString);
						if (dt != null)
						{
							dataGridView1.DataSource = dt;

							if (dataGridView1.Columns.Count == RequestData.queryColumnsNames[requestIndex].Count())
							{
								dataGridView1.BackgroundColor = Color.White;
								dataGridView1.ClearSelection();
								dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

								for (int i = 0; i < RequestData.queryColumnsNames[requestIndex].Count(); i++)
								{
									dataGridView1.Columns[i].HeaderText = RequestData.queryColumnsNames[requestIndex][i];
								}

								exportToExcelButton.Enabled = true;
							}
						}

						CountRecordinglabel.Text = "Количество записей: " + dataGridView1.Rows.Count;
					}
					break;
				case 2:
					{
						string[] dates =
						{
							$"'{dateTimePicker1.Value.Year}-{dateTimePicker1.Value.Month}-{dateTimePicker1.Value.Day}'",
							$"'{dateTimePicker2.Value.Year}-{dateTimePicker2.Value.Month}-{dateTimePicker2.Value.Day}'"
						};

						string cmd = String.Format(RequestData.innerJoinWithDate1, dates[0], dates[1]);

						DataTable dt = DBFunctions.SpecifitSelectFieldsFromTable(cmd, _connectionString);
						if (dt != null)
						{
							dataGridView1.DataSource = dt;

							if (dataGridView1.Columns.Count == RequestData.queryColumnsNames[requestIndex].Count())
							{
								dataGridView1.BackgroundColor = Color.White;
								dataGridView1.ClearSelection();
								dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

								for (int i = 0; i < RequestData.queryColumnsNames[requestIndex].Count(); i++)
								{
									dataGridView1.Columns[i].HeaderText = RequestData.queryColumnsNames[requestIndex][i];
								}

								exportToExcelButton.Enabled = true;
							}
						}

						CountRecordinglabel.Text = "Количество записей: " + dataGridView1.Rows.Count;
					}
					break;
				case 3:
					{
						string[] dates =
						{
							$"{dateTimePicker1.Value.Year}",
							$"{dateTimePicker2.Value.Year}"
						};

						string cmd = String.Format(RequestData.innerJoinWithDate2, dates[0], dates[1]);

						DataTable dt = DBFunctions.SpecifitSelectFieldsFromTable(cmd, _connectionString);
						if (dt != null)
						{
							dataGridView1.DataSource = dt;

							if (dataGridView1.Columns.Count == RequestData.queryColumnsNames[requestIndex].Count())
							{
								dataGridView1.BackgroundColor = Color.White;
								dataGridView1.ClearSelection();
								dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

								for (int i = 0; i < RequestData.queryColumnsNames[requestIndex].Count(); i++)
								{
									dataGridView1.Columns[i].HeaderText = RequestData.queryColumnsNames[requestIndex][i];
								}

								exportToExcelButton.Enabled = true;
							}
						}

						CountRecordinglabel.Text = "Количество записей: " + dataGridView1.Rows.Count;
					}
					break;
				case 4:
					{
						string cmd = String.Format(RequestData.leftJoin);

						DataTable dt = DBFunctions.SpecifitSelectFieldsFromTable(cmd, _connectionString);
						if (dt != null)
						{
							dataGridView1.DataSource = dt;

							if (dataGridView1.Columns.Count == RequestData.queryColumnsNames[requestIndex].Count())
							{
								dataGridView1.BackgroundColor = Color.White;
								dataGridView1.ClearSelection();
								dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

								for (int i = 0; i < RequestData.queryColumnsNames[requestIndex].Count(); i++)
								{
									dataGridView1.Columns[i].HeaderText = RequestData.queryColumnsNames[requestIndex][i];
								}

								//exportToExcelButton.Enabled = true;
							}
						}

						CountRecordinglabel.Text = "Количество записей: " + dataGridView1.Rows.Count;
					}
					break;
				case 5:
					{
						string cmd = String.Format(RequestData.rightJoin);

						DataTable dt = DBFunctions.SpecifitSelectFieldsFromTable(cmd, _connectionString);
						if (dt != null)
						{
							dataGridView1.DataSource = dt;

							if (dataGridView1.Columns.Count == RequestData.queryColumnsNames[requestIndex].Count())
							{
								dataGridView1.BackgroundColor = Color.White;
								dataGridView1.ClearSelection();
								dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

								for (int i = 0; i < RequestData.queryColumnsNames[requestIndex].Count(); i++)
								{
									dataGridView1.Columns[i].HeaderText = RequestData.queryColumnsNames[requestIndex][i];
								}

								exportToExcelButton.Enabled = true;

							}
						}

						CountRecordinglabel.Text = "Количество записей: " + dataGridView1.Rows.Count;
					}
					break;
				case 6:
					{
						string cmd = String.Format(RequestData.queryOnQueryByLeftJoinPrinciple);

						DataTable dt = DBFunctions.SpecifitSelectFieldsFromTable(cmd, _connectionString);
						if (dt != null)
						{
							dataGridView1.DataSource = dt;

							if (dataGridView1.Columns.Count == RequestData.queryColumnsNames[requestIndex].Count())
							{
								dataGridView1.BackgroundColor = Color.White;
								dataGridView1.ClearSelection();
								dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

								for (int i = 0; i < RequestData.queryColumnsNames[requestIndex].Count(); i++)
								{
									dataGridView1.Columns[i].HeaderText = RequestData.queryColumnsNames[requestIndex][i];
								}

								exportToExcelButton.Enabled = true;
								
							}
						}

						CountRecordinglabel.Text = "Количество записей: " + dataGridView1.Rows.Count;

					}
					break;
				case 7:
					{
						string cmd = String.Format(RequestData.finalQueryWithoutCondition);

						DataTable dt = DBFunctions.SpecifitSelectFieldsFromTable(cmd, _connectionString);
						if (dt != null)
						{
							dataGridView1.DataSource = dt;

							if (dataGridView1.Columns.Count == RequestData.queryColumnsNames[requestIndex].Count())
							{
								dataGridView1.BackgroundColor = Color.White;
								dataGridView1.ClearSelection();
								dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

								for (int i = 0; i < RequestData.queryColumnsNames[requestIndex].Count(); i++)
								{
									dataGridView1.Columns[i].HeaderText = RequestData.queryColumnsNames[requestIndex][i];
								}

								exportToExcelButton.Enabled = true;

							}
						}

						CountRecordinglabel.Text = "Количество записей: " + dataGridView1.Rows.Count;

					}
					break;
				case 8:
					{
						string cmd = String.Format(RequestData.totalIncluding);

						DataTable dt = DBFunctions.SpecifitSelectFieldsFromTable(cmd, _connectionString);
						if (dt != null)
						{
							dataGridView1.DataSource = dt;

							if (dataGridView1.Columns.Count == RequestData.queryColumnsNames[requestIndex].Count())
							{
								dataGridView1.BackgroundColor = Color.White;
								dataGridView1.ClearSelection();
								dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

								for (int i = 0; i < RequestData.queryColumnsNames[requestIndex].Count(); i++)
								{
									dataGridView1.Columns[i].HeaderText = RequestData.queryColumnsNames[requestIndex][i];
								}

								exportToExcelButton.Enabled = true;

							}
						}

						CountRecordinglabel.Text = "Количество записей: " + dataGridView1.Rows.Count;
					}
					break;
				case 9:
					{

						if (!Int32.TryParse(InputtextBox.Text.Trim(), out int sum)) return;
						string cmd = String.Format(RequestData.summaryQueriesWithConditionOnDataByValue, sum);

						DataTable dt = DBFunctions.SpecifitSelectFieldsFromTable(cmd, _connectionString);
						if (dt != null)
						{
							dataGridView1.DataSource = dt;

							if (dataGridView1.Columns.Count == RequestData.queryColumnsNames[requestIndex].Count())
							{
								dataGridView1.BackgroundColor = Color.White;
								dataGridView1.ClearSelection();
								dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

								for (int i = 0; i < RequestData.queryColumnsNames[requestIndex].Count(); i++)
								{
									dataGridView1.Columns[i].HeaderText = RequestData.queryColumnsNames[requestIndex][i];
								}

								exportToExcelButton.Enabled = true;
							}
						}

						CountRecordinglabel.Text = "Количество записей: " + dataGridView1.Rows.Count;
					}
					break;
				case 10:
					{
						if (!String.IsNullOrEmpty(InputtextBox.Text.Trim()))
                        {
							string cmd = String.Format(RequestData.summaryQueriesWithConditionOnDataByMask, InputtextBox.Text);

							DataTable dt = DBFunctions.SpecifitSelectFieldsFromTable(cmd, _connectionString);
							if (dt != null)
							{
								dataGridView1.DataSource = dt;

								if (dataGridView1.Columns.Count == RequestData.queryColumnsNames[requestIndex].Count())
								{
									dataGridView1.BackgroundColor = Color.White;
									dataGridView1.ClearSelection();
									dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

									for (int i = 0; i < RequestData.queryColumnsNames[requestIndex].Count(); i++)
									{
										dataGridView1.Columns[i].HeaderText = RequestData.queryColumnsNames[requestIndex][i];
									}

									exportToExcelButton.Enabled = true;
								}
							}

							CountRecordinglabel.Text = "Количество записей: " + dataGridView1.Rows.Count;
						}
						
						
					}
					break;
				case 11:
					{
						
						string cmd = String.Format(RequestData.summaryQueriesWithConditionOnDataByIndex);

						DataTable dt = DBFunctions.SpecifitSelectFieldsFromTable(cmd, _connectionString);
						if (dt != null)
						{
							dataGridView1.DataSource = dt;

							if (dataGridView1.Columns.Count == RequestData.queryColumnsNames[requestIndex].Count())
							{
								dataGridView1.BackgroundColor = Color.White;
								dataGridView1.ClearSelection();
								dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

								for (int i = 0; i < RequestData.queryColumnsNames[requestIndex].Count(); i++)
								{
									dataGridView1.Columns[i].HeaderText = RequestData.queryColumnsNames[requestIndex][i];
								}

								exportToExcelButton.Enabled = true;
							}
						}

						CountRecordinglabel.Text = "Количество записей: " + dataGridView1.Rows.Count;
					}
					break;
				case 12:
					{
						if (OutputcomboBox.SelectedItem == null) return;

						AnyNamesAndIDs3.TryGetValue(OutputcomboBox.Text, out int Id);
						string cmd = String.Format(RequestData.summaryQueriesWithConditionOnDataWithoutIndex, Id);

						DataTable dt = DBFunctions.SpecifitSelectFieldsFromTable(cmd, _connectionString);
						if (dt != null)
						{
							dataGridView1.DataSource = dt;

							if (dataGridView1.Columns.Count == RequestData.queryColumnsNames[requestIndex].Count())
							{
								dataGridView1.BackgroundColor = Color.White;
								dataGridView1.ClearSelection();
								dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

								for (int i = 0; i < RequestData.queryColumnsNames[requestIndex].Count(); i++)
								{
									dataGridView1.Columns[i].HeaderText = RequestData.queryColumnsNames[requestIndex][i];
								}

								exportToExcelButton.Enabled = true;
							}
						}

						CountRecordinglabel.Text = "Количество записей: " + dataGridView1.Rows.Count;
					}
					break;
				case 13:
					{
						//string[] dates =
						//{
						//	$"{dateTimePicker1.Value.Year}",
						//	$"{dateTimePicker2.Value.Year}"
						//};

						//string cmd = String.Format(RequestData.finalQueryWithConditionOnGroups, dates[0], dates[1]);

						if (!Int32.TryParse(InputtextBox.Text.Trim(), out int sum)) return;
						string cmd = String.Format(RequestData.finalQueryWithConditionOnGroups, sum);

						DataTable dt = DBFunctions.SpecifitSelectFieldsFromTable(cmd, _connectionString);
						if (dt != null)
						{
							dataGridView1.DataSource = dt;

							if (dataGridView1.Columns.Count == RequestData.queryColumnsNames[requestIndex].Count())
							{
								dataGridView1.BackgroundColor = Color.White;
								dataGridView1.ClearSelection();
								dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

								for (int i = 0; i < RequestData.queryColumnsNames[requestIndex].Count(); i++)
								{
									dataGridView1.Columns[i].HeaderText = RequestData.queryColumnsNames[requestIndex][i];
								}

								exportToExcelButton.Enabled = true;

							}
						}

						CountRecordinglabel.Text = "Количество записей: " + dataGridView1.Rows.Count;
					}
					break;
				case 14:
					{
						if (OutputcomboBox.SelectedItem == null || !Int32.TryParse(InputtextBox.Text.Trim(), out int sum)) return;
						AnyNamesAndIDs4.TryGetValue(OutputcomboBox.Text, out int Id4);
						
						string cmd = String.Format(RequestData.finalQueryWithConditionOnDataAndGroups, Id4, sum);

						DataTable dt = DBFunctions.SpecifitSelectFieldsFromTable(cmd, _connectionString);
						if (dt != null)
						{
							dataGridView1.DataSource = dt;

							if (dataGridView1.Columns.Count == RequestData.queryColumnsNames[requestIndex].Count())
							{
								dataGridView1.BackgroundColor = Color.White;
								dataGridView1.ClearSelection();
								dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

								for (int i = 0; i < RequestData.queryColumnsNames[requestIndex].Count(); i++)
								{
									dataGridView1.Columns[i].HeaderText = RequestData.queryColumnsNames[requestIndex][i];
								}

								exportToExcelButton.Enabled = true;
							}
						}

						CountRecordinglabel.Text = "Количество записей: " + dataGridView1.Rows.Count;
					}
					break;
				case 15:
					{
						string cmd = String.Format(RequestData.requestOnRequestBasedOnPrincipleOfFinalRequest);

						DataTable dt = DBFunctions.SpecifitSelectFieldsFromTable(cmd, _connectionString);
						if (dt != null)
						{
							dataGridView1.DataSource = dt;

							if (dataGridView1.Columns.Count == RequestData.queryColumnsNames[requestIndex].Count())
							{
								dataGridView1.BackgroundColor = Color.White;
								dataGridView1.ClearSelection();
								dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

								for (int i = 0; i < RequestData.queryColumnsNames[requestIndex].Count(); i++)
								{
									dataGridView1.Columns[i].HeaderText = RequestData.queryColumnsNames[requestIndex][i];
								}

								exportToExcelButton.Enabled = true;

							}
						}

						CountRecordinglabel.Text = "Количество записей: " + dataGridView1.Rows.Count;
					}
					break;
				case 16:
					{
						string cmd = String.Format(RequestData.queryUsingUnion);

						DataTable dt = DBFunctions.SpecifitSelectFieldsFromTable(cmd, _connectionString);
						if (dt != null)
						{
							dataGridView1.DataSource = dt;

							if (dataGridView1.Columns.Count == RequestData.queryColumnsNames[requestIndex].Count())
							{
								dataGridView1.BackgroundColor = Color.White;
								dataGridView1.ClearSelection();
								dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

								for (int i = 0; i < RequestData.queryColumnsNames[requestIndex].Count(); i++)
								{
									dataGridView1.Columns[i].HeaderText = RequestData.queryColumnsNames[requestIndex][i];
								}

								exportToExcelButton.Enabled = true;
							}
						}

						CountRecordinglabel.Text = "Количество записей: " + dataGridView1.Rows.Count;
					}
					break;
				case 17:
					{
						if (OutputcomboBox.SelectedItem == null) return;

						AnyNamesAndIDs5.TryGetValue(OutputcomboBox.Text, out int Id);
						string cmd = String.Format(RequestData.queriesWithSubqueriesUsingIn, Id);

						DataTable dt = DBFunctions.SpecifitSelectFieldsFromTable(cmd, _connectionString);
						if (dt != null)
						{
							dataGridView1.DataSource = dt;

							if (dataGridView1.Columns.Count == RequestData.queryColumnsNames[requestIndex].Count())
							{
								dataGridView1.BackgroundColor = Color.White;
								dataGridView1.ClearSelection();
								dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

								for (int i = 0; i < RequestData.queryColumnsNames[requestIndex].Count(); i++)
								{
									dataGridView1.Columns[i].HeaderText = RequestData.queryColumnsNames[requestIndex][i];
								}

								exportToExcelButton.Enabled = true;
							}
						}

						CountRecordinglabel.Text = "Количество записей: " + dataGridView1.Rows.Count;
					}
					break;
				case 18:
					{
						if (OutputcomboBox.SelectedItem == null) return;

						AnyNamesAndIDs3.TryGetValue(OutputcomboBox.Text, out int Id);
						string cmd = String.Format(RequestData.queriesWithSubqueriesUsingNotIn, Id);

						DataTable dt = DBFunctions.SpecifitSelectFieldsFromTable(cmd, _connectionString);
						if (dt != null)
						{
							dataGridView1.DataSource = dt;

							if (dataGridView1.Columns.Count == RequestData.queryColumnsNames[requestIndex].Count())
							{
								dataGridView1.BackgroundColor = Color.White;
								dataGridView1.ClearSelection();
								dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

								for (int i = 0; i < RequestData.queryColumnsNames[requestIndex].Count(); i++)
								{
									dataGridView1.Columns[i].HeaderText = RequestData.queryColumnsNames[requestIndex][i];
								}

								exportToExcelButton.Enabled = true;
							}
						}

						CountRecordinglabel.Text = "Количество записей: " + dataGridView1.Rows.Count;
					}
					break;
				case 19:
					{
						string cmd = String.Format(RequestData.queriesWithSubqueriesUsingCase);

						DataTable dt = DBFunctions.SpecifitSelectFieldsFromTable(cmd, _connectionString);
						if (dt != null)
						{
							dataGridView1.DataSource = dt;

							if (dataGridView1.Columns.Count == RequestData.queryColumnsNames[requestIndex].Count())
							{
								dataGridView1.BackgroundColor = Color.White;
								dataGridView1.ClearSelection();
								dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

								for (int i = 0; i < RequestData.queryColumnsNames[requestIndex].Count(); i++)
								{
									dataGridView1.Columns[i].HeaderText = RequestData.queryColumnsNames[requestIndex][i];
								}

								exportToExcelButton.Enabled = true;
							}
						}

						CountRecordinglabel.Text = "Количество записей: " + dataGridView1.Rows.Count;
					}
					break;
				case 20:
					{
						string cmd = String.Format(RequestData.queriesWithSubqueriesUsingWith);

						DataTable dt = DBFunctions.SpecifitSelectFieldsFromTable(cmd, _connectionString);
						if (dt != null)
						{
							dataGridView1.DataSource = dt;

							if (dataGridView1.Columns.Count == RequestData.queryColumnsNames[requestIndex].Count())
							{
								dataGridView1.BackgroundColor = Color.White;
								dataGridView1.ClearSelection();
								dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

								for (int i = 0; i < RequestData.queryColumnsNames[requestIndex].Count(); i++)
								{
									dataGridView1.Columns[i].HeaderText = RequestData.queryColumnsNames[requestIndex][i];
								}

								exportToExcelButton.Enabled = true;
							}
						}

						CountRecordinglabel.Text = "Количество записей: " + dataGridView1.Rows.Count;
					}
					break;
				case 21:
					{
						string cmd = String.Format(RequestData.specialQuery1);

						DataTable dt = DBFunctions.SpecifitSelectFieldsFromTable(cmd, _connectionString);
						if (dt != null)
						{
							dataGridView1.DataSource = dt;

							if (dataGridView1.Columns.Count == RequestData.queryColumnsNames[requestIndex].Count())
							{
								dataGridView1.BackgroundColor = Color.White;
								dataGridView1.ClearSelection();
								dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

								for (int i = 0; i < RequestData.queryColumnsNames[requestIndex].Count(); i++)
								{
									dataGridView1.Columns[i].HeaderText = RequestData.queryColumnsNames[requestIndex][i];
								}

								exportToExcelButton.Enabled = true;
							}
						}

						CountRecordinglabel.Text = "Количество записей: " + dataGridView1.Rows.Count;
					}
					break;
				case 22:
					{
						string cmd = String.Format(RequestData.specialQuery2_1);

						DataTable dt = DBFunctions.SpecifitSelectFieldsFromTable(cmd, _connectionString);
						if (dt != null)
						{
							dataGridView1.DataSource = dt;

							if (dataGridView1.Columns.Count == RequestData.queryColumnsNames[requestIndex].Count())
							{
								dataGridView1.BackgroundColor = Color.White;
								dataGridView1.ClearSelection();
								dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

								for (int i = 0; i < RequestData.queryColumnsNames[requestIndex].Count(); i++)
								{
									dataGridView1.Columns[i].HeaderText = RequestData.queryColumnsNames[requestIndex][i];
								}

								exportToExcelButton.Enabled = true;
							}
						}

						CountRecordinglabel.Text = "Количество записей: " + dataGridView1.Rows.Count;
					}
					break;
				case 23:
                    {
						string cmd = String.Format(RequestData.specialQuery2_2);

						DataTable dt = DBFunctions.SpecifitSelectFieldsFromTable(cmd, _connectionString);
						if (dt != null)
						{
							dataGridView1.DataSource = dt;

							if (dataGridView1.Columns.Count == RequestData.queryColumnsNames[requestIndex].Count())
							{
								dataGridView1.BackgroundColor = Color.White;
								dataGridView1.ClearSelection();
								dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

								for (int i = 0; i < RequestData.queryColumnsNames[requestIndex].Count(); i++)
								{
									dataGridView1.Columns[i].HeaderText = RequestData.queryColumnsNames[requestIndex][i];
								}

								exportToExcelButton.Enabled = true;
							}
						}

						CountRecordinglabel.Text = "Количество записей: " + dataGridView1.Rows.Count;
					}
					break;
				case 24:
					{
						if (OutputcomboBox.SelectedItem == null) return;

						AnyNamesAndIDs6.TryGetValue(OutputcomboBox.Text, out int Id);

						string cmd = String.Format(RequestData.specialQuery3, Id);

						DataTable dt = DBFunctions.SpecifitSelectFieldsFromTable(cmd, _connectionString);
						if (dt != null)
						{
							dataGridView1.DataSource = dt;

							if (dataGridView1.Columns.Count == RequestData.queryColumnsNames[requestIndex].Count())
							{
								dataGridView1.BackgroundColor = Color.White;
								dataGridView1.ClearSelection();
								dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

								for (int i = 0; i < RequestData.queryColumnsNames[requestIndex].Count(); i++)
								{
									dataGridView1.Columns[i].HeaderText = RequestData.queryColumnsNames[requestIndex][i];
								}

								exportToExcelButton.Enabled = true;
							}
						}

						CountRecordinglabel.Text = "Количество записей: " + dataGridView1.Rows.Count;
					}
					break;
			}
		}

		private void exportToExcelButton_Click(object sender, EventArgs e)
		{
			var dialog = saveFileDialog1.ShowDialog();
			if (dialog != DialogResult.OK && dialog != DialogResult.Yes) return;

			if (!SaveTableToExcel(saveFileDialog1.FileName))
			{
				MessageBox.Show("Ошибка при экспорте таблицы в Excel");
				return;
			}

			var res = MessageBox.Show("Экспорт завершен.\nYes - открыть сгенерированный файл." +
				"\nNo - не открывать сгенерированный файл.", "Экспорт в Excel", MessageBoxButtons.YesNo);

			if (res == DialogResult.Yes)
			{
				try
				{
					Process.Start(saveFileDialog1.FileName);
				}
				catch (Exception ex)
				{
					MessageBox.Show("Файл не найден!");
				}
			}
		}

		private bool SaveTableToExcel(string fileName)
		{
			try
			{
				DataTable dt = (DataTable)dataGridView1.DataSource;

				for (int i = 0; i < RequestData.queryColumnsNames[requestIndex].Count(); i++)
				{
					dt.Columns[i].ColumnName = RequestData.queryColumnsNames[requestIndex][i];
				}

				var file = new FileInfo(fileName);
				Task t = WorkWithExcel.SaveExcelFile(dt, file);
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

        private void SelectscomboBox_MouseHover(object sender, EventArgs e)
        {
			if (SelectscomboBox.SelectedItem != null)
			{
				toolTip1.ToolTipTitle = SelectscomboBox.SelectedItem.ToString();
			}
			else
			{
				toolTip1.ToolTipTitle = "";
			}
		}

        private void OutputcomboBox_MouseHover(object sender, EventArgs e)
        {
			if (OutputcomboBox.SelectedItem != null)
			{
				toolTip1.ToolTipTitle = OutputcomboBox.SelectedItem.ToString();
			}
			else
			{
				toolTip1.ToolTipTitle = "";
			}
		}

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
    }
}
