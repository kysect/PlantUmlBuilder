using Kysect.CommonLib.BaseTypes.Extensions;
using Kysect.PlantUmlBuilder.Syntax;
using System.Text;

namespace Kysect.PlantUmlBuilder.StringBuilding;

public class DiagramBuilderSyntaxVisitor : PlantUmlSyntaxVisitor
{
    private readonly StringBuilder _stringBuilder;

    public DiagramBuilderSyntaxVisitor(StringBuilder stringBuilder)
    {
        _stringBuilder = stringBuilder;
    }

    public override void Visit(IdentifierSyntaxNode identifierSyntaxNode)
    {
        identifierSyntaxNode.ThrowIfNull();

        _stringBuilder.Append(identifierSyntaxNode.Name);
        base.Visit(identifierSyntaxNode);
    }

    public override void Visit(ObjectSyntaxNode objectSyntaxNode)
    {
        objectSyntaxNode.ThrowIfNull();

        _stringBuilder.Append("object ");
        Visit(objectSyntaxNode.Identifier);
        _stringBuilder
            .Append(" { }")
            .AppendLine();

        base.Visit(objectSyntaxNode);
    }

    public override void Visit(RelationSyntaxNode relationSyntaxNode)
    {
        relationSyntaxNode.ThrowIfNull();

        Visit(relationSyntaxNode.Left);
        Visit(relationSyntaxNode.Arrow);
        Visit(relationSyntaxNode.Right);
        _stringBuilder.AppendLine();
    }

    public override void Visit(RelationArrowSyntaxNode relationArrowSyntaxNode)
    {
        relationArrowSyntaxNode.ThrowIfNull();

        char arrowChar = relationArrowSyntaxNode.IsDotted ? '.' : '-';

        _stringBuilder
            .Append(' ')
            .Append(arrowChar)
            .Append(ToDiagramSymbol(relationArrowSyntaxNode.LocationDirection))
            .Append(arrowChar)
            .Append(ToArrowString(relationArrowSyntaxNode.RelationType))
            .Append(' ');
    }

    private string ToDiagramSymbol(RelationSuggestLocationDirection? directory)
    {
        return directory switch
        {
            RelationSuggestLocationDirection.Up => "up",
            RelationSuggestLocationDirection.Right => "right",
            RelationSuggestLocationDirection.Down => "down",
            RelationSuggestLocationDirection.Left => "left",
            null => string.Empty,

            _ => throw new ArgumentOutOfRangeException(nameof(directory), directory, null)
        };
    }

    private string ToArrowString(RelationType relationType)
    {
        return relationType switch
        {
            RelationType.Relation => string.Empty,
            RelationType.DirectedRelation => ">",
            RelationType.Extension => "|>",
            RelationType.Composition => "*",
            RelationType.Aggregation => "o",
            _ => throw new ArgumentOutOfRangeException(nameof(relationType), relationType, null)
        };
    }
}