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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        private void button1_Click_1(object sender, EventArgs e)
        {

            //using (var con = new NpgsqlConnection($"Server=127.0.0.1;Port=5432;User Id={logInTextBox.Text.Trim()};Password={passwordTextBox.Text.Trim()};Database=InsuranceCompanies;"))
            string str = "Server=127.0.0.1;Port=5432;User Id=postgres;Password=ycdam90A;Database=db_dogClubs;";
            //str = str.Replace("ycdam90A", "1111");

            if (String.IsNullOrEmpty(logInTextBox.Text.Trim()) || String.IsNullOrEmpty(passwordTextBox.Text.Trim())) return;
            NpgsqlConnection con = new NpgsqlConnection();
            try
            {
                string connectionString = $"Server=127.0.0.1;Port=5432;User Id={logInTextBox.Text.Trim()};Password={passwordTextBox.Text.Trim()};Database=db_dogClubs;";

                con = new NpgsqlConnection(str);
             
                con.Open();
                con.Close();

                Form2 mainForm = new Form2(str);
                mainForm.Show();

                this.Hide();
            }
            catch 
            {
                MessageBox.Show("Неверный логин или пароль!");
                con.Close();
                //MessageBox.Show("Ошибка авторизации"); 
                //this.Close();
            }
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        private void label3_Click(object sender, EventArgs e)
        {

        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
    }
}
