using Kysect.CommonLib.BaseTypes.Extensions;
using Kysect.PlantUmlBuilder.Syntax.Enums;
using System.Collections.Immutable;

namespace Kysect.PlantUmlBuilder.Syntax;

public class RelationArrowSyntaxNode : PlantUmlSyntaxNode
{
    public bool IsDotted { get; init; }
    public RelationSuggestLocationDirection? LocationDirection { get; init; }
    public RelationType RelationType { get; init; }

    public RelationArrowSyntaxNode(bool isDotted, RelationSuggestLocationDirection? locationDirection, RelationType relationType)
    {
        IsDotted = isDotted;
        LocationDirection = locationDirection;
        RelationType = relationType;
    }

    public override ImmutableArray<PlantUmlSyntaxNode> GetChild()
    {
        return ImmutableArray<PlantUmlSyntaxNode>.Empty;
    }

    public override void Visit(PlantUmlSyntaxVisitor visitor)
    {
        visitor.ThrowIfNull();
        visitor.VisitRelationArrowSyntaxNode(this);
    }
}