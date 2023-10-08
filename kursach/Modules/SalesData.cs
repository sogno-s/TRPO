using DocumentFormat.OpenXml.Office.CustomUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursach.Modules
{
    public class SalesData
    {
        public string EmployeeName { get; set; }
        public DateOnly ReportDate { get; set; }
        public List<Item> SoldItems { get; set; }
        public decimal TotalSalesAmount { get; set; }

        public SalesData()
        {
            SoldItems = new List<Item>();
        }



    }
}
