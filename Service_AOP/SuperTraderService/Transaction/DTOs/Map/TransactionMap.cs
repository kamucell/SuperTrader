using System.IdentityModel.Tokens.Jwt;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using SuperTraderService.Share.DTOs;

namespace SuperTraderService.Transaction.DTOs.Map
{
    public class TransactionMap : Profile
    {
        public TransactionMap()
        {
            

            CreateMap<TransactionDto, Data.Entities.Transaction>()
                .ForMember(o => o.UpdatedDate,
                        opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(o => o.TransactionDate,
                    opt => opt.MapFrom(src => DateTime.Now))

                .ForMember(o => o.Sold,
                    opt => opt.MapFrom(src => src.Amount))
                    .ForMember(o => o.UpdatedBy,
                        opt => opt.MapFrom(src => src.UserId))

                .ReverseMap();
        }
    }
}


