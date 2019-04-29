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
            "host=89.208.199.118;port=5432;database=PostgreSQL-2564;username=student;password=password";

        public async Task<User> GetById(Guid id)
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                return await connection.QuerySingleAsync<User>(
                    "SELECT * FROM \"simple256\".\"users\" WHERE id = @id", new { id });
            }
        }

        public async Task<User> AppendUser(User user)
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                return await connection.QuerySingleAsync<User>(
                    "INSERT INTO simple256.users(id, email, nickname, phone) VALUES (@id, @email, @nickname, @phone) RETURNING *;", user);
            }
        }

    }
}
