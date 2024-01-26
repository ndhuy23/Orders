using System;
using System.IO;
using NPOI.SS;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;

namespace Orders.Services
{
    public class ExcelService
    {

        private OrderDbContext _context;
        public ExcelService(OrderDbContext context)
        {
            _context = context;
        }
        public void WriteExcel(Delivery delivery)
        {
            Order order = _context.Orders.First<Order>(or => or.OrderId == delivery.OrderId);
            Shipper shipper = _context.Shippers.First<Shipper>(sp => sp.ShipperId == delivery.ShipperId);
            // Tạo một file Excel
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Delivery.xlsx");
            IWorkbook workbook;
            ISheet sheet;
            IRow row;
            int rowCount;

            // Kiểm tra xem tệp đã tồn tại hay chưa
            if (File.Exists(filePath))
            {
                // Nếu tệp đã tồn tại, mở nó
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite))
                {
                    workbook = new XSSFWorkbook(fs);
                    sheet = workbook.GetSheetAt(0); // Lấy ra sheet đầu tiên
                    rowCount = sheet.LastRowNum + 1; // Lấy số hàng hiện có và tăng thêm 1
                }
            }
            else
            {
                // Nếu tệp không tồn tại, tạo một tệp mới
                workbook = new XSSFWorkbook();
                sheet = workbook.CreateSheet("Sheet1"); // Tạo sheet mới với tên "Sheet1"
                rowCount = 0;
            }

            // Thêm dữ liệu vào tệp Excel
            row = sheet.CreateRow(rowCount);
            string deliveryDate = delivery.DeliveryDate.ToString("dd-MM-yyyy");
            row.CreateCell(0).SetCellValue(order.OrderCode);
            row.CreateCell(1).SetCellValue(order.TotalPrice);
            row.CreateCell(2).SetCellValue(delivery.DeliveryCode);
            row.CreateCell(3).SetCellValue(deliveryDate);
            row.CreateCell(4).SetCellValue(delivery.Status);
            row.CreateCell(5).SetCellValue(shipper.Code);
            row.CreateCell(6).SetCellValue(shipper.Name);

            // Lưu tệp Excel
            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                workbook.Write(fs);
            }
        }
    }
}
