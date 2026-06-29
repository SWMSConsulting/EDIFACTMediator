using EDIFACTMediator.Formats.CommonD96A;

namespace EDIFACTMediator.PropertyMapper;

public class GetItemCodeMapper : IPropertyMapper
{
    public IEnumerable<string> RequiredParameters => DefaultValues.Keys;
    public Dictionary<string, string> DefaultValues => new Dictionary<string, string> { { "ItemNumberTypeCoded", "" } };

    public object? Map(object? source, Dictionary<string, string> parameters, object? sourceBase)
    {
        if (source == null)
        {
            return null;
        }

        LineItemGroupD96A? sourceLineItem = source as LineItemGroupD96A;
        if (sourceLineItem == null)
        {
            return null;
        }

        var itemNumberTypeCoded = parameters.ContainsKey("ItemNumberTypeCoded") ? parameters["ItemNumberTypeCoded"] : null;
        if(string.IsNullOrEmpty(itemNumberTypeCoded))
        {
            itemNumberTypeCoded = null;
        }

        if (sourceLineItem.ItemNumberTypeCoded == itemNumberTypeCoded)
        {
            return sourceLineItem.ItemNumber;
        }

        return null;
    }
}
