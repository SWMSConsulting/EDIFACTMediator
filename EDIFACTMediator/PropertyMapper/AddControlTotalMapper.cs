using EDIFACTMediator.Formats.CommonD96A;

namespace EDIFACTMediator.PropertyMapper;

public class AddControlTotalMapper: IPropertyMapper
{
    public IEnumerable<string> RequiredParameters => DefaultValues.Keys;
    public Dictionary<string, string> DefaultValues => new Dictionary<string, string>
    {
        { "ControlQualifier", "2" }
    };

    public object? Map(object? source, Dictionary<string, string> parameters, object? sourceBase)
    {

        if (source is not IEnumerable<object> sourceList)
        {
            return null;
        }

        var controlQualifier = parameters.GetValueOrDefault("ControlQualifier", "2");

        return new ControlTotal
        {
            ControlQualifier = controlQualifier,
            ControlValue = sourceList.Count(),
        };
    }

}
