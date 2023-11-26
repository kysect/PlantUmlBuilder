namespace Kysect.PlantUmlBuilder.Syntax;

public class ObjectSyntaxNode : PlantUmlSyntaxNode
{
    public string Alias { get; }

    public ObjectSyntaxNode(string alias)
    {
        Alias = alias;
    }
}