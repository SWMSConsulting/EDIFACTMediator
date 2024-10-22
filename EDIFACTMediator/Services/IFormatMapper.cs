namespace EDIFACTMediator.Services;

public interface IFormatMapper
{
    public IList<Type> SourceFormats { get; }

    public IList<Type> TargetFormats { get; }

    public Task<object?> Map(IFormatMapping formatMapping, object? source);
}
