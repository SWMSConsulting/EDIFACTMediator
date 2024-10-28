using indice.Edi;

namespace EDIFACTMediator.Services;

public static class EdiParserService
{
    public static T? FromEdi<T>(string ediString)
    {
        try
        {
            var grammar = EdiGrammar.NewEdiFact();

            using var reader = new StringReader(ediString);
            var ediOrders = new EdiSerializer().Deserialize<T>(reader, grammar);
            return ediOrders;
        }
        catch (Exception e)
        {
            return default(T);
        }
    }
}
