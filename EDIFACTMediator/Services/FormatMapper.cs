using EDIFACTMediator.Extensions;
using EDIFACTMediator.PropertyMapper;
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

    public object? Map(IFormatMapping formatMapping, object? source)
    {
        var target = Activator.CreateInstance(formatMapping.TargetFormat);
        var baseProperties = formatMapping.PropertyMapping.Where(m => m.BaseMapping == null).ToList();
        Task.WaitAll(baseProperties.Select(m => MapProperty(source, target, m)).ToArray());
        return target;
    }


    public async Task MapProperty(object? source, object? target, IPropertyMapping mapping)
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

                Task.WaitAll(mapping.SubMappings.Select(m => MapProperty(sourceInstance, targetInstance, m)).ToArray());

            }

            targetProperty.SetValue(target, targetList);
            return;
        }

        if (targetProperty.PropertyType.IsComplexType())
        {
            var instance = Activator.CreateInstance(targetProperty.PropertyType);
            targetProperty.SetValue(target, instance);

            Task.WaitAll(mapping.SubMappings.Select(m => MapProperty(source, instance, m)).ToArray());

            return;
        }

        var mappedValue = await MapPropertyValue(mapping, sourceValue);
        if (mappedValue != null && mappedValue.GetType().IsAssignableTo(targetProperty.PropertyType))
        {
            targetProperty.SetValue(target, mappedValue);
        }
    }

    private async Task<object?> MapPropertyValue(IPropertyMapping propertyMapping, object? sourceValue)
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
        return mapper.Map(sourceValue, propertyMapping.MapperParameters);
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
