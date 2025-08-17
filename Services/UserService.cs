using AutoMapper;
using Dapper;
using DapperUserApi.DTO;
using DapperUserApi.Models;
using Microsoft.Data.SqlClient;

namespace DapperUserApi.Services
{
    public class UserService : IUserInterface
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public UserService(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<ResponseModel<List<UserListDTO>>> AlterUser(AlterUserDTO alterUserDTO)
        {
            ResponseModel<List<UserListDTO>> response = new();

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var user = await connection
                    .ExecuteAsync("UPDATE Users SET FullName = @FullName, " +
                    "Email = @Email, " +
                    "Position = @Position, " +
                    "TaxNumber = @TaxNumber, " +
                    "Salary = @Salary, " +
                    "Situation = @Situation " +
                    "WHERE Id = @Id", alterUserDTO);

                if (user == 0)
                {
                    response.Messages = "There was an error during the update.";
                    response.Status = false;

                    return response;
                }

                var users = await ListUsers(connection);

                var mapUsers = _mapper.Map<List<UserListDTO>>(users);

                response.Data = mapUsers;
                response.Messages = "User successfully updated!";
            }

            return response;
        }

        public async Task<ResponseModel<List<UserListDTO>>> CreateUser(CreateUserDTO createUserDTO)
        {
            ResponseModel<List<UserListDTO>> response = new();

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var user = await connection
                    .ExecuteAsync("INSERT INTO Users (FullName, Email, Position, TaxNumber, Salary, Situation, [Password])" +
                    "VALUES (@FullName, @Email, @Position, @TaxNumber, @Salary, @Situation, @Password)", createUserDTO);

                if (user == 0)
                {
                    response.Messages = "There was an error during creation.";
                    response.Status = false;

                    return response;
                }

                var users = await ListUsers(connection);

                var mapUsers = _mapper.Map<List<UserListDTO>>(users);

                response.Data = mapUsers;
                response.Messages = "User successfully created!";
            }

            return response;
        }

        public async Task<ResponseModel<UserListDTO>> GetUserById(int userId)
        {
            ResponseModel<UserListDTO> response = new();

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var user = await connection.QueryFirstOrDefaultAsync<User>("SELECT * FROM Users WHERE Id = @Id", new { Id = userId });

                if (user is null)
                {
                    response.Messages = "User not found!";
                    response.Status = false;

                    return response;
                }

                var userMap = _mapper.Map<UserListDTO>(user);

                response.Data = userMap;
                response.Messages = "User found!";
            }

            return response;
        }

        public async Task<ResponseModel<List<UserListDTO>>> GetUserList()
        {
            ResponseModel<List<UserListDTO>> response = new();

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var user = await connection.QueryAsync<User>("SELECT * FROM Users");

                if (user is null)
                {
                    response.Messages = "Users not found!";
                    response.Status = false;

                    return response;
                }

                var userMap = _mapper.Map<List<UserListDTO>>(user);

                response.Data = userMap;
                response.Messages = "Users found!";
            }

            return response;
        }

        public async Task<ResponseModel<List<UserListDTO>>> RemoveUser(int userId)
        {
            ResponseModel<List<UserListDTO>> response = new();

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var user = await connection.ExecuteAsync("DELETE FROM Users WHERE Id = @Id", new { Id = userId });

                if (user == 0)
                {
                    response.Messages = "User not found!";
                    response.Status = false;

                    return response;
                }

                var users = await ListUsers(connection);

                var userMap = _mapper.Map<List<UserListDTO>>(users);

                response.Data = userMap;
                response.Messages = "User successfully removed!";
            }

            return response;
        }

        private static async Task<IEnumerable<User>> ListUsers(SqlConnection sqlConnection)
        {
            return await sqlConnection.QueryAsync<User>("SELECT * FROM Users OPTION(MAXDOP 1)");
        }
    }
}