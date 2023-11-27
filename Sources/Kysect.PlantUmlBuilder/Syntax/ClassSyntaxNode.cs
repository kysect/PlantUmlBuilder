using Kysect.CommonLib.BaseTypes.Extensions;
using Kysect.PlantUmlBuilder.Syntax.Enums;

namespace Kysect.PlantUmlBuilder.Syntax;

public class ClassSyntaxNode : TypeDeclarationSyntaxNode
{
    public ClassSyntaxNode(IdentifierSyntaxNode identifier) : base(TypeDeclarationType.Class, identifier)
    {
    }

    public override void Visit(PlantUmlSyntaxVisitor visitor)
    {
        visitor.ThrowIfNull();
        visitor.VisitClassSyntaxNode(this);
    }
}