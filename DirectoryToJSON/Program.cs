using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace DirectoryToJSON
{
    internal class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Console.WriteLine("Write Path of Directory");
            string directory = Console.ReadLine();
            Console.WriteLine("Write Path of File to Save");
            string path = Console.ReadLine();

            if (Directory.Exists(directory))
            {
                string data = GetFileList(directory);
                Write(path,data);
            }
            else
            {
                Console.WriteLine("Directory isn't exist");
                Console.ReadLine();
            }
        }

        public static void Write(string path, string text)
        {
            using (StreamWriter writer = new StreamWriter(path))  
            {  
                writer.Write(text);
            }  
        }

        public static string GetFileList(string directory)
        {
            var list = new List<FileInformation>();
            string[] fileNames = Directory.GetFiles(directory);
            foreach (string filename in fileNames)
            {
                FileInfo fileInfo = new FileInfo(filename);

                list.Add(new FileInformation() { path = fileInfo.Name });
            }

            return JsonConvert.SerializeObject(list);
        }
    }
}