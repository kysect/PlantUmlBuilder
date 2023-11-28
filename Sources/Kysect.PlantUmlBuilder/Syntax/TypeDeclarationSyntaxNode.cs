using Kysect.PlantUmlBuilder.Syntax.Enums;
using System.Collections.Immutable;

namespace Kysect.PlantUmlBuilder.Syntax;

public abstract record TypeDeclarationSyntaxNode(
    TypeDeclarationType Type,
    IdentifierSyntaxNode Identifier,
    ImmutableArray<PlantUmlSyntaxNode> Children) : PlantUmlSyntaxNode(Children)
{
    protected TypeDeclarationSyntaxNode(TypeDeclarationType type, IdentifierSyntaxNode identifier)
        : this(type, identifier, [])
    {
    }
}