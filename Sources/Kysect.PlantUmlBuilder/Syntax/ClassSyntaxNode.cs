using Kysect.CommonLib.BaseTypes.Extensions;
using Kysect.PlantUmlBuilder.Syntax.Enums;

namespace Kysect.PlantUmlBuilder.Syntax;

public record ClassSyntaxNode(IdentifierSyntaxNode Identifier) : TypeDeclarationSyntaxNode(TypeDeclarationType.Class, Identifier, [])
{
    public override void Visit(PlantUmlSyntaxVisitor visitor)
    {
        visitor.ThrowIfNull();
        visitor.VisitClassSyntaxNode(this);
    }
}