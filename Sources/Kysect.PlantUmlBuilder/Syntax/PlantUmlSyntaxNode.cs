using System.Collections.Immutable;

namespace Kysect.PlantUmlBuilder.Syntax;

public abstract record PlantUmlSyntaxNode(ImmutableArray<PlantUmlSyntaxNode> Children)
{
    public abstract void Visit(PlantUmlSyntaxVisitor visitor);
}