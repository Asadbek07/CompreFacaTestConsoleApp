using System.Text.Json;
using Shared.Extensions;

namespace Shared.CustomJSONSerializer;

public class SnakeCaseToCamelCaseNamingPolicy : JsonNamingPolicy
{
    public static SnakeCaseToCamelCaseNamingPolicy Policy { get; } = new SnakeCaseToCamelCaseNamingPolicy();
    public override string ConvertName(string name)
    {
        return name.ToSnakeCase();
    }
}