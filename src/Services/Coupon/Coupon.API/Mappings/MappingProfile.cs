using AutoMapper;
using Coupon.API.Models;
using Coupon.API.Models.Dto;

namespace Coupon.API.Mappings
{
    public class MappingProfile
    {
        public static MapperConfiguration RegisterMaps() 
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponEntity, CouponDto>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
