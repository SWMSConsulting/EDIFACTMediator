namespace EDIFACTMediator.PropertyMapper;
public class ToStringMapper: IPropertyMapper
{
    public IEnumerable<string> RequiredParameters => new List<string>();
    public Dictionary<string, string> DefaultValues => new Dictionary<string, string>();

    public object? Map(object? source, Dictionary<string, string> parameters)
    {
        return source?.ToString();
    }
}
