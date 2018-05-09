using System;
using System.Net;
using System.Net.Http;
using System.ServiceModel;
using System.Web.Http;
using Rebtel.Client.Entities;
using Rebtel.Core.Infrastructure;

namespace Rebtel.Client.WebAPI.Controllers
{
    public abstract class BaseController : ApiController
    {
        /// <summary>
        /// Prepare a proper Error Response for current request
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        protected IHttpActionResult GetExceptionResponse(Exception e)
        {
            switch (e)
            {
                case FaultException<FaultResponseDTO> frEx:
                    if (frEx.Detail.Code == ResultCode.InternalServerError)
                    {
                        throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.InternalServerError, frEx.Detail));
                    }
                    if (frEx.Detail.Code == ResultCode.NotFound)
                    {
                        throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound, frEx.Detail));
                    }

                    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, frEx.Detail));
                case FaultException fEx:
                    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, fEx.Message));
            }

            return InternalServerError(e);
        }
    }
}
