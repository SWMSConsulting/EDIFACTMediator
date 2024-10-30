using EDIFACTMediator.Formats;
using EDIFACTMediator.Formats.OrdersD96A;
using indice.Edi;
using Newtonsoft.Json;

namespace EDIFACTMediator.Services;

public static class FormatParserService
{
    public static T? Deserialize<T>(string ediString)
    {
        var result = default(T);
        try
        {
            var grammar = EdiGrammar.NewEdiFact();

            using var reader = new StringReader(ediString);
            result = new EdiSerializer().Deserialize<T>(reader, grammar);
            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Failed to parse EDI: {e.Message}");
        }
        try
        {
            result = JsonConvert.DeserializeObject<T>(ediString);
            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Failed to parse EDI: {e.Message}");
        }


        return result;
    }

    public static string Serialize(object? toSerialize)
    {
        var type = toSerialize?.GetType();
        if (toSerialize == null ||type == null)
        {
            return string.Empty;
        }

        if (type.IsAssignableTo(typeof(IEdiFormat)))
        {
            (toSerialize as IEdiFormat)?.UpdateDerivedProperties();

            var grammar = EdiGrammar.NewEdiFact();
            using var textWriter = new StringWriter();
            using var ediWriter = new EdiTextWriter(textWriter, grammar);
            new EdiSerializer().Serialize(ediWriter, toSerialize);
            return textWriter.ToString();
        }

        return JsonConvert.SerializeObject(toSerialize);
    }
}
