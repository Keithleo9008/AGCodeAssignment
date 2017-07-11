using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAssignment.Models.CustomExceptions
{    
    public class InvalidArgsException : Exception
    {
        public InvalidArgsException()
        {
        }

        public InvalidArgsException(string message)
            : base(message)
        {
        }

        public InvalidArgsException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
