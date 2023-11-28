using Kysect.CommonLib.BaseTypes.Extensions;
using Kysect.PlantUmlBuilder.Syntax.Enums;

namespace Kysect.PlantUmlBuilder.Syntax;

public record RelationArrowSyntaxNode(
    bool IsDotted,
    RelationSuggestLocationDirection? LocationDirection,
    RelationType RelationType) : PlantUmlSyntaxNode([])
{
    public override void Visit(PlantUmlSyntaxVisitor visitor)
    {
        visitor.ThrowIfNull();
        visitor.VisitRelationArrowSyntaxNode(this);
    }
}