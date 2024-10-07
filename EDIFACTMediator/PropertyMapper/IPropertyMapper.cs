using SWMS.EDISolution.Module.Extensions;

namespace SWMS.EDISolution.Module.Mapper;

#nullable enable
public interface IPropertyMapper
{
    IEnumerable<string> RequiredParameters { get; }

    object? Map(object? source, Dictionary<string, string> parameters);
}