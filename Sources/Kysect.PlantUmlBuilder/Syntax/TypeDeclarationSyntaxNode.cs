using Kysect.PlantUmlBuilder.Syntax.Enums;
using System.Collections.Immutable;

namespace Kysect.PlantUmlBuilder.Syntax;

public abstract class TypeDeclarationSyntaxNode : PlantUmlSyntaxNode
{
    public TypeDeclarationType Type { get; }
    public IdentifierSyntaxNode Identifier { get; }
    public ImmutableArray<PlantUmlSyntaxNode> Children { get; }

    protected TypeDeclarationSyntaxNode(TypeDeclarationType type, IdentifierSyntaxNode identifier)
    {
        Type = type;
        Identifier = identifier;
    }

    protected TypeDeclarationSyntaxNode(TypeDeclarationType type, IdentifierSyntaxNode identifier, ImmutableArray<PlantUmlSyntaxNode> children)
    {
        Type = type;
        Identifier = identifier;
        Children = children;
    }

    public override ImmutableArray<PlantUmlSyntaxNode> GetChildren()
    {
        return Children;
    }
}