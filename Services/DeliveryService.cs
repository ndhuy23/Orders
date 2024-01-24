using AutoMapper;
using Orders.ViewModel;
using Orders.ViewModel.Dto;
using Orders.ViewModel.Response;

namespace Orders.Services
{
    public interface IDeliveryService
    {
        public ResultModel Get();
        public ResultModel Post(Order order, Shipper shipper);
    }
    public class DeliveryService : IDeliveryService
    {
        private readonly OrderDbContext _context;
        private ResultModel _result;
        private IMapper _mapper;
        public DeliveryService(OrderDbContext context, IMapper mapper)
        {
            _context = context;
            _result = new ResultModel();
            _mapper = mapper;
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
                delivery.Order = order;
                delivery.Shipper = shipper;
                delivery.DeliveryDate = DateTime.Now;
                delivery.DeliveryCode = "DC" + delivery.DeliveryDate.Millisecond.ToString();
                _context.Add(delivery);
                _context.SaveChanges();
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
    }
}
