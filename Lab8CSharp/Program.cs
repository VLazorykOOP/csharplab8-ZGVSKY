using System;
using System.IO;

namespace Lab8
{
    class Program
    {
        /// <summary>
        /// Main entry point for Lab 8.
        /// </summary>
        static void Main()
        {
            GenerateTestFiles();

            while (true)
            {
                Console.WriteLine("\nChoose a task (1-5) or 0 to exit:");
                string choice = Console.ReadLine()!;

                switch (choice)
                {
                    case "1": Task1.Execute(); break;
                    case "2": Task2.Execute(); break;
                    case "3": Task3.Execute(); break;
                    case "4": Task4.Execute(); break;
                    case "5": Task5.Execute(); break;
                    case "0": return;
                    default: Console.WriteLine("Invalid choice."); break;
                }
            }
        }

        /// <summary>
        /// Generates dummy input files for tasks 1, 2, and 3.
        /// </summary>
        private static void GenerateTestFiles()
        {
            File.WriteAllText("task1_in.txt", "Welcome to chnu.cv.ua! You can also visit our portal at portal.cv.ua. Other sites like google.com or chnu.edu.ua are not matched. Another one is test-site.cv.ua here.");
            File.WriteAllText("task2_in.txt", "Це тестове повідомлення. Ми міксуємо English words та українські слова. Programming in CSharp is fun.");
            File.WriteAllText("task3_in.txt", "Один два три один чотири два п'ять. Текст текст текст.");
        }
    }
}