namespace EDIFACTMediator.PropertyMapper;

public class GetFirstOrDefaultMapper : IPropertyMapper
{
    public IEnumerable<string> RequiredParameters => new List<string> { "FilterProperty", "FilterValue", "PropertyName" };
    public Dictionary<string, string> DefaultValues => new Dictionary<string, string>();

    public object? Map(object? source, Dictionary<string, string> parameters)
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
        return property?.GetValue(first);
    }
}
