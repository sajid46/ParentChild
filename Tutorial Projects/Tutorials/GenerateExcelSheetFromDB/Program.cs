using GenerateExcelSheetFromDB.Data;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateExcelSheetFromDB
{

    class Program
    {
        static TaxiBoxEntities db = new TaxiBoxEntities();
        public Program()
        {
            
        }
        static void Main(string[] args)
        {
            GetData getData = new GetData();
            CreateSpreadSheet(getData.ReturnDataSet());
        }

        private static void CreateSpreadSheet(List<JobModel> jobModels)
        {
            string fileName = "sample.xlsx";
            
            File.Delete(fileName);
            FileInfo fileInfo = new FileInfo(fileName);
            ExcelPackage exp = new ExcelPackage(fileInfo);

            var ws = exp.Workbook.Worksheets.Add("Jobs");

            ws.Cells["A1"].Value = "ID";
            ws.Cells["B1"].Value = "Pickup";
            ws.Cells["C1"].Value = "Desrtination";

            ws.Cells["A1:C1"].Style.Font.Bold = true;


            ws.Cells["A:Z1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid; 
            ws.Cells["A1:Z1"].Style.Fill.BackgroundColor.SetColor(Color.Red);
            ws.Cells["A1:Z1"].Style.Font.Color.SetColor(Color.White);

            ws.Cells["A1:Z1"].Style.Font.Size = 13;
            ws.Row(1).Height = 40;

            
            ws.Column(1).Width = 10;
            ws.Column(2).Width = 40;
            ws.Column(3).Width = 40;




            int currentRow = 2;
            foreach (var item in jobModels)
            {
                ws.Cells["A" + currentRow].Value = item.ID;
                ws.Cells["B" + currentRow].Value = item.Pickup;
                ws.Cells["C" + currentRow].Value = item.Destination;
                ws.Row(currentRow).Height = 30;
                currentRow++;
            }

            ws.View.FreezePanes(2, 1);

            exp.Save();
        }
    }

    public class GetData : IGetData
    {
        public static TaxiBoxEntities db = new TaxiBoxEntities();

        public List<JobModel> ReturnDataSet()
        {
            List<JobModel> obj  = (from x in db.Jobs
                          select new JobModel
                          {
                              ID = x.ID,
                              Pickup = x.Pickup,
                              Destination = x.Destination
                          }).ToList();

            return obj;
        }
    }

    internal interface IGetData
    {
        List<JobModel> ReturnDataSet();
    }

    public class JobModel
    {
        public int ID { get; set; }
        public string Pickup { get; set; }
        public string Destination { get; set; }
    }
}
