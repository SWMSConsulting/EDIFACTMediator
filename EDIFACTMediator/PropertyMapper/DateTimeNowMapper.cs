namespace EDIFACTMediator.PropertyMapper;

public class DateTimeNowMapper : IPropertyMapper
{
    public IEnumerable<string> RequiredParameters => ["StringFormat"];
    public Dictionary<string, string> DefaultValues => new Dictionary<string, string>();

    public object? Map(object? source, Dictionary<string, string> parameters)
    {
        var stringFormat = parameters.GetValueOrDefault("StringFormat");
        if(stringFormat != null)
        {
            return DateTime.Now.ToString(stringFormat);
        }

        return DateTime.Now;
    }
}
