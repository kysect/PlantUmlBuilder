using Kysect.PlantUmlBuilder.Syntax;

namespace Kysect.PlantUmlBuilder.StringBuilding;

public interface IDiagramBuilder
{
    string Build(DiagramSyntaxTree tree);
}