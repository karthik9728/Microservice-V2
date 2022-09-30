using Mango.Services.OrderAPI.Models;
using Mango.Services.OrderAPI.Models.DTOs;

namespace Mango.Services.OrderAPI.Repository
{
    public interface IOrderRepository
    {
        Task<OrderHeaderDto> AddOrderHeader(OrderHeaderDto orderHeaderDto);
        Task<bool> AddOrder(OrderHeader orderHeader);

        Task UpdateOrderPaymentStatus(int orderHeaderId,bool paid);
    }
}
