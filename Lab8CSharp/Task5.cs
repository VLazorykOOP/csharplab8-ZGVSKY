using System;
using System.IO;

namespace Lab8
{
    public class Task5
    {
        /// <summary>
        /// Performs directory and file manipulations.
        /// </summary>
        public static void Execute()
        {
            string basePath = Path.Combine(Environment.CurrentDirectory, "temp");
            
            if (Directory.Exists(basePath))
            {
                Directory.Delete(basePath, true);
            }
            Directory.CreateDirectory(basePath);

            string dir1 = Path.Combine(basePath, "Oleksandr1");
            string dir2 = Path.Combine(basePath, "Oleksandr2");

            Directory.CreateDirectory(dir1);
            Directory.CreateDirectory(dir2);

            string t1Path = Path.Combine(dir1, "t1.txt");
            string t2Path = Path.Combine(dir1, "t2.txt");
            
            File.WriteAllText(t1Path, "<Шевченко Степан Іванович, 2001> року народження, місце проживання <м. Суми>\n");
            File.WriteAllText(t2Path, "<Комар Сергій Федорович, 2000> року народження, місце проживання <м. Київ>\n");

            string t3Path = Path.Combine(dir2, "t3.txt");
            string t1Content = File.ReadAllText(t1Path);
            string t2Content = File.ReadAllText(t2Path);
            File.WriteAllText(t3Path, t1Content + t2Content);

            Console.WriteLine("--- Created Files Info ---");
            PrintFileInfo(t1Path);
            PrintFileInfo(t2Path);
            PrintFileInfo(t3Path);

            string t2NewPath = Path.Combine(dir2, "t2.txt");
            File.Move(t2Path, t2NewPath);

            string t1CopyPath = Path.Combine(dir2, "t1.txt");
            File.Copy(t1Path, t1CopyPath);

            string allDirPath = Path.Combine(basePath, "ALL");
            Directory.Move(dir2, allDirPath);
            
            Directory.Delete(dir1, true);

            Console.WriteLine("\n--- Files in ALL directory ---");
            DirectoryInfo allDirInfo = new DirectoryInfo(allDirPath);
            foreach (FileInfo file in allDirInfo.GetFiles())
            {
                PrintFileInfo(file.FullName);
            }
        }

        /// <summary>
        /// Helper method to print detailed information about a file.
        /// </summary>
        private static void PrintFileInfo(string filePath)
        {
            FileInfo fi = new FileInfo(filePath);
            if (fi.Exists)
            {
                Console.WriteLine($"Name: {fi.Name}, Size: {fi.Length} bytes, Created: {fi.CreationTime}, Path: {fi.FullName}");
            }
        }
    }
}