using System.Text;

namespace Kysect.PlantUmlBuilder.StringBuilding;

public class SyntaxStringBuilder
{
    private readonly StringBuilder _stringBuilder;

    private int _nesting;

    public SyntaxStringBuilder()
    {
        _stringBuilder = new StringBuilder();
    }

    public SyntaxStringBuilder PrepareForNextElement()
    {
        if (_stringBuilder.Length != 0)
        {
            _stringBuilder.AppendLine();
            for (int i = 0; i < _nesting; i++)
                _stringBuilder.Append('\t');
        }

        return this;
    }

    public SyntaxStringBuilder Append(string value)
    {
        _stringBuilder.Append(value);
        return this;
    }

    public SyntaxStringBuilder Append(char value)
    {
        _stringBuilder.Append(value);
        return this;
    }

    public SyntaxStringBuilder IncreaseNesting()
    {
        _nesting++;
        return this;
    }

    public SyntaxStringBuilder DecreaseNesting()
    {
        _nesting--;
        return this;
    }

    public override string ToString()
    {
        return _stringBuilder.ToString();
    }
}