using System;
using System.Web.Http;
using Rebtel.Client.Entities;
using Rebtel.Client.ServiceContracts;

namespace Rebtel.Client.WebAPI.Controllers
{
    [RoutePrefix("api/subscriptions")]
    public class SubscriptionController : BaseController
    {
        private readonly ISubscriptionService _subscriptionService;

        public SubscriptionController(ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService ?? throw new ArgumentNullException(nameof(subscriptionService));
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(_subscriptionService.GetAll());
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
                return Ok(_subscriptionService.Get(id));
            }
            catch (Exception e)
            {
                return GetExceptionResponse(e);
            }
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Post([FromBody]SubscriptionCreateDTO subscription)
        {
            try
            {
                return Ok(_subscriptionService.Create(subscription));
            }
            catch (Exception e)
            {
                return GetExceptionResponse(e);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult Put(string id, [FromBody]SubscriptionUpdateDTO subscription)
        {
            try
            {
                subscription.Id = id;
                return Ok(_subscriptionService.Update(subscription));
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
                return Ok(_subscriptionService.Delete(id));
            }
            catch (Exception e)
            {
                return GetExceptionResponse(e);
            }
        }
    }
}

