using Kysect.CommonLib.BaseTypes.Extensions;
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

    public override ImmutableArray<PlantUmlSyntaxNode> GetChildren()
    {
        return ImmutableArray<PlantUmlSyntaxNode>.Empty;
    }

    public override void Visit(PlantUmlSyntaxVisitor visitor)
    {
        visitor.ThrowIfNull();
        visitor.VisitRelationSyntaxNode(this);
    }
}