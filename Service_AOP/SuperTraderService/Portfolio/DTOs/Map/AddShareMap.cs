using AutoMapper;
using Data.Entities;


namespace SuperTraderService.Portfolio.DTOs.Map
{
    public class AddShareMap : Profile
    {
        public AddShareMap()
        {
            //var userId = Convert.ToInt32(httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub).Value);
            var userId = 2;
            CreateMap<AddShareDto, Data.Entities.Portfolio>()
                .BeforeMap((src, dest) =>
                {
                    dest.UpdatedDate = DateTime.Now;
                    dest.UpdatedBy = userId;
                    dest.UserId = userId;
                })
                .ReverseMap();
            CreateMap<SaleSharesDto, Data.Entities.Portfolio>()
                .BeforeMap((src, dest) =>
                {
                    dest.UpdatedDate = DateTime.Now;
                    dest.UpdatedBy = userId;
                    dest.UserId = userId;
                })
                .ReverseMap();
            
        }
    }
}
