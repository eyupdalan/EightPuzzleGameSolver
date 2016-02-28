using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EightPuzzleGameSolver
{
    public class Node
    {
        public Node()
        {

        }

        public Node(int[] matrix, int level, int index)
        {
            this.Matrix = matrix;
            this.Level = level;
            this.Index = index;
        }

        public int[] Matrix { get; set; }

        public int Level { get; set; }

        public int Index { get; set; }

    }
}
