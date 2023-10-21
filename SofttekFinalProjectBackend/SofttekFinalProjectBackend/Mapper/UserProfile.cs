using AutoMapper;
using SofttekFinalProjectBackend.DTOs;
using SofttekFinalProjectBackend.Entities;

namespace SofttekFinalProjectBackend.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDTO, User>()
          .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => false))
          .ForMember(dest => dest.DeletedTimeUtc, opt => opt.MapFrom(src => (DateTime?)null));



            CreateMap<User, UserDTO>();
        }

        private TypeOfAccount MapAccountStringToEnum(string type)
        {
            switch (type.ToLower())
            {
                case "pesos":
                    return TypeOfAccount.Pesos;
                case "dollar":
                    return TypeOfAccount.Dollar;
                case "crypto":
                    return TypeOfAccount.Crypto;
                default:
                    throw new ArgumentException($"Invalid type of account string: {type}");
            }
        }
    }
}
