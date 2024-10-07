using EDIFACTMediator.Extensions;
using System.Collections.ObjectModel;

namespace EDIFACTMediator.Services;

public class FormatMapper: IFormatMapper
{
    public IList<Type> SourceFormats { get; internal set; } = new ObservableCollection<Type>();
    public IList<Type> TargetFormats { get; internal set; } = new ObservableCollection<Type>();

    public FormatMapper RegisterSourceFormat(Type type)
    {
        SourceFormats.Add(type);
        return this;
    }
    public FormatMapper RegisterSourceFormats(List<Type> types)
    {
        types.ForEach(SourceFormats.Add);
        return this;
    }

    public FormatMapper RegisterTargetFormat(Type t)
    {
        TargetFormats.Add(t);
        return this;
    }
    public FormatMapper RegisterTargetFormats(List<Type> types)
    {
        types.ForEach(TargetFormats.Add);
        return this;
    }

    public void Map(IFormatMapping formatMapping, object? source, out object? target)
    {
        target = Map(formatMapping, source);
    }

    public object? Map(IFormatMapping formatMapping, object? source)
    {
        var target = Activator.CreateInstance(formatMapping.TargetFormat);
        var baseProperties = formatMapping.PropertyMapping.Where(m => m.BaseMapping == null).ToList();
        baseProperties.ForEach(m => MapProperty(source, target, m));

        return target;
    }


    public void MapProperty(object? source, object? target, IPropertyMapping mapping)
    {
        var targetPropName = mapping.TargetProperty.Split(".").LastOrDefault();
        var targetProperty = string.IsNullOrEmpty(targetPropName) ? null : target?.GetType().GetProperty(targetPropName);

        if (targetProperty == null)
        {
            Console.WriteLine("Target property not found");
            return;
        }

        var sourcePropName = mapping.SourceProperty;
        var basePropName = mapping.BaseMapping?.SourceProperty ?? "";
        if (!string.IsNullOrEmpty(sourcePropName) && !string.IsNullOrEmpty(basePropName) && sourcePropName.StartsWith(basePropName))
        {
            sourcePropName = sourcePropName?.Replace(basePropName + ".", "");
        }

        var sourceValue = GetPropertyValue(source, sourcePropName);
        var sourceType = sourceValue?.GetType();

        if (targetProperty.PropertyType.IsListType())
        {
            var targetListType = targetProperty.PropertyType.GetGenericArguments().First();
            var targetList = Activator.CreateInstance(typeof(List<>).MakeGenericType(targetListType)) as System.Collections.IList;

            if (sourceType == null || !sourceType.IsListType())
            {
                Console.WriteLine("Source property is not a list or null");
                return;
            }

            var sourceList = sourceValue as IEnumerable<object>;
            if(sourceList == null || targetList == null)
            {
                targetProperty.SetValue(target, targetList);
                return;
            }

            foreach (var sourceInstance in sourceList)
            {
                var targetInstance = Activator.CreateInstance(targetListType);
                targetList.Add(targetInstance);

                mapping.SubMappings.ToList().ForEach(m => MapProperty(sourceInstance, targetInstance, m));

            }

            targetProperty.SetValue(target, targetList);
            return;
        }

        if (targetProperty.PropertyType.IsComplexType())
        {
            var instance = Activator.CreateInstance(targetProperty.PropertyType);
            targetProperty.SetValue(target, instance);

            mapping.SubMappings.ToList().ForEach(m => MapProperty(source, instance, m));

            return;
        }

        var mappedValue = MapPropertyValueAsync(mapping, sourceValue);
        if (mappedValue != null)
        {
            targetProperty.SetValue(target, mappedValue);
        }
    }

    private async Task<object?> MapPropertyValueAsync(IPropertyMapping propertyMapping, object? sourceValue)
    {
        if (propertyMapping.Mapper == null)
        {
            return sourceValue;
        }

        var mapper = Activator.CreateInstance(propertyMapping.Mapper) as IPropertyMapper;
        if (mapper == null)
        {
            return null;
        }
        return await mapper.Map(sourceValue, propertyMapping.MapperParameters);
    }

    public object? GetPropertyValue(object? source, string? propertyName)
    {
        if (source == null || string.IsNullOrEmpty(propertyName))
        {
            return null;
        }

        var type = source.GetType();
        foreach (var prop in propertyName.Split("."))
        {
            var property = type.GetProperty(prop);
            if (property == null)
            {
                return null;
            }
            type = property.PropertyType;
            source = property.GetValue(source);
        }

        return source;
    }
}
