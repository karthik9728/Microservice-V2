using Mango.Services.CouponAPI.Models.DTOs;

namespace Mango.Services.CouponAPI.Repository
{
    public interface ICouponRepository
    {
        Task<CouponDto> GetCouponCode(string couponCode);
    }
}
