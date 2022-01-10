using AutoMapper;
using FrontDeskApp.Api.Resources;
using FrontDeskApp.Core.Models;

namespace FrontDeskApp.Api.Mapping
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            // Domain to Resource
            CreateMap<Customer, CustomerResource>();
            CreateMap<Storage, StorageResource>();

            // Resource to Domain
            CreateMap<CustomerResource, Customer>();
            CreateMap<SaveCustomerResource, Customer>();

            CreateMap<StorageResource, Storage>();
            CreateMap<SaveStorageResource, Storage>();
        }
    }
}
