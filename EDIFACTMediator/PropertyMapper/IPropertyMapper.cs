namespace EDIFACTMediator.PropertyMapper;

#nullable enable
public interface IPropertyMapper
{
    IEnumerable<string> RequiredParameters { get; }

    Task<object?> Map(object? source, Dictionary<string, string> parameters);
}