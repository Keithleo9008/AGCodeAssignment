using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAssignment.Helper
{
    public static class ConsoleHandler
    {
        public static void HandleException(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("Press Enter to Exit");
            Console.ReadLine();
            Environment.Exit(1);
        }
    }
}
