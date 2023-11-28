using Kysect.CommonLib.BaseTypes.Extensions;

namespace Kysect.PlantUmlBuilder.Syntax;

public record IdentifierSyntaxNode(string Name) : PlantUmlSyntaxNode([])
{
    public override void Visit(PlantUmlSyntaxVisitor visitor)
    {
        visitor.ThrowIfNull();
        visitor.VisitIdentifierSyntaxNode(this);
    }
}