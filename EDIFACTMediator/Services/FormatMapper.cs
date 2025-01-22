using CsvHelper;
using CsvHelper.Configuration;
using EDIFACTMediator.Extensions;
using EDIFACTMediator.Formats;
using EDIFACTMediator.PropertyMapper;
using indice.Edi;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Globalization;

namespace EDIFACTMediator.Services;

public class FormatMapper: IFormatMapper
{
    public IList<Type> SourceFormats { get; internal set; } = new ObservableCollection<Type>();
    public IList<Type> TargetFormats { get; internal set; } = new ObservableCollection<Type>();

    public Dictionary<Type, SerializedFormat> SerializedFormats { get; internal set; } = new Dictionary<Type, SerializedFormat>();

    public FormatMapper RegisterSourceFormat(Type type, SerializedFormat serializedFormat)
    {
        SerializedFormats[type] = serializedFormat;
        SourceFormats.Add(type);
        return this;
    }
    public FormatMapper RegisterSourceFormats(List<Tuple<Type, SerializedFormat>> types)
    {
        types.ForEach(t => {
            SerializedFormats[t.Item1] = t.Item2;
            SourceFormats.Add(t.Item1);
        });
        return this;
    }

    public FormatMapper RegisterTargetFormat(Type type, SerializedFormat serializedFormat)
    {
        SerializedFormats[type] = serializedFormat;
        TargetFormats.Add(type);
        return this;
    }
    public FormatMapper RegisterTargetFormats(List<Tuple<Type, SerializedFormat>> types)
    {
        types.ForEach(t => {
            SerializedFormats[t.Item1] = t.Item2;
            TargetFormats.Add(t.Item1);
        });
        return this;
    }

    public object? Map(IFormatMapping formatMapping, object? source)
    {
        var target = Activator.CreateInstance(formatMapping.TargetFormat);
        var baseProperties = formatMapping.PropertyMapping.Where(m => m.BaseMapping == null).ToList();
        Task.WaitAll(baseProperties.Select(m => MapProperty(source, target, m, source)).ToArray());
        return target;
    }


    public async Task MapProperty(object? source, object? target, IPropertyMapping mapping, object? sourceBase)
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
        if(basePropName == sourcePropName)
        {
            sourceValue = source;
        }
        var sourceType = sourceValue?.GetType();

        if (targetProperty.PropertyType.IsListType())
        {
            var targetListType = targetProperty.PropertyType.GetGenericArguments().First();
            var targetList = Activator.CreateInstance(typeof(List<>).MakeGenericType(targetListType)) as System.Collections.IList;

            var mapper = mapping.Mapper;

            if (mapper != null)
            {
                Console.WriteLine("Directly map property list");
                var mapped = await MapPropertyValue(mapping, sourceValue, sourceBase);
                if (mapped != null && mapped.GetType().IsAssignableTo(targetProperty.PropertyType))
                {
                    targetProperty.SetValue(target, mapped);
                }
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
                Task.WaitAll(mapping.SubMappings.Select(m => MapProperty(sourceInstance, targetInstance, m, sourceInstance)).ToArray());

            }

            targetProperty.SetValue(target, targetList);
            return;
        }

        if (targetProperty.PropertyType.IsComplexType())
        {
            if(mapping.Mapper != null)
            {
                var mapped = await MapPropertyValue(mapping, sourceValue, sourceBase);
                if (mapped != null && mapped.GetType().IsAssignableTo(targetProperty.PropertyType))
                {
                    targetProperty.SetValue(target, mapped);
                }
                return;
            }

            var instance = Activator.CreateInstance(targetProperty.PropertyType);
            targetProperty.SetValue(target, instance);

            Task.WaitAll(mapping.SubMappings.Select(m => MapProperty(source, instance, m, sourceBase)).ToArray());

            return;
        }

        var mappedValue = await MapPropertyValue(mapping, sourceValue, sourceBase);
        if (mappedValue != null && mappedValue.GetType().IsAssignableTo(targetProperty.PropertyType))
        {
            targetProperty.SetValue(target, mappedValue);
        }
    }

    private async Task<object?> MapPropertyValue(IPropertyMapping propertyMapping, object? sourceValue, object? sourceBase)
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
        return mapper.Map(sourceValue, propertyMapping.MapperParameters, sourceBase);
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

    public object? Deserialize(Type type, string content)
    {
        var format = SerializedFormats.GetValueOrDefault(type);

        switch (format)
        {
            case SerializedFormat.Json:
                return DeserializeJson(type, content);
            case SerializedFormat.EdiFact:
                return DeserializeEdiFact(type, content);
            default:
                return null;
        }
    }

    public static object? DeserializeEdiFact(Type type, string content)
    {
        try
        {
            var grammar = EdiGrammar.NewEdiFact();

            using var reader = new StringReader(content);
            var result = new EdiSerializer().Deserialize(reader, grammar, type);
            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Failed to parse EDI: {e.Message}");
        }
        return null;
    }
    public static object? DeserializeJson(Type type, string content)
    {
        try
        {
            var result = JsonConvert.DeserializeObject(content, type);
            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Failed to parse JSON: {e.Message}");
        }
        return null;
    }

    public string Serialize(object? toSerialize)
    {
        if (toSerialize == null)
        {
            return string.Empty;
        }

        var type = toSerialize.GetType();
        var format = SerializedFormats.GetValueOrDefault(type);

        switch (format)
        {
            case SerializedFormat.Json:
                return SerializeJson(toSerialize);
            case SerializedFormat.EdiFact:
                return SerializeEdiFact(toSerialize);
            case SerializedFormat.Csv:
                return SerializeCsv(toSerialize);
            default:
                Console.WriteLine($"Unknown format {format}");
                return string.Empty;
        }
    }

    public static string SerializeEdiFact(object toSerialize)
    {
        try
        {
            var type = toSerialize.GetType();
            if (type.IsAssignableTo(typeof(IEdiFormat)))
            {
                (toSerialize as IEdiFormat)?.UpdateDerivedProperties();
            }

            var grammar = EdiGrammar.NewEdiFact();
            using var textWriter = new StringWriter();
            using var ediWriter = new EdiTextWriter(textWriter, grammar);
            new EdiSerializer().Serialize(ediWriter, toSerialize);
            return textWriter.ToString();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Failed to serialize EDI: {e.Message}");
        }

        return string.Empty;
    }

    public static string SerializeJson(object toSerialize)
    {
        try
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };
            return JsonConvert.SerializeObject(toSerialize, settings);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Failed to serialize JSON: {e.Message}");
        }
        return string.Empty;
    }
    public static string SerializeCsv(object toSerialize)
    {
        var type = toSerialize.GetType();
        if (!type.IsAssignableTo(typeof(ICsvFormat)))
        {
            return string.Empty;
        }

        try
        {
            var csvObject = toSerialize as ICsvFormat;
            var rows = csvObject?.Rows;
            if (rows == null || rows.Count() <= 0)
            {
                return string.Empty;
            }
            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
                Delimiter = ";"
            };

            using var writer = new StringWriter();
            using var csv = new CsvWriter(writer, configuration);
            csv.WriteRecords(rows);
            return writer.ToString();

        }
        catch (Exception e)
        {
            Console.WriteLine($"Failed to serialize CSV: {e.Message}");
        }
        return string.Empty;
    }
}
