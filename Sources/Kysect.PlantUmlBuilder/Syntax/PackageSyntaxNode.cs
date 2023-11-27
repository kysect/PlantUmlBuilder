using Kysect.CommonLib.BaseTypes.Extensions;
using Kysect.PlantUmlBuilder.Syntax.Enums;

namespace Kysect.PlantUmlBuilder.Syntax;

public class PackageSyntaxNode : TypeDeclarationSyntaxNode
{
    public PackageSyntaxNode(IdentifierSyntaxNode identifier) : base(TypeDeclarationType.Package, identifier)
    {
    }

    public override void Visit(PlantUmlSyntaxVisitor visitor)
    {
        visitor.ThrowIfNull();
        visitor.VisitPackageSyntaxNode(this);
    }
}