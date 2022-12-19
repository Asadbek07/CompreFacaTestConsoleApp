using System.Collections.Specialized;
using Shared.Extensions;

namespace Shared;

public interface IInterface
{
    int Page { get; set; }
}

public static class NameValueCollectionExtensions
{
    public static NameValueCollection AssignPropertyValue<T>(this NameValueCollection collection, T value)
    {
        var properties = value.GetType().GetProperties();
        
        foreach (var property in properties)
        {
            var propertyValue = property.GetValue(value, null);
            // parameter name should be in the snake case!!!
            var propertyName = property.Name.ToSnakeCase();
            
            if (propertyValue != null)
            {
                collection[propertyName] = propertyValue.ToString();
            }
        }

        return collection;
    }
}