using Microsoft.AspNetCore.Mvc;
using WebUI.Services.IService;

namespace WebUI.Controllers
{
    public class CouponController : Controller
    {
        private readonly ICouponService _couponService;

        public CouponController(ICouponService couponService)
        {
            _couponService = couponService;
        }
    }
}
