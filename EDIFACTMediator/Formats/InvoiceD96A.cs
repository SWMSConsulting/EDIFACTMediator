using EDIFACTMediator.Formats.CommonD96A;
using EDIFACTMediator.Formats.OrdersD96A;
using indice.Edi.Serialization;

namespace EDIFACTMediator.Formats.InvoiceD96A;

public class InvoiceD96A : IEdiFormat
{
    public InterchangeHeader Header { get; set; } = new InterchangeHeader();

    public List<Invoice> Invoices { get; set; } = new List<Invoice>();

    public InterchangeTrailer Trailer { get; set; } = new InterchangeTrailer();

    public void UpdateDerivedProperties()
    {
        Header.ControlRef = "1";
        Header.SyntaxIdentifier = "UNOC";
        Header.SyntaxVersion = 3;

        Header.DateOfPreparation = DateTime.Now;

        foreach (var item in Invoices)
        {
            item.MessageHeader.MessageTypeIdentifier = "INVOIC";
            item.MessageHeader.MessageReferenceNumber = "1";

            item.ControlTotal = new ControlTotal
            {
                ControlQualifier = "2",
                ControlValue = item.LineItems.Count,
            };

            item.MessageTrailer.MessageReferenceNumber = item.MessageHeader.MessageReferenceNumber;

            item.DateTimes.Add(new DateTimePeriodMessage
            {
                DateTimePeriodFunctionCode = "137",
                DateOfPreparation = DateTime.Now.ToString("yyyyMMdd"),
                FormatQualifier = "102",
            });

            item.SectionControl = new SectionControl
            {
                SectionIdentification = "S"
            };
        }

        Trailer.InterchangeControl = "1";
        Trailer.InterchangeControlCount = Invoices.Count;
    }
}

[EdiMessage]
public class Invoice
{
    public MessageHeader MessageHeader { get; set; } = new MessageHeader(); // UNH segment

    public BeginningOfMessageD96A BeginningOfMessage { get; set; } = new BeginningOfMessageD96A(); // BGM segment

    public List<DateTimePeriodMessage> DateTimes { get; set; } = new List<DateTimePeriodMessage>(); // DTM segments

    public List<ReferenceMessage> References { get; set; } = new List<ReferenceMessage>(); // RFF segments

    public List<PartySegment> Parties { get; set; } = new List<PartySegment>(); // NAD segments

    public List<Currencies> Currencies { get; set; } = new List<Currencies>(); // CUX segments

    public List<SegmentGroup8> PaymentTerms { get; set; } = new List<SegmentGroup8>(); // PAT segments

    public List<SegmentGroup6> Taxes { get; set; } = new List<SegmentGroup6>(); // TAX-MOA-LOC segments

    public List<LineItemGroupD96A> LineItems { get; set; } = new List<LineItemGroupD96A>(); // LIN+ groups (line items)

    [EdiSegment(Mandatory = true)]
    public SectionControl SectionControl { get; set; } = new SectionControl(); // UNS segment

    public ControlTotal ControlTotal { get; set; } = new ControlTotal(); // CNT segment

    public List<MonetaryAmountD96A> MonetaryAmounts { get; set; } = new List<MonetaryAmountD96A>(); // MOA segment

    public MessageTrailer MessageTrailer { get; set; } = new MessageTrailer(); // UNT segment
}



/*
[EdiSegmentGroup("LIN", SequenceEnd = "UNS")]
public class LineItemGroup
{
    public LineItem LineItem { get; set; } = new LineItem(); // LIN segment

    public List<ItemDescriptionMessage> ItemDescriptions { get; set; } = new List<ItemDescriptionMessage>(); // IMD segments

    public List<Quantity> Quantities { get; set; } = new List<Quantity>(); // QTY segment

    public List<PriceDetails> PriceDetails { get; set; } = new List<PriceDetails>(); // PRI segment

    public List<DateTimePeriodMessage> DateTimePeriods { get; set; } = new List<DateTimePeriodMessage>(); // DTM segment

    public List<TaxDetails> TaxDetails { get; set; } = new List<TaxDetails>(); // TAX segment
}
*/

[EdiSegment, EdiPath("TAX")]
public class TaxDetails
{
    [EdiValue("X(3)", Path = "TAX/0/0", Mandatory = true)]
    public string DutyTaxFeeFunctionQualifier { get; set; } = "7"; // Tax information coded

    // Additional tax-related fields as required
}

