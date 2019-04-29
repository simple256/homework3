using System;
using System.Threading.Tasks;
using homework3.Services.Interfaces;
using homework3.Models;

namespace homework3.BusinessLogic
{
    public class GetUserInfoRequestHadler
    {
        private readonly IUserInfoService _userInfoService;

        public GetUserInfoRequestHadler(IUserInfoService userInfoService)
        {
            _userInfoService = userInfoService;
        }

        public Task<User> Hadle(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Некорректный идентификатор пользователя", nameof(id));

            return _userInfoService.GetById(id);
        }

        public Task<User> Append(User user)
        {
            if (user == null)
                throw new ArgumentException("Некорректный экземпляр User", nameof(user));

            return _userInfoService.AppendUser(user);
        }
    }
}
