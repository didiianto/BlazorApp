using Microsoft.JSInterop;
using BlazorApp.Data;
using ClosedXML.Excel;

namespace BlazorApp.XLS
{
    public class Excel
    {
        public async Task GenerateEventRegistrationAsync(IJSRuntime js,
                                                   List<EventRegistration> data,
                                                   string filename = "Report.xlsx")
        {
            var XLSStream = GenerateExcel(data);

            await js.InvokeVoidAsync("BlazorDownloadFile", filename, XLSStream);
        }

        public byte[] GenerateExcel(List<EventRegistration> data)
        {
            var wb = new XLWorkbook();
            wb.Properties.Author = "the Author";
            wb.Properties.Title = "the Title";
            wb.Properties.Subject = "the Subject";
            wb.Properties.Category = "the Category";
            wb.Properties.Keywords = "the Keywords";
            wb.Properties.Comments = "the Comments";
            wb.Properties.Status = "the Status";
            wb.Properties.LastModifiedBy = "the Last Modified By";
            wb.Properties.Company = "the Company";
            wb.Properties.Manager = "the Manager";

            var ws = wb.Worksheets.Add("Sheet1");

            ws.Cell(1, 1).Value = "FullName";
            ws.Cell(1, 2).Value = "Email";
            ws.Cell(1, 3).Value = "Address";
            ws.Cell(1, 4).Value = "Gender";
            ws.Cell(1, 5).Value = "Country";
            ws.Cell(1, 6).Value = "Interest";

            // Fill a cell with a date
            //var cellDateTime = ws.Cell(1, 2);
            //cellDateTime.Value = new DateTime(2010, 9, 2);
            //cellDateTime.Style.DateFormat.Format = "yyyy-MMM-dd";

            int x = 2;
            int y = 2;

            for (int row = 0; row < data.Count; row++)
            {
                // The apostrophe is to force ClosedXML to treat the date as a string
                x = 1;
                ws.Cell(y, x).Value = "'" + data[row].FullName; x++;
                ws.Cell(y, x).Value = data[row].Email; x++;
                ws.Cell(y, x).Value = data[row].Address; x++;
                ws.Cell(y, x).Value = data[row].Gender; x++;
                ws.Cell(y, x).Value = data[row].Country; x++;
                ws.Cell(y, x).Value = data[row].Interests; x++;

                y++;
            }

            MemoryStream XLSStream = new();
            wb.SaveAs(XLSStream);

            return XLSStream.ToArray();
        }
    }
}
