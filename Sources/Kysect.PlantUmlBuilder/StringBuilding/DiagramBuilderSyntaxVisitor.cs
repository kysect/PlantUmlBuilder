using Kysect.CommonLib.BaseTypes;
using Kysect.CommonLib.BaseTypes.Extensions;
using Kysect.PlantUmlBuilder.Syntax;
using Kysect.PlantUmlBuilder.Syntax.Enums;

namespace Kysect.PlantUmlBuilder.StringBuilding;

public class DiagramBuilderSyntaxVisitor : PlantUmlSyntaxVisitor
{
    private readonly SyntaxStringBuilder _stringBuilder;

    public DiagramBuilderSyntaxVisitor(SyntaxStringBuilder stringBuilder)
    {
        _stringBuilder = stringBuilder;
    }

    public override void VisitIdentifierSyntaxNode(IdentifierSyntaxNode identifierSyntaxNode)
    {
        identifierSyntaxNode.ThrowIfNull();
        _stringBuilder.PrepareForNextElement();
        ContinueVisitIdentifierSyntaxNode(identifierSyntaxNode);
    }

    public override void VisitObjectSyntaxNode(ObjectSyntaxNode objectSyntaxNode)
    {
        VisitTypeDeclarationSyntaxNode(objectSyntaxNode);
    }

    public override void VisitClassSyntaxNode(ClassSyntaxNode classSyntaxNode)
    {
        VisitTypeDeclarationSyntaxNode(classSyntaxNode);
    }

    public override void VisitPackageSyntaxNode(PackageSyntaxNode packageSyntaxNode)
    {
        VisitTypeDeclarationSyntaxNode(packageSyntaxNode);
    }

    public override void VisitRelationSyntaxNode(RelationSyntaxNode relationSyntaxNode)
    {
        relationSyntaxNode.ThrowIfNull();
        _stringBuilder.PrepareForNextElement();

        ContinueVisitIdentifierSyntaxNode(relationSyntaxNode.Left);
        ContinueVisitRelationArrowSyntaxNode(relationSyntaxNode.Arrow);
        ContinueVisitIdentifierSyntaxNode(relationSyntaxNode.Right);
    }

    public override void VisitRelationArrowSyntaxNode(RelationArrowSyntaxNode relationArrowSyntaxNode)
    {
        relationArrowSyntaxNode.ThrowIfNull();
        _stringBuilder.PrepareForNextElement();

        ContinueVisitRelationArrowSyntaxNode(relationArrowSyntaxNode);
    }

    private void VisitTypeDeclarationSyntaxNode(TypeDeclarationSyntaxNode typeDeclarationSyntaxNode)
    {
        typeDeclarationSyntaxNode.ThrowIfNull();
        _stringBuilder.PrepareForNextElement();

        _stringBuilder
            .Append(EnumStringValue.ToEnumString(typeDeclarationSyntaxNode.Type))
            .Append(' ');
        ContinueVisitIdentifierSyntaxNode(typeDeclarationSyntaxNode.Identifier);
        VisitChildren(typeDeclarationSyntaxNode);
    }

    private void VisitChildren(PlantUmlSyntaxNode typeDeclarationSyntaxNode)
    {
        _stringBuilder.Append(" {");

        if (typeDeclarationSyntaxNode.Children.IsEmpty)
        {
            _stringBuilder.Append(" }");
            return;
        }

        _stringBuilder.IncreaseNesting();
        VisitDefault(typeDeclarationSyntaxNode);
        _stringBuilder.DecreaseNesting();
        _stringBuilder.PrepareForNextElement();
        _stringBuilder.Append("}");
    }

    private void ContinueVisitIdentifierSyntaxNode(IdentifierSyntaxNode identifierSyntaxNode)
    {
        _stringBuilder.Append(identifierSyntaxNode.Name);
        base.VisitIdentifierSyntaxNode(identifierSyntaxNode);
    }

    private void ContinueVisitRelationArrowSyntaxNode(RelationArrowSyntaxNode relationArrowSyntaxNode)
    {
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