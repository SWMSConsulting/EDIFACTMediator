namespace EDIFACTMediator.PropertyMapper;
public class ToStringMapper: IPropertyMapper
{
    public IEnumerable<string> RequiredParameters => new List<string>();

    public object? Map(object? source, Dictionary<string, string> parameters)
    {
        return source?.ToString();
    }
}
