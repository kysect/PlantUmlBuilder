using Kysect.CommonLib.BaseTypes.Extensions;
using Kysect.PlantUmlBuilder.Syntax;
using System.Text;

namespace Kysect.PlantUmlBuilder.StringBuilding;

public class DiagramBuilder : IDiagramBuilder
{
    public string Build(DiagramSyntaxTree tree)
    {
        tree.ThrowIfNull();

        var stringBuilder = new StringBuilder();
        var visitor = new DiagramBuilderSyntaxVisitor(stringBuilder);

        stringBuilder.AppendLine(PlantUmlConstants.StartUml);

        foreach (PlantUmlSyntaxNode plantUmlSyntaxNode in tree.Child)
            visitor.Visit(plantUmlSyntaxNode);

        stringBuilder.AppendLine(PlantUmlConstants.EndUml);

        return stringBuilder.ToString().Trim();
    }
}