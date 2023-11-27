using FluentAssertions;
using Kysect.PlantUmlBuilder.StringBuilding;
using Kysect.PlantUmlBuilder.Syntax;
using Kysect.PlantUmlBuilder.Syntax.Enums;

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
            .AddChild(new ObjectSyntaxNode(new IdentifierSyntaxNode("ObjectName")));

        string? result = _builder.Build(tree);

        result.Should().Be(expected);
    }

    [Test]
    public void Build_AfterAddingClass_ReturnStringWithObject()
    {
        string expected = """
                          @startuml
                          class TypeName { }
                          @enduml
                          """;

        var tree = new DiagramSyntaxTree()
            .AddChild(new ClassSyntaxNode(new IdentifierSyntaxNode("TypeName")));

        string? result = _builder.Build(tree);

        result.Should().Be(expected);
    }

    [Test]
    public void Build_AfterAddingObjectAndRelation_ReturnExpectedOutput()
    {
        string expected = """
                          @startuml
                          object First { }
                          object Second { }
                          First --> Second
                          @enduml
                          """;

        var firstIdentifier = new IdentifierSyntaxNode("First");
        var secondIdentifier = new IdentifierSyntaxNode("Second");

        var tree = new DiagramSyntaxTree()
            .AddChild(new ObjectSyntaxNode(firstIdentifier))
            .AddChild(new ObjectSyntaxNode(secondIdentifier))
            .AddChild(
                new RelationSyntaxNode(
                    firstIdentifier,
                    new RelationArrowSyntaxNode(isDotted: false, locationDirection: null, RelationType.DirectedRelation),
                    secondIdentifier));

        string? result = _builder.Build(tree);

        result.Should().Be(expected);
    }
}