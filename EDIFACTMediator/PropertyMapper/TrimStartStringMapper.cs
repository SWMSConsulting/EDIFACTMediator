namespace EDIFACTMediator.PropertyMapper;

public class TrimStartStringMapper : IPropertyMapper
{
    public IEnumerable<string> RequiredParameters => ["TrimString"];
    public Dictionary<string, string> DefaultValues => new Dictionary<string, string>();

    public object? Map(object? source, Dictionary<string, string> parameters, object? sourceBase)
    {
        var sourceString = source as string;
        if (sourceString == null)
        {
            return null;
        }

        var trimString = parameters.GetValueOrDefault("TrimString", "");
        return sourceString.TrimStart(trimString.ToCharArray());
    }
}