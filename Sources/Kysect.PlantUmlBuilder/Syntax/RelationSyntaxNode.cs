using System.Collections.Immutable;

namespace Kysect.PlantUmlBuilder.Syntax;

public class RelationSyntaxNode : PlantUmlSyntaxNode
{
    public IdentifierSyntaxNode Left { get; }
    public RelationArrowSyntaxNode Arrow { get; }
    public IdentifierSyntaxNode Right { get; }

    public RelationSyntaxNode(IdentifierSyntaxNode left, RelationArrowSyntaxNode arrow, IdentifierSyntaxNode right)
    {
        Left = left;
        Arrow = arrow;
        Right = right;
    }

    public override ImmutableArray<PlantUmlSyntaxNode> GetChild()
    {
        return ImmutableArray<PlantUmlSyntaxNode>.Empty;
    }
}