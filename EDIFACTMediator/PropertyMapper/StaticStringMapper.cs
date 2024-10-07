namespace EDIFACTMediator.PropertyMapper;

public class StaticStringMapper : IPropertyMapper
{
    public IEnumerable<string> RequiredParameters => ["Value"];

    public async Task<object?> Map(object? source, Dictionary<string, string> parameters)
    {
        return parameters.GetValueOrDefault("Value");
    }
}
