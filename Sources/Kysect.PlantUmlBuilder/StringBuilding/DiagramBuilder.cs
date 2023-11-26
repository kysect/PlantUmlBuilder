using Kysect.PlantUmlBuilder.Syntax;
using System.Text;

namespace Kysect.PlantUmlBuilder.StringBuilding;

public class DiagramBuilder : IDiagramBuilder
{
    public string Build(DiagramSyntaxTree tree)
    {
        var stringBuilder = new StringBuilder();

        stringBuilder.AppendLine(PlantUmlConstants.StartUml);
        stringBuilder.AppendLine(PlantUmlConstants.EndUml);

        return stringBuilder.ToString().Trim();
    }
}