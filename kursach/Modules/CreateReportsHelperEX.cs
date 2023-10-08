using kursach.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using Microsoft.Win32;
using OfficeOpenXml.Style;
using System.Drawing;

namespace kursach.Modules
{
    public class CreateReportsHelperEX
    {
        public static void GenerateSalesReportByEmployeeExcel(int IdEmployee)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var employee = ModelPublic.GetContext().Employees.FirstOrDefault(f => f.Idemployee == Reserv.IdPerson);
            if (employee == null)
            {
                throw new Exception("Сотрудник не найден.");
            }

            var sales = ModelPublic.GetContext().Payments
                .Where(w => w.Idemployee == employee.Idemployee)
                .SelectMany(sm => sm.Paymentproducts)
                .GroupBy(gb => gb.Idproduct)
                .Select(s => new
                {
                    IdProduct = s.Key,
                    Quantity = s.Sum(ss => ss.Quantity)
                })
                .ToList();

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel файл (*.xlsx)|*.xlsx";
            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;

                // Создание нового пакета Excel
                using (ExcelPackage package = new ExcelPackage())
                {
                    // Создание нового листа
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Отчет о продажах");

                    // Заполнение заголовков
                    worksheet.Cells[1, 1].Value = "Название товара";
                    worksheet.Cells[1, 2].Value = "Количество";
                    worksheet.Cells[1, 3].Value = employee.Surname;
                    worksheet.Cells[1, 4].Value = employee.Firstname;
                    worksheet.Cells[1, 5].Value = employee.Lastname;

                    // Заполнение данных о продажах
                    int row = 2;
                    foreach (var sale in sales)
                    {
                        var product = ModelPublic.GetContext().Products.FirstOrDefault(p => p.Idproduct == sale.IdProduct);
                        worksheet.Cells[row, 1].Value = product.Naming;
                        worksheet.Cells[row, 2].Value = sale.Quantity;
                        row++;
                    }

                    // Добавление стилей для заголовков
                    using (var range = worksheet.Cells[1, 1, 1, 2])
                    {
                        range.Style.Font.Bold = true;
                        range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        range.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                    }

                    // Автоматическое подгонка ширины столбцов
                    worksheet.Cells.AutoFitColumns();

                    // Сохранение пакета Excel в файл
                    package.SaveAs(new FileInfo(filePath));
                }
            }
        }

        public static void GenerateSalesReportByEmployeeWithPeriodExcel(int IdEmployee, DateTime dateStart, DateTime dateEnd)
        {
            var employee = ModelPublic.GetContext().Employees.FirstOrDefault(f => f.Idemployee == Reserv.IdPerson);
            if (employee == null)
            {
                throw new Exception("Сотрудник не найден.");
            }
            DateOnly dateStartOnly = new DateOnly(dateStart.Year, dateStart.Month, dateStart.Day);
            DateOnly dateEndOnly = new DateOnly(dateEnd.Year, dateEnd.Month, dateEnd.Day);

            var sales = ModelPublic.GetContext().Payments
                .Where(w => w.Idemployee == employee.Idemployee && w.Dateofpay >= dateStartOnly && w.Dateofpay <= dateEndOnly)
                .Select(p => new
                {
                    Sale = p,
                    Products = p.Paymentproducts.Select(pp => new
                    {
                        Product = pp.IdproductNavigation,
                        Quantity = pp.Quantity,
                        Price = pp.IdproductNavigation.Price
                    })
                })
                .ToList();

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel документ (*.xlsx)|*.xlsx";
            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;

                // Создание файла Excel
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelPackage excelPackage = new ExcelPackage();
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Отчет");

                // Заполнение заголовков столбцов
                worksheet.Cells[1, 1].Value = "Название товара";
                worksheet.Cells[1, 2].Value = "Количество";
                worksheet.Cells[1, 3].Value = "Цена";

                int row = 2;
                foreach (var sale in sales)
                {
                    worksheet.Cells[row, 1].Value = $"ПРОДАЖА №{row - 1}:";
                    worksheet.Cells[row, 1].Style.Font.Bold = true;
                    worksheet.Cells[row, 1, row, 3].Merge = true;
                    row++;

                    decimal? saleTotal = 0;
                    foreach (var product in sale.Products)
                    {
                        worksheet.Cells[row, 1].Value = product.Product.Naming;
                        worksheet.Cells[row, 2].Value = product.Quantity;
                        worksheet.Cells[row, 3].Value = product.Price;
                        row++;

                        saleTotal += product.Quantity * product.Price;
                    }

                    worksheet.Cells[row, 1].Value = "ИТОГО(сумма):";
                    worksheet.Cells[row, 1].Style.Font.Bold = true;
                    worksheet.Cells[row, 1, row, 2].Merge = true;
                    worksheet.Cells[row, 3].Value = saleTotal;
                    row++;
                }

                // Добавление ФИО сотрудника
                worksheet.Cells[row, 1].Value = "Сотрудник:";
                worksheet.Cells[row, 2].Value = $"{employee.Surname} {employee.Firstname} {employee.Lastname}";
                row++;

                // Вычисление итоговой суммы всех продаж
                decimal? totalSalesAmount = sales.Sum(s => s.Sale.Totalsumm);
                worksheet.Cells[row, 1].Value = "ИТОГО(всего продаж):";
                worksheet.Cells[row, 1].Style.Font.Bold = true;
                worksheet.Cells[row, 1, row, 2].Merge = true;
                worksheet.Cells[row, 3].Value = totalSalesAmount;

                // Автоизменение ширины столбцов
                worksheet.Cells.AutoFitColumns();

                // Сохранение файла Excel
                File.WriteAllBytes(filePath, excelPackage.GetAsByteArray());
            }
        }
    }
}
