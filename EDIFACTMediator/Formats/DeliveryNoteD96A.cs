﻿using EDIFACTMediator.Formats.CommonD96A;
using EDIFACTMediator.Formats.InvoiceD96A;
using EDIFACTMediator.Formats.OrderResponseD96A;
using EDIFACTMediator.Utils;
using indice.Edi.Serialization;

namespace EDIFACTMediator.Formats.DeliveryNoteD96A
{

    public class DeliveryNoteD96A : IEdiFormat
    {
        public InterchangeHeader Header { get; set; } = new InterchangeHeader();

        public List<Delivery> Deliveries { get; set; } = new List<Delivery>();

        public InterchangeTrailer Trailer { get; set; } = new InterchangeTrailer();

        public void UpdateDerivedProperties()
        {
            Header.ControlRef = "1";
            Header.SyntaxIdentifier = "UNOC";
            Header.SyntaxVersion = 3;

            Header.DateOfPreparation = DateTime.Now;

            foreach (var item in Deliveries)
            {
                item.MessageHeader.MessageTypeIdentifier = "DESADV";
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
            Trailer.InterchangeControlCount = Deliveries.Count;
        }
    }

    [EdiMessage]
    public class Delivery
    {
        public MessageHeader MessageHeader { get; set; } = new MessageHeader(); // UNH segment

        public BeginningOfMessage BeginningOfMessage { get; set; } = new BeginningOfMessage(); // BGM segment

        public List<DateTimePeriodMessage> DateTimes { get; set; } = new List<DateTimePeriodMessage>(); // DTM segments

        public List<ReferenceMessage> References { get; set; } = new List<ReferenceMessage>(); // RFF segments

        //public List<SegmentGroup2> Parties { get; set; } = new List<SegmentGroup2>(); // NAD segments (shipper, consignee, etc.)

        //public List<SegmentGroup9> TransportDetails { get; set; } = new List<SegmentGroup9>(); // TDT segment group

        public List<LineItemGroupD96A> LineItems { get; set; } = new List<LineItemGroupD96A>(); // LIN+ groups (line items)

        [EdiSegment(Mandatory = true)]
        public SectionControl SectionControl { get; set; } = new SectionControl(); // UNS segment

        public ControlTotal ControlTotal { get; set; } = new ControlTotal(); // CNT segment

        public MessageTrailer MessageTrailer { get; set; } = new MessageTrailer(); // UNT segment
    }

    [EdiSegment, EdiPath("BGM")]
    public class BeginningOfMessage
    {
        [EdiValue("X(3)", Mandatory = true, Path = "BGM/0/0")]
        public string DocumentNameCoded { get; set; } = "351"; // Delivery note coded (351 in EDIFACT)

        [EdiValue("X(3)", Path = "BGM/0/1")]
        public string CodeListQualifier { get; set; } // Optional

        [EdiValue("X(3)", Path = "BGM/0/2")]
        public string CodelistResponsibleAgency { get; set; } = "9"; // UN/EDIFACT

        [EdiValue("X(35)", Path = "BGM/1")]
        public string DocumentNumber { get; set; } // Delivery note number

        [EdiValue("X(3)", Path = "BGM/2")]
        public string MessageFunction { get; set; } = "9"; // Original (1225)
    }

    /*
    [EdiSegmentGroup("LIN", SequenceEnd = "UNS")]
    public class LineItemGroup
    {
        public LineItem LineItem { get; set; } = new LineItem(); // LIN segment

        public List<ItemDescriptionMessage> ItemDescriptions { get; set; } = new List<ItemDescriptionMessage>(); // IMD segments

        public List<Quantity> Quantities { get; set; } = new List<Quantity>(); // QTY segment

        public List<DateTimePeriodMessage> DateTimePeriods { get; set; } = new List<DateTimePeriodMessage>(); // DTM segment

        public List<Package> Packages { get; set; } = new List<Package>(); // PAC segments (package details)
    }
    */
}