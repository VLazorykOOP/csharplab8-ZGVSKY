using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Lab8
{
    public class Task3
    {
        /// <summary>
        /// Removes all duplicate occurrences of words from a text file.
        /// </summary>
        public static void Execute()
        {
            string inputFile = "task3_in.txt";
            string outputFile = "task3_out.txt";

            if (!File.Exists(inputFile)) return;

            string text = File.ReadAllText(inputFile);
            Console.WriteLine($"Original Text:\n{text}\n");

            HashSet<string> seenWords = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            string resultText = Regex.Replace(text, @"\b\p{L}+\b", match =>
            {
                if (seenWords.Contains(match.Value))
                {
                    return string.Empty;
                }
                
                seenWords.Add(match.Value);
                return match.Value;
            });

            resultText = Regex.Replace(resultText, @"\s+", " ").Trim();

            File.WriteAllText(outputFile, resultText);

            Console.WriteLine($"Modified text saved to {outputFile}.");
            Console.WriteLine($"Result:\n{resultText}");
        }
    }
}