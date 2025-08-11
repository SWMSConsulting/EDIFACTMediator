using EDIFACTMediator.Formats.CommonD96A;
using EDIFACTMediator.Formats.OrdersD96A;
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
                    ControlQualifier = "11", // total number of packages
                    ControlValue = item.Packages.Count,
                };

                item.MessageTrailer.MessageReferenceNumber = item.MessageHeader.MessageReferenceNumber;

                if (item.DateTimes.FirstOrDefault(d => d.DateTimePeriodFunctionCode == "137") == null)
                {
                    item.DateTimes.Add(new DateTimePeriodMessage
                    {
                        DateTimePeriodFunctionCode = "137",
                        DateOfPreparation = DateTime.Now.ToString("yyyyMMdd"),
                        FormatQualifier = "102",
                    });
                }
                foreach (var package in item.Packages)
                {
                    var minItemNum = package.LineItems.Min(i => i.LineItemNumber);
                    if (minItemNum == null || minItemNum < 1)
                    {
                        var itemNumber = 1;
                        foreach (var lineItem in package.LineItems.OrderBy(i => i.LineItemNumber))
                        {
                            lineItem.LineItemNumber = itemNumber;
                            var reference = lineItem.References.FirstOrDefault(r => r.ReferenceQualifier == "LI");
                            if (reference != null) {
                                reference.ReferenceNumber = itemNumber.ToString();
                            }
                            itemNumber++;
                        }
                    }
                }

                foreach (var party in item.Parties)
                {
                    party.UpdateDerivedProperties();
                }
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

        public List<PartySegment> Parties { get; set; } = new List<PartySegment>(); // NAD segments 

        public List<TransportDetails> TransportDetails { get; set; } = new List<TransportDetails>(); // TDT segment group

        public List<PackageGroup> Packages { get; set; } = new List<PackageGroup>(); // CPS groups (package details)

        public SectionControl? SectionControl { get; set; } = null; // UNS segment

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

    
    [EdiSegmentGroup("CPS", SequenceEnd = "UNS")]
    public class PackageGroup
    {
        [EdiValue("9(1)", Path = "CPS/0", Mandatory = true)]
        public int? HierarchicalIdNumber { get; set; } // 7164

        [EdiValue("9(6)", Path = "CPS/1", Mandatory = false)]
        public int? HierarchicalParentId { get; set; } // 7166

        [EdiValue("X(3)", Path = "CPS/2", Mandatory = false)]
        public string? PackagingLevelCode { get; set; } // 7075

        public List<PackageDetails> PackageDetails { get; set; } = new List<PackageDetails>(); // PAC segments (package details)

        public List<PackageIdentification> PackageIdentification { get; set; } = new List<PackageIdentification>(); // PCI segments (package identifications)

        public List<LineItemGroupD96A> LineItems { get; set; } = new List<LineItemGroupD96A>(); // LIN+ groups (line items)

    }


    [EdiSegment, EdiPath("TDT")]
    public class TransportDetails
    {
        [EdiValue("X(3)", Path = "TDT/0", Mandatory = true)]
        public string TransportStageQualifier { get; set; } // 8051

        [EdiValue("X(17)", Path = "TDT/1", Mandatory = false)]
        public string ConveyanceReferenceNumber { get; set; } // 8028

        // C220 Composite
        [EdiValue("X(3)", Path = "TDT/2/0", Mandatory = false)]
        public string ModeOfTransportCoded { get; set; } // 8067

        [EdiValue("X(17)", Path = "TDT/2/1", Mandatory = false)]
        public string ModeOfTransport { get; set; } // 8066

        // C228 Composite
        [EdiValue("X(8)", Path = "TDT/3/0", Mandatory = false)]
        public string TypeOfMeansOfTransportIdentification { get; set; } // 8179

        [EdiValue("X(17)", Path = "TDT/3/1", Mandatory = false)]
        public string TypeOfMeansOfTransport { get; set; } // 8178

        // C040 Composite
        [EdiValue("X(17)", Path = "TDT/4/0", Mandatory = false)]
        public string CarrierIdentification { get; set; } // 3127

        [EdiValue("X(3)", Path = "TDT/4/1", Mandatory = false)]
        public string CarrierCodeListQualifier { get; set; } // 1131

        [EdiValue("X(3)", Path = "TDT/4/2", Mandatory = false)]
        public string CarrierCodeListResponsibleAgency { get; set; } // 3055

        [EdiValue("X(35)", Path = "TDT/4/3", Mandatory = false)]
        public string CarrierName { get; set; } // 3128

        [EdiValue("X(3)", Path = "TDT/5", Mandatory = false)]
        public string TransitDirectionCoded { get; set; } // 8101

        // C401 Composite
        [EdiValue("X(3)", Path = "TDT/6/0", Mandatory = true)]
        public string ExcessTransportationReasonCoded { get; set; } // 8457

        [EdiValue("X(3)", Path = "TDT/6/1", Mandatory = true)]
        public string ExcessTransportationResponsibilityCoded { get; set; } // 8459

        [EdiValue("X(17)", Path = "TDT/6/2", Mandatory = false)]
        public string CustomerAuthorizationNumber { get; set; } // 7130

        // C222 Composite
        [EdiValue("X(9)", Path = "TDT/7/0", Mandatory = false)]
        public string IdOfMeansOfTransportIdentification { get; set; } // 8213

        [EdiValue("X(3)", Path = "TDT/7/1", Mandatory = false)]
        public string MeansOfTransportCodeListQualifier { get; set; } // 1131

        [EdiValue("X(3)", Path = "TDT/7/2", Mandatory = false)]
        public string MeansOfTransportCodeListResponsibleAgency { get; set; } // 3055

        [EdiValue("X(35)", Path = "TDT/7/3", Mandatory = false)]
        public string IdOfTheMeansOfTransport { get; set; } // 8212

        [EdiValue("X(3)", Path = "TDT/7/4", Mandatory = false)]
        public string NationalityOfMeansOfTransportCoded { get; set; } // 8453

        [EdiValue("X(3)", Path = "TDT/8", Mandatory = false)]
        public string TransportOwnershipCoded { get; set; } // 8281
    }


    [EdiSegment, EdiPath("PCI")]
    public class PackageIdentification
    {
        [EdiValue("X(3)", Path = "PCI/0", Mandatory = false)]
        public string MarkingInstructionsCoded { get; set; } // 4233

        // C210 Composite
        [EdiValue("X(35)", Path = "PCI/1/0", Mandatory = true)]
        public string ShippingMarks1 { get; set; } // 7102

        [EdiValue("X(35)", Path = "PCI/1/1", Mandatory = false)]
        public string ShippingMarks2 { get; set; } // 7102

        [EdiValue("X(35)", Path = "PCI/1/2", Mandatory = false)]
        public string ShippingMarks3 { get; set; } // 7102

        [EdiValue("X(35)", Path = "PCI/1/3", Mandatory = false)]
        public string ShippingMarks4 { get; set; } // 7102

        [EdiValue("X(35)", Path = "PCI/1/4", Mandatory = false)]
        public string ShippingMarks5 { get; set; } // 7102

        [EdiValue("X(35)", Path = "PCI/1/5", Mandatory = false)]
        public string ShippingMarks6 { get; set; } // 7102

        [EdiValue("X(35)", Path = "PCI/1/6", Mandatory = false)]
        public string ShippingMarks7 { get; set; } // 7102

        [EdiValue("X(35)", Path = "PCI/1/7", Mandatory = false)]
        public string ShippingMarks8 { get; set; } // 7102

        [EdiValue("X(35)", Path = "PCI/1/8", Mandatory = false)]
        public string ShippingMarks9 { get; set; } // 7102

        [EdiValue("X(35)", Path = "PCI/1/9", Mandatory = false)]
        public string ShippingMarks10 { get; set; } // 7102

        [EdiValue("X(3)", Path = "PCI/2", Mandatory = false)]
        public string ContainerPackageStatusCoded { get; set; } // 8275

        // C827 Composite
        [EdiValue("X(3)", Path = "PCI/3/0", Mandatory = true)]
        public string TypeOfMarkingCoded { get; set; } // 7511

        [EdiValue("X(3)", Path = "PCI/3/1", Mandatory = false)]
        public string CodeListQualifier { get; set; } // 1131

        [EdiValue("X(3)", Path = "PCI/3/2", Mandatory = false)]
        public string CodeListResponsibleAgency { get; set; } // 3055
    }

}