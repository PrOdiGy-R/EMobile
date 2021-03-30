using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMobile.Models
{
    public class ApiError
    {
        public string Message { get; set; }

        public string Detail { get; set; }

        public ApiError()
        {

        }

        public ApiError(ModelStateDictionary modelState)
        {
            Message = "Invalid parameters";
            Detail = modelState
                .FirstOrDefault(x => x.Value.Errors.Any()).Value.Errors
                .FirstOrDefault().ErrorMessage;
        }
    }
}
