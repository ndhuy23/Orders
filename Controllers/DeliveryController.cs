using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Orders.Services;
using Orders.ViewModel;
using Orders.ViewModel.Dto;

namespace Orders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        public readonly IDeliveryService _deliveryService;
        public readonly IOrderService _orderService;
        public DeliveryController(IDeliveryService deliveryService, IOrderService orderService)
        {
            _deliveryService = deliveryService;
        }

        
        [HttpPost]
        public IActionResult Search(SearchDto searchDto)
        {
            ResultModel result = _deliveryService.Search(searchDto);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
    
}
