using Kysect.CommonLib.BaseTypes;
using System.Diagnostics.CodeAnalysis;

namespace Kysect.PlantUmlBuilder.Syntax.Enums;

[SuppressMessage("Naming", "CA1720:Identifier contains type name")]
public enum TypeDeclarationType
{
    [EnumStringValue("object")]
    Object,
    [EnumStringValue("class")]
    Class
}