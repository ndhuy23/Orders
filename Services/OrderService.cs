using AutoMapper;
using Orders.ViewModel;
using Orders.ViewModel.Dto;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Orders.Services
{
    public interface IOrderService
    {
        public ResultModel Get();
        public ResultModel Get(int id);
        public ResultModel Post(CreateOrderDto orderDto);
    }
    
    public class OrderService : IOrderService
    {
        private readonly OrderDbContext _context;
        private ResultModel _result;
        private IMapper _mapper;
        public readonly IDeliveryService _deliveryService;

        public OrderService(OrderDbContext context, IMapper mapper, IDeliveryService deliveryService)
        {
            _context = context;
            _result = new ResultModel();
            _mapper = mapper;
            _deliveryService = deliveryService;
        }

        public ResultModel Get()
        {
            try
            {
                IEnumerable<Order> data = _context.Orders.ToList();
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

        public ResultModel Get(int id)
        {
            try
            {
                var data = _context.Orders.First(o => o.OrderId == id);
                _result.Data = _mapper.Map<OrderDto>(data);
                _result.IsSuccess = true;
                _result.Message = "Get Successfully";
            }
            catch(Exception ex)
            {
                _result.IsSuccess = false;
                _result.Message = ex.Message;
            }
            return _result;
        }

        public ResultModel Post(CreateOrderDto createOrderDto)
        {
            try
            {
                Order order = new Order(createOrderDto.OrderCode, createOrderDto.TotalPrice);
                Shipper shipper = _context.Shippers.First(s => s.Code == createOrderDto.ShipperCode);
                _context.Add(order);
                _context.SaveChanges();
                _result = _deliveryService.Post(order, shipper);
            }
            catch( Exception ex)
            {
                _result.IsSuccess = false;
                _result.Message = "Please check Shipper Id";
            }

            return _result;
        }

        //public ResultModel Post()
        //{
        //    var 
        //    throw new NotImplementedException();
        //}
    }
}
