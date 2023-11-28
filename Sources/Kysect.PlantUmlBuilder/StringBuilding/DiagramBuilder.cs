using Kysect.CommonLib.BaseTypes.Extensions;
using Kysect.PlantUmlBuilder.Syntax;

namespace Kysect.PlantUmlBuilder.StringBuilding;

public class DiagramBuilder : IDiagramBuilder
{
    public string Build(DiagramSyntaxTree tree)
    {
        tree.ThrowIfNull();

        var stringBuilder = new SyntaxStringBuilder();
        var visitor = new DiagramBuilderSyntaxVisitor(stringBuilder);

        stringBuilder.PrepareForNextElement();
        stringBuilder.Append(PlantUmlConstants.StartUml);

        foreach (PlantUmlSyntaxNode plantUmlSyntaxNode in tree.Children)
            visitor.Visit(plantUmlSyntaxNode);

        stringBuilder.PrepareForNextElement();
        stringBuilder.Append(PlantUmlConstants.EndUml);

        return stringBuilder.ToString().Trim();
    }
}