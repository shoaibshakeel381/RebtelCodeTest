using System;
using System.Collections.Generic;
using System.Web.Http;
using Rebtel.Client.Entities;
using Rebtel.Client.ServiceContracts;

namespace Rebtel.Client.WebAPI.Controllers
{
    [RoutePrefix("api/users")]
    public class UserController : ApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<UserListDTO> Get()
        {
            return _userService.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        public UserDetailDTO Get(string id)
        {
            return _userService.Get(id);
        }

        [HttpPost]
        [Route("")]
        public string Post([FromBody]UserCreateDTO user)
        {
            return _userService.Create(user);
        }

        [HttpDelete, Route("{id}")]
        public void Delete(string id)
        {
            _userService.Delete(id);
        }
        
        [HttpGet]
        [Route("{userId}/{subscriptionId}")]
        public void Get(string userId, string subscriptionId)
        {
            _userService.Subscribe(userId, subscriptionId);
        }
    }
}
