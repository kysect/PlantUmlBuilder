using FluentAssertions;
using Kysect.PlantUmlBuilder.StringBuilding;
using Kysect.PlantUmlBuilder.Syntax;

namespace Kysect.PlantUmlBuilder.Tests;

public class DiagramBuilderTests
{
    private IDiagramBuilder _builder;

    [SetUp]
    public void Setup()
    {
        _builder = new DiagramBuilder();
    }

    [Test]
    public void Build_EmptyTree_ReturnStringWithHeaderAndFooter()
    {
        string expected = """
                          @startuml
                          @enduml
                          """;

        var tree = new DiagramSyntaxTree();
        string? result = _builder.Build(tree);

        result.Should().Be(expected);
    }

    [Test]
    public void Build_AfterAddingObject_ReturnStringWithObject()
    {
        string expected = """
                          @startuml
                          object ObjectName { }
                          @enduml
                          """;

        var tree = new DiagramSyntaxTree()
            .AddChild(new ObjectSyntaxNode("ObjectName"));

        string? result = _builder.Build(tree);

        result.Should().Be(expected);
    }
}