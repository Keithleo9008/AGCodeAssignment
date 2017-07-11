using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeAssignment.DataLayer.ConcreteFileLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAssignment.Models;
using System.IO;
using CodeAssignment.Models.CustomExceptions;

namespace CodeAssignment.DataLayer.ConcreteFileLogic.Tests
{
    [TestClass]
    public class FileProcessorTweetTests
    {
        [TestMethod]
        public void FileProcessorTweet_FileExists_Valid()
        {
            //Arrange
            string filePath = "tweet.txt";
            //Act
            FileProcessorTweet testingclass = new FileProcessorTweet(filePath);
            //Assert
            Assert.IsTrue(testingclass.Valid);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void FileProcessorTweet_FileNotExist_Fail()
        {
            //Arrange
            string filePath = "DoesNotExist.txt";
            //Act
            FileProcessorTweet testingclass = new FileProcessorTweet(filePath);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidFormatException))]
        public void FileProcessorTweet_FileInvalidFormat_Valid()
        {
            //Arrange
            string filePath = "tweet_Bad.txt";
            //Act
            List<TwitterTweet> tweets = new FileProcessorTweet(filePath).Process().ToList();
        }

        [TestMethod]
        public void FileProcessorTweet_LongTweetsCheck_ShouldBeTruncated()
        {
            //Arrange
            bool valid = true;
            string filePath = "tweet_TooLong.txt";

            //Act
            List<TwitterTweet> tweets = new FileProcessorTweet(filePath).Process().ToList();
            foreach (var item in tweets)
            {
                if (item.Message.Length > 140)
                    valid = false;

            }

            //Assert
            Assert.IsTrue(valid);
        }

    }
}