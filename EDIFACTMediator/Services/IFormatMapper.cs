namespace EDIFACTMediator.Services;

public interface IFormatMapper
{
    public IList<Type> SourceFormats { get; }

    public IList<Type> TargetFormats { get; }

    public object? Deserialize(Type type, string content);

    public object? Map(IFormatMapping formatMapping, object? source);

    public string Serialize(object? toSerialize);

    public Dictionary<Type, SerializedFormat> SerializedFormats { get; }
}

public enum SerializedFormat
{
    Json,
    EdiFact,
    Csv
}
