using AutoMapper;
using CBOS.DataModels;

namespace ContactsApp.Models
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ContactViewModel, Contact>(); 
            CreateMap<Contact, ContactViewModel>(); 
        }
    }
}