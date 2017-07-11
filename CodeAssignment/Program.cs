using CodeAssignment.Helper;
using CodeAssignment.Models.CustomExceptions;
using CodeAssignment.ServiceLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAssignment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                System.AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionTrapper;
                if (args.Length < 2)
                {
                    throw new InvalidArgsException("Cannot proceed, Please provide the 2 arguments");
                }
                else
                {
                    LoadTwitterFeed(args[0], args[1]);
                }
                Console.WriteLine("End of Program. Console will close in 5 seconds");
                System.Threading.Thread.Sleep(5000);
                Environment.Exit(1);
            }
            catch (Exception ex)
            {
                if (ex is InvalidArgsException || ex is InvalidFormatException || ex is FileNotFoundException)
                {
                    ConsoleHandler.HandleException(ex.Message);
                    System.Threading.Thread.Sleep(5000);
                    //Log error
                }
            }
        }

        public static void LoadTwitterFeed(string userTxt, string tweetsTxt)
        {
                ITwitterDataService service = new TwitterDataService(userTxt, tweetsTxt);

                foreach (var user in service.GetUserList())
                {
                    Console.WriteLine(user.Username);
                    Console.WriteLine("");
                
                    foreach (var tweet in service.GetTwitterFeed(user)){
                        Console.WriteLine("@{0}:{1}", tweet.Uid,tweet.Message);
                    }
                    Console.WriteLine("");
                }
        }

        static void UnhandledExceptionTrapper(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine("An unhandled exception occured");
            Console.WriteLine(e.ExceptionObject.ToString());
            Console.WriteLine("Press Enter to continue");
            System.Threading.Thread.Sleep(5000);
        }
    }
}
