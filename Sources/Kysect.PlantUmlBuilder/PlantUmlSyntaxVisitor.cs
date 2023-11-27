using Kysect.CommonLib.BaseTypes.Extensions;
using Kysect.PlantUmlBuilder.Syntax;

namespace Kysect.PlantUmlBuilder;

public abstract class PlantUmlSyntaxVisitor
{
    public void Visit(PlantUmlSyntaxNode node)
    {
        node.ThrowIfNull();
        node.Visit(this);
    }

    public virtual void VisitIdentifierSyntaxNode(IdentifierSyntaxNode identifierSyntaxNode)
    {
        identifierSyntaxNode.ThrowIfNull();
        VisitDefault(identifierSyntaxNode);
    }

    public virtual void VisitObjectSyntaxNode(ObjectSyntaxNode objectSyntaxNode)
    {
        objectSyntaxNode.ThrowIfNull();
        VisitDefault(objectSyntaxNode);
    }

    public virtual void VisitClassSyntaxNode(ClassSyntaxNode classSyntaxNode)
    {
        classSyntaxNode.ThrowIfNull();
        VisitDefault(classSyntaxNode);
    }

    public virtual void VisitRelationSyntaxNode(RelationSyntaxNode relationSyntaxNode)
    {
        relationSyntaxNode.ThrowIfNull();
        VisitDefault(relationSyntaxNode);
    }

    public virtual void VisitRelationArrowSyntaxNode(RelationArrowSyntaxNode relationArrowSyntaxNode)
    {
        relationArrowSyntaxNode.ThrowIfNull();
        VisitDefault(relationArrowSyntaxNode);
    }

    private void VisitDefault(PlantUmlSyntaxNode node)
    {
        foreach (PlantUmlSyntaxNode syntaxNode in node.GetChild())
            syntaxNode.Visit(this);
    }
}