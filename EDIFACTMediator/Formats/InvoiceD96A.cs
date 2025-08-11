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

            item.MessageTrailer.MessageReferenceNumber = item.MessageHeader.MessageReferenceNumber;

            if(item.DateTimes.FirstOrDefault(d => d.DateTimePeriodFunctionCode == "137") == null)
            {
                item.DateTimes.Add(new DateTimePeriodMessage
                {
                    DateTimePeriodFunctionCode = "137",
                    DateOfPreparation = DateTime.Now.ToString("yyyyMMdd"),
                    FormatQualifier = "102",
                });
            }

            item.SectionControl = new SectionControl
            {
                SectionIdentification = "S"
            };

            if(item.ControlTotal != null)
            {
                item.ControlTotal.ControlValue = item.LineItems.Count;
            }

            var minItemNum = item.LineItems.Min(i => i.LineItemNumber);
            if (minItemNum == null || minItemNum < 1)
            {
                var itemNumber = 1;
                foreach (var lineItem in item.LineItems.OrderBy(i => i.LineItemNumber))
                {
                    lineItem.LineItemNumber = itemNumber;
                    var reference = lineItem.References.FirstOrDefault(r => r.ReferenceQualifier == "LI");
                    if (reference != null)
                    {
                        reference.ReferenceNumber = itemNumber.ToString();
                    }
                    itemNumber++;
                }
            }

            foreach (var party in item.Parties)
            {
                party.UpdateDerivedProperties();
            }
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

    public List<FreeTextMessage> FreeTexts { get; set; } = new List<FreeTextMessage>(); // FTX segments

    public List<ReferenceMessage> References { get; set; } = new List<ReferenceMessage>(); // RFF segments

    public List<PartySegment> Parties { get; set; } = new List<PartySegment>(); // NAD segments

    public List<Currencies> Currencies { get; set; } = new List<Currencies>(); // CUX segments

    public List<SegmentGroup8> PaymentTerms { get; set; } = new List<SegmentGroup8>(); // PAT segments

    public List<LineItemGroupD96A> LineItems { get; set; } = new List<LineItemGroupD96A>(); // LIN+ groups (line items)

    [EdiSegment(Mandatory = true)]
    public SectionControl SectionControl { get; set; } = new SectionControl(); // UNS segment

    public ControlTotal? ControlTotal { get; set; } = null; // CNT segment

    public List<MonetaryAmountD96A> MonetaryAmounts { get; set; } = new List<MonetaryAmountD96A>(); // MOA segment

    public List<TaxDetails> TaxDetails { get; set; } = new List<TaxDetails>(); // TAX+MOA+LOC segments

    public MessageTrailer MessageTrailer { get; set; } = new MessageTrailer(); // UNT segment
}



