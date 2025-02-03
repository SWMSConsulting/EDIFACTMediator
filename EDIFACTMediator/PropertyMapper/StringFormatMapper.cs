
namespace EDIFACTMediator.PropertyMapper;

public class StringFormatMapper : IPropertyMapper
{
    public IEnumerable<string> RequiredParameters => DefaultValues.Keys;

    public Dictionary<string, string> DefaultValues => new Dictionary<string, string>
    {
        ["Format"] = "{0}"
    };

    public object? Map(object? source, Dictionary<string, string> parameters, object? sourceBase)
    {
        var format = parameters.GetValueOrDefault("Format");
        if (string.IsNullOrEmpty(format) || !format.Contains("{0}"))
        {
            return null;
        }
        return string.Format(format, source);
    }
}
