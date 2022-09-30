using Mango.Services.ShoppingCart.Models.DTOs;
using Mango.Services.ShoppingCart.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.ShoppingCart.Controllers
{
    [Route("api/cart")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;
        protected ResponceDto _responce;
        public CartController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
            this._responce = new ResponceDto();
        }

        [HttpGet("GetCart/{userId}")]
        public async Task<object> GetCart(string userID)
        {
            try
            {
                CartDto cartDto = await _cartRepository.GetCartByUserId(userID);
                _responce.Result = cartDto;
            }
            catch (Exception ex)
            {

                _responce.IsSuccess = false;
                _responce.ErrorMessage = new List<string> { ex.ToString() };
            }
            return _responce;
        }

        [HttpPost("AddCart")]
        public async Task<object> AddCart(CartDto cartDto)
        {
            try
            {
                CartDto cartDt = await _cartRepository.CreateUpdateCart(cartDto);
                _responce.Result = cartDt;
            }
            catch (Exception ex)
            {

                _responce.IsSuccess = false;
                _responce.ErrorMessage = new List<string> { ex.ToString() };
            }
            return _responce;
        }

        [HttpPost("UpdateCart")]
        public async Task<object> UpdateCart(CartDto cartDto)
        {
            try
            {
                CartDto cartDt = await _cartRepository.CreateUpdateCart(cartDto);
                _responce.Result = cartDt;
            }
            catch (Exception ex)
            {

                _responce.IsSuccess = false;
                _responce.ErrorMessage = new List<string> { ex.ToString() };
            }
            return _responce;
        }

        [HttpPost("RemoveCart")]
        public async Task<object> RemoveCart([FromBody]int cartId)
        {
            try
            {
                bool isSuccess = await _cartRepository.RemoveFromCart(cartId);
                _responce.Result = isSuccess;
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
