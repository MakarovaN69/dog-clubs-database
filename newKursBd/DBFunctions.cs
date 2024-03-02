using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace newKursBd
{
    public static class DBFunctions
    {
		public static DataTable SelectAllFieldsFromTable(string tableName, string connString)
		{
			try
			{
				using (var conn = new NpgsqlConnection(connString))
				{
					conn.Open();
					DataTable dt = new DataTable();

					using (var command = new NpgsqlCommand($"SELECT * FROM {tableName}", conn))
					{

						var reader = command.ExecuteReader();
						if (reader.HasRows)
						{
							dt.Load(reader);
						}
						reader.Close();
					}
					return dt;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
				return null;
			}
		}

		public static DataTable SpecifitSelectFieldsFromTable(string cmd, string connString)
		{
			try
			{
				using (var conn = new NpgsqlConnection(connString))
				{

					conn.Open();
					DataTable dt = new DataTable();

					using (var command = new NpgsqlCommand(cmd, conn))
					{
						var reader = command.ExecuteReader();
						if (reader.HasRows)
						{
							dt.Load(reader);
						}
						reader.Close();
					}
					return dt;
				}
			}
			catch (Exception ex)
			{
				//MessageBox.Show(ex.Message);
				return null;
			}
		}
		public static int SelectRowsCountFromTable(string tableName, string connString)
		{
			int count = 0;
			try
			{
				using (var conn = new NpgsqlConnection(connString))
				{
					conn.Open();

					using (var command = new NpgsqlCommand($"SELECT COUNT (*) FROM {tableName}", conn))
					{
						count = Convert.ToInt32(command.ExecuteScalar());
					}
					return count;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return count;
			}
		}


		public static bool ClearTableCascade(string tableName, string connString)
		{
			try
			{
				using (var conn = new NpgsqlConnection(connString))
				{
					conn.Open();


					using (var command = new NpgsqlCommand($"TRUNCATE TABLE {tableName} RESTART IDENTITY CASCADE", conn))
					{

						command.ExecuteReader();
					}
					return true;
				}

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString() + "\n" + tableName);
				return false;
			}
		}
		public static bool DeleteLineFromTable(string tableName, string where, string connString)
		{
			try
			{
				using (var conn = new NpgsqlConnection(connString))
				{
					conn.Open();
					using (var command = new NpgsqlCommand($"DELETE FROM {tableName} WHERE {where}", conn))
					{

						command.ExecuteReader();

					}
					return true;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString() + "\n" + tableName);
				return false;
			}
		}
		public static bool InsertValueIntoTable(string tableName, string fields, string values, string connString)
		{
			try
			{
				using (var conn = new NpgsqlConnection(connString))
				{
					conn.Open();

					using (var command = new NpgsqlCommand($"INSERT INTO {tableName}({fields}) VALUES (@{fields}) ON CONFLICT ({fields}) DO NOTHING;", conn))
					{
						command.Parameters.AddWithValue($"{fields}", values);
						command.ExecuteNonQuery();
					}
					return true;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return false;
			}
		}

		public static bool InsertValuesIntoTable(string tableNameAndFields, string values, string connString)
		{
			try
			{
				using (var conn = new NpgsqlConnection(connString))
				{
					conn.Open();

					using (var command = new NpgsqlCommand($"INSERT INTO {tableNameAndFields} VALUES ({values}) ON CONFLICT DO NOTHING", conn))
					{
						command.ExecuteNonQuery();
					}
					return true;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return false;
			}
		}

		public static DataTable SelectIDsFromTable(string IDName, string tableName, string connString)
		{
			try
			{
				using (var conn = new NpgsqlConnection(connString))
				{
					conn.Open();

					DataTable dt = new DataTable();

					using (var command = new NpgsqlCommand($"SELECT ({IDName}) FROM {tableName}", conn))
					{
						var reader = command.ExecuteReader();
						if (reader.HasRows)
						{
							dt.Load(reader);
						}
						reader.Close();
						return dt;
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return null;
			}
		}
		public static async Task<string> ClearAllTablesAsync(string connString)
		{
			return await Task.Run(() =>
			{
				ClearTableCascade("club", connString);
				ClearTableCascade("competition", connString);
				ClearTableCascade("dog", connString);
				ClearTableCascade("participation", connString);
				ClearTableCascade("awarding", connString);
				ClearTableCascade("breed", connString);
				ClearTableCascade("owner", connString);
				ClearTableCascade("district", connString);
				ClearTableCascade("city", connString);
				ClearTableCascade("region", connString);
				ClearTableCascade("bank", connString);
				ClearTableCascade("venue", connString);
				ClearTableCascade("award", connString);

				return "Очистка записей завершена";
			});
		}

		public static DataTable AddFieldsFromTable(string cmd, string connString)
		{
			try
			{
				using (var conn = new NpgsqlConnection(connString))
				{
					conn.Open();
					DataTable dt = new DataTable();

					using (var command = new NpgsqlCommand(cmd, conn))
					{
						var reader = command.ExecuteReader();
						if (reader.HasRows)
						{
							dt.Load(reader);
						}
						reader.Close();
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

		public static DataTable Read(string cmd, string connString)
		{
			try
			{
				using (var conn = new NpgsqlConnection(connString))
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

		public static string SelectLineFromTable(string cmd, string connString)
		{
			try
			{
				using (var conn = new NpgsqlConnection(connString))
				{
					conn.Open();

					string line = null;

					using (var command = new NpgsqlCommand(cmd, conn))
					{
						line = command.ExecuteScalar().ToString();
						return line;
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return null;
			}
		}
	}
}
