using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Lab8
{
    public class Task2
    {
        /// <summary>
        /// Replaces all English words in a text file with three dots.
        /// </summary>
        public static void Execute()
        {
            string inputFile = "task2_in.txt";
            string outputFile = "task2_out.txt";

            if (!File.Exists(inputFile)) return;

            string text = File.ReadAllText(inputFile);
            Console.WriteLine($"Original Text:\n{text}\n");

            string pattern = @"\b[A-Za-z]+\b";
            string resultText = Regex.Replace(text, pattern, "...");

            File.WriteAllText(outputFile, resultText);

            Console.WriteLine($"Modified text saved to {outputFile}.");
            Console.WriteLine($"Result:\n{resultText}");
        }
    }
}