namespace EDIFACTMediator.PropertyMapper;

public class ListCountMapper : IPropertyMapper
{
    public IEnumerable<string> RequiredParameters => [];
    public Dictionary<string, string> DefaultValues => new Dictionary<string, string>();

    public object? Map(object? source, Dictionary<string, string> parameters)
    {
        var sourceList = source as IEnumerable<object>;

        if (sourceList == null)
        {
            return null;
        }
        return sourceList.Count();
    }
}
