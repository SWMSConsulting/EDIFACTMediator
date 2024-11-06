using indice.Edi.Serialization;
namespace EDIFACTMediator.Formats.CommonD96A;

[EdiSegmentGroup("LIN", SequenceEnd = "UNS")]
public class LineItemGroupD96A
{
    public LineItem LineItem { get; set; } = new LineItem(); // LIN segment

    public List<ItemDescriptionMessage> ItemDescriptions { get; set; } = new List<ItemDescriptionMessage>(); // IMD segments

    public List<Quantity> Quantities { get; set; } = new List<Quantity>(); // QTY segment

    public List<DateTimePeriodMessage> DateTimePeriods { get; set; } = new List<DateTimePeriodMessage>(); // DTM segment

    public List<Package> Packages { get; set; } = new List<Package>(); // PAC segments (package details)

    public List<PriceDetailsD96A> PriceDetails { get; set; } = new List<PriceDetailsD96A>(); // PRI segment

    public List<ReferenceMessage> References { get; set; } = new List<ReferenceMessage>();

    public List<AdditionalProductIdD96A> AdditionalProductIds { get; set; } = new List<AdditionalProductIdD96A>();
}
