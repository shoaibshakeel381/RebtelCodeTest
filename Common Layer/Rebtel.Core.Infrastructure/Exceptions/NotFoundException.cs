using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base()
        {

        }

        public NotFoundException(string message)
            : base(message)
        {

        }

        public NotFoundException(string message, Exception e)
            : base(message, e)
        {

        }
    }
}
