using System;
using System.Threading.Tasks;
using homework3.Models;

namespace homework3.Services.Interfaces
{
    public interface IUserInfoService
    {
        Task<User> GetById(Guid id);
    }
}
