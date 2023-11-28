using Kysect.CommonLib.BaseTypes.Extensions;

namespace Kysect.PlantUmlBuilder.Syntax;

public record TypeFieldSyntaxNode(IdentifierSyntaxNode Identifier, IdentifierSyntaxNode Type) : TypeMemberSyntaxNode(Identifier)
{
    public override void Visit(PlantUmlSyntaxVisitor visitor)
    {
        visitor.ThrowIfNull();
        visitor.VisitTypeFieldSyntaxNode(this);
    }
}