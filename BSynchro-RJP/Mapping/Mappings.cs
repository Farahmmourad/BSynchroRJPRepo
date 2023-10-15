using AutoMapper;
using BSynchro_RJP.DTOs;
using BSynchro_RJP_Core.Models;

namespace BSynchro_RJP.Mapping
{
    public class Mappings: Profile
    {
        public Mappings() 
        {
            CreateMap<Transaction, TransactionDTO>(); 
            CreateMap<Account, AccountDTO>()
                .ForMember(dest => dest.Transactions, opt => opt.MapFrom(src => src.Transactions)); 

            CreateMap<Customer, UserInfo>()
                .ForMember(dest => dest.Accounts, opt => opt.MapFrom(src => src.Accounts)); 

        }
    }
}
