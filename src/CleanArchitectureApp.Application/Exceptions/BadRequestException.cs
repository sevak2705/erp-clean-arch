using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace CleanArchitectureApp.Application.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message)
            : base(message)
        {
            ValidationErrors = new Dictionary<string, string[]>();
        }

        public BadRequestException(string message, ValidationResult validationResult)
            : base(message)
        {
            ValidationErrors = validationResult.ToDictionary();
        }

        public IDictionary<string, string[]> ValidationErrors { get; set; }
    }
}
