using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EightPuzzleGameSolver
{
    public class NodeTreeOperations
    {
        public List<Node> NodeTree { get; set; }

        public void CreateNodeTree(int[] given, int maxLevel)
        {
            NodeTree = new List<Node>();
            NodeTree.Add(new Node(given, 0, 0));

            for (int i = 0; i < 3; i++)
            {
                List<Node> allNodesCopy = new List<Node>();
                allNodesCopy.AddRange(NodeTree);

                var levelNodes = from node in allNodesCopy
                                 where node.Level == i
                                 select node;

                foreach (var item in levelNodes)
                {
                    List<Node> children = CreateChildNodes(item);
                    NodeTree.AddRange(children);
                }
            }
        }

        public List<Node> CreateChildNodes(Node rootNode)
        {
            try
            {
                List<Node> children = new List<Node>();

                int zeroIndex = Array.IndexOf(rootNode.Matrix, 0);

                int maxLevelIndex = getMaxLevelIndex(rootNode.Level) - 1;

                //top control
                if (zeroIndex - 3 > 0)
                {
                    maxLevelIndex++;
                    Node topNode = new Node(swapMatrix(rootNode.Matrix, zeroIndex, zeroIndex - 3),
                                            rootNode.Level + 1,
                                            maxLevelIndex);
                    children.Add(topNode);
                }

                //right control
                if (zeroIndex % 3 != 2)
                {
                    maxLevelIndex++;
                    Node rightNode = new Node(swapMatrix(rootNode.Matrix, zeroIndex, zeroIndex + 1),
                                            rootNode.Level + 1,
                                            maxLevelIndex);
                    children.Add(rightNode);
                }

                //bottom control
                if (zeroIndex + 3 < 9)
                {
                    maxLevelIndex++;
                    Node bottomNode = new Node(swapMatrix(rootNode.Matrix, zeroIndex, zeroIndex + 3),
                                            rootNode.Level + 1,
                                            maxLevelIndex);
                    children.Add(bottomNode);
                }

                //left control
                if (zeroIndex % 3 != 0)
                {
                    maxLevelIndex++;
                    Node leftNode = new Node(swapMatrix(rootNode.Matrix, zeroIndex, zeroIndex - 1),
                                            rootNode.Level + 1,
                                            maxLevelIndex);
                    children.Add(leftNode);
                }

                return children;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private int[] swapMatrix(int[] rootMatrix, int zeroIndex, int newIndex)
        {
            int[] newMatrix = (int[])rootMatrix.Clone();
            int temp = newMatrix[zeroIndex];
            newMatrix[zeroIndex] = newMatrix[newIndex];
            newMatrix[newIndex] = temp;
            return newMatrix;
        }

        private int getMaxLevelIndex(int rootLevel)
        {
            if (NodeTree.Count(x => x.Level == rootLevel + 1) <= 0)
            {
                return 0;
            }

            var levelNodes = NodeTree.Select(x => x.Level == rootLevel + 1);
            return levelNodes.Count();
        }
    }
}
