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

    static bool Check(Node input, Node solution) {
        Dictionary<int, List<Node>> origHashTable = BFSHashTable(input);
        Dictionary<int, List<Node>> solnHashTable = BFSHashTable(solution);

        while (origHashTable.Count > 0) {
            foreach (var item in origHashTable.Keys) {

                if (!solnHashTable.ContainsKey(item)) {
                    return false;
                }
                
                foreach (var node in origHashTable[item]) {
                    Node? foundSolNode = null;
                    foreach (var solnNode in solnHashTable[item]) {
                        if (solnNode.val == node.val) {
                            foundSolNode = solnNode; 
                            break;
                        }
                    }
                    if(foundSolNode == null || foundSolNode == node) {
                        return false;
                    }
                }
                origHashTable.Remove(item);
                solnHashTable.Remove(item);
            }
        }

        if (solnHashTable.Count > 0) {
            return false;
        }
        return true;
    }

    static void BFSHashTableChecker(Dictionary<int, List<Node>> bfsHashTable) {
        foreach(var bfsHashKey in bfsHashTable.Keys) {
            Console.WriteLine("Node.val: " + bfsHashTable[bfsHashKey][0].val);
            bfsHashTable[bfsHashKey].RemoveAt(0);
            foreach(var bfsHashValue in bfsHashTable[bfsHashKey]) {
                Console.WriteLine("Neighbor: " + bfsHashValue.val);
            }
        }
    }
    static Dictionary<int, List<Node>> BFSHashTable(Node root)
    {
        Dictionary<int, List<Node>> bfsHashTable = new Dictionary<int, List<Node>>();
        Queue<Node> q = new Queue<Node>();
        q.Enqueue(root);
        while (q.Count > 0)
        {
            Node node = q.Dequeue();
            if (!bfsHashTable.ContainsKey(node.val))
            {
                bfsHashTable.Add(node.val, new List<Node>());
                bfsHashTable[node.val].Add(node);
                foreach (Node neighbor in node.neighbors)
                {
                    q.Enqueue(neighbor);
                    bfsHashTable[node.val].Add(neighbor);
                }
            }
        }
        return bfsHashTable;
    }
    public static void Main(string[] args)
    {
        int test_case_number = 0;
        Node n1 = new Node(1);
        Node n2 = new Node(2);
        Node n3 = new Node(3);
        Node n4 = new Node(4);

        n1.neighbors.Add(n2);
        n1.neighbors.Add(n4);

        n2.neighbors.Add(n1);
        n2.neighbors.Add(n3);
        
        n3.neighbors.Add(n2);
        n3.neighbors.Add(n4);

        n4.neighbors.Add(n1);
        n4.neighbors.Add(n3);

        BFSHashTableChecker(BFSHashTable(n1));

        Node n11 = new Node(1);
        Node n12 = new Node(2);
        Node n13 = new Node(3);
        Node n14 = new Node(4);

        n11.neighbors.Add(n12);
        n11.neighbors.Add(n14);

        n12.neighbors.Add(n11);
        n12.neighbors.Add(n13);
        
        n13.neighbors.Add(n12);
        n13.neighbors.Add(n14);

        n14.neighbors.Add(n11);
        n14.neighbors.Add(n13);
        Console.WriteLine(Check(n1, n11));
    }
}