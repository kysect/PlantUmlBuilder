using Kysect.CommonLib.BaseTypes.Extensions;
using Kysect.PlantUmlBuilder.Syntax.Enums;
using System.Collections.Immutable;

namespace Kysect.PlantUmlBuilder.Syntax;

public class ClassSyntaxNode : TypeDeclarationSyntaxNode
{
    public ClassSyntaxNode(IdentifierSyntaxNode identifier) : base(TypeDeclarationType.Class, identifier)
    {
    }

    public override ImmutableArray<PlantUmlSyntaxNode> GetChild()
    {
        return ImmutableArray<PlantUmlSyntaxNode>.Empty;
    }

    public override void Visit(PlantUmlSyntaxVisitor visitor)
    {
        visitor.ThrowIfNull();
        visitor.VisitClassSyntaxNode(this);
    }
}