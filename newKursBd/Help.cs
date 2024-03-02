using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace newKursBd
{
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
        }

        private void Help_Load(object sender, EventArgs e)
        {
            HelpLoad();
        }

        private void HelpLoad()
        {
            try
            {
                string[] str = File.ReadAllLines(@"files\Help.txt", Encoding.UTF8);

                foreach (string s in str)
                {
                    helpRichTextBox.Text += s + "\n";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Файл помощи не найден!");
                this.Close();
            }
        }
    }
}
