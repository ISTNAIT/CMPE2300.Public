using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Demo_9___Dictionary
{
    //A toy class for demonstrating a dictionary
    //and listview integration.
    public class DirData
    {
        private string directory = "";
        public string Directory
        {
            get => directory;
            private set
            {
                if (System.IO.Directory.Exists(value))
                    directory = value;
                else throw new DirectoryNotFoundException();
            }
        }
        public int DirectoryCount { private set; get; }
        public int FileCount { private set; get; }
        public long StorageSize { private set; get; } //Bytes
        public DirData(string directory)
        {
            Directory = directory;
            ParseDirectory();
        }

        //Default ctor: do user home directory
        public DirData() :  this(Environment.GetFolderPath(
            Environment.SpecialFolder.UserProfile)){ }

        //Get the data for this particular directory
        //Doesn't recurse, just gets the top level count
        public void ParseDirectory()
        {
            DirectoryCount = 
                System.IO.Directory.EnumerateDirectories(Directory).Count();

            //Fun with collections! Distinct prob. not necessary, but for demo purposes..
            List<string> Files = 
                System.IO.Directory.EnumerateFiles(Directory).Distinct().ToList();
            StorageSize = Files.Sum((f) => new FileInfo(f).Length); //Add up length(size)
            FileCount = Files.Count;
        }
    }
}
