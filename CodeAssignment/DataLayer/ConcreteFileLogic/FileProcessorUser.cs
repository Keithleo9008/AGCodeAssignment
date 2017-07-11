using CodeAssignment.Helper;
using CodeAssignment.Models;
using CodeAssignment.Models.CustomExceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAssignment.DataLayer.ConcreteFileLogic
{
    public class FileProcessorUser : FileProcessor<TwitterUser>
    {
        public FileProcessorUser(string fileTxt) : base (fileTxt)
        {
        }

        /// <summary>
        /// Method that converts the text file into a list of TwitterUser objects</summary>
        /// <returns> A list of TwitterUsers</returns>
        public override IEnumerable<TwitterUser> Process()
        {
            string[] delimiter_follow = new string[] { " follows " };
            string[] delimiter_multiFollow = new string[] { ", " };

            if (base.Valid)
            {
                try{
                    string[] lines = File.ReadAllLines(base.Filepath);

                    //Create user for user part
                    var users = lines.Where(x => x != string.Empty)
                        .Select(x => x.Split(delimiter_follow, StringSplitOptions.None))
                        .Select(names => new TwitterUser()
                        {
                            Uid = names[0].Trim(),
                            Username = names[0].Trim(),
                            Following = names[1].Split(delimiter_multiFollow, StringSplitOptions.None)
                        }).ToList();

                    //Create user for follows part that doesnt alreadt exist in the above step
                    List<string[]> follwingArray = lines.Where(x => x != string.Empty)
                       .Select(x => x.Split(delimiter_follow, StringSplitOptions.None)[1])
                       .Select(s => s.Split(delimiter_multiFollow, StringSplitOptions.None)).ToList();

                    foreach (var item in follwingArray)
                    {
                        foreach (var follower in item)
                        {
                            if(!(users.Select(u => u.Uid).ToList().Contains(follower)))
                            {
                                users.Add(new TwitterUser()
                                {
                                    Uid = follower.Trim(),
                                    Username = follower.Trim(),
                                    Following = new string[] { }
                                });
                            }
                        }
                    }

                    return users.Distinct();
                }
                catch (Exception ex) {
                    throw new InvalidFormatException("The " + Filepath + " file contains an invalid format. Please fix this and try again");
                    //Log Error
                }
            }

            return null;
        }
    }
}