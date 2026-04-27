using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Lab8
{
    public class Task1
    {
        /// <summary>
        /// Processes a text file to find, count, and replace web addresses ending in cv.ua.
        /// </summary>
        public static void Execute()
        {
            string inputFile = "task1_in.txt";
            string outputFile = "task1_out.txt";

            if (!File.Exists(inputFile)) return;

            string text = File.ReadAllText(inputFile);
            Console.WriteLine($"Original Text:\n{text}\n");

            string pattern = @"\b[a-zA-Z0-9.-]+\.cv\.ua\b";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);

            MatchCollection matches = regex.Matches(text);
            Console.WriteLine($"Found {matches.Count} domains ending in 'cv.ua':");
            
            foreach (Match match in matches)
            {
                Console.WriteLine($"- {match.Value}");
            }

            Console.Write("\nEnter a domain from the list to replace: ");
            string target = Console.ReadLine()!;
            Console.Write("Enter the new replacement string: ");
            string replacement = Console.ReadLine()!;

            string resultText = text.Replace(target, replacement);
            File.WriteAllText(outputFile, resultText);

            Console.WriteLine($"\nModified text saved to {outputFile}.");
            Console.WriteLine($"Result:\n{resultText}");
        }
    }
}