using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using homework3.BusinessLogic;
using homework3.Models;

namespace homework3.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly GetUserInfoRequestHadler _getUserInfoRequestHadler;

        public UsersController(GetUserInfoRequestHadler getUserInfoRequestHadler)
        {
            _getUserInfoRequestHadler = getUserInfoRequestHadler;
        }


        [HttpGet("{id}")]
        public Task<User> GetUserInfo(Guid id)
        {
            return _getUserInfoRequestHadler.Hadle(id);
        }

        [HttpPost("append")]
        public Task<User> AppendUser([FromBody] User user)
        {
            Guid guid = Guid.NewGuid();
            user.Id = guid;

            return _getUserInfoRequestHadler.Append(user);
        }
    }
}