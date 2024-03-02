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
    public partial class Diagram2 : Form
    {

		private readonly string _connectionString = null;
		public Diagram2(string connString)
		{
			InitializeComponent();
			_connectionString = connString;
		}

		private void Diagram2_Load(object sender, EventArgs e)
		{
			LoadDiagramm();
		}

		private void LoadDiagramm()
		{
			chart1.Dock = DockStyle.Fill;
			DataTable dt = DBFunctions.SpecifitSelectFieldsFromTable(RequestData.totalIncluding, _connectionString);
			if (dt != null)
			{
				if (dt.Columns.Count == RequestData.queryColumnsNames[8].Count())
				{
					var values = dt.Rows[0].ItemArray.Select(x => Convert.ToInt32(x)).ToArray();

					chart1.Series[0].Points.DataBindXY(RequestData.queryColumnsNames[8], values);

					for (int i = 0; i < values.Count(); i++)
					{
						chart1.Series[0].Points[i].Label = (values[i]).ToString();
						chart1.Series[0].Points[i].LegendText = (RequestData.queryColumnsNames[8]).ToString();
					}
				}
			}
		}
	}
}
