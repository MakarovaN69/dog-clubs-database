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
    public partial class Diagram1 : Form
    {
		private readonly string _connectionString = null;
		public Diagram1(string connString)
        {
            InitializeComponent();
			_connectionString = connString;
		}

        private void Diagram1_Load(object sender, EventArgs e)
        {
			LoadDiagramm();
		}

        private void LoadDiagramm()
        {
			DataTable dt = DBFunctions.SpecifitSelectFieldsFromTable(RequestData.forDiagram1, _connectionString);
			if (dt != null)
			{
				if (dt.Columns.Count == RequestData.queryColumnsNames[13].Count()-1)
				{
					var diagramNames = dt.Rows.Cast<DataRow>().Select(x => x.ItemArray[1]).ToArray();
					var diagramTriangles = dt.Rows.Cast<DataRow>().Select(x => x.ItemArray[2]).ToArray();

					chart1.Series[0].Points.DataBindXY(diagramNames, diagramTriangles);

					for (int i = 0; i < diagramTriangles.Count(); i++)
					{
						chart1.Series[0].Points[i].Label = (diagramTriangles[i]).ToString();
						chart1.Series[0].Points[i].LegendText = (diagramNames[i]).ToString();
					}
				}
			}
		}
    }
}
