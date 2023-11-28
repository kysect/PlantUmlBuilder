using Kysect.CommonLib.BaseTypes.Extensions;
using Kysect.PlantUmlBuilder.Syntax;

namespace Kysect.PlantUmlBuilder.SyntaxTreeBuilding;

public static class PackageSyntaxNodeBuildingExtensions
{
    public static PackageSyntaxNode AddMember(this PackageSyntaxNode syntaxNode, PlantUmlSyntaxNode member)
    {
        syntaxNode.ThrowIfNull();
        member.ThrowIfNull();
        return syntaxNode with { Children = syntaxNode.Children.Add(member) };
    }
}