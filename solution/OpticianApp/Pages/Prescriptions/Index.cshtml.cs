using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using OpticianApp.Models;

namespace OpticianApp.Pages.OpticalPrescriptions
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<OpticalPrescription> OpticalPrescription { get; set; } = default!;

        public string SearchCustomer { get; set; }
        public DateTime? SearchDate { get; set; }

        public async Task OnGetAsync(string searchCustomer, DateTime? searchDate)
        {
            SearchCustomer = searchCustomer;
            SearchDate = searchDate;

            var prescriptions = _context.OpticalPrescription.Include(p => p.Customer).AsQueryable();

            if (!string.IsNullOrEmpty(SearchCustomer))
            {
                prescriptions = prescriptions.Where(p => p.Customer.Surname.Contains(SearchCustomer));
            }

            if (SearchDate.HasValue)
            {
                prescriptions = prescriptions.Where(p => p.PrescriptionDate.Date == SearchDate.Value.Date);
            }

            OpticalPrescription = await prescriptions.ToListAsync();
        }

        public async Task<IActionResult> OnGetExportToExcel()
        {
            var prescriptions = await _context.OpticalPrescription.Include(x => x.Customer)
            .Select(p => new
            {
                p.PrescriptionDate,
                p.CustomerId,
                CustomerName = p.Customer.FullName,
                p.RightEyeCorrection,
                p.LeftEyeCorrection,
            }).ToListAsync(); // Fetch your data from the database

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {

                var worksheet = package.Workbook.Worksheets.Add("Prescriptions");
                worksheet.Cells["A1"].LoadFromCollection(prescriptions, PrintHeaders: true);
                var stream = new MemoryStream();
                package.SaveAs(stream);

                string excelName = $"Prescriptions-{DateTime.Now.ToString("yyyyMMddHHmmssfff")}.xlsx";

                return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
            }
        }

        public async Task<IActionResult> OnGetExportToPdf()
        {
            var prescriptions = await _context.OpticalPrescription.Include(x => x.Customer).ToListAsync(); // Fetch your data from the database

            using (MemoryStream stream = new MemoryStream())
            {
                Document pdfDoc = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 0f);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();

                PdfPTable table = new PdfPTable(6); // Create a table with 6 columns

                // Add table headers
                table.AddCell("Prescription Date");
                table.AddCell("Name");
                table.AddCell("Surname");
                table.AddCell("Address");
                table.AddCell("Left Coorrection");
                table.AddCell("Right Correction");

                foreach (var prescription in prescriptions)
                {
                    // Add customer data to the table
                    table.AddCell(prescription.PrescriptionDate.ToString("dd/MM/yyyy"));
                    table.AddCell(prescription.Customer.Name);
                    table.AddCell(prescription.Customer.Surname);
                    table.AddCell(prescription.Customer.Address);
                    table.AddCell(prescription.LeftEyeCorrection.ToString());
                    table.AddCell(prescription.RightEyeCorrection.ToString());
                }

                pdfDoc.Add(table); // Add the table to the PDF document

                pdfDoc.Close();

                return File(stream.ToArray(), "application/pdf", "Prescriptions.pdf");
            }
        }
    }
}
