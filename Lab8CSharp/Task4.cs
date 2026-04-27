using System;
using System.IO;

namespace Lab8
{
    public class Task4
    {
        /// <summary>
        /// Creates a binary file with integers, filters out multiples of a given number, and reads the file.
        /// </summary>
        public static void Execute()
        {
            string binFile = "task4.dat";

            Console.Write("Enter the number of integers (n): ");
            int n = int.Parse(Console.ReadLine()!);

            Console.Write("Enter the divisor to filter out multiples of: ");
            int divisor = int.Parse(Console.ReadLine()!);

            Random rnd = new Random();
            using (FileStream fs = new FileStream(binFile, FileMode.Create))
            using (BinaryWriter bw = new BinaryWriter(fs))
            {
                Console.WriteLine("\nGenerated sequence:");
                for (int i = 0; i < n; i++)
                {
                    int num = rnd.Next(1, 100);
                    Console.Write($"{num} ");
                    
                    if (num % divisor != 0)
                    {
                        bw.Write(num);
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine($"\nNumbers not multiple of {divisor} (read from binary file):");
            using (FileStream fs = new FileStream(binFile, FileMode.Open))
            using (BinaryReader br = new BinaryReader(fs))
            {
                while (fs.Position < fs.Length)
                {
                    int val = br.ReadInt32();
                    Console.Write($"{val} ");
                }
                Console.WriteLine();
            }
        }
    }
}