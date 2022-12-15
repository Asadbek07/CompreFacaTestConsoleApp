using System.Collections.Specialized;

namespace Shared;

public static class NameValueCollectionExtensions
{
    public static NameValueCollection AssignPropertyValue<T>(this NameValueCollection collection, T type)
    where T: class
    {
        var properties = type.GetType().GetProperties();
        T value = null;
        foreach (var property in properties)
        {
            Console.WriteLine($"{property.Name}, {property.GetValue(value, null)}"); 
        }

        return collection;
    }
}