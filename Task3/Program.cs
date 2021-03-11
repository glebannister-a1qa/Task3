using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Task3
{
    class Program
    {
        private const string extension = ".txt";
        private static string path;
        private static string name;
        static void Main(string[] args)
        {
            string resultPath = SelectСases(path + name + extension, 10);
            Console.WriteLine("The result path is: " + resultPath);
        }
        
        public static string SelectСases(string pathToFirstFile, int amountOfStrings)
        {
            string newPath = string.Format("{0}{1}_res{2}", path, name, extension);
            using (StreamReader sr = new StreamReader(pathToFirstFile, System.Text.Encoding.Default))
            {
                string line;
                Console.WriteLine("Start file data:");
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
            var file = new List<string>(System.IO.File.ReadAllLines(pathToFirstFile));
            var file2 = new List<string>();           
            file2.Add(file[0]);
            Random random = new Random();
            for (int i = 1; i < amountOfStrings; i++)
            {
                int index = random.Next(1, file.Count);
                file2.Add(file[index]);
                file.RemoveAt(index);          
            }          
            File.WriteAllLines(newPath, file2.ToArray());
            File.WriteAllLines(pathToFirstFile, file.ToArray());
            Console.ReadLine();
            return newPath;
        }
    }
}
