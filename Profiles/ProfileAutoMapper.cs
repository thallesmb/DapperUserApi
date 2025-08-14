using AutoMapper;
using DapperUserApi.DTO;
using DapperUserApi.Models;

namespace DapperUserApi.Profiles
{
    public class ProfileAutoMapper : Profile
    {
        public ProfileAutoMapper()
        {
            CreateMap<User, UserListDTO>();
        }
    }
}