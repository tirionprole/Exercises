using TreeSummingExercise.DomainObjects;

namespace TreeSummingExercise.Utilities
{
    public static class ValidInputTypeConverter
    {
        public static ValidInputTypes GetCharType(this char character) =>
            int.TryParse(character.ToString(), out _) || character.ToString() == "-"
                ? ValidInputTypes.Number
                : character != '('
                    ? character == ')' ? ValidInputTypes.CloseBracket : ValidInputTypes.Unknown
                    : ValidInputTypes.OpenBracket;
    }
}