using Kysect.CommonLib.BaseTypes.Extensions;
using System.Collections.Immutable;

namespace Kysect.PlantUmlBuilder.Syntax;

public class DiagramSyntaxTree
{
    public ImmutableArray<PlantUmlSyntaxNode> Child { get; }

    public DiagramSyntaxTree() : this(ImmutableArray<PlantUmlSyntaxNode>.Empty)
    {
    }

    public DiagramSyntaxTree(ImmutableArray<PlantUmlSyntaxNode> child)
    {
        Child = child.ThrowIfNull();
    }

    public DiagramSyntaxTree AddChild(PlantUmlSyntaxNode node)
    {
        return new DiagramSyntaxTree(Child.Add(node));
    }
}