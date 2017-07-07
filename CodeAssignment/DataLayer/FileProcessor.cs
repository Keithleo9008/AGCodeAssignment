using CodeAssignment.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAssignment.DataLayer
{
    public abstract class FileProcessor<T> where T : class
    {
        private string _BaseUrl;
        public string Filepath { get; set; }
        public bool Valid;

        public FileProcessor(string filepath)
        {
            _BaseUrl = AppDomain.CurrentDomain.BaseDirectory + "Files\\";
            try
            {
                this.Filepath = _BaseUrl + filepath;
                Valid = File.Exists(this.Filepath);
                if (!Valid)
                {
                    ConsoleHandler.HandleException(String.Format("File [{0}] cannot be found", filepath));
                }
            }
            catch (Exception e)
            {
                throw new Exception(String.Format("ERROR: could not process file {0} due to error - {1}", filepath, e.Message));
            }
           
        }

        public abstract IEnumerable<T> Process();
    }
}
