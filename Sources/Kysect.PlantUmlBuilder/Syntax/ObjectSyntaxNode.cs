using Kysect.CommonLib.BaseTypes.Extensions;
using Kysect.PlantUmlBuilder.Syntax.Enums;

namespace Kysect.PlantUmlBuilder.Syntax;

public class ObjectSyntaxNode : TypeDeclarationSyntaxNode
{
    public ObjectSyntaxNode(IdentifierSyntaxNode identifier) : base(TypeDeclarationType.Object, identifier)
    {
    }

    public override void Visit(PlantUmlSyntaxVisitor visitor)
    {
        visitor.ThrowIfNull();
        visitor.VisitObjectSyntaxNode(this);
    }
}