using FluentAssertions;
using Kysect.PlantUmlBuilder.StringBuilding;
using Kysect.PlantUmlBuilder.Syntax;
using Kysect.PlantUmlBuilder.Syntax.Enums;
using Kysect.PlantUmlBuilder.SyntaxTreeBuilding;

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

        Verify(tree, expected);
    }

    [Test]
    public void Build_AfterAddingObject_ReturnStringWithObject()
    {
        string expected = """
                          @startuml
                          object ObjectName { }
                          @enduml
                          """;

        DiagramSyntaxTree tree = new DiagramSyntaxTree()
            .AddChild(new ObjectSyntaxNode(new IdentifierSyntaxNode("ObjectName")));

        Verify(tree, expected);
    }

    [Test]
    public void Build_AfterAddingClass_ReturnStringWithObject()
    {
        string expected = """
                          @startuml
                          class TypeName { }
                          @enduml
                          """;

        DiagramSyntaxTree tree = new DiagramSyntaxTree()
            .AddChild(new ClassSyntaxNode(new IdentifierSyntaxNode("TypeName")));

        Verify(tree, expected);
    }

    [Test]
    public void Build_AfterAddingPackage_ReturnStringWithPackage()
    {
        string expected = """
                          @startuml
                          package TypeName { }
                          @enduml
                          """;

        DiagramSyntaxTree tree = new DiagramSyntaxTree()
            .AddChild(new PackageSyntaxNode(new IdentifierSyntaxNode("TypeName")));

        Verify(tree, expected);
    }

    [Test]
    public void Build_PackageInsidePackage_RenderedCorrectly()
    {
        string expected = $$"""
                          @startuml
                          package A {
                          {{'\t'}}package B { }
                          }
                          @enduml
                          """;

        DiagramSyntaxTree tree = new DiagramSyntaxTree()
            .AddChild(
                new PackageSyntaxNode(new IdentifierSyntaxNode("A"))
                    .AddChild(new PackageSyntaxNode(new IdentifierSyntaxNode("B"))));

        Verify(tree, expected);
    }

    [Test]
    public void Build_ClassWithMethodAndField_RenderCorrectly()
    {
        string expected = $$"""
                            @startuml
                            class A {
                            {{'\t'}}Do(): int[]
                            {{'\t'}}Name: string
                            }
                            @enduml
                            """;

        DiagramSyntaxTree tree = new DiagramSyntaxTree()
            .AddChild(
                new ClassSyntaxNode(new IdentifierSyntaxNode("A"))
                    .AddChild(new TypeMethodSyntaxNode(new IdentifierSyntaxNode("Do"), new IdentifierSyntaxNode("int[]")))
                    .AddChild(new TypeFieldSyntaxNode(new IdentifierSyntaxNode("Name"), new IdentifierSyntaxNode("string"))));

        Verify(tree, expected);
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

        DiagramSyntaxTree tree = new DiagramSyntaxTree()
            .AddChild(new ObjectSyntaxNode(firstIdentifier))
            .AddChild(new ObjectSyntaxNode(secondIdentifier))
            .AddChild(
                new RelationSyntaxNode(
                    firstIdentifier,
                    new RelationArrowSyntaxNode(IsDotted: false, LocationDirection: null, RelationType.DirectedRelation),
                    secondIdentifier));

        Verify(tree, expected);
    }

    private void Verify(DiagramSyntaxTree tree, string expected)
    {
        string? result = _builder.Build(tree);

        result.Should().Be(expected);
    }
}