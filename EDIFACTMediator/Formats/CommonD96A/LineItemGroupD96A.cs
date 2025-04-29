using EDIFACTMediator.Formats.OrdersD96A;
using indice.Edi.Serialization;
namespace EDIFACTMediator.Formats.CommonD96A;

[EdiSegmentGroup("LIN", SequenceEnd = "UNS")]
public class LineItemGroupD96A
{
    [EdiValue("9(6)", Path = "LIN/0", Mandatory = false)]
    public int? LineItemNumber { get; set; } // 1082

    [EdiValue("X(3)", Path = "LIN/1", Mandatory = false)]
    public string? ActionRequestNotificationCoded { get; set; } // 1229

    // Composite Element (C212)
    [EdiValue("X(35)", Path = "LIN/2/0", Mandatory = false)]
    public string? ItemNumber { get; set; } // 7140

    [EdiValue("X(3)", Path = "LIN/2/1", Mandatory = false)]
    public string? ItemNumberTypeCoded { get; set; } // 7143


    public List<AdditionalProductIdD96A> AdditionalProductIds { get; set; } = new List<AdditionalProductIdD96A>();

    public List<ItemDescriptionMessage> ItemDescriptions { get; set; } = new List<ItemDescriptionMessage>(); // IMD segments

    public Quantity Quantity { get; set; } = new Quantity(); // QTY segment

    public List<DateTimePeriodMessage> DateTimePeriods { get; set; } = new List<DateTimePeriodMessage>(); // DTM segment

    public List<PackageDetails> Packages { get; set; } = new List<PackageDetails>(); // PAC segments (package details)

    public List<MonetaryAmountD96A> MonetaryAmounts { get; set; } = new List<MonetaryAmountD96A>(); // MOA segment

    public List<PriceDetailsD96A> PriceDetails { get; set; } = new List<PriceDetailsD96A>(); // PRI segment

    public List<TaxDetails> TaxDetails { get; set; } = new List<TaxDetails>(); // TAX segment

    public List<ReferenceMessage> References { get; set; } = new List<ReferenceMessage>();
}
