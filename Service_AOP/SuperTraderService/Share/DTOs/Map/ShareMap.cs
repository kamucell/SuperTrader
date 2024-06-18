using System.IdentityModel.Tokens.Jwt;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using SuperTraderService.SharePriceDetail.DTOs;

namespace SuperTraderService.Share.DTOs.Map
{
    public class ShareMap : Profile
    {
        public ShareMap()
        {
            var userId = 2;//Convert.ToInt32(httpContextAccessor.HttpContext.User.Claims.First().Value);

            CreateMap<ShareDto, Data.Entities.Share>().BeforeMap((src, dest) =>
                {
                    dest.UpdatedDate = DateTime.Now;
                    dest.UpdatedBy = userId;
                    dest.OwnerId = userId;
                })
                .ReverseMap();


            CreateMap<ShareUpdateDto, Data.Entities.Share>()
                .BeforeMap((src, dest) =>
                {
                    dest.UpdatedDate = DateTime.Now;
                    dest.UpdatedBy = userId;
                    dest.OwnerId = userId;
                })
                .ReverseMap();
        }
    }
}


