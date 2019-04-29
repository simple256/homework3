using System;
using System.Threading.Tasks;
using homework3.Services.Interfaces;
using homework3.Models;
using Npgsql;
using Dapper;

namespace homework3.Services
{
    public class UserInfoService : IUserInfoService
    {
        private const string ConnectionString =
            "host = localhost;port=5432;database=simple256DB;user=simple256;password=hesoyam";

        public async Task<User> GetById(Guid id)
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                return await connection.QuerySingleAsync<User>(
                    "SELECT * FROM Users WHERE Id = @id", new { id });
            }
        }
    }
}
