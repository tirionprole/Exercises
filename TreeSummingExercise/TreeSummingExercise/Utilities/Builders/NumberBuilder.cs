using System.Text;

namespace TreeSummingExercise.Utilities.Builders
{
    public class NumberBuilder
    {
        private readonly StringBuilder _builder;

        public NumberBuilder()
        {
            _builder = new StringBuilder();
        }

        public void AddNumberCharacter(string character) => _builder.Append(character);
        public int? GetIntValue() => _builder.Length != 0 ? int.Parse(_builder.ToString()) : null;
        public bool ContainsAnyNumbers() => _builder.Length > 0;
        public void Reset() => _builder.Clear();
    }
}