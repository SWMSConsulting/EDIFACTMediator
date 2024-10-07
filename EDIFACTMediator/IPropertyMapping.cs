namespace EDIFACTMediator;

public interface IPropertyMapping 
{
    public string TargetProperty { get; }
    
    public string SourceProperty { get; }

    public IPropertyMapping? BaseMapping { get; }
        
    public IList<IPropertyMapping> SubMappings { get; }

    public Type Mapper { get; }

    public Dictionary<string, string> MapperParameters { get; }
}
