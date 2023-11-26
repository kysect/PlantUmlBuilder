using Kysect.CommonLib.BaseTypes.Extensions;
using Kysect.CommonLib.Exceptions;
using Kysect.PlantUmlBuilder.Syntax;

namespace Kysect.PlantUmlBuilder;

public abstract class PlantUmlSyntaxVisitor
{
    public void Visit(PlantUmlSyntaxNode node)
    {
        switch (node)
        {
            case IdentifierSyntaxNode identifierSyntaxNode:
                Visit(identifierSyntaxNode);
                break;
            case ObjectSyntaxNode objectSyntaxNode:
                Visit(objectSyntaxNode);
                break;
            case RelationSyntaxNode relationSyntaxNode:
                Visit(relationSyntaxNode);
                break;
            case RelationArrowSyntaxNode relationArrowSyntaxNode:
                Visit(relationArrowSyntaxNode);
                break;

            default:
                throw SwitchDefaultExceptions.OnUnexpectedType(node);
        }
    }

    public virtual void Visit(IdentifierSyntaxNode identifierSyntaxNode)
    {
        identifierSyntaxNode.ThrowIfNull();
        VisitChild(identifierSyntaxNode);
    }

    public virtual void Visit(ObjectSyntaxNode objectSyntaxNode)
    {
        objectSyntaxNode.ThrowIfNull();
        VisitChild(objectSyntaxNode);
    }

    public virtual void Visit(RelationSyntaxNode relationSyntaxNode)
    {
        relationSyntaxNode.ThrowIfNull();
        VisitChild(relationSyntaxNode);
    }

    public virtual void Visit(RelationArrowSyntaxNode relationArrowSyntaxNode)
    {
        relationArrowSyntaxNode.ThrowIfNull();
        VisitChild(relationArrowSyntaxNode);
    }

    private void VisitChild(PlantUmlSyntaxNode node)
    {
        foreach (PlantUmlSyntaxNode syntaxNode in node.GetChild())
            Visit(syntaxNode);
    }
}