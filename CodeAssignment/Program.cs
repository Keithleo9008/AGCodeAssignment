using CodeAssignment.Helper;
using CodeAssignment.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            System.AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionTrapper;
            if (args.Length < 2) {
                ConsoleHandler.HandleException("Cannot proceed, Please provide the 2 arguments");
            }
            else {
                LoadTwitterFeed(args[0], args[1]);
            }
            Console.WriteLine("End of Program. Press Enter to continue");
            Console.ReadLine();
        }

        static void LoadTwitterFeed(string userTxt, string tweetsTxt)
        {
            try {
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
            catch (NullReferenceException ex1){
                ConsoleHandler.HandleException("There was an error loading the data context from the text files");
            }
        }

        static void UnhandledExceptionTrapper(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine("An unhandled exception occured");
            Console.WriteLine(e.ExceptionObject.ToString());
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
            Environment.Exit(1);
        }
    }
}
