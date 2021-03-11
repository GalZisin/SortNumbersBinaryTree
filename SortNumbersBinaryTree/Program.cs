using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortNumbersBinaryTree
{
    class Program
    {
        private static string filePathInput = "RandomNumbers.txt";
        private static string filePathOutput = "SortedNumbers.txt";
        public static void Main(string[] args)
        {
            string[] rendomNumbers = File.ReadAllLines(filePathInput);
            int[] rendomNumbersArray = new int[rendomNumbers.Length];
            int i = 0;
            foreach (String number in rendomNumbers)
            {
                try
                {
                    int result = Int32.Parse(number);

                    rendomNumbersArray[i] = result;
                    i++;
                    //Console.WriteLine(result);
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Unable to parse '{number}'");
                }
            }

            BinaryTree tree = new BinaryTree(rendomNumbersArray.Length, filePathOutput);

            tree.treeins(rendomNumbersArray);
            tree.inorderRec(tree.root);

            Console.ReadLine();
        }
    
    }

}

