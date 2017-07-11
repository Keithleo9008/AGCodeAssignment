using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAssignment.Models.CustomExceptions
{
    public class InvalidTweetLengthException : Exception
    {
        public InvalidTweetLengthException()
        {
        }

        public InvalidTweetLengthException(string message)
            : base(message)
        {
        }

        public InvalidTweetLengthException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
