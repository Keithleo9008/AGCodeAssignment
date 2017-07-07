using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAssignment.Models
{
    public class TwitterUser
    {
        /// <summary>
        /// Uid property </summary>
        /// <value>
        /// The unique id of the user</value>
        public string Uid { get; set; }

        /// <summary>
        /// Username property </summary>
        /// <value>
        /// The name of the user</value>
        public string Username { get; set; }

        /// <summary>
        /// Following property </summary>
        /// <value>
        /// A string array of the unique id's of users followed</value>e
        public string[] Following { get; set; }

        /// <summary>
        /// Override of Equals Method to allow Linq distinct method to evualte correctly </summary>
        public override bool Equals(object obj)
        {
            if (!(obj is TwitterUser))
                return false;
            TwitterUser p = (TwitterUser) obj;
            return (p.Uid == Uid && p.Username == Username && p.Following.ToString() == Following.ToString());
        }

        ///// <summary>
        ///// Override of GetHashCode Method to allow Linq distinct method to evualte correctly </summary>
        public override int GetHashCode()
        {
            return String.Format("{0}|{1}|{2}", Uid, Username, Following.ToString()).GetHashCode();
        }
    }
}
