using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CqrsMediatoRTest.ApiResponse
{
    public class ApiOkResponse : ApiResponseBase
    {
        public object Result { get; }

        public ApiOkResponse(object result) : base(200)
        {
            Result = result;
        }
    }
}
