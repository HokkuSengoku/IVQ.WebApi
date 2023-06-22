using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace IVQ.WebApi.WebUtility;

// Now:
// C# *required* modifier is applied to OpenApi schema generation.
// Non-nullable value type properties are made required by default.
// Profit:
// Clients that rely on OpenApi do not have to expect undefined values in places
// where they clearly will not appear. C# newest features are respected.

// ReSharper disable once ClassNeverInstantiated.Global
public class RequiredSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (schema.Properties == null || schema.Properties.Count == 0)
        {
            return;
        }

        var typeProperties = context.Type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach (var property in schema.Properties)
        {
            if (IsSourceTypePropertyRequired(typeProperties, property.Key))
            {
                AddPropertyToRequired(schema, property.Key);
            }

            if (IsSourceTypePropertyNullable(typeProperties, property.Key))
            {
                continue;
            }


            // "null", "boolean", "object", "array", "number", or "string"), or "integer" which matches any number with a zero fractional part.
            // see also: https://json-schema.org/latest/json-schema-validation.html#rfc.section.6.1.1
            switch (property.Value.Type)
            {
                case "boolean":
                case "integer":
                case "number":
                    AddPropertyToRequired(schema, property.Key);
                    break;
                case "string":
                    switch (property.Value.Format)
                    {
                        case "date-time":
                        case "uuid":
                            AddPropertyToRequired(schema, property.Key);
                            break;
                    }

                    break;
            }
        }
    }

    private static bool IsNullable(Type type)
    {
        return Nullable.GetUnderlyingType(type) != null;
    }

    private static bool IsRequired(PropertyInfo propertyInfo)
    {
        return propertyInfo.HasAttribute<RequiredMemberAttribute>();
    }

    private static bool IsSourceTypePropertyRequired(IEnumerable<PropertyInfo> typeProperties, string propertyName)
    {
        return typeProperties.Any(info => info.Name.Equals(propertyName, StringComparison.OrdinalIgnoreCase)
                                          && IsRequired(info));
    }

    private static bool IsSourceTypePropertyNullable(IEnumerable<PropertyInfo> typeProperties, string propertyName)
    {
        return typeProperties.Any(info => info.Name.Equals(propertyName, StringComparison.OrdinalIgnoreCase)
                                          && IsNullable(info.PropertyType));
    }

    private static void AddPropertyToRequired(OpenApiSchema schema, string propertyName)
    {
        schema.Required ??= new HashSet<string>();

        schema.Required.Add(propertyName);
    }
}