using Kysect.CommonLib.BaseTypes.Extensions;
using Kysect.PlantUmlBuilder.Syntax.Enums;

namespace Kysect.PlantUmlBuilder.Syntax;

public record ObjectSyntaxNode(IdentifierSyntaxNode Identifier) : TypeDeclarationSyntaxNode(TypeDeclarationType.Object, Identifier)
{
    public override void Visit(PlantUmlSyntaxVisitor visitor)
    {
        visitor.ThrowIfNull();
        visitor.VisitObjectSyntaxNode(this);
    }
}