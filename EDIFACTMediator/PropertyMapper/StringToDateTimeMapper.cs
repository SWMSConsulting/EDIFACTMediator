
namespace EDIFACTMediator.PropertyMapper;

public class StringToDateTimeMapper : IPropertyMapper
{
    public IEnumerable<string> RequiredParameters => [];

    public Dictionary<string, string> DefaultValues => new Dictionary<string, string>();

    public object? Map(object? source, Dictionary<string, string> parameters, object? sourceBase)
    {
        var sourceString = source as string;

        if(string.IsNullOrEmpty(sourceString))
            return null;

        DateTime.TryParse(sourceString, out DateTime result);

        return result;
    }
}
