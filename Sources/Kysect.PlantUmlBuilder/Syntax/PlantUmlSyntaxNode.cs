using System.Collections.Immutable;

namespace Kysect.PlantUmlBuilder.Syntax;

public abstract class PlantUmlSyntaxNode
{
    public abstract ImmutableArray<PlantUmlSyntaxNode> GetChild();
}