namespace EDIFACTMediator.PropertyMapper;

public class GetNestedPropertyFirstOrDefaultMapper : IPropertyMapper
{
    public IEnumerable<string> RequiredParameters => new List<string> { "FilterProperty", "FilterValue", "PropertyName", "ReturnValueAsString" };
    public Dictionary<string, string> DefaultValues => new Dictionary<string, string>();

    public object? Map(object? source, Dictionary<string, string> parameters, object? sourceBase)
    {
        if (source == null)
            return null;

        if (source is not IEnumerable<object> sourceList)
            return null;

        var filterPropertyName = parameters.GetValueOrDefault("FilterProperty");
        var filterValue = parameters.GetValueOrDefault("FilterValue");
        var propertyName = parameters.GetValueOrDefault("PropertyName");
        var returnValueAsString = parameters.GetValueOrDefault("ReturnValueAsString") == "true";

        // No filter → just take first item
        if (string.IsNullOrEmpty(filterPropertyName) || string.IsNullOrEmpty(filterValue))
        {
            var first = sourceList.FirstOrDefault();
            if (first == null)
                return null;

            if (string.IsNullOrEmpty(propertyName))
                return first;

            var value = GetNestedPropertyValue(first, propertyName);
            return returnValueAsString ? value?.ToString() : value;
        }

        // Filter by *simple* property
        var filterProp = sourceList.FirstOrDefault()?.GetType().GetProperty(filterPropertyName);
        if (filterProp == null)
            return null;

        var match = sourceList.FirstOrDefault(x =>
            filterProp.GetValue(x)?.ToString() == filterValue);

        if (match == null || string.IsNullOrEmpty(propertyName))
            return match;

        var result = GetNestedPropertyValue(match, propertyName);
        return returnValueAsString ? result?.ToString() : result;
    }

    public static object? GetNestedPropertyValue(object? obj, string propertyPath)
    {
        if (obj == null || string.IsNullOrWhiteSpace(propertyPath))
            return null;

        foreach (var part in propertyPath.Split('.'))
        {
            if (obj == null)
                return null;

            var prop = obj.GetType().GetProperty(part);
            if (prop == null)
                return null;

            obj = prop.GetValue(obj);
        }

        return obj;
    }
}
