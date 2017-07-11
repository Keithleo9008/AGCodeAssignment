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
            _BaseUrl = AppDomain.CurrentDomain.BaseDirectory + "\\Files\\";
         
            this.Filepath = _BaseUrl + filepath;
            Valid = File.Exists(this.Filepath);
            if (!Valid)
            {
                throw new FileNotFoundException(String.Format("File [{0}] cannot be found", filepath));
            }
        }

        public abstract IEnumerable<T> Process();
    }
}
