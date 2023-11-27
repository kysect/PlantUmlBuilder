using Kysect.CommonLib.BaseTypes.Extensions;
using System.Collections.Immutable;

namespace Kysect.PlantUmlBuilder.Syntax;

public class ObjectSyntaxNode : PlantUmlSyntaxNode
{
    public IdentifierSyntaxNode Identifier { get; }

    public ObjectSyntaxNode(IdentifierSyntaxNode identifier)
    {
        Identifier = identifier;
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