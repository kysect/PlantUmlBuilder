using Kysect.CommonLib.BaseTypes.Extensions;
using Kysect.PlantUmlBuilder.Syntax;

namespace Kysect.PlantUmlBuilder.SyntaxTreeBuilding;

public static class ClassSyntaxNodeBuildingExtensions
{
    public static ClassSyntaxNode AddChild(this ClassSyntaxNode syntaxNode, PlantUmlSyntaxNode child)
    {
        syntaxNode.ThrowIfNull();
        child.ThrowIfNull();
        return syntaxNode with { Children = syntaxNode.Children.Add(child) };
    }
}