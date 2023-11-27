using Kysect.PlantUmlBuilder.Syntax.Enums;

namespace Kysect.PlantUmlBuilder.Syntax;

public abstract class TypeDeclarationSyntaxNode : PlantUmlSyntaxNode
{
    public TypeDeclarationType Type { get; }
    public IdentifierSyntaxNode Identifier { get; }

    protected TypeDeclarationSyntaxNode(TypeDeclarationType type, IdentifierSyntaxNode identifier)
    {
        Type = type;
        Identifier = identifier;
    }
}