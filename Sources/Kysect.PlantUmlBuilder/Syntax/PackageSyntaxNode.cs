using Kysect.CommonLib.BaseTypes.Extensions;
using Kysect.PlantUmlBuilder.Syntax.Enums;

namespace Kysect.PlantUmlBuilder.Syntax;

public record PackageSyntaxNode(IdentifierSyntaxNode Identifier) : TypeDeclarationSyntaxNode(TypeDeclarationType.Package, Identifier, [])
{
    public override void Visit(PlantUmlSyntaxVisitor visitor)
    {
        visitor.ThrowIfNull();
        visitor.VisitPackageSyntaxNode(this);
    }
}