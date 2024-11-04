using EDIFACTMediator.Formats.OrdersD96A;
using EDIFACTMediator.Utils;
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

        foreach (var item in Invoices)
        {
            item.MessageHeader.MessageTypeIdentifier = "INVOIC";

            item.ControlTotal = new ControlTotal
            {
                ControlQualifier = "2",
                ControlValue = item.LineItems.Count,
            };

            item.MessageTrailer.MessageReferenceNumber = item.MessageHeader.MessageReferenceNumber;
        }

        Trailer.InterchangeControlCount = Invoices.Count;
    }
}

[EdiMessage]
public class Invoice
{
    public MessageHeader MessageHeader { get; set; } = new MessageHeader(); // UNH segment

    public BeginningOfMessage BeginningOfMessage { get; set; } = new BeginningOfMessage(); // BGM segment

    public List<DateTimePeriodMessage> DateTimes { get; set; } = new List<DateTimePeriodMessage>(); // DTM segments

    public List<ReferenceMessage> References { get; set; } = new List<ReferenceMessage>(); // RFF segments

    public List<PartySegment> Parties { get; set; } = new List<PartySegment>(); // NAD segments

    public List<SegmentGroup7> Currencies { get; set; } = new List<SegmentGroup7>(); // CUX segments

    public List<SegmentGroup8> PaymentTerms { get; set; } = new List<SegmentGroup8>(); // PAT segments

    public List<SegmentGroup6> Taxes { get; set; } = new List<SegmentGroup6>(); // TAX-MOA-LOC segments

    public List<LineItemGroup> LineItems { get; set; } = new List<LineItemGroup>(); // LIN+ groups (line items)

    public ControlTotal ControlTotal { get; set; } = new ControlTotal(); // CNT segment

    [EdiSegment(Mandatory = true)]
    public SectionControl SectionControl { get; set; } = new SectionControl(); // UNS segment

    public MonetaryAmount InvoiceTotal { get; set; } = new MonetaryAmount(); // MOA segment

    public MessageTrailer MessageTrailer { get; set; } = new MessageTrailer(); // UNT segment
}

[EdiSegment, EdiPath("BGM")]
public class BeginningOfMessage
{
    [EdiValue("X(3)", Mandatory = true, Path = "BGM/0/0")]
    public string DocumentNameCoded { get; set; } = "380"; // Commercial invoice coded (380 in EDIFACT)

    [EdiValue("X(35)", Path = "BGM/1", Mandatory = true)]
    public string DocumentNumber { get; set; } // Invoice number

    [EdiValue("X(3)", Path = "BGM/2", Mandatory = false)]
    public string MessageFunction { get; set; } = "9"; // Original invoice (1225)
}

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

[EdiSegment, EdiPath("TAX")]
public class TaxDetails
{
    [EdiValue("X(3)", Path = "TAX/0/0", Mandatory = true)]
    public string DutyTaxFeeFunctionQualifier { get; set; } = "7"; // Tax information coded

    // Additional tax-related fields as required
}

[EdiSegment, EdiPath("MOA")]
public class MonetaryAmount
{
    [EdiValue("X(3)", Path = "MOA/0/0", Mandatory = true)]
    public string MonetaryAmountTypeQualifier { get; set; } // Total amount, tax amount, etc.

    [EdiValue("9(18)", Path = "MOA/0/1", Mandatory = true)]
    public decimal Amount { get; set; } // Amount value
}

