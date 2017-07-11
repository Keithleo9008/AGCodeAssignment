using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeAssignment.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAssignment.Models;
using CodeAssignment.DataLayer.ConcreteFileLogic;

namespace CodeAssignment.ServiceLayer.Tests
{
    [TestClass]
    public class TwitterDataServiceTests
    {
        private IEnumerable<TwitterUser> Users { get; set; }
        private IEnumerable<TwitterTweet> Tweets { get; set; }

        /// </summary>
        [TestInitialize]
        public void SetUp()
        {
            Users = new FileProcessorUser("user.txt").Process();
            Tweets = new FileProcessorTweet("tweet.txt").Process();
        }

        [TestMethod]
        public void GetTweetsByUidTest()
        {
            //Arrange
            string uid = "Alan";
            int expected = 2;
            IEnumerable<TwitterTweet> tweets = Tweets.Where(x => x.Uid == uid);

            //Act
            int actual = tweets.Count();

            //Assert
            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void GetTwitterFeedTest()
        {
            //Arrange
            TwitterUser user = new TwitterUser()
            {
                Uid = "Alan",
                Username = "Alan",
                Following = new string[] { "Martin" }
            };
            int expected = 2;
            IEnumerable<TwitterTweet> tweets = null;
            List<string> usersTweetsToShow;

           //Act
            usersTweetsToShow = user.Following.ToList();
            usersTweetsToShow.Insert(0, user.Uid);
            tweets = Tweets.Where(x => usersTweetsToShow.Contains(x.Uid));
            int actual = tweets.Count();

            //Assert
            Assert.AreEqual(actual, expected, "Incorrect number of Tweets retruned: " + actual);
        }

        [TestMethod]
        public void GetUserListTest()
        {
            //Arrange
            int expected = 5;

            //Act
            int actual = Users.Count();

            //Assert
            Assert.IsTrue(Users.Count() > 0, "Returned no items.");
            Assert.AreEqual(actual, expected, "Incorrect number of users retruned");
        }
    }
}