using Kysect.CommonLib.BaseTypes.Extensions;
using Kysect.PlantUmlBuilder.Syntax.Enums;
using System.Collections.Immutable;

namespace Kysect.PlantUmlBuilder.Syntax;

public class PackageSyntaxNode : TypeDeclarationSyntaxNode
{
    public PackageSyntaxNode(IdentifierSyntaxNode identifier) : base(TypeDeclarationType.Package, identifier)
    {
    }

    public override ImmutableArray<PlantUmlSyntaxNode> GetChild()
    {
        return ImmutableArray<PlantUmlSyntaxNode>.Empty;
    }

    public override void Visit(PlantUmlSyntaxVisitor visitor)
    {
        visitor.ThrowIfNull();
        visitor.VisitPackageSyntaxNode(this);
    }
}