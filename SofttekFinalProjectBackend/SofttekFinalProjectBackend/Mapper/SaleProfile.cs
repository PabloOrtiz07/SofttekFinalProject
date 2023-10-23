using AutoMapper;
using SofttekFinalProjectBackend.DTOs;
using SofttekFinalProjectBackend.Entities;

namespace SofttekFinalProjectBackend.Mapper
{
    public class SaleProfile : Profile
    {

        public SaleProfile()
        {
            CreateMap<SaleDTO, Sale>();

            CreateMap<Sale, SaleDTO>()
                .ForMember(dest => dest.SaleNumber, opt => opt.MapFrom(src => src.Id));

            CreateMap<SaleRequestDTO, Sale>()
                .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => false))
                .ForMember(dest => dest.DeletedTimeUtc, opt => opt.MapFrom(src => (DateTime?)null));

            CreateMap<Sale, SaleRequestDTO>();
        }


    }

}
