using AutoMapper;
using ShoppingCart.Application.DTOs.Order;
using ShoppingCart.Application.Interfaces.Repositories;
using ShoppingCart.Application.Interfaces.Services;
using ShoppingCart.Domain.Entities;
using ShoppingCart.Domain.Enums;

namespace ShoppingCart.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<OrderDetail> repository;
        private readonly IMapper mapper;

        public OrderService(IRepository<OrderDetail> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public OrderReadDto CreateOrder(OrderCreateDto order)
        {
            //var orderItem = mapper.Map<IList<OrderItem>>(order.OrderItems);

            var orderDetail = mapper.Map<OrderDetail>(order);
            //orderDetail.OrderItems = orderItem;
            orderDetail.CreatedOn = DateTime.Now;
            orderDetail.UpdatedOn = DateTime.Now;

            repository.Add(orderDetail);
            repository.SaveChanges();

            var orderReadDto = mapper.Map<OrderReadDto>(orderDetail);

            return orderReadDto;
        }

        public OrderReadDto GetOrder(int orderId)
        {
            var orderDetail = mapper.Map<OrderReadDto>(repository.Get(o => o.Id == orderId));

            return orderDetail;
        }

        public IEnumerable<OrderReadDto> GetOrders()
        {
            var orderDetails = mapper.Map<IEnumerable<OrderReadDto>>(repository.GetAll());

            return orderDetails;
        }

        public OrderReadDto UpdateOrder(int orderId, OrderStatus orderStatus)
        {
            var orderDetail = repository.Get(o => o.Id == orderId);
            orderDetail.UpdatedOn = DateTime.Now;
            if (orderDetail != null)
            {
                repository.Update(orderDetail);
                repository.SaveChanges();

                return mapper.Map<OrderReadDto>(orderDetail);
            }

            return null;
        }
    }
}
