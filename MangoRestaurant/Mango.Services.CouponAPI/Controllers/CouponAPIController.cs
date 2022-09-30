using Mango.Services.CouponAPI.Models.DTOs;
using Mango.Services.CouponAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.CouponAPI.Controllers
{
    [Route("api/coupon")]
    [ApiController]
    public class CouponAPIController : ControllerBase
    {
        private readonly ICouponRepository _couponRepository;
        protected ResponceDto _responce;

        public CouponAPIController(ICouponRepository couponRepository)
        {
            _couponRepository = couponRepository;
            this._responce = new ResponceDto();
        }

        [HttpGet("{code}")]
        public async Task<object> GetDiscountForCode(string code)
        {
            try
            {
                var coupon = await _couponRepository.GetCouponCode(code);
                _responce.Result = coupon;
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
