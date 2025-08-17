using DapperUserApi.DTO;
using DapperUserApi.Models;

namespace DapperUserApi.Services
{
    public interface IUserInterface
    {
        Task<ResponseModel<List<UserListDTO>>> GetUserList();
        Task<ResponseModel<UserListDTO>> GetUserById(int userId);
        Task<ResponseModel<List<UserListDTO>>> CreateUser(CreateUserDTO createUserDTO);
        Task<ResponseModel<List<UserListDTO>>> AlterUser(AlterUserDTO alterUserDTO);
        Task<ResponseModel<List<UserListDTO>>> RemoveUser(int userId);
    }
}