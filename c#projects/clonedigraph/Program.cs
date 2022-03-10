using Microsoft.VisualStudio.TestTools.UnitTesting;

public class Node
{
    public int val;
    public IList<Node> neighbors;

    public Node()
    {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val)
    {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors)
    {
        val = _val;
        neighbors = _neighbors;
    }
}

// public class Solution2
// {

//     public Node? CloneGraph(Node node)
//     {
//         if (node == null)
//         {
//             return null;
//         }
//         var visited = Enumerable.Repeat(false, node.neighbors.Count).ToList();

//         return DFSClone(node, new Node(node.val), visited);
//     }

//     public Node DFSClone(Node node, Node clone, List<bool> visited)
//     {
//         foreach (Node neighbor in node.neighbors)
//         {
//             try
//             {
//                 var currentCapacity = visited.Capacity;
//                 if (currentCapacity < neighbor.val - 1)
//                 {
//                     var rangeToAdd = visited.EnsureCapacity(neighbor.val - 1) - currentCapacity;
//                     visited.AddRange(Enumerable.Repeat())
//                 }
//                 if (visited[neighbor.val - 1] == false)
//                 {
//                     var cloneNeighbor = new Node(neighbor.val - 1);
//                     clone.neighbors.Add(cloneNeighbor);
//                     visited[neighbor.val - 1] = true;
//                     DFSClone(neighbor, cloneNeighbor, visited);
//                 }
//             }
//             catch (Exception e)
//             {
//                 Console.WriteLine("Message :" + e.Message);
//                 Console.WriteLine("Value: " + neighbor.val + " Count: " + visited.Count + " Capacity: " + visited.Capacity);
//             }
//         }
//         return clone;
//     }
// }

public class Solution
{
    static Dictionary<Node, Node> visited = new Dictionary<Node, Node>();
    public Node? CloneGraph(Node node)
    {
        if (node == null) {
            return null;
        }
        visited.Add(node, new Node(node.val));
        return CloneHelper(node, visited[node]);
    }

    public Node CloneHelper(Node node, Node clone)
    {
        foreach (Node neighbor in node.neighbors)
        {
            if (!visited.ContainsKey(neighbor))
            {
                visited.Add(neighbor, new Node(neighbor.val));
                CloneHelper(neighbor, visited[neighbor]);
            }
            clone.neighbors.Add(visited[neighbor]);
        }
        return clone;
    }
    public static void Main(string[] args)
    {
        int test_case_number = 0;
        bool Check(Node inputRoot, Node outputRoot) {
            if(inputRoot == outputRoot || inputRoot.val != outputRoot.val) {
                Console.WriteLine("Incorrect, Test #" + test_case_number);
            }

            foreach (Node neighbor in inputRoot.neighbors) {
                Check()
            }
        }
    }
}