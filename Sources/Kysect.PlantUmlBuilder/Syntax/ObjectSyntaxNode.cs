using Kysect.CommonLib.BaseTypes.Extensions;
using Kysect.PlantUmlBuilder.Syntax.Enums;
using System.Collections.Immutable;

namespace Kysect.PlantUmlBuilder.Syntax;

public class ObjectSyntaxNode : TypeDeclarationSyntaxNode
{
    public ObjectSyntaxNode(IdentifierSyntaxNode identifier) : base(TypeDeclarationType.Object, identifier)
    {
    }

    public override ImmutableArray<PlantUmlSyntaxNode> GetChild()
    {
        return ImmutableArray<PlantUmlSyntaxNode>.Empty;
    }

    public override void Visit(PlantUmlSyntaxVisitor visitor)
    {
        visitor.ThrowIfNull();
        visitor.VisitObjectSyntaxNode(this);
    }
}