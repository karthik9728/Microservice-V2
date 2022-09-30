using Mango.Web.Models;

namespace Mango.Web.Services.IServices
{
    public interface IOrderService
    {
        Task<T> CreateOrderAsync<T>(CartHeaderDto cartHeaderDto, string token);
    }
}
