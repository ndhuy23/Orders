using AutoMapper;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Orders.Migrations;
using Orders.ViewModel;
using Orders.ViewModel.Dto;
using Orders.ViewModel.Response;

namespace Orders.Services
{
    public interface IDeliveryService
    {
        public ResultModel Get();
        public ResultModel Post(Order order, Shipper shipper);
        ResultModel Search(SearchDto searchDto);
    }
    public class DeliveryService : IDeliveryService
    {
        private readonly OrderDbContext _context;
        private ResultModel _result;
        private IMapper _mapper;
        private readonly ExcelService _excelService;
        public DeliveryService(OrderDbContext context, IMapper mapper, ExcelService excelService)
        {
            _context = context;
            _result = new ResultModel();
            _mapper = mapper;
            _excelService = excelService;
        }

        public ResultModel Get()
        {
            try
            {
                IEnumerable<Delivery> data = _context.Deliveries.ToList();
                _result.Data = data;
                _result.IsSuccess = true;
                _result.Message = "Get Successfully";
            }
            catch (Exception ex)
            {
                _result.IsSuccess = false;
                _result.Message = ex.Message;
            }
            return _result;
        }

        public ResultModel Post(Order order, Shipper shipper)
        {
            try
            {
                Delivery delivery = new Delivery();
                delivery.OrderId = order.OrderId;
                delivery.ShipperId = shipper.ShipperId;
                delivery.DeliveryDate = DateTime.Now;
                delivery.DeliveryCode = "DC" + delivery.DeliveryDate.Millisecond.ToString();
                delivery.Status = order.Status;
                _context.Add(delivery);
                _context.SaveChanges();
                _excelService.WriteExcel(delivery);
                DeliveryResponse deliveryResponse = new DeliveryResponse(order.OrderCode, order.TotalPrice, delivery.DeliveryCode, delivery.DeliveryDate, order.Status, shipper.Code, shipper.Name);
                _result.Data = deliveryResponse;
                _result.IsSuccess = true;
                _result.Message = "Create Order Successfully";
            }
            catch (Exception ex)
            {
                _result.Data = null;
                _result.IsSuccess = false;
                _result.Message = "Please check again OrderId or ShipperId";
            }
            
            return _result;
        }

        

        public ResultModel Search(SearchDto searchDto)
        {
            var deliveries = _context.Deliveries
                .Where(de => (de.DeliveryDate >= searchDto.from
                              && de.DeliveryDate <= searchDto.to) && de.Status == "Delivered");
            try
            {
                Dictionary<Shipper, int> ListShipper = new Dictionary<Shipper, int>();
                List<Shipper> shippers = new List<Shipper>();
                var result = deliveries.GroupBy(de => de.ShipperId)
                                        .Select(group => new
                                        {
                                            Shipper = group.Key,
                                            Count = group.Count()
                                        })
                                        .OrderBy(sp => sp.Shipper);
                List<ShipperResponseDelivered> data = new List<ShipperResponseDelivered>();
                foreach (var line in result)
                {
                    Shipper shipper = _context.Shippers.First(sp => sp.ShipperId == line.Shipper);
                    data.Add(new ShipperResponseDelivered(shipper.Code, shipper.Name, line.Count));
                }
                _result.Data = data;
                _result.IsSuccess = true;
                _result.Message = "Successfully";
            }
            catch (Exception ex)
            {
                _result.Data =
                _result.IsSuccess = false;
                _result.Message = ex.Message;
            }
            return _result;

        }
    }
}
