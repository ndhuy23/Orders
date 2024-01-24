using AutoMapper;
using Orders.ViewModel;
using Orders.ViewModel.Dto;

namespace Orders.Services
{
    public interface IOrderService
    {
        public ResultModel Get();
        public ResultModel Get(int id);
        public ResultModel Post(OrderDto orderDto);
    }
    
    public class OrderService : IOrderService
    {
        private readonly OrderDbContext _context;
        private ResultModel _result;
        private IMapper _mapper;

        public OrderService(OrderDbContext context, IMapper mapper)
        {
            _context = context;
            _result = new ResultModel();
            _mapper = mapper;
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

        public ResultModel Post(OrderDto orderDto)
        {
            try
            {
                Order data = _mapper.Map<Order>(orderDto);
                _context.Add(data);
                _context.SaveChanges();
                _result.Data = orderDto;
                _result.IsSuccess = true;
                _result.Message = "Post Successfully";
            }
            catch( Exception ex)
            {
                _result.IsSuccess = false;
                _result.Message = "Post Failed";
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
