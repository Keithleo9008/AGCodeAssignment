using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeAssignment.DataLayer.ConcreteFileLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CodeAssignment.Models.CustomExceptions;
using CodeAssignment.Models;

namespace CodeAssignment.DataLayer.ConcreteFileLogic.Tests
{
    [TestClass]
    public class FileProcessorUserTests
    {

        [TestMethod]
        public void FileProcessorUser_FileExists_Valid()
        {
            //Arrange
            string filePath = "user.txt";
            //Act
            FileProcessorUser testingclass = new FileProcessorUser(filePath);
            //Assert
            Assert.IsTrue(testingclass.Valid);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void FileProcessorUser_FileNotExist_Fail()
        {
            //Arrange
            string filePath = "DoesNotExist.txt";
            //Act
            FileProcessorUser testingclass = new FileProcessorUser(filePath);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidFormatException))]
        public void FileProcessorUser_FileInvalidFormat_Valid()
        {
            //Arrange
            string filePath = "user_Bad.txt";
            //Act
            List<TwitterUser> users = new FileProcessorUser(filePath).Process().ToList();
        }

        [TestMethod]
        public void FileProcessorUser_CheckNumberOfUsersCreated_ShouldBeTruncated()
        {
            //Arrange
            bool valid = true;
            string filePath = "user - CreateFiveUsers.txt";
            int expected = 5;

            //Act
            List<TwitterUser> users = new FileProcessorUser(filePath).Process().ToList();
            int actual = users.Count;

            //Assert
            Assert.AreEqual(expected,actual);
        }
    }
}