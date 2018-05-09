using System;
using System.Web.Http;
using Rebtel.Client.Entities;
using Rebtel.Client.ServiceContracts;

namespace Rebtel.Client.WebAPI.Controllers
{
    [RoutePrefix("api/users")]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(_userService.GetAll());
            }
            catch (Exception e)
            {
                return GetExceptionResponse(e);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Get(string id)
        {
            try
            {
                return Ok(_userService.Get(id));
            }
            catch (Exception e)
            {
                return GetExceptionResponse(e);
            }
        }

        [HttpGet]
        [Route("{userId}/{subscriptionId}")]
        public IHttpActionResult Get(string userId, string subscriptionId)
        {
            try
            {
                return Ok(_userService.Subscribe(userId, subscriptionId));
            }
            catch (Exception e)
            {
                return GetExceptionResponse(e);
            }
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Post([FromBody]UserCreateDTO user)
        {
            try
            {
                return Ok(_userService.Create(user));
            }
            catch (Exception e)
            {
                return GetExceptionResponse(e);
            }
        }

        [HttpDelete, Route("{id}")]
        public IHttpActionResult Delete(string id)
        {
            try
            {
                return Ok(_userService.Delete(id));
            }
            catch (Exception e)
            {
                return GetExceptionResponse(e);
            }
        }
    }
}
