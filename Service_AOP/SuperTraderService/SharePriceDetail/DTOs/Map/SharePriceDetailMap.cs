using AutoMapper;
using Data.Entities;

namespace SuperTraderService.SharePriceDetail.DTOs.Map
{
    public class SharePriceDetailMap : Profile
    {
        
        public SharePriceDetailMap()
        {
            CreateMap< UpdatePriceDTOs, Data.Entities.SharePriceDetail>().BeforeMap((src, dest) =>
            {
                dest.UpdatedBy= src.UserId;
                dest.UpdatedDate = DateTime.Now;
                dest.Date=DateTime.Now;
            }).ReverseMap();
        }
         
    }
}


