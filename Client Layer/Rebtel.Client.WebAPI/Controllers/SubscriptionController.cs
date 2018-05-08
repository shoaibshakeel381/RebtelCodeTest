using System;
using System.Collections.Generic;
using System.Web.Http;
using Rebtel.Client.Entities;
using Rebtel.Client.ServiceContracts;

namespace Rebtel.Client.WebAPI.Controllers
{
    [RoutePrefix("api/subscriptions")]
    public class SubscriptionController : ApiController
    {
        private readonly ISubscriptionService _subscriptionService;

        public SubscriptionController(ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService ?? throw new ArgumentNullException(nameof(subscriptionService));
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<SubscriptionListDTO> Get()
        {
            return _subscriptionService.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        public SubscriptionDetailDTO Get(string id)
        {
            return _subscriptionService.Get(id);
        }

        [HttpPost]
        [Route("")]
        public string Post([FromBody]SubscriptionCreateDTO subscription)
        {
            return _subscriptionService.Create(subscription);
        }

        [HttpPut]
        [Route("{id}")]
        public string Put(string id, [FromBody]SubscriptionUpdateDTO subscription)
        {
            subscription.Id = id;
            return _subscriptionService.Update(subscription);
        }

        [HttpDelete, Route("{id}")]
        public void Delete(string id)
        {
            _subscriptionService.Delete(id);
        }
    }
}
