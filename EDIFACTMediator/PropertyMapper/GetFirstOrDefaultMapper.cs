namespace EDIFACTMediator.PropertyMapper;

public class GetFirstOrDefaultMapper : IPropertyMapper
{
    public IEnumerable<string> RequiredParameters => new List<string> { "FilterProperty", "FilterValue", "PropertyName", "ReturnValueAsString" };
    public Dictionary<string, string> DefaultValues => new Dictionary<string, string>();

    public object? Map(object? source, Dictionary<string, string> parameters, object? sourceBase)
    {
        if(source == null)
        {
            return null;
        }

        IEnumerable<object>? sourceList = source as IEnumerable<object>;
        if (sourceList == null)
        {
            return null;
        }

        var filterPropertyName = parameters.GetValueOrDefault("FilterProperty");
        var filterValue = parameters.GetValueOrDefault("FilterValue");
        var propertyName = parameters.GetValueOrDefault("PropertyName");
        var returnValueAsString = parameters.GetValueOrDefault("ReturnValueAsString") == "true";

        if (string.IsNullOrEmpty(filterPropertyName) || string.IsNullOrEmpty(filterValue))
        {
            var f = sourceList.FirstOrDefault();
            if (string.IsNullOrEmpty(propertyName))
            {
                return f;
            }
            var p = f.GetType().GetProperty(propertyName);
            return p?.GetValue(f);
        }

        var filterProperty = sourceList.FirstOrDefault()?.GetType().GetProperty(filterPropertyName);
        if (filterProperty == null)
        {
            return null;
        }

        var first = sourceList.FirstOrDefault(x => filterProperty.GetValue(x)?.ToString() == filterValue);

        if (first == null || string.IsNullOrEmpty(propertyName))
        {
            return first;
        }

        var property = first.GetType().GetProperty(propertyName);
        var value = property?.GetValue(first);

        if (value == null)
        {
            return null;
        }

        if (returnValueAsString)
        {
            return value.ToString();
        }

        return value;
    }
}
