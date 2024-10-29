namespace EDIFACTMediator.PropertyMapper;

public class ListCountMapper : IPropertyMapper
{
    public IEnumerable<string> RequiredParameters => [];

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
