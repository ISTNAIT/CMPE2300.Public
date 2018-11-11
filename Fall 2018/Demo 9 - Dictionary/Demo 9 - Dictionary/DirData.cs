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
            List<string> Files = null;
            try
            {
                DirectoryCount =
                    System.IO.Directory.EnumerateDirectories(Directory).Count();
                //Fun with collections! Distinct prob. not necessary, but for demo purposes..
                Files = System.IO.Directory.EnumerateFiles(Directory).Distinct().ToList();
            }
            catch (UnauthorizedAccessException) { Files = null; } //Not allowed to look in there.

            //New nullable and null coalescing features in C# make some stuff much easier.
            try
            {
                StorageSize = Files?.Sum((f) => new FileInfo(f).Length) ?? 0; //Add up length(size)
            }
            catch (FileNotFoundException){ } //Not sure why I get these once in a while.  Microsoft.  <Shrug>
            FileCount = Files?.Count ?? 0;
        }
    }
}
