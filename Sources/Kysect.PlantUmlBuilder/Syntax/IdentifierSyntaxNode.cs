using System.Collections.Immutable;

namespace Kysect.PlantUmlBuilder.Syntax;

public class IdentifierSyntaxNode : PlantUmlSyntaxNode
{
    public string Name { get; }

    public IdentifierSyntaxNode(string name)
    {
        Name = name;
    }

    public override ImmutableArray<PlantUmlSyntaxNode> GetChild()
    {
        return ImmutableArray<PlantUmlSyntaxNode>.Empty;
    }
}