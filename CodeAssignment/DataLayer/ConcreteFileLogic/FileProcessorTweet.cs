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
    public class FileProcessorTweet : FileProcessor<TwitterTweet>
    {
        public FileProcessorTweet(string fileTxt) : base (fileTxt)
        {
        }

        /// <summary>
        /// Method that converts the text file into a list of TwitterTweet objects</summary>
        /// <returns> A list of TwitterUsers</returns>
        public override IEnumerable<TwitterTweet> Process()
        { 
            if (base.Valid)
            {
                try
                {
                    string[] lines = File.ReadAllLines(base.Filepath);

                    var messages = lines.Where(x => x != string.Empty)
                        .Select(x => x.Split('>'))
                        .Select(message => new TwitterTweet()
                        {
                            Uid = message[0].Trim(),
                            Message = message[1].TrimStart()
                        }).ToList();


                    return TrunacteMessages(messages, 140);
                    //return messages;
                }
                catch (Exception ex)
                {
                    throw new InvalidFormatException("The " + Filepath + " file contains an invalid format. Please fix this and try again");
                    //Log Error
                }
            }

            return null;
        }

        private IEnumerable<TwitterTweet> TrunacteMessages(List<TwitterTweet> list, int size)
        {
            foreach (var item in list){
                if(item.Message.Length > size){
                    item.Message = item.Message.Substring(0, size);
                }
            }
            return list;
        }
    }
}
