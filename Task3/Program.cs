using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Task3
{
    class Program
    {
        private const string extension = ".txt";
        private const string path = @"D:\GlebIgnatovich\VisualStudio\Task3\Task3\Files\";
        private const string name = "1";
        static void Main(string[] args)
        {
            string resultPath = SelectСases(path + name + extension, 10);
            Console.WriteLine("The result path is: " + resultPath);
        }
        
        public static string SelectСases(string pathToFirstFile, int amountOfStrings)
        {
            string newPath = string.Format("{0}{1}_res{2}", path, name, extension);
           /* Console.WriteLine(newPath);
            using (FileStream fstream = File.OpenRead(pathToFirstFile))
            {
                byte[] array = new byte[fstream.Length];
                fstream.Read(array, 0, array.Length);
                string textFromFile = System.Text.Encoding.Default.GetString(array);
                
            }*/
            var file = new List<string>(System.IO.File.ReadAllLines(pathToFirstFile));
            var file2 = new List<string>();
            Random random = new Random();
            file2.Add(file[0]);
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
