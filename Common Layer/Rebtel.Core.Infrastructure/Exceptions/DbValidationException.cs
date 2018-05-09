using System;
using System.Collections.Generic;

namespace System
{
    public class DbValidationException : Exception
    {
        public IEnumerable<string> Errors { get; set; }

        public DbValidationException(IEnumerable<string> errors)
        {
            Errors = errors;
        }

        public DbValidationException(string message, IEnumerable<string> errors) : base(message)
        {
            Errors = errors;
        }
    }
}
