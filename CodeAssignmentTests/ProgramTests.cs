using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeAssignment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAssignment.Models.CustomExceptions;

namespace CodeAssignment.Tests
{
    [TestClass]
    public class ProgramTests
    {

        [ExpectedException(typeof(InvalidArgsException))]
        [TestMethod]
        public void Main_Only1Arg_InvalidArgsException()
        {
            //Arrange
            string[] args = new string[] { "tweet.txt" };
            //Act
            Program.Main(args);
            //Assert
            //No assertion as testing exception
        }

        [TestMethod]
        public void Main__TwoArgs_CanContinue()
        {
            //Arrange
            string[] args = new string[] { "tweet.txt" , "user.txt"};
            //Act
            Program.Main(args);
            //Assert
            Assert.AreEqual(2, args.Length);
        }
    }
}