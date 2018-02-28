using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TestNinja.Mocking
{
    
    public class FileReader : IFileReader
    {
        //Task 1 - Isolate the File Reading.
        public string Read(string path)
        {
            //var str = File.ReadAllText("video.txt");
            return File.ReadAllText(path);
        }
    }

    //Task 2 - Extract Interface
    public interface IFileReader
    {
        string Read(string path);
    }
}
