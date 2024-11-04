namespace EDIFACTMediator.PropertyMapper;

public class StaticStringMapper : IPropertyMapper
{
    public IEnumerable<string> RequiredParameters => ["Value"];
    public Dictionary<string, string> DefaultValues => new Dictionary<string, string>();

    public object? Map(object? source, Dictionary<string, string> parameters)
    {
        return parameters.GetValueOrDefault("Value");
    }
}
