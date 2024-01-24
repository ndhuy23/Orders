using AutoMapper;
using Orders.ViewModel.Dto;

namespace Orders
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMap()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<OrderDto, Order>();
                config.CreateMap<Order, OrderDto>();
        
            });
            return mappingConfig;
        }
    }
}
