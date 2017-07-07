using CodeAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAssignment.ServiceLayer
{
    public interface ITwitterDataService
    {
        IEnumerable<TwitterTweet> GetTweetsByUid(string uid);
        IEnumerable<TwitterTweet> GetTwitterFeed(TwitterUser user);
        IEnumerable<TwitterUser> GetUserList();
    }
}
