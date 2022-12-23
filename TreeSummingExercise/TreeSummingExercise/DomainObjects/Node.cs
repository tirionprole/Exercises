using System.Collections.Generic;
using System.Linq;

namespace TreeSummingExercise.DomainObjects
{
    public class Node
    {
        public readonly int Id;
        public readonly Node? Parent;
        public int? Value;
        public readonly List<Node> SubNodes;
        public bool IsLeaf => !SubNodes.Any();

        public Node(Node? parent, int? value, List<Node> subNodes, int id)
        {
            Id = id;
            Parent = parent;
            Value = value;
            SubNodes = subNodes;
        }
    }
}