namespace EDIFACTMediator.Formats;

public interface ICsvFormat
{
    public abstract IEnumerable<object> Rows { get; }
}
