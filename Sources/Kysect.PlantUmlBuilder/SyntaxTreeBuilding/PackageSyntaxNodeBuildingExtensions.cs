﻿using Kysect.CommonLib.BaseTypes.Extensions;
using Kysect.PlantUmlBuilder.Syntax;

namespace Kysect.PlantUmlBuilder.SyntaxTreeBuilding;

public static class PackageSyntaxNodeBuildingExtensions
{
    public static PackageSyntaxNode AddChild(this PackageSyntaxNode syntaxNode, PlantUmlSyntaxNode child)
    {
        syntaxNode.ThrowIfNull();
        child.ThrowIfNull();
        return syntaxNode with { Children = syntaxNode.Children.Add(child) };
    }
}