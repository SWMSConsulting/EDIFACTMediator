namespace EDIFACTMediator;

public interface IFormatMapping 
{
    public Type SourceFormat { get; set; }

    public Type TargetFormat { get; set; }

    public IList<IPropertyMapping> PropertyMapping { get; }
}
