namespace EDIFACTMediator.PropertyMapper;

#nullable enable
public interface IPropertyMapper
{
    IEnumerable<string> RequiredParameters { get; }

    Dictionary<string, string> DefaultValues { get; }

    object? Map(object? source, Dictionary<string, string> parameters);
}