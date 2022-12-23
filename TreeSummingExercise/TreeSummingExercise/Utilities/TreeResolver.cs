using System.Collections.Generic;
using System.Linq;
using TreeSummingExercise.DomainObjects;
using TreeSummingExercise.Utilities.Builders;

namespace TreeSummingExercise.Utilities
{
    public class TreeResolver
    {
        private static readonly List<Node> NodeRegistry = new();
        private readonly IEnumerable<Node> _leafRegistry = NodeRegistry.Where(x => x.IsLeaf);

        public static Node DecodeAndCreateAllTrees(string stringToConvert)
        {
            var numBuilder = new NumberBuilder();
            var nodeLocationBuilder = new TraversingBuilder();

            var nodeId = 0;
            var root = new Node(null, null, new List<Node>(), nodeId);
            var node = root;

            foreach (var cursor in stringToConvert.Select(currentChar => new CursorInput(currentChar)))
            {
                switch (cursor.Type)
                {
                    case ValidInputTypes.NegativeSign:
                    case ValidInputTypes.Number:
                        numBuilder.AddNumberCharacter(cursor.IntegerValue!);
                        break;
                    case ValidInputTypes.OpenBracket:
                        if (!numBuilder.ContainsAnyNumbers())
                        {
                            nodeLocationBuilder.AggregateTraversalMoves(cursor.Value);
                            break;
                        }
                        node = nodeLocationBuilder.TraverseTo(node);
                        var nextNode = new Node(node, numBuilder.GetIntValue() + (node.Value ?? 0), new List<Node>(), ++nodeId);
                        NodeRegistry.Add(nextNode);
                        node.SubNodes.Add(nextNode);
                        node = nextNode;
                        numBuilder.Reset();
                        nodeLocationBuilder.Reset();
                        break;
                    case ValidInputTypes.CloseBracket:
                        nodeLocationBuilder.AggregateTraversalMoves(cursor.Value);
                        break;
                }
            }

            return root;
        }

        public List<string> SolveTrees(Node rootOfAllTrees)
        {
            var rootsWithTargets = rootOfAllTrees.SubNodes
                .Select(x => new RootIdWithTarget(x.Value ?? 0, x.Id))
                .Reverse()
                .ToList();

            var solutionList = new List<string>(); // required string condition output
            foreach (var (target, id) in rootsWithTargets)
            {
                solutionList.Add(_leafRegistry.Any(x => x.Id > id && target == x.Value - target) 
                    ? "Yes" 
                    : "No");
                
                NodeRegistry.RemoveAll(x => x.Id > id);
            }

            solutionList.Reverse();
            return solutionList;
        }
    }
}