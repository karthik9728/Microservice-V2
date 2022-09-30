using Mango.Services.OrderAPI.Models.DTOs;
using Mango.Services.OrderAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.OrderAPI.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderAPIController : Controller
    {
        protected ResponceDto _responce;
        private IOrderRepository _orderRepository;
        public OrderAPIController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
            this._responce = new ResponceDto();
        }

        [HttpPost]
        //[Authorize]
        public async Task<object> Create([FromBody] OrderHeaderDto orderHeaderDto)
        {
            try
            {
                var model = await _orderRepository.AddOrderHeader(orderHeaderDto);
                _responce.Result = model;
            }
            catch (Exception ex)
            {

                _responce.IsSuccess = false;
                _responce.ErrorMessage = new List<string> { ex.ToString() };
            }
            return _responce;
        }
    }
}
