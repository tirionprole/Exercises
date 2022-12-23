using TreeSummingExercise.Utilities;

namespace TreeSummingExercise.DomainObjects
{
    public class CursorInput
    {
        public readonly string? IntegerValue;
        public readonly ValidInputTypes Type;
        public readonly string Value;

        public CursorInput(char character)
        {
            var type = character.GetCharType();
            IntegerValue = type == ValidInputTypes.Number ? character.ToString() : null;
            Type = type;
            Value = character.ToString();
        }
    }
}