using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodManagment.Application.Commane
{
    public class BadRequestException : Exception
    {
      

        public object? Errors { get; }

        public BadRequestException(string message)
            : base(message)
        {
        }

        public BadRequestException(string message, object errors)
            : base(message)
        {
            Errors = errors;
        }
    }
}
