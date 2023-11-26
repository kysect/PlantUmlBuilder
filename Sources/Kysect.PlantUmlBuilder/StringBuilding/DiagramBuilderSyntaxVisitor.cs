using Kysect.CommonLib.BaseTypes.Extensions;
using Kysect.PlantUmlBuilder.Syntax;
using System.Text;

namespace Kysect.PlantUmlBuilder.StringBuilding;

public class DiagramBuilderSyntaxVisitor : PlantUmlSyntaxVisitor
{
    private readonly StringBuilder _stringBuilder;

    public DiagramBuilderSyntaxVisitor(StringBuilder stringBuilder)
    {
        _stringBuilder = stringBuilder;
    }

    public override void Visit(ObjectSyntaxNode objectSyntaxNode)
    {
        objectSyntaxNode.ThrowIfNull();

        _stringBuilder.AppendLine($"object {objectSyntaxNode.Alias} {{ }}");
        base.Visit(objectSyntaxNode);
    }
}