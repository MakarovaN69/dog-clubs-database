using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace newKursBd
{
    static public class WorkWithExcel
    {
		public static async Task SaveExcelFile(DataTable dt, FileInfo file)
		{

			DeleteIfExists(file);
			try
			{
				using (var package = new ExcelPackage(file))
				{
					var ws = package.Workbook.Worksheets.Add("Запрос");
					var range = ws.Cells["A1"].LoadFromDataTable(dt, true);

					range.AutoFitColumns();

                    ws.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Row(1).Style.Font.Bold = true;

                    await package.SaveAsync();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private static void DeleteIfExists(FileInfo file)
		{
			try
			{
				if (file.Exists)
				{
					file.Delete();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}
