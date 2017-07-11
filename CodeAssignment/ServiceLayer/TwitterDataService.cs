using CodeAssignment.DataLayer.ConcreteFileLogic;
using CodeAssignment.Helper;
using CodeAssignment.Models;
using CodeAssignment.Models.CustomExceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAssignment.ServiceLayer
{
    public class TwitterDataService : ITwitterDataService
    {
        private readonly string _tweetTxt;
        private readonly string _usersTxt;
        private IEnumerable<TwitterUser> Users { get; set; }
        private IEnumerable<TwitterTweet> Tweets { get; set; }

        public TwitterDataService(string userstxt, string tweetTxt)
        {
                this._tweetTxt = tweetTxt;
                this._usersTxt = userstxt;
                Users = new FileProcessorUser(userstxt).Process();
                Tweets = new FileProcessorTweet(tweetTxt).Process();

            if (this.Users == null)
                throw new InvalidFormatException("The user file provided is not in a correct format to support the TwitterDataService. Please fix and try again.");
            if (this.Tweets == null)
                throw new InvalidFormatException("The user file provided is not in a correct format to support the TwitterDataService. Please fix and try again.");
        }

        public IEnumerable<TwitterTweet> GetTweetsByUid(string uid)
        {
            return Tweets.Where(x => x.Uid == uid);
        }

        public IEnumerable<TwitterTweet> GetTwitterFeed(TwitterUser user)
        {
            List<string> usersTweetsToShow = user.Following.ToList();
            usersTweetsToShow.Insert(0, user.Uid);
            return Tweets.Where(x => usersTweetsToShow.Contains(x.Uid));
        }

        public IEnumerable<TwitterUser> GetUserList()
        {
            return Users;
        }
    }
}
