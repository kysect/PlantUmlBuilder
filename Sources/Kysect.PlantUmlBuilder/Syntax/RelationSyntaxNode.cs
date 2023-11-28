using Kysect.CommonLib.BaseTypes.Extensions;

namespace Kysect.PlantUmlBuilder.Syntax;

public record RelationSyntaxNode(IdentifierSyntaxNode Left, RelationArrowSyntaxNode Arrow, IdentifierSyntaxNode Right) : PlantUmlSyntaxNode([])
{
    public override void Visit(PlantUmlSyntaxVisitor visitor)
    {
        visitor.ThrowIfNull();
        visitor.VisitRelationSyntaxNode(this);
    }
}