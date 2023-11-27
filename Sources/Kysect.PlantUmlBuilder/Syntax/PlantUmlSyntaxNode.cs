using System.Collections.Immutable;

namespace Kysect.PlantUmlBuilder.Syntax;

public abstract class PlantUmlSyntaxNode
{
    public abstract ImmutableArray<PlantUmlSyntaxNode> GetChildren();
    public abstract void Visit(PlantUmlSyntaxVisitor visitor);
}