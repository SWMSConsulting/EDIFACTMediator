using EDIFACTMediator.Formats.CommonD96A;
using EDIFACTMediator.Formats.OrdersD96A;
using indice.Edi.Serialization;

namespace EDIFACTMediator.Formats.OrderResponseD96A;

public class OrderResponseD96A : IEdiFormat
{
    public InterchangeHeader Header { get; set; } = new InterchangeHeader();

    public List<OrderResponse> OrderResponses { get; set; } = new List<OrderResponse>();

    public InterchangeTrailer Trailer { get; set; } = new InterchangeTrailer();

    public void UpdateDerivedProperties()
    {
        Header.ControlRef = "1";
        Header.SyntaxIdentifier = "UNOC";
        Header.SyntaxVersion = 3;

        Header.DateOfPreparation = DateTime.Now;

        foreach (var item in OrderResponses)
        {
            item.MessageHeader.MessageTypeIdentifier = "ORDRSP";
            item.MessageHeader.MessageReferenceNumber = "1";

            item.ControlTotal = new ControlTotal
            {
                ControlQualifier = "2",
                ControlValue = item.LineItems.Count,
            };
            item.MessageTrailer.MessageReferenceNumber = item.MessageHeader.MessageReferenceNumber;

            item.DateTimes.Insert(0, new DateTimePeriodMessage
            {
                DateTimePeriodFunctionCode = "137",
                DateOfPreparation = DateTime.Now.ToString("yyyyMMdd"),
                FormatQualifier = "102",
            });

            item.SectionControl = new SectionControl { 
                SectionIdentification = "S"
            };
        }

        Trailer.InterchangeControl = "1";
        Trailer.InterchangeControlCount = OrderResponses.Count;
    }
}

[EdiMessage]
public class OrderResponse
{
    public MessageHeader MessageHeader { get; set; } = new MessageHeader(); // UNH segment

    public BeginningOfMessage BeginningOfMessage { get; set; } = new BeginningOfMessage(); // BGM segment

    public List<DateTimePeriodMessage> DateTimes { get; set; } = new List<DateTimePeriodMessage>(); // DTM segments

    public List<ReferenceMessage> References { get; set; } = new List<ReferenceMessage>(); // RFF segments

    public List<PartySegment> Parties { get; set; } = new List<PartySegment>(); // NAD segments

    public List<Currencies> Currencies { get; set; } = new List<Currencies>(); // CUX segments

    //public List<SegmentGroup9> TransportDetails { get; set; } = new List<SegmentGroup9>(); // TDT segments

    public List<LineItemGroupD96A> LineItems { get; set; } = new List<LineItemGroupD96A>(); // LIN+ groups (line items)


    //[EdiSegment(Mandatory = true)]
    public SectionControl? SectionControl { get; set; } = null; // UNS segment

    public ControlTotal? ControlTotal { get; set; } = null;  // CNT segment

    public MessageTrailer MessageTrailer { get; set; } = new MessageTrailer(); // UNT segment
}

[EdiSegment, EdiPath("BGM")]
public class BeginningOfMessage
{
    [EdiValue("X(3)", Mandatory = true, Path = "BGM/0/0")]
    public string DocumentNameCoded { get; set; } = "231"; // Order response coded (231 in EDIFACT)

    [EdiValue("X(35)", Path = "BGM/1", Mandatory = true)]
    public string DocumentNumber { get; set; } // Order response number

    [EdiValue("X(3)", Path = "BGM/2", Mandatory = false)]
    public string MessageFunction { get; set; } = "29"; // Order acknowledgement (1225)
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
}
*/
