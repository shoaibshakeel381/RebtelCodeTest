using System.ComponentModel;

namespace Rebtel.Core.Infrastructure
{
    public enum ResultCode
    {
        [Description("Operation Successfully completed")]
        OK = 1,

        [Description("Validation Error")]
        ValidationError,

        [Description("Operation Not Allowed")]
        OperationNotAllowed,

        [Description("Bad Request")]
        BadRequest,

        [Description("Internal Server Error")]
        InternalServerError,

        [Description("Resource Not Found")]
        NotFound
    }
}
