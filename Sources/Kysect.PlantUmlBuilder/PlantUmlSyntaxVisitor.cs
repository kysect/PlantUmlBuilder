using Kysect.CommonLib.Exceptions;
using Kysect.PlantUmlBuilder.Syntax;

namespace Kysect.PlantUmlBuilder;

public abstract class PlantUmlSyntaxVisitor
{
    public void Visit(PlantUmlSyntaxNode node)
    {
        switch (node)
        {
            case ObjectSyntaxNode objectSyntaxNode:
                Visit(objectSyntaxNode);
                return;

            default:
                throw SwitchDefaultExceptions.OnUnexpectedType(node);
        }
    }

    public virtual void Visit(ObjectSyntaxNode objectSyntaxNode)
    {
    }
}