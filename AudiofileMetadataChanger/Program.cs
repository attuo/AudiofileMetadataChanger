using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagLib;

namespace AudiofileMetadataChanger
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string path = currentDirectory;
            string[] filesArrayFullPath = Directory.GetFiles(path);
            string[] fileArray = Directory.GetFiles(path);
            int number = 1;
            foreach (string filename in fileArray)
            {

                string[] songName = Path.GetFileName(filename).Split('-');
                if (songName.Length == 3)
                {
                    try
                    {
                        TagLib.File file = TagLib.File.Create(filename);
                        file.Tag.Title = songName[1];
                        string[] perfs = new string[] { songName[0] };
                        file.Tag.Performers = perfs;
                        file.Save();
                        Console.WriteLine("Write succesful: " + number + " " + Path.GetFileName(filename));

                    }
                    catch (UnsupportedFormatException e)
                    {
                        Console.WriteLine(filename + " failed, unsupported format" + e);
                    }
                }

                else
                {
                    Console.WriteLine("Write failed:    " + number + " " + Path.GetFileName(filename));
                }
                number++;
            }

            Console.WriteLine("\nCompleted!");
        }
    }
}
