

namespace SWMS.EDISolution.Module.Mapper;

public class StaticStringMapper : IPropertyMapper
{
    public IEnumerable<string> RequiredParameters => ["Value"];

    public object? Map(object? source, Dictionary<string, string> parameters)
    {
        return parameters.GetValueOrDefault("Value");
    }
}
