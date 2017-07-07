using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAssignment.Models
{
    public class TwitterTweet
    {
        /// <summary>
        /// Uid property </summary>
        /// <value>
        /// The unique id of the user who made the tweet</value>
        public string Uid { get; set; }

        /// <summary>
        /// Message property </summary>
        /// <value>
        /// The content of the twitter message</value>
        public string Message { get; set; }
    }
}
