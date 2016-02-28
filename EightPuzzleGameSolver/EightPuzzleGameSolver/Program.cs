using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EightPuzzleGameSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            NodeTreeOperations op = new NodeTreeOperations();
            op.CreateNodeTree(new int[] { 8, 0, 4, 7, 6, 5, 1, 2, 3 }, 3);

            int level = 0;
            var writeList = from node in op.NodeTree
                            where node.Level == level
                            select node;

            while (writeList != null && writeList.Count() > 0)
            {
                Console.WriteLine("******** Level " + level + " ********");
                foreach (var item in writeList)
                {
                    Console.WriteLine();
                    consoleWriter(item.Matrix);
                }
                Console.WriteLine("**********************");
                level++;
                writeList = from node in op.NodeTree
                            where node.Level == level
                            select node;
            }

            Console.ReadKey();
        }

        private static void consoleWriter(int[] matrix)
        {
            Console.Write(matrix[0] + " " + matrix[1] + " " + matrix[2]);
            Console.WriteLine();
            Console.Write(matrix[3] + " " + matrix[4] + " " + matrix[5]);
            Console.WriteLine();
            Console.Write(matrix[6] + " " + matrix[7] + " " + matrix[8]);
            Console.WriteLine();
        }
    }
}
