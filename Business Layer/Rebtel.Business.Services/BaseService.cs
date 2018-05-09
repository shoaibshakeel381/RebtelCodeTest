using System;
using System.ServiceModel;
using Rebtel.Business.DTOs;
using Rebtel.Core.Infrastructure;

namespace Rebtel.Business.Services
{
    public abstract class BaseService
    {
        /// <summary>
        /// Prepare a proper Error Response for current request
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        protected Exception GetExceptionResponse(Exception e)
        {
            var response = new FaultResponseDTO(ResultCode.InternalServerError, ResultCode.InternalServerError.GetDescription());

            switch (e)
            {
                case DbValidationException dbEx:
                    response = new FaultResponseDTO(ResultCode.ValidationError, string.Join("\n", dbEx.Errors));
                    break;
                case NotFoundException nfEx:
                    response = new FaultResponseDTO(ResultCode.NotFound, nfEx.Message);
                    break;
            }

            return new FaultException<FaultResponseDTO>(response, new FaultReason(response.Code.GetDescription()));
        }
    }
}
