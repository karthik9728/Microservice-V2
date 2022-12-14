using Mango.Services.ShoppingCart.Messages;
using Mango.Services.ShoppingCart.Models.DTOs;
using Mango.Services.ShoppingCart.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.ShoppingCart.Controllers
{
    [Route("api/cart")]
    [ApiController]
    public class CartAPIController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;
        protected ResponceDto _responce;
        public CartAPIController(ICartRepository cartRepository)
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

        [HttpPost("ApplyCoupon")]
        public async Task<object> ApplyCoupon([FromBody] CartDto cartDto)
        {
            try
            {
                bool isSuccess = await _cartRepository.ApplyCoupon(cartDto.CartHeader.UserId,cartDto.CartHeader.CouponCode);
                _responce.Result = isSuccess;
            }
            catch (Exception ex)
            {

                _responce.IsSuccess = false;
                _responce.ErrorMessage = new List<string> { ex.ToString() };
            }
            return _responce;
        }

        [HttpPost("RemoveCoupon")]
        public async Task<object> RemoveCoupon([FromBody] string userId)
        {
            try
            {
                bool isSuccess = await _cartRepository.RemoveCoupon(userId);
                _responce.Result = isSuccess;
            }
            catch (Exception ex)
            {

                _responce.IsSuccess = false;
                _responce.ErrorMessage = new List<string> { ex.ToString() };
            }
            return _responce;
        }

        [HttpPost("Checkout")]
        public async Task<object> Checkout(CheckoutHeaderDto checkoutHeader)
        {
            try
            {
                CartDto cartDto = await _cartRepository.GetCartByUserId(checkoutHeader.UserId);

                if(cartDto == null)
                {
                    return BadRequest();
                }
                checkoutHeader.CartDetails = cartDto.CartDetails;
                //Logic to add message to process order
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
