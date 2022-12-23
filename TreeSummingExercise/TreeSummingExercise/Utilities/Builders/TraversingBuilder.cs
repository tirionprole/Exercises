using TreeSummingExercise.DomainObjects;

namespace TreeSummingExercise.Utilities.Builders
{
    public class TraversingBuilder
    {
        private int _moveByOrder;

        public void AggregateTraversalMoves(string @string)
        {
            switch (@string)
            {
                case "(":
                    _moveByOrder -= 1;
                    break;
                case ")":
                    _moveByOrder += 1;
                    break;
            }
        }

        public Node TraverseTo(Node? node)
        {
            if (_moveByOrder == 0) return node!;
            
            for (var i = 0; i < _moveByOrder; i++) node = node?.Parent;
            return node!;
        }

        public void Reset() => _moveByOrder = 0;
    }
}