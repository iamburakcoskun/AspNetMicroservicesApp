namespace Coupon.API.Models
{
    public class CouponEntity
    {
        public int Id { get; set; }

        public string CouponCode { get; set; }

        public double DiscountAmount { get; set; }

        public int MinAmount { get; set; }
    }
}
