using indice.Edi.Serialization;

namespace EDIFACTMediator
{
    public class OrdersD96A
    {
        public InterchangeHeader Header { get; set; } = new InterchangeHeader();
        public List<Order> Orders { get; set; } = new List<Order>();
        public InterchangeTrailer Trailer { get; set; } = new InterchangeTrailer();
    }

    public class Order
    {
        public MessageHeader MessageHeader { get; set; } = new MessageHeader(); // UNH segment
        public BeginningOfMessage BeginningOfMessage { get; set; } = new BeginningOfMessage(); // BGM segment
        public List<DateTimePeriodMessage> DateTimes { get; set; } = new List<DateTimePeriodMessage>(); // DTM segments

        public List<PaymentInstructionMessage> PaymentInstructions { get; set; } =
            new List<PaymentInstructionMessage>(); // PAI segments

        public List<AdditionalInformationMessage> AdditionalInformations { get; set; } =
            new List<AdditionalInformationMessage>(); // ALI segments

        public List<ItemDescriptionMessage> ItemDescriptions { get; set; } =
            new List<ItemDescriptionMessage>(); // IMD segments

        public List<FreeTextMessage> FreeTexts { get; set; } = new List<FreeTextMessage>(); // FTX segments
        public List<SegmentGroup1> References { get; set; } = new List<SegmentGroup1>(); // RFF-DTM segment group

        public List<SegmentGroup2> Parties { get; set; } =
            new List<SegmentGroup2>(); // NAD-LOC-FII-SG3-SG4-SG5 segment group

        public List<SegmentGroup6> Taxes { get; set; } = new List<SegmentGroup6>(); // TAX-MOA-LOC segment group
        public List<SegmentGroup7> Currencies { get; set; } = new List<SegmentGroup7>(); // CUX-PCD-DTM segment group

        public List<SegmentGroup8> PaymentTerms { get; set; } =
            new List<SegmentGroup8>(); // PAT-DTM-PCD-MOA segment group

        public List<SegmentGroup9> TransportDetails { get; set; } = new List<SegmentGroup9>(); // TDT-SG10 segment group
        public List<SegmentGroup11> DeliveryTerms { get; set; } = new List<SegmentGroup11>(); // TOD-LOC segment group

        public List<SegmentGroup12> PackagingDetails { get; set; } =
            new List<SegmentGroup12>(); // PAC-MEA-SG13 segment group

        public List<SegmentGroup15> SchedulingConditions { get; set; } =
            new List<SegmentGroup15>(); // SCC-FTX-RFF-SG16 segment group

        public List<SegmentGroup17> AdditionalPrices { get; set; } =
            new List<SegmentGroup17>(); // APR-DTM-RNG segment group

        public List<SegmentGroup18> AllowancesAndCharges { get; set; } =
            new List<SegmentGroup18>(); // ALC-ALI-DTM-SG19-SG20-SG21-SG22-SG23 segment group

        public List<SegmentGroup24> Regulations { get; set; } =
            new List<SegmentGroup24>(); // RCS-RFF-DTM-FTX segment group

        public List<SegmentGroup25> LineItems { get; set; } =
            new List<SegmentGroup25>(); // LIN-PIA-IMD-MEA-QTY-PCD-ALI-DTM-MOA-GIN-GIR-QVR-DOC-PAI-FTX-SG26-SG27-SG28-SG29-SG30-SG33-SG34-SG35-SG39-SG45-SG47-SG48-SG49-SG51-SG52 segment group

        public List<SegmentGroup54> AllowanceChargeSummaries { get; set; } =
            new List<SegmentGroup54>(); // ALC-ALI-MOA segment group

        public SectionControl SectionControl { get; set; } = new SectionControl(); // UNS segment
        public ControlTotal ControlTotal { get; set; } = new ControlTotal(); // CNT segment
        public MessageTrailer MessageTrailer { get; set; } = new MessageTrailer(); // UNT segment
    }

    [EdiSegment, EdiPath("UNB")]
    public class InterchangeHeader
    {
        //UNB

        //S0001
        [EdiValue("X(4)", Mandatory = true, Path = "UNB/0")]
        public string SyntaxIdentifier { get; set; }

        [EdiValue("9(1)", Path = "UNB/0/1", Mandatory = true)]
        public int SyntaxVersion { get; set; }

        //S0002

        [EdiValue("X(35)", Path = "UNB/1/0", Mandatory = true)]
        public string SenderId { get; set; }

        //S003
        [EdiValue("X(35)", Path = "UNB/2/0", Mandatory = true)]
        public string RecipientId { get; set; }

        [EdiValue("X(4)", Path = "UNB/2/1", Mandatory = true)]
        public string ParterIDCode { get; set; }


        //S004

        [EdiValue("9(6)", Path = "UNB/3/0", Format = "ddMMyy", Description = "Date of Preparation")]
        [EdiValue("9(4)", Path = "UNB/3/1", Format = "HHmm", Description = "Time or Prep")]
        public DateTime DateOfPreparation { get; set; }

        //S005

        [EdiValue("X(14)", Path = "UNB/4", Mandatory = true)]
        public string ControlRef { get; set; }
    }


    [EdiSegment]
    public class InterchangeTrailer
    {
        [EdiValue("9(6)", Path = "UNZ/0", Mandatory = true)]
        public int InterchangeControlCount { get; set; }

        [EdiValue("X(14)", Path = "UNZ/1", Mandatory = true)]
        public string InterchangeControl { get; set; }
    }

    [EdiSegment, EdiPath("UNH")]
    public class MessageHeader
    {
        // UNH
        [EdiValue("X(14)", Mandatory = true, Path = "UNH/0")]
        public string MessageReferenceNumber { get; set; }

        // S009
        [EdiValue("X(6)", Path = "UNH/1/0", Mandatory = true)]
        public string MessageTypeIdentifier { get; set; } = "ORDERS"; // 0065

        [EdiValue("X(3)", Path = "UNH/1/1", Mandatory = true)]
        public string MessageTypeVersion { get; set; } = "D"; // 0052

        [EdiValue("X(3)", Path = "UNH/1/2", Mandatory = true)]
        public string MessageTypeRelease { get; set; } = "96A"; // 0054

        [EdiValue("X(2)", Path = "UNH/1/3", Mandatory = true)]
        public string ControllingAgency { get; set; } = "UN"; // 0051

        [EdiValue("X(3)", Path = "UNH/1/4", Mandatory = false)]
        public string AssociationAsignedCode { get; set; } = "EAN005";
    }

    [EdiSegment, EdiPath("DTM")]
    public class DateTimePeriodMessage
    {
        // DTM
        [EdiValue("X(3)", Path = "DTM/0/0", Mandatory = true)]
        public string DateTimePeriodFunctionCode { get; set; } = "137"; // 2005

        [EdiValue("9(6)", Path = "DTM/0/1", Format = "yyyyMMddHHmm", Description = "Date and Time of Preparation")]
        public DateTime DateOfPreparation { get; set; } = DateTime.Now; // 2380

        [EdiValue("X(3)", Path = "DTM/0/2")] public string FormatQualifier { get; set; } = "203"; // 2379
    }


    [EdiSegment, EdiPath("BGM")]
    public class BeginningOfMessage
    {
        // BGM

        [EdiValue("X(3)", Mandatory = true, Path = "BGM/0/0")]
        public string DocumentNameCoded { get; set; } = "610"; // 1001

        [EdiValue("X(3)", Mandatory = true, Path = "BGM/0/1")]
        public string CodeListQualifier { get; set; } // 1131

        [EdiValue("X(3)", Mandatory = true, Path = "BGM/0/2")]
        public string CodelistResponsibleAgency { get; set; } = "9"; // 3055

        [EdiValue("X(35)", Path = "BGM/0/3", Mandatory = false)]
        public string DocumentMessageName { get; set; } // 1000

        [EdiValue("X(35)", Path = "BGM/1", Mandatory = false)]
        public string DocumentNumber { get; set; } // 1004

        [EdiValue("X(3)", Path = "BGM/2", Mandatory = false)]
        public string MessageFunction { get; set; } = "9"; // 1225

        [EdiValue("X(3)", Path = "BGM/3", Mandatory = false)]
        public string ResponseTypeCoded { get; set; } // 4343 (optional, add if needed)
    }

    [EdiSegment, EdiPath("PAI")]
    public class PaymentInstructionMessage
    {
        // PAI
        [EdiValue("X(3)", Path = "PAI/0/0", Mandatory = false)]
        public string PaymentConditionsCoded { get; set; } // 4439

        [EdiValue("X(3)", Path = "PAI/0/1", Mandatory = false)]
        public string PaymentGuaranteeCoded { get; set; } // 4431

        [EdiValue("X(3)", Path = "PAI/0/2", Mandatory = false)]
        public string PaymentMeansCoded { get; set; } // 4461

        [EdiValue("X(3)", Path = "PAI/0/3", Mandatory = false)]
        public string CodeListQualifier { get; set; } // 1131

        [EdiValue("X(3)", Path = "PAI/0/4", Mandatory = false)]
        public string CodeListResponsibleAgencyCoded { get; set; } // 3055

        [EdiValue("X(3)", Path = "PAI/0/5", Mandatory = false)]
        public string PaymentChannelCoded { get; set; } // 4435
    }

    [EdiSegment, EdiPath("ALI")]
    public class AdditionalInformationMessage
    {
        // ALI
        [EdiValue("X(3)", Path = "ALI/0", Mandatory = false)]
        public string CountryOfOriginCoded { get; set; } // 3239

        [EdiValue("X(3)", Path = "ALI/1", Mandatory = false)]
        public string TypeOfDutyRegimeCoded { get; set; } // 9213

        [EdiValue("X(3)", Path = "ALI/2", Mandatory = false)]
        public string SpecialConditionsCoded1 { get; set; } // 4183 (1st occurrence)

        [EdiValue("X(3)", Path = "ALI/3", Mandatory = false)]
        public string SpecialConditionsCoded2 { get; set; } // 4183 (2nd occurrence)

        [EdiValue("X(3)", Path = "ALI/4", Mandatory = false)]
        public string SpecialConditionsCoded3 { get; set; } // 4183 (3rd occurrence)

        [EdiValue("X(3)", Path = "ALI/5", Mandatory = false)]
        public string SpecialConditionsCoded4 { get; set; } // 4183 (4th occurrence)

        [EdiValue("X(3)", Path = "ALI/6", Mandatory = false)]
        public string SpecialConditionsCoded5 { get; set; } // 4183 (5th occurrence)

        [EdiValue("X(3)", Path = "ALI/7", Mandatory = false)]
        public string SpecialConditionsCoded6 { get; set; } // 4183 (6th occurrence)
    }

    [EdiSegment, EdiPath("IMD")]
    public class ItemDescriptionMessage
    {
        // IMD
        [EdiValue("X(3)", Path = "IMD/0", Mandatory = false)]
        public string ItemDescriptionTypeCoded { get; set; } // 7077

        [EdiValue("X(3)", Path = "IMD/1", Mandatory = false)]
        public string ItemCharacteristicCoded { get; set; } // 7081

        // C273 Composite
        [EdiValue("X(17)", Path = "IMD/2/0", Mandatory = false)]
        public string ItemDescriptionIdentification { get; set; } // 7009

        [EdiValue("X(3)", Path = "IMD/2/1", Mandatory = false)]
        public string CodeListQualifier { get; set; } // 1131

        [EdiValue("X(3)", Path = "IMD/2/2", Mandatory = false)]
        public string CodeListResponsibleAgencyCoded { get; set; } // 3055

        [EdiValue("X(35)", Path = "IMD/2/3", Mandatory = false)]
        public string ItemDescription1 { get; set; } // 7008 (1st occurrence)

        [EdiValue("X(35)", Path = "IMD/2/4", Mandatory = false)]
        public string ItemDescription2 { get; set; } // 7008 (2nd occurrence)

        [EdiValue("X(3)", Path = "IMD/2/5", Mandatory = false)]
        public string LanguageCoded { get; set; } // 3453

        [EdiValue("X(3)", Path = "IMD/3", Mandatory = false)]
        public string SurfaceLayerIndicatorCoded { get; set; } // 7383
    }

    [EdiSegment, EdiPath("FTX")]
    public class FreeTextMessage
    {
        // FTX
        [EdiValue("X(3)", Path = "FTX/0", Mandatory = true)]
        public string TextSubjectQualifier { get; set; } // 4451

        [EdiValue("X(3)", Path = "FTX/1", Mandatory = false)]
        public string TextFunctionCoded { get; set; } // 4453

        // C107 Composite
        [EdiValue("X(3)", Path = "FTX/2/0", Mandatory = false)]
        public string FreeTextCoded { get; set; } // 4441

        [EdiValue("X(3)", Path = "FTX/2/1", Mandatory = false)]
        public string CodeListQualifier { get; set; } // 1131

        [EdiValue("X(3)", Path = "FTX/2/2", Mandatory = false)]
        public string CodeListResponsibleAgencyCoded { get; set; } // 3055

        // C108 Composite
        [EdiValue("X(70)", Path = "FTX/3/0", Mandatory = false)]
        public string FreeText1 { get; set; } // 4440 (1st occurrence)

        [EdiValue("X(70)", Path = "FTX/3/1", Mandatory = false)]
        public string FreeText2 { get; set; } // 4440 (2nd occurrence)

        [EdiValue("X(70)", Path = "FTX/3/2", Mandatory = false)]
        public string FreeText3 { get; set; } // 4440 (3rd occurrence)

        [EdiValue("X(70)", Path = "FTX/3/3", Mandatory = false)]
        public string FreeText4 { get; set; } // 4440 (4th occurrence)

        [EdiValue("X(70)", Path = "FTX/3/4", Mandatory = false)]
        public string FreeText5 { get; set; } // 4440 (5th occurrence)

        [EdiValue("X(3)", Path = "FTX/4", Mandatory = false)]
        public string LanguageCoded { get; set; } // 3453
    }

    [EdiSegment, EdiPath("RFF")]
    public class ReferenceMessage
    {
        // C506 Composite
        [EdiValue("X(3)", Path = "RFF/0/0", Mandatory = true)]
        public string ReferenceQualifier { get; set; } // 1153

        [EdiValue("X(35)", Path = "RFF/0/1", Mandatory = false)]
        public string ReferenceNumber { get; set; } // 1154

        [EdiValue("X(6)", Path = "RFF/0/2", Mandatory = false)]
        public string LineNumber { get; set; } // 1156

        [EdiValue("X(35)", Path = "RFF/0/3", Mandatory = false)]
        public string ReferenceVersionNumber { get; set; } // 4000
    }

    [EdiSegmentGroup("SG1", "RFF", "DTM")]
    public class SegmentGroup1
    {
        [EdiValue("X(35)", Path = "SG1/0")] public ReferenceMessage Reference { get; set; } // RFF segment

        [EdiValue("X(35)", Path = "SG1/1")] public DateTimePeriodMessage DateTimePeriod { get; set; } // DTM segment
    }

    [EdiSegment, EdiPath("NAD")]
    public class NameAndAddressMessage
    {
        [EdiValue("X(3)", Path = "NAD/0", Mandatory = true)]
        public string PartyQualifier { get; set; } // 3035

        // C082 Composite
        [EdiValue("X(35)", Path = "NAD/1/0", Mandatory = false)]
        public string PartyIdIdentification { get; set; } // 3039

        [EdiValue("X(3)", Path = "NAD/1/1", Mandatory = false)]
        public string CodeListQualifier { get; set; } // 1131

        [EdiValue("X(3)", Path = "NAD/1/2", Mandatory = false)]
        public string CodeListResponsibleAgency { get; set; } // 3055

        // C058 Composite
        [EdiValue("X(35)", Path = "NAD/2/0", Mandatory = false)]
        public string NameAndAddressLine1 { get; set; } // 3124

        [EdiValue("X(35)", Path = "NAD/2/1", Mandatory = false)]
        public string NameAndAddressLine2 { get; set; } // 3124

        [EdiValue("X(35)", Path = "NAD/2/2", Mandatory = false)]
        public string NameAndAddressLine3 { get; set; } // 3124

        [EdiValue("X(35)", Path = "NAD/2/3", Mandatory = false)]
        public string NameAndAddressLine4 { get; set; } // 3124

        [EdiValue("X(35)", Path = "NAD/2/4", Mandatory = false)]
        public string NameAndAddressLine5 { get; set; } // 3124

        // C080 Composite
        [EdiValue("X(35)", Path = "NAD/3/0", Mandatory = false)]
        public string PartyName1 { get; set; } // 3036

        [EdiValue("X(35)", Path = "NAD/3/1", Mandatory = false)]
        public string PartyName2 { get; set; } // 3036

        [EdiValue("X(35)", Path = "NAD/3/2", Mandatory = false)]
        public string PartyName3 { get; set; } // 3036

        [EdiValue("X(35)", Path = "NAD/3/3", Mandatory = false)]
        public string PartyName4 { get; set; } // 3036

        [EdiValue("X(35)", Path = "NAD/3/4", Mandatory = false)]
        public string PartyName5 { get; set; } // 3036

        [EdiValue("X(3)", Path = "NAD/3/5", Mandatory = false)]
        public string PartyNameFormatCoded { get; set; } // 3045

        // C059 Composite
        [EdiValue("X(35)", Path = "NAD/4/0", Mandatory = false)]
        public string StreetAndNumberPOBox1 { get; set; } // 3042

        [EdiValue("X(35)", Path = "NAD/4/1", Mandatory = false)]
        public string StreetAndNumberPOBox2 { get; set; } // 3042

        [EdiValue("X(35)", Path = "NAD/4/2", Mandatory = false)]
        public string StreetAndNumberPOBox3 { get; set; } // 3042

        [EdiValue("X(35)", Path = "NAD/4/3", Mandatory = false)]
        public string StreetAndNumberPOBox4 { get; set; } // 3042

        [EdiValue("X(35)", Path = "NAD/5", Mandatory = false)]
        public string CityName { get; set; } // 3164

        [EdiValue("X(9)", Path = "NAD/6", Mandatory = false)]
        public string CountrySubEntityIdentification { get; set; } // 3229

        [EdiValue("X(9)", Path = "NAD/7", Mandatory = false)]
        public string PostcodeIdentification { get; set; } // 3251

        [EdiValue("X(3)", Path = "NAD/8", Mandatory = false)]
        public string CountryCoded { get; set; } // 3207
    }

    [EdiSegment, EdiPath("LOC")]
    public class PlaceLocationIdentificationMessage
    {
        [EdiValue("X(3)", Path = "LOC/0", Mandatory = true)]
        public string PlaceLocationQualifier { get; set; } // 3227

        // C517 Composite
        [EdiValue("X(25)", Path = "LOC/1/0", Mandatory = false)]
        public string PlaceLocationIdentification { get; set; } // 3225

        [EdiValue("X(3)", Path = "LOC/1/1", Mandatory = false)]
        public string CodeListQualifier { get; set; } // 1131

        [EdiValue("X(3)", Path = "LOC/1/2", Mandatory = false)]
        public string CodeListResponsibleAgency { get; set; } // 3055

        [EdiValue("X(70)", Path = "LOC/1/3", Mandatory = false)]
        public string PlaceLocation { get; set; } // 3224

        // C519 Composite
        [EdiValue("X(25)", Path = "LOC/2/0", Mandatory = false)]
        public string RelatedPlaceLocationOneIdentification { get; set; } // 3223

        [EdiValue("X(3)", Path = "LOC/2/1", Mandatory = false)]
        public string RelatedPlaceLocationOneCodeListQualifier { get; set; } // 1131

        [EdiValue("X(3)", Path = "LOC/2/2", Mandatory = false)]
        public string RelatedPlaceLocationOneResponsibleAgency { get; set; } // 3055

        [EdiValue("X(70)", Path = "LOC/2/3", Mandatory = false)]
        public string RelatedPlaceLocationOne { get; set; } // 3222

        // C553 Composite
        [EdiValue("X(25)", Path = "LOC/3/0", Mandatory = false)]
        public string RelatedPlaceLocationTwoIdentification { get; set; } // 3233

        [EdiValue("X(3)", Path = "LOC/3/1", Mandatory = false)]
        public string RelatedPlaceLocationTwoCodeListQualifier { get; set; } // 1131

        [EdiValue("X(3)", Path = "LOC/3/2", Mandatory = false)]
        public string RelatedPlaceLocationTwoResponsibleAgency { get; set; } // 3055

        [EdiValue("X(70)", Path = "LOC/3/3", Mandatory = false)]
        public string RelatedPlaceLocationTwo { get; set; } // 3232

        [EdiValue("X(3)", Path = "LOC/4", Mandatory = false)]
        public string RelationCoded { get; set; } // 5479
    }

    [EdiSegment, EdiPath("FII")]
    public class FinancialInstitutionInformationMessage
    {
        [EdiValue("X(3)", Path = "FII/0", Mandatory = true)]
        public string PartyQualifier { get; set; } // 3035

        // C078 Composite
        [EdiValue("X(35)", Path = "FII/1/0", Mandatory = false)]
        public string AccountHolderNumber { get; set; } // 3194

        [EdiValue("X(35)", Path = "FII/1/1", Mandatory = false)]
        public string AccountHolderName1 { get; set; } // 3192

        [EdiValue("X(35)", Path = "FII/1/2", Mandatory = false)]
        public string AccountHolderName2 { get; set; } // 3192

        [EdiValue("X(3)", Path = "FII/1/3", Mandatory = false)]
        public string CurrencyCoded { get; set; } // 6345

        // C088 Composite
        [EdiValue("X(11)", Path = "FII/2/0", Mandatory = false)]
        public string InstitutionNameIdentification { get; set; } // 3433

        [EdiValue("X(3)", Path = "FII/2/1", Mandatory = false)]
        public string InstitutionCodeListQualifier { get; set; } // 1131

        [EdiValue("X(3)", Path = "FII/2/2", Mandatory = false)]
        public string InstitutionResponsibleAgency { get; set; } // 3055

        [EdiValue("X(17)", Path = "FII/2/3", Mandatory = false)]
        public string InstitutionBranchNumber { get; set; } // 3434

        [EdiValue("X(3)", Path = "FII/2/4", Mandatory = false)]
        public string InstitutionBranchCodeListQualifier { get; set; } // 1131

        [EdiValue("X(3)", Path = "FII/2/5", Mandatory = false)]
        public string InstitutionBranchResponsibleAgency { get; set; } // 3055

        [EdiValue("X(70)", Path = "FII/2/6", Mandatory = false)]
        public string InstitutionName { get; set; } // 3432

        [EdiValue("X(70)", Path = "FII/2/7", Mandatory = false)]
        public string InstitutionBranchPlace { get; set; } // 3436

        [EdiValue("X(3)", Path = "FII/3", Mandatory = false)]
        public string CountryCoded { get; set; } // 3207
    }

    [EdiSegment, EdiPath("DOC")]
    public class DocumentMessageDetails
    {
        // C002 Composite
        [EdiValue("X(3)", Path = "DOC/0/0", Mandatory = false)]
        public string DocumentMessageNameCoded { get; set; } // 1001

        [EdiValue("X(3)", Path = "DOC/0/1", Mandatory = false)]
        public string CodeListQualifier { get; set; } // 1131

        [EdiValue("X(3)", Path = "DOC/0/2", Mandatory = false)]
        public string CodeListResponsibleAgency { get; set; } // 3055

        [EdiValue("X(35)", Path = "DOC/0/3", Mandatory = false)]
        public string DocumentMessageName { get; set; } // 1000

        // C503 Composite
        [EdiValue("X(35)", Path = "DOC/1/0", Mandatory = false)]
        public string DocumentMessageNumber { get; set; } // 1004

        [EdiValue("X(3)", Path = "DOC/1/1", Mandatory = false)]
        public string DocumentMessageStatusCoded { get; set; } // 1373

        [EdiValue("X(35)", Path = "DOC/1/2", Mandatory = false)]
        public string DocumentMessageSource { get; set; } // 1366

        [EdiValue("X(3)", Path = "DOC/1/3", Mandatory = false)]
        public string LanguageCoded { get; set; } // 3453

        [EdiValue("X(3)", Path = "DOC/2", Mandatory = false)]
        public string CommunicationChannelIdentifierCoded { get; set; } // 3153

        [EdiValue("9(2)", Path = "DOC/3", Mandatory = false)]
        public int NumberOfCopiesOfDocumentRequired { get; set; } // 1220

        [EdiValue("9(2)", Path = "DOC/4", Mandatory = false)]
        public int NumberOfOriginalsOfDocumentRequired { get; set; } // 1218
    }

    [EdiSegment, EdiPath("CTA")]
    public class ContactInformation
    {
        [EdiValue("X(3)", Path = "CTA/0", Mandatory = false)]
        public string ContactFunctionCoded { get; set; } // 3139

        // C056 Composite
        [EdiValue("X(17)", Path = "CTA/1/0", Mandatory = false)]
        public string DepartmentOrEmployeeIdentification { get; set; } // 3413

        [EdiValue("X(35)", Path = "CTA/1/1", Mandatory = false)]
        public string DepartmentOrEmployee { get; set; } // 3412
    }

    [EdiSegment, EdiPath("COM")]
    public class CommunicationContact
    {
        // C076 Composite
        [EdiValue("X(512)", Path = "COM/0/0", Mandatory = true)]
        public string CommunicationNumber { get; set; } // 3148

        [EdiValue("X(3)", Path = "COM/0/1", Mandatory = true)]
        public string CommunicationChannelQualifier { get; set; } // 3155
    }

    [EdiSegmentGroup("SG36", "RFF", "DTM")]
    public class SegmentGroup36
    {
        [EdiValue("X(35)", Path = "SG36/0")] public ReferenceMessage Reference { get; set; } // RFF segment

        [EdiValue("X(35)", Path = "SG36/1", Mandatory = false)]
        public DateTimePeriodMessage DateTimePeriod { get; set; } // DTM segment
    }

    [EdiSegmentGroup("SG37", "DOC", "DTM")]
    public class SegmentGroup37
    {
        [EdiValue("X(35)", Path = "SG37/0")] public DocumentMessageDetails Document { get; set; } // DOC segment

        [EdiValue("X(35)", Path = "SG37/1", Mandatory = false)]
        public DateTimePeriodMessage DateTimePeriod { get; set; } // DTM segment
    }


    [EdiSegmentGroup("SG38", "CTA", "COM")]
    public class SegmentGroup38
    {
        [EdiValue("X(35)", Path = "SG38/0")] public ContactInformation ContactInformation { get; set; } // CTA segment

        [EdiValue("X(35)", Path = "SG38/1", Mandatory = false)]
        public CommunicationContact CommunicationContact { get; set; } // COM segment
    }


    [EdiSegmentGroup("SG35", "NAD", "LOC", "SG36", "SG37", "SG38")]
    public class SegmentGroup35
    {
        [EdiValue("X(35)", Path = "SG35/0")] public NameAndAddressMessage NameAndAddress { get; set; } // NAD segment

        [EdiValue("X(35)", Path = "SG35/1", Mandatory = false)]
        public PlaceLocationIdentificationMessage PlaceLocationIdentification { get; set; } // LOC segment

        [EdiValue("X(35)", Path = "SG35/2", Mandatory = false)]
        public SegmentGroup36 ReferenceDateTimePeriod { get; set; } // SG36

        [EdiValue("X(35)", Path = "SG35/3", Mandatory = false)]
        public SegmentGroup37 DocumentDateTimePeriod { get; set; } // SG37

        [EdiValue("X(35)", Path = "SG35/4", Mandatory = false)]
        public SegmentGroup38 ContactCommunication { get; set; } // SG38
    }

    [EdiSegmentGroup("SG3", "RFF", "DTM")]
    public class SegmentGroup3
    {
        [EdiValue("X(35)", Path = "SG3/0")] public ReferenceMessage Reference { get; set; } // RFF segment

        [EdiValue("X(35)", Path = "SG3/1", Mandatory = false)]
        public DateTimePeriodMessage DateTimePeriod { get; set; } // DTM segment
    }

    [EdiSegmentGroup("SG4", "DOC", "DTM")]
    public class SegmentGroup4
    {
        [EdiValue("X(35)", Path = "SG4/0")] public DocumentMessageDetails Document { get; set; } // DOC segment

        [EdiValue("X(35)", Path = "SG4/1", Mandatory = false)]
        public DateTimePeriodMessage DateTimePeriod { get; set; } // DTM segment
    }

    [EdiSegmentGroup("SG5", "CTA", "COM")]
    public class SegmentGroup5
    {
        [EdiValue("X(35)", Path = "SG5/0")] public ContactInformation ContactInformation { get; set; } // CTA segment

        [EdiValue("X(35)", Path = "SG5/1", Mandatory = false)]
        public CommunicationContact CommunicationContact { get; set; } // COM segment
    }

    [EdiSegmentGroup("SG2", "NAD", "LOC", "FII", "SG3", "SG4", "SG5")]
    public class SegmentGroup2
    {
        [EdiValue("X(35)", Path = "SG2/0")] public NameAndAddressMessage NameAndAddress { get; set; } // NAD segment

        [EdiValue("X(35)", Path = "SG2/1", Mandatory = false)]
        public PlaceLocationIdentificationMessage PlaceLocationIdentification { get; set; } // LOC segment

        [EdiValue("X(35)", Path = "SG2/2", Mandatory = false)]
        public FinancialInstitutionInformationMessage FinancialInstitutionInformation { get; set; } // FII segment

        [EdiValue("X(35)", Path = "SG2/3", Mandatory = false)]
        public SegmentGroup3 ReferenceDateTimePeriod { get; set; } // SG3

        [EdiValue("X(35)", Path = "SG2/4", Mandatory = false)]
        public SegmentGroup4 DocumentDateTimePeriod { get; set; } // SG4

        [EdiValue("X(35)", Path = "SG2/5", Mandatory = false)]
        public SegmentGroup5 ContactCommunication { get; set; } // SG5
    }

    [EdiSegment, EdiPath("TAX")]
    public class DutyTaxFeeDetails
    {
        [EdiValue("X(3)", Path = "TAX/0", Mandatory = true)]
        public string DutyTaxFeeFunctionQualifier { get; set; } // 5283

        // C241 Composite
        [EdiValue("X(3)", Path = "TAX/1/0", Mandatory = false)]
        public string DutyTaxFeeTypeCoded { get; set; } // 5153

        [EdiValue("X(3)", Path = "TAX/1/1", Mandatory = false)]
        public string CodeListQualifier { get; set; } // 1131

        [EdiValue("X(3)", Path = "TAX/1/2", Mandatory = false)]
        public string CodeListResponsibleAgency { get; set; } // 3055

        [EdiValue("X(35)", Path = "TAX/1/3", Mandatory = false)]
        public string DutyTaxFeeType { get; set; } // 5152

        // C533 Composite
        [EdiValue("X(6)", Path = "TAX/2/0", Mandatory = true)]
        public string DutyTaxFeeAccountIdentification { get; set; } // 5289

        [EdiValue("X(3)", Path = "TAX/2/1", Mandatory = false)]
        public string DutyTaxFeeAccountCodeListQualifier { get; set; } // 1131

        [EdiValue("X(3)", Path = "TAX/2/2", Mandatory = false)]
        public string DutyTaxFeeAccountCodeListResponsibleAgency { get; set; } // 3055

        [EdiValue("X(15)", Path = "TAX/3", Mandatory = false)]
        public string DutyTaxFeeAssessmentBasis { get; set; } // 5286

        // C243 Composite
        [EdiValue("X(7)", Path = "TAX/4/0", Mandatory = false)]
        public string DutyTaxFeeRateIdentification { get; set; } // 5279

        [EdiValue("X(3)", Path = "TAX/4/1", Mandatory = false)]
        public string DutyTaxFeeRateCodeListQualifier { get; set; } // 1131

        [EdiValue("X(3)", Path = "TAX/4/2", Mandatory = false)]
        public string DutyTaxFeeRateCodeListResponsibleAgency { get; set; } // 3055

        [EdiValue("X(17)", Path = "TAX/4/3", Mandatory = false)]
        public string DutyTaxFeeRate { get; set; } // 5278

        [EdiValue("X(12)", Path = "TAX/4/4", Mandatory = false)]
        public string DutyTaxFeeRateBasisIdentification { get; set; } // 5273

        [EdiValue("X(3)", Path = "TAX/4/5", Mandatory = false)]
        public string DutyTaxFeeRateBasisCodeListQualifier { get; set; } // 1131

        [EdiValue("X(3)", Path = "TAX/4/6", Mandatory = false)]
        public string DutyTaxFeeRateBasisCodeListResponsibleAgency { get; set; } // 3055

        [EdiValue("X(3)", Path = "TAX/5", Mandatory = false)]
        public string DutyTaxFeeCategoryCoded { get; set; } // 5305

        [EdiValue("X(20)", Path = "TAX/6", Mandatory = false)]
        public string PartyTaxIdentificationNumber { get; set; } // 3446
    }

    [EdiSegment, EdiPath("MOA")]
    public class MonetaryAmount
    {
        // C516 Composite
        [EdiValue("X(3)", Path = "MOA/0/0", Mandatory = true)]
        public string MonetaryAmountTypeQualifier { get; set; } // 5025

        [EdiValue("9(18)", Path = "MOA/0/1", Mandatory = false)]
        public decimal MonetaryAmountValue { get; set; } // 5004

        [EdiValue("X(3)", Path = "MOA/0/2", Mandatory = false)]
        public string CurrencyCoded { get; set; } // 6345

        [EdiValue("X(3)", Path = "MOA/0/3", Mandatory = false)]
        public string CurrencyQualifier { get; set; } // 6343

        [EdiValue("X(3)", Path = "MOA/0/4", Mandatory = false)]
        public string StatusCoded { get; set; } // 4405
    }

    [EdiSegmentGroup("SG6", "TAX", "MOA", "LOC")]
    public class SegmentGroup6
    {
        [EdiValue("X(35)", Path = "SG6/0")] public DutyTaxFeeDetails Tax { get; set; } // TAX segment

        [EdiValue("X(35)", Path = "SG6/1", Mandatory = false)]
        public MonetaryAmount MonetaryAmount { get; set; } // MOA segment

        [EdiValue("X(35)", Path = "SG6/2", Mandatory = false)]
        public PlaceLocationIdentificationMessage PlaceLocationIdentification { get; set; } // LOC segment
    }

    [EdiSegment, EdiPath("CUX")]
    public class Currencies
    {
        // First C504 Composite
        [EdiValue("X(3)", Path = "CUX/0/0", Mandatory = true)]
        public string CurrencyDetailsQualifier1 { get; set; } // 6347

        [EdiValue("X(3)", Path = "CUX/0/1", Mandatory = false)]
        public string CurrencyCoded1 { get; set; } // 6345

        [EdiValue("X(3)", Path = "CUX/0/2", Mandatory = false)]
        public string CurrencyQualifier1 { get; set; } // 6343

        [EdiValue("9(4)", Path = "CUX/0/3", Mandatory = false)]
        public int CurrencyRateBase1 { get; set; } // 6348

        // Second C504 Composite
        [EdiValue("X(3)", Path = "CUX/1/0", Mandatory = true)]
        public string CurrencyDetailsQualifier2 { get; set; } // 6347

        [EdiValue("X(3)", Path = "CUX/1/1", Mandatory = false)]
        public string CurrencyCoded2 { get; set; } // 6345

        [EdiValue("X(3)", Path = "CUX/1/2", Mandatory = false)]
        public string CurrencyQualifier2 { get; set; } // 6343

        [EdiValue("9(4)", Path = "CUX/1/3", Mandatory = false)]
        public int CurrencyRateBase2 { get; set; } // 6348

        [EdiValue("9(12)", Path = "CUX/2", Mandatory = false)]
        public decimal RateOfExchange { get; set; } // 5402

        [EdiValue("X(3)", Path = "CUX/3", Mandatory = false)]
        public string CurrencyMarketExchangeCoded { get; set; } // 6341
    }

    [EdiSegment, EdiPath("PCD")]
    public class PercentageDetails
    {
        // C501 Composite
        [EdiValue("X(3)", Path = "PCD/0/0", Mandatory = true)]
        public string PercentageQualifier { get; set; } // 5245

        [EdiValue("9(10)", Path = "PCD/0/1", Mandatory = false)]
        public decimal Percentage { get; set; } // 5482

        [EdiValue("X(3)", Path = "PCD/0/2", Mandatory = false)]
        public string PercentageBasisCoded { get; set; } // 5249

        [EdiValue("X(3)", Path = "PCD/0/3", Mandatory = false)]
        public string CodeListQualifier { get; set; } // 1131

        [EdiValue("X(3)", Path = "PCD/0/4", Mandatory = false)]
        public string CodeListResponsibleAgencyCoded { get; set; } // 3055
    }

    [EdiSegmentGroup("SG7", "CUX", "PCD", "DTM")]
    public class SegmentGroup7
    {
        [EdiValue("X(35)", Path = "SG7/0")] public Currencies Currencies { get; set; } // CUX segment

        [EdiValue("X(35)", Path = "SG7/1", Mandatory = false)]
        public PercentageDetails PercentageDetails { get; set; } // PCD segment

        [EdiValue("X(35)", Path = "SG7/2", Mandatory = false)]
        public DateTimePeriodMessage DateTimePeriod { get; set; } // DTM segment
    }

    [EdiSegment, EdiPath("PAT")]
    public class PaymentTermsBasis
    {
        [EdiValue("X(3)", Path = "PAT/0", Mandatory = true)]
        public string PaymentTermsTypeQualifier { get; set; } // 4279

        // C110 Composite
        [EdiValue("X(17)", Path = "PAT/1/0", Mandatory = true)]
        public string TermsOfPaymentIdentification { get; set; } // 4277

        [EdiValue("X(3)", Path = "PAT/1/1", Mandatory = false)]
        public string CodeListQualifier { get; set; } // 1131

        [EdiValue("X(3)", Path = "PAT/1/2", Mandatory = false)]
        public string CodeListResponsibleAgency { get; set; } // 3055

        [EdiValue("X(35)", Path = "PAT/1/3", Mandatory = false)]
        public string TermsOfPayment1 { get; set; } // 4276

        [EdiValue("X(35)", Path = "PAT/1/4", Mandatory = false)]
        public string TermsOfPayment2 { get; set; } // 4276

        // C112 Composite
        [EdiValue("X(3)", Path = "PAT/2/0", Mandatory = true)]
        public string PaymentTimeReferenceCoded { get; set; } // 2475

        [EdiValue("X(3)", Path = "PAT/2/1", Mandatory = false)]
        public string TimeRelationCoded { get; set; } // 2009

        [EdiValue("X(3)", Path = "PAT/2/2", Mandatory = false)]
        public string TypeOfPeriodCoded { get; set; } // 2151

        [EdiValue("9(3)", Path = "PAT/2/3", Mandatory = false)]
        public int NumberOfPeriods { get; set; } // 2152
    }

    [EdiSegmentGroup("SG8", "PAT", "DTM", "PCD", "MOA")]
    public class SegmentGroup8
    {
        [EdiValue("X(35)", Path = "SG8/0")] public PaymentTermsBasis PaymentTermsBasis { get; set; } // PAT segment

        [EdiValue("X(35)", Path = "SG8/1", Mandatory = false)]
        public DateTimePeriodMessage DateTimePeriod { get; set; } // DTM segment

        [EdiValue("X(35)", Path = "SG8/2", Mandatory = false)]
        public PercentageDetails PercentageDetails { get; set; } // PCD segment

        [EdiValue("X(35)", Path = "SG8/3", Mandatory = false)]
        public MonetaryAmount MonetaryAmount { get; set; } // MOA segment
    }

    [EdiSegment, EdiPath("TDT")]
    public class DetailsOfTransport
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

    [EdiSegmentGroup("SG9", "TDT", "SG10")]
    public class SegmentGroup9
    {
        [EdiValue("X(35)", Path = "SG9/0")] public DetailsOfTransport DetailsOfTransport { get; set; } // TDT segment

        [EdiValue("X(35)", Path = "SG9/1", Mandatory = false)]
        public SegmentGroup10 LocationDateTime { get; set; } // SG10 segment group
    }

    [EdiSegmentGroup("SG10", "LOC", "DTM")]
    public class SegmentGroup10
    {
        [EdiValue("X(35)", Path = "SG10/0")]
        public PlaceLocationIdentificationMessage PlaceLocationIdentification { get; set; } // LOC segment

        [EdiValue("X(35)", Path = "SG10/1", Mandatory = false)]
        public DateTimePeriodMessage DateTimePeriod { get; set; } // DTM segment
    }

    [EdiSegment, EdiPath("TOD")]
    public class TermsOfDeliveryOrTransport
    {
        [EdiValue("X(3)", Path = "TOD/0", Mandatory = false)]
        public string TermsOfDeliveryOrTransportFunctionCoded { get; set; } // 4055

        [EdiValue("X(3)", Path = "TOD/1", Mandatory = false)]
        public string TransportChargesMethodOfPaymentCoded { get; set; } // 4215

        // C100 Composite
        [EdiValue("X(3)", Path = "TOD/2/0", Mandatory = false)]
        public string TermsOfDeliveryOrTransportCoded { get; set; } // 4053

        [EdiValue("X(3)", Path = "TOD/2/1", Mandatory = false)]
        public string CodeListQualifier { get; set; } // 1131

        [EdiValue("X(3)", Path = "TOD/2/2", Mandatory = false)]
        public string CodeListResponsibleAgency { get; set; } // 3055

        [EdiValue("X(70)", Path = "TOD/2/3", Mandatory = false)]
        public string TermsOfDeliveryOrTransport1 { get; set; } // 4052

        [EdiValue("X(70)", Path = "TOD/2/4", Mandatory = false)]
        public string TermsOfDeliveryOrTransport2 { get; set; } // 4052
    }

    [EdiSegmentGroup("SG11", "TOD", "LOC")]
    public class SegmentGroup11
    {
        [EdiValue("X(35)", Path = "SG11/0")]
        public TermsOfDeliveryOrTransport TermsOfDeliveryOrTransport { get; set; } // TOD segment

        [EdiValue("X(35)", Path = "SG11/1", Mandatory = false)]
        public PlaceLocationIdentificationMessage PlaceLocationIdentification { get; set; } // LOC segment
    }

    [EdiSegment, EdiPath("PAC")]
    public class Package
    {
        [EdiValue("9(8)", Path = "PAC/0", Mandatory = false)]
        public int NumberOfPackages { get; set; } // 7224

        // C531 Composite
        [EdiValue("X(3)", Path = "PAC/1/0", Mandatory = false)]
        public string PackagingLevelCoded { get; set; } // 7075

        [EdiValue("X(3)", Path = "PAC/1/1", Mandatory = false)]
        public string PackagingRelatedInformationCoded { get; set; } // 7233

        [EdiValue("X(3)", Path = "PAC/1/2", Mandatory = false)]
        public string PackagingTermsAndConditionsCoded { get; set; } // 7073

        // C202 Composite
        [EdiValue("X(17)", Path = "PAC/2/0", Mandatory = false)]
        public string TypeOfPackagesIdentification { get; set; } // 7065

        [EdiValue("X(3)", Path = "PAC/2/1", Mandatory = false)]
        public string TypeOfPackagesCodeListQualifier { get; set; } // 1131

        [EdiValue("X(3)", Path = "PAC/2/2", Mandatory = false)]
        public string TypeOfPackagesCodeListResponsibleAgency { get; set; } // 3055

        [EdiValue("X(35)", Path = "PAC/2/3", Mandatory = false)]
        public string TypeOfPackages { get; set; } // 7064

        // C402 Composite
        [EdiValue("X(3)", Path = "PAC/3/0", Mandatory = true)]
        public string ItemDescriptionTypeCoded { get; set; } // 7077

        [EdiValue("X(35)", Path = "PAC/3/1", Mandatory = true)]
        public string TypeOfPackagesDescription1 { get; set; } // 7064

        [EdiValue("X(3)", Path = "PAC/3/2", Mandatory = false)]
        public string ItemNumberTypeCoded1 { get; set; } // 7143

        [EdiValue("X(35)", Path = "PAC/3/3", Mandatory = false)]
        public string TypeOfPackagesDescription2 { get; set; } // 7064

        [EdiValue("X(3)", Path = "PAC/3/4", Mandatory = false)]
        public string ItemNumberTypeCoded2 { get; set; } // 7143

        // C532 Composite
        [EdiValue("X(3)", Path = "PAC/4/0", Mandatory = false)]
        public string ReturnablePackageFreightPaymentResponsibilityCoded { get; set; } // 8395

        [EdiValue("X(3)", Path = "PAC/4/1", Mandatory = false)]
        public string ReturnablePackageLoadContentsCoded { get; set; } // 8393
    }

    [EdiSegment, EdiPath("MEA")]
    public class Measurements
    {
        [EdiValue("X(3)", Path = "MEA/0", Mandatory = true)]
        public string MeasurementApplicationQualifier { get; set; } // 6311

        // C502 Composite
        [EdiValue("X(3)", Path = "MEA/1/0", Mandatory = false)]
        public string MeasurementDimensionCoded { get; set; } // 6313

        [EdiValue("X(3)", Path = "MEA/1/1", Mandatory = false)]
        public string MeasurementSignificanceCoded { get; set; } // 6321

        [EdiValue("X(3)", Path = "MEA/1/2", Mandatory = false)]
        public string MeasurementAttributeCoded { get; set; } // 6155

        [EdiValue("X(70)", Path = "MEA/1/3", Mandatory = false)]
        public string MeasurementAttribute { get; set; } // 6154

        // C174 Composite
        [EdiValue("X(3)", Path = "MEA/2/0", Mandatory = true)]
        public string MeasureUnitQualifier { get; set; } // 6411

        [EdiValue("9(18)", Path = "MEA/2/1", Mandatory = false)]
        public decimal MeasurementValue { get; set; } // 6314

        [EdiValue("9(18)", Path = "MEA/2/2", Mandatory = false)]
        public decimal RangeMinimum { get; set; } // 6162

        [EdiValue("9(18)", Path = "MEA/2/3", Mandatory = false)]
        public decimal RangeMaximum { get; set; } // 6152

        [EdiValue("9(2)", Path = "MEA/2/4", Mandatory = false)]
        public int SignificantDigits { get; set; } // 6432

        [EdiValue("X(3)", Path = "MEA/3", Mandatory = false)]
        public string SurfaceLayerIndicatorCoded { get; set; } // 7383
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

    [EdiSegment, EdiPath("GIN")]
    public class GoodsIdentityNumber
    {
        [EdiValue("X(3)", Path = "GIN/0", Mandatory = true)]
        public string IdentityNumberQualifier { get; set; } // 7405

        // C208 Composite
        [EdiValue("X(35)", Path = "GIN/1/0", Mandatory = true)]
        public string IdentityNumber1 { get; set; } // 7402

        [EdiValue("X(35)", Path = "GIN/1/1", Mandatory = false)]
        public string IdentityNumber2 { get; set; } // 7402

        [EdiValue("X(35)", Path = "GIN/2/0", Mandatory = true)]
        public string IdentityNumber3 { get; set; } // 7402

        [EdiValue("X(35)", Path = "GIN/2/1", Mandatory = false)]
        public string IdentityNumber4 { get; set; } // 7402

        [EdiValue("X(35)", Path = "GIN/3/0", Mandatory = true)]
        public string IdentityNumber5 { get; set; } // 7402

        [EdiValue("X(35)", Path = "GIN/3/1", Mandatory = false)]
        public string IdentityNumber6 { get; set; } // 7402

        [EdiValue("X(35)", Path = "GIN/4/0", Mandatory = true)]
        public string IdentityNumber7 { get; set; } // 7402

        [EdiValue("X(35)", Path = "GIN/4/1", Mandatory = false)]
        public string IdentityNumber8 { get; set; } // 7402

        [EdiValue("X(35)", Path = "GIN/5/0", Mandatory = true)]
        public string IdentityNumber9 { get; set; } // 7402

        [EdiValue("X(35)", Path = "GIN/5/1", Mandatory = false)]
        public string IdentityNumber10 { get; set; } // 7402

        [EdiValue("X(35)", Path = "GIN/6/0", Mandatory = true)]
        public string IdentityNumber11 { get; set; } // 7402

        [EdiValue("X(35)", Path = "GIN/6/1", Mandatory = false)]
        public string IdentityNumber12 { get; set; } // 7402
    }

    [EdiSegmentGroup("SG13", "PCI", "RFF", "DTM", "GIN")]
    public class SegmentGroup13
    {
        [EdiValue("X(35)", Path = "SG13/0")]
        public PackageIdentification PackageIdentification { get; set; } // PCI segment

        [EdiValue("X(35)", Path = "SG13/1", Mandatory = false)]
        public ReferenceMessage Reference { get; set; } // RFF segment

        [EdiValue("X(35)", Path = "SG13/2", Mandatory = false)]
        public DateTimePeriodMessage DateTimePeriod { get; set; } // DTM segment

        [EdiValue("X(35)", Path = "SG13/3", Mandatory = false)]
        public GoodsIdentityNumber GoodsIdentityNumber { get; set; } // GIN segment
    }

    [EdiSegmentGroup("SG12", "PAC", "MEA", "SG13")]
    public class SegmentGroup12
    {
        [EdiValue("X(35)", Path = "SG12/0")] public Package Package { get; set; } // PAC segment

        [EdiValue("X(35)", Path = "SG12/1", Mandatory = false)]
        public Measurements Measurements { get; set; } // MEA segment

        [EdiValue("X(35)", Path = "SG12/2", Mandatory = false)]
        public SegmentGroup13 PackageIdentificationGroup { get; set; } // SG13 segment group
    }

    [EdiSegment, EdiPath("EQD")]
    public class EquipmentDetails
    {
        [EdiValue("X(3)", Path = "EQD/0", Mandatory = true)]
        public string EquipmentQualifier { get; set; } // 8053

        // C237 Composite
        [EdiValue("X(17)", Path = "EQD/1/0", Mandatory = false)]
        public string EquipmentIdentificationNumber { get; set; } // 8260

        [EdiValue("X(3)", Path = "EQD/1/1", Mandatory = false)]
        public string EquipmentCodeListQualifier { get; set; } // 1131

        [EdiValue("X(3)", Path = "EQD/1/2", Mandatory = false)]
        public string EquipmentCodeListResponsibleAgency { get; set; } // 3055

        [EdiValue("X(3)", Path = "EQD/1/3", Mandatory = false)]
        public string EquipmentCountryCoded { get; set; } // 3207

        // C224 Composite
        [EdiValue("X(10)", Path = "EQD/2/0", Mandatory = false)]
        public string EquipmentSizeAndTypeIdentification { get; set; } // 8155

        [EdiValue("X(3)", Path = "EQD/2/1", Mandatory = false)]
        public string EquipmentSizeAndTypeCodeListQualifier { get; set; } // 1131

        [EdiValue("X(3)", Path = "EQD/2/2", Mandatory = false)]
        public string EquipmentSizeAndTypeCodeListResponsibleAgency { get; set; } // 3055

        [EdiValue("X(35)", Path = "EQD/2/3", Mandatory = false)]
        public string EquipmentSizeAndType { get; set; } // 8154

        [EdiValue("X(3)", Path = "EQD/3", Mandatory = false)]
        public string EquipmentSupplierCoded { get; set; } // 8077

        [EdiValue("X(3)", Path = "EQD/4", Mandatory = false)]
        public string EquipmentStatusCoded { get; set; } // 8249

        [EdiValue("X(3)", Path = "EQD/5", Mandatory = false)]
        public string FullEmptyIndicatorCoded { get; set; } // 8169
    }


    [EdiSegment, EdiPath("HAN")]
    public class HandlingInstructions
    {
        // C524 Composite
        [EdiValue("X(3)", Path = "HAN/0/0", Mandatory = false)]
        public string HandlingInstructionsCoded { get; set; } // 4079

        [EdiValue("X(3)", Path = "HAN/0/1", Mandatory = false)]
        public string HandlingInstructionsCodeListQualifier { get; set; } // 1131

        [EdiValue("X(3)", Path = "HAN/0/2", Mandatory = false)]
        public string HandlingInstructionsCodeListResponsibleAgency { get; set; } // 3055

        [EdiValue("X(70)", Path = "HAN/0/3", Mandatory = false)]
        public string HandlingInstruction { get; set; } // 4078

        // C218 Composite
        [EdiValue("X(4)", Path = "HAN/1/0", Mandatory = false)]
        public string HazardousMaterialClassCodeIdentification { get; set; } // 7419

        [EdiValue("X(3)", Path = "HAN/1/1", Mandatory = false)]
        public string HazardousMaterialCodeListQualifier { get; set; } // 1131

        [EdiValue("X(3)", Path = "HAN/1/2", Mandatory = false)]
        public string HazardousMaterialCodeListResponsibleAgency { get; set; } // 3055
    }

    [EdiSegmentGroup("SG14", "EQD", "HAN", "MEA", "FTX")]
    public class SegmentGroup14
    {
        [EdiValue("X(35)", Path = "SG14/0")] public EquipmentDetails EquipmentDetails { get; set; } // EQD segment

        [EdiValue("X(35)", Path = "SG14/1", Mandatory = false)]
        public HandlingInstructions HandlingInstructions { get; set; } // HAN segment

        [EdiValue("X(35)", Path = "SG14/2", Mandatory = false)]
        public Measurements Measurements { get; set; } // MEA segment

        [EdiValue("X(35)", Path = "SG14/3", Mandatory = false)]
        public FreeTextMessage FreeText { get; set; } // FTX segment
    }

    [EdiSegment, EdiPath("SCC")]
    public class SchedulingConditions
    {
        [EdiValue("X(3)", Path = "SCC/0", Mandatory = true)]
        public string DeliveryPlanStatusIndicatorCoded { get; set; } // 4017

        [EdiValue("X(3)", Path = "SCC/1", Mandatory = false)]
        public string DeliveryRequirementsCoded { get; set; } // 4493

        // C329 Composite
        [EdiValue("X(3)", Path = "SCC/2/0", Mandatory = false)]
        public string FrequencyCoded { get; set; } // 2013

        [EdiValue("X(3)", Path = "SCC/2/1", Mandatory = false)]
        public string DespatchPatternCoded { get; set; } // 2015

        [EdiValue("X(3)", Path = "SCC/2/2", Mandatory = false)]
        public string DespatchPatternTimingCoded { get; set; } // 2017
    }

    [EdiSegment, EdiPath("QTY")]
    public class Quantity
    {
        // C186 Composite
        [EdiValue("X(3)", Path = "QTY/0/0", Mandatory = true)]
        public string QuantityQualifier { get; set; } // 6063

        [EdiValue("9(15)", Path = "QTY/0/1", Mandatory = true)]
        public decimal QuantityValue { get; set; } // 6060

        [EdiValue("X(3)", Path = "QTY/0/2", Mandatory = false)]
        public string MeasureUnitQualifier { get; set; } // 6411
    }

    [EdiSegmentGroup("SG16", "QTY", "DTM")]
    public class SegmentGroup16
    {
        [EdiValue("X(35)", Path = "SG16/0")] public Quantity Quantity { get; set; } // QTY segment

        [EdiValue("X(35)", Path = "SG16/1", Mandatory = false)]
        public DateTimePeriodMessage DateTimePeriod { get; set; } // DTM segment
    }

    [EdiSegmentGroup("SG15", "SCC", "FTX", "RFF", "SG16")]
    public class SegmentGroup15
    {
        [EdiValue("X(35)", Path = "SG15/0")]
        public SchedulingConditions SchedulingConditions { get; set; } // SCC segment

        [EdiValue("X(35)", Path = "SG15/1", Mandatory = false)]
        public FreeTextMessage FreeText { get; set; } // FTX segment

        [EdiValue("X(35)", Path = "SG15/2", Mandatory = false)]
        public ReferenceMessage Reference { get; set; } // RFF segment

        [EdiValue("X(35)", Path = "SG15/3", Mandatory = false)]
        public SegmentGroup16 ScheduledQuantitiesDates { get; set; } // SG16 segment group
    }

    [EdiSegment, EdiPath("APR")]
    public class AdditionalPriceInformation
    {
        [EdiValue("X(3)", Path = "APR/0", Mandatory = false)]
        public string ClassOfTradeCoded { get; set; } // 4043

        // C138 Composite
        [EdiValue("9(12)", Path = "APR/1/0", Mandatory = true)]
        public decimal PriceMultiplier { get; set; } // 5394

        [EdiValue("X(3)", Path = "APR/1/1", Mandatory = false)]
        public string PriceMultiplierQualifier { get; set; } // 5393

        // C960 Composite
        [EdiValue("X(3)", Path = "APR/2/0", Mandatory = false)]
        public string ChangeReasonCoded { get; set; } // 4295

        [EdiValue("X(3)", Path = "APR/2/1", Mandatory = false)]
        public string ChangeReasonCodeListQualifier { get; set; } // 1131

        [EdiValue("X(3)", Path = "APR/2/2", Mandatory = false)]
        public string ChangeReasonCodeListResponsibleAgency { get; set; } // 3055

        [EdiValue("X(35)", Path = "APR/2/3", Mandatory = false)]
        public string ChangeReason { get; set; } // 4294
    }

    [EdiSegment, EdiPath("RNG")]
    public class RangeDetails
    {
        [EdiValue("X(3)", Path = "RNG/0", Mandatory = true)]
        public string RangeTypeQualifier { get; set; } // 6167

        // C280 Composite
        [EdiValue("X(3)", Path = "RNG/1/0", Mandatory = true)]
        public string MeasureUnitQualifier { get; set; } // 6411

        [EdiValue("9(18)", Path = "RNG/1/1", Mandatory = false)]
        public decimal RangeMinimum { get; set; } // 6162

        [EdiValue("9(18)", Path = "RNG/1/2", Mandatory = false)]
        public decimal RangeMaximum { get; set; } // 6152
    }

    [EdiSegmentGroup("SG17", "APR", "DTM", "RNG")]
    public class SegmentGroup17
    {
        [EdiValue("X(35)", Path = "SG17/0")]
        public AdditionalPriceInformation AdditionalPriceInformation { get; set; } // APR segment

        [EdiValue("X(35)", Path = "SG17/1", Mandatory = false)]
        public DateTimePeriodMessage DateTimePeriod { get; set; } // DTM segment

        [EdiValue("X(35)", Path = "SG17/2", Mandatory = false)]
        public RangeDetails RangeDetails { get; set; } // RNG segment
    }

    [EdiSegment, EdiPath("ALC")]
    public class AllowanceOrCharge
    {
        [EdiValue("X(3)", Path = "ALC/0", Mandatory = true)]
        public string AllowanceOrChargeQualifier { get; set; } // 5463

        // C552 Composite
        [EdiValue("X(35)", Path = "ALC/1/0", Mandatory = false)]
        public string AllowanceOrChargeNumber { get; set; } // 1230

        [EdiValue("X(3)", Path = "ALC/1/1", Mandatory = false)]
        public string ChargeAllowanceDescriptionCoded { get; set; } // 5189

        [EdiValue("X(3)", Path = "ALC/2", Mandatory = false)]
        public string SettlementCoded { get; set; } // 4471

        [EdiValue("X(3)", Path = "ALC/3", Mandatory = false)]
        public string CalculationSequenceIndicatorCoded { get; set; } // 1227

        // C214 Composite
        [EdiValue("X(3)", Path = "ALC/4/0", Mandatory = false)]
        public string SpecialServicesCoded { get; set; } // 7161

        [EdiValue("X(3)", Path = "ALC/4/1", Mandatory = false)]
        public string SpecialServicesCodeListQualifier { get; set; } // 1131

        [EdiValue("X(3)", Path = "ALC/4/2", Mandatory = false)]
        public string SpecialServicesCodeListResponsibleAgency { get; set; } // 3055

        [EdiValue("X(35)", Path = "ALC/4/3", Mandatory = false)]
        public string SpecialService1 { get; set; } // 7160

        [EdiValue("X(35)", Path = "ALC/4/4", Mandatory = false)]
        public string SpecialService2 { get; set; } // 7160
    }

    [EdiSegment, EdiPath("RTE")]
    public class RateDetails
    {
        // C128 Composite
        [EdiValue("X(3)", Path = "RTE/0/0", Mandatory = true)]
        public string RateTypeQualifier { get; set; } // 5419

        [EdiValue("9(15)", Path = "RTE/0/1", Mandatory = true)]
        public decimal RatePerUnit { get; set; } // 5420

        [EdiValue("9(9)", Path = "RTE/0/2", Mandatory = false)]
        public decimal UnitPriceBasis { get; set; } // 5284

        [EdiValue("X(3)", Path = "RTE/0/3", Mandatory = false)]
        public string MeasureUnitQualifier { get; set; } // 6411
    }

    [EdiSegmentGroup("SG19", "QTY", "RNG")]
    public class SegmentGroup19
    {
        [EdiValue("X(35)", Path = "SG19/0")] public Quantity Quantity { get; set; } // QTY segment

        [EdiValue("X(35)", Path = "SG19/1", Mandatory = false)]
        public RangeDetails RangeDetails { get; set; } // RNG segment
    }

    [EdiSegmentGroup("SG20", "PCD", "RNG")]
    public class SegmentGroup20
    {
        [EdiValue("X(35)", Path = "SG20/0")] public PercentageDetails PercentageDetails { get; set; } // PCD segment

        [EdiValue("X(35)", Path = "SG20/1", Mandatory = false)]
        public RangeDetails RangeDetails { get; set; } // RNG segment
    }

    [EdiSegmentGroup("SG21", "MOA", "RNG")]
    public class SegmentGroup21
    {
        [EdiValue("X(35)", Path = "SG21/0")] public MonetaryAmount MonetaryAmount { get; set; } // MOA segment

        [EdiValue("X(35)", Path = "SG21/1", Mandatory = false)]
        public RangeDetails RangeDetails { get; set; } // RNG segment
    }

    [EdiSegmentGroup("SG22", "RTE", "RNG")]
    public class SegmentGroup22
    {
        [EdiValue("X(35)", Path = "SG22/0")] public RateDetails RateDetails { get; set; } // RTE segment

        [EdiValue("X(35)", Path = "SG22/1", Mandatory = false)]
        public RangeDetails RangeDetails { get; set; } // RNG segment
    }

    [EdiSegmentGroup("SG23", "TAX", "MOA")]
    public class SegmentGroup23
    {
        [EdiValue("X(35)", Path = "SG23/0")] public DutyTaxFeeDetails DutyTaxFeeDetails { get; set; } // TAX segment

        [EdiValue("X(35)", Path = "SG23/1", Mandatory = false)]
        public MonetaryAmount MonetaryAmount { get; set; } // MOA segment
    }

    [EdiSegmentGroup("SG18", "ALC", "ALI", "DTM", "SG19", "SG20", "SG21", "SG22", "SG23")]
    public class SegmentGroup18
    {
        [EdiValue("X(35)", Path = "SG18/0")] public AllowanceOrCharge AllowanceOrCharge { get; set; } // ALC segment

        [EdiValue("X(35)", Path = "SG18/1", Mandatory = false)]
        public AdditionalInformationMessage AdditionalInformation { get; set; } // ALI segment

        [EdiValue("X(35)", Path = "SG18/2", Mandatory = false)]
        public DateTimePeriodMessage DateTimePeriod { get; set; } // DTM segment

        [EdiValue("X(35)", Path = "SG18/3", Mandatory = false)]
        public SegmentGroup19 QuantityRange { get; set; } // SG19 segment group

        [EdiValue("X(35)", Path = "SG18/4", Mandatory = false)]
        public SegmentGroup20 PercentageRange { get; set; } // SG20 segment group

        [EdiValue("X(35)", Path = "SG18/5", Mandatory = false)]
        public SegmentGroup21 MonetaryRange { get; set; } // SG21 segment group

        [EdiValue("X(35)", Path = "SG18/6", Mandatory = false)]
        public SegmentGroup22 RateRange { get; set; } // SG22 segment group

        [EdiValue("X(35)", Path = "SG18/7", Mandatory = false)]
        public SegmentGroup23 TaxMonetaryAmount { get; set; } // SG23 segment group
    }

    [EdiSegment, EdiPath("RCS")]
    public class RequirementsAndConditions
    {
        [EdiValue("X(3)", Path = "RCS/0", Mandatory = true)]
        public string SectorSubjectIdentificationQualifier { get; set; } // 7293

        // C550 Composite
        [EdiValue("X(17)", Path = "RCS/1/0", Mandatory = true)]
        public string RequirementConditionIdentification { get; set; } // 7295

        [EdiValue("X(3)", Path = "RCS/1/1", Mandatory = false)]
        public string RequirementConditionCodeListQualifier { get; set; } // 1131

        [EdiValue("X(3)", Path = "RCS/1/2", Mandatory = false)]
        public string RequirementConditionCodeListResponsibleAgency { get; set; } // 3055

        [EdiValue("X(35)", Path = "RCS/1/3", Mandatory = false)]
        public string RequirementOrCondition { get; set; } // 7294

        [EdiValue("X(3)", Path = "RCS/2", Mandatory = false)]
        public string ActionRequestNotificationCoded { get; set; } // 1229
    }

    [EdiSegmentGroup("SG24", "RCS", "RFF", "DTM", "FTX")]
    public class SegmentGroup24
    {
        [EdiValue("X(35)", Path = "SG24/0")]
        public RequirementsAndConditions RequirementsAndConditions { get; set; } // RCS segment

        [EdiValue("X(35)", Path = "SG24/1", Mandatory = false)]
        public ReferenceMessage Reference { get; set; } // RFF segment

        [EdiValue("X(35)", Path = "SG24/2", Mandatory = false)]
        public DateTimePeriodMessage DateTimePeriod { get; set; } // DTM segment

        [EdiValue("X(35)", Path = "SG24/3", Mandatory = false)]
        public FreeTextMessage FreeText { get; set; } // FTX segment
    }

    [EdiSegment, EdiPath("LIN")]
    public class LineItem
    {
        [EdiValue("9(6)", Path = "LIN/0", Mandatory = false)]
        public int LineItemNumber { get; set; } // 1082

        [EdiValue("X(3)", Path = "LIN/1", Mandatory = false)]
        public string ActionRequestNotificationCoded { get; set; } // 1229

        // C212 Composite
        [EdiValue("X(35)", Path = "LIN/2/0", Mandatory = false)]
        public string ItemNumber { get; set; } // 7140

        [EdiValue("X(3)", Path = "LIN/2/1", Mandatory = false)]
        public string ItemNumberTypeCoded { get; set; } // 7143

        [EdiValue("X(3)", Path = "LIN/2/2", Mandatory = false)]
        public string ItemNumberCodeListQualifier { get; set; } // 1131

        [EdiValue("X(3)", Path = "LIN/2/3", Mandatory = false)]
        public string ItemNumberCodeListResponsibleAgency { get; set; } // 3055

        // C829 Composite
        [EdiValue("X(3)", Path = "LIN/3/0", Mandatory = false)]
        public string SubLineIndicatorCoded { get; set; } // 5495

        [EdiValue("9(6)", Path = "LIN/3/1", Mandatory = false)]
        public int SubLineItemNumber { get; set; } // 1082

        [EdiValue("9(2)", Path = "LIN/4", Mandatory = false)]
        public int ConfigurationLevel { get; set; } // 1222

        [EdiValue("X(3)", Path = "LIN/5", Mandatory = false)]
        public string ConfigurationCoded { get; set; } // 7083
    }

    [EdiSegment, EdiPath("PIA")]
    public class AdditionalProductId
    {
        [EdiValue("X(3)", Path = "PIA/0", Mandatory = true)]
        public string ProductIdFunctionQualifier { get; set; } // 4347

        // First C212 Composite
        [EdiValue("X(35)", Path = "PIA/1/0", Mandatory = false)]
        public string ItemNumber1 { get; set; } // 7140

        [EdiValue("X(3)", Path = "PIA/1/1", Mandatory = false)]
        public string ItemNumberTypeCoded1 { get; set; } // 7143

        [EdiValue("X(3)", Path = "PIA/1/2", Mandatory = false)]
        public string ItemNumberCodeListQualifier1 { get; set; } // 1131

        [EdiValue("X(3)", Path = "PIA/1/3", Mandatory = false)]
        public string ItemNumberCodeListResponsibleAgency1 { get; set; } // 3055

        // Second C212 Composite
        [EdiValue("X(35)", Path = "PIA/2/0", Mandatory = false)]
        public string ItemNumber2 { get; set; } // 7140

        [EdiValue("X(3)", Path = "PIA/2/1", Mandatory = false)]
        public string ItemNumberTypeCoded2 { get; set; } // 7143

        [EdiValue("X(3)", Path = "PIA/2/2", Mandatory = false)]
        public string ItemNumberCodeListQualifier2 { get; set; } // 1131

        [EdiValue("X(3)", Path = "PIA/2/3", Mandatory = false)]
        public string ItemNumberCodeListResponsibleAgency2 { get; set; } // 3055

        // Third C212 Composite
        [EdiValue("X(35)", Path = "PIA/3/0", Mandatory = false)]
        public string ItemNumber3 { get; set; } // 7140

        [EdiValue("X(3)", Path = "PIA/3/1", Mandatory = false)]
        public string ItemNumberTypeCoded3 { get; set; } // 7143

        [EdiValue("X(3)", Path = "PIA/3/2", Mandatory = false)]
        public string ItemNumberCodeListQualifier3 { get; set; } // 1131

        [EdiValue("X(3)", Path = "PIA/3/3", Mandatory = false)]
        public string ItemNumberCodeListResponsibleAgency3 { get; set; } // 3055

        // Fourth C212 Composite
        [EdiValue("X(35)", Path = "PIA/4/0", Mandatory = false)]
        public string ItemNumber4 { get; set; } // 7140

        [EdiValue("X(3)", Path = "PIA/4/1", Mandatory = false)]
        public string ItemNumberTypeCoded4 { get; set; } // 7143

        [EdiValue("X(3)", Path = "PIA/4/2", Mandatory = false)]
        public string ItemNumberCodeListQualifier4 { get; set; } // 1131

        [EdiValue("X(3)", Path = "PIA/4/3", Mandatory = false)]
        public string ItemNumberCodeListResponsibleAgency4 { get; set; } // 3055

        // Fifth C212 Composite
        [EdiValue("X(35)", Path = "PIA/5/0", Mandatory = false)]
        public string ItemNumber5 { get; set; } // 7140

        [EdiValue("X(3)", Path = "PIA/5/1", Mandatory = false)]
        public string ItemNumberTypeCoded5 { get; set; } // 7143

        [EdiValue("X(3)", Path = "PIA/5/2", Mandatory = false)]
        public string ItemNumberCodeListQualifier5 { get; set; } // 1131

        [EdiValue("X(3)", Path = "PIA/5/3", Mandatory = false)]
        public string ItemNumberCodeListResponsibleAgency5 { get; set; } // 3055
    }

    [EdiSegment, EdiPath("GIR")]
    public class RelatedIdentificationNumbers
    {
        [EdiValue("X(3)", Path = "GIR/0", Mandatory = true)]
        public string SetIdentificationQualifier { get; set; } // 7297

        // First C206 Composite
        [EdiValue("X(35)", Path = "GIR/1/0", Mandatory = true)]
        public string IdentityNumber1 { get; set; } // 7402

        [EdiValue("X(3)", Path = "GIR/1/1", Mandatory = false)]
        public string IdentityNumberQualifier1 { get; set; } // 7405

        [EdiValue("X(3)", Path = "GIR/1/2", Mandatory = false)]
        public string StatusCoded1 { get; set; } // 4405

        // Second C206 Composite
        [EdiValue("X(35)", Path = "GIR/2/0", Mandatory = false)]
        public string IdentityNumber2 { get; set; } // 7402

        [EdiValue("X(3)", Path = "GIR/2/1", Mandatory = false)]
        public string IdentityNumberQualifier2 { get; set; } // 7405

        [EdiValue("X(3)", Path = "GIR/2/2", Mandatory = false)]
        public string StatusCoded2 { get; set; } // 4405

        // Third C206 Composite
        [EdiValue("X(35)", Path = "GIR/3/0", Mandatory = false)]
        public string IdentityNumber3 { get; set; } // 7402

        [EdiValue("X(3)", Path = "GIR/3/1", Mandatory = false)]
        public string IdentityNumberQualifier3 { get; set; } // 7405

        [EdiValue("X(3)", Path = "GIR/3/2", Mandatory = false)]
        public string StatusCoded3 { get; set; } // 4405

        // Fourth C206 Composite
        [EdiValue("X(35)", Path = "GIR/4/0", Mandatory = false)]
        public string IdentityNumber4 { get; set; } // 7402

        [EdiValue("X(3)", Path = "GIR/4/1", Mandatory = false)]
        public string IdentityNumberQualifier4 { get; set; } // 7405

        [EdiValue("X(3)", Path = "GIR/4/2", Mandatory = false)]
        public string StatusCoded4 { get; set; } // 4405

        // Fifth C206 Composite
        [EdiValue("X(35)", Path = "GIR/5/0", Mandatory = false)]
        public string IdentityNumber5 { get; set; } // 7402

        [EdiValue("X(3)", Path = "GIR/5/1", Mandatory = false)]
        public string IdentityNumberQualifier5 { get; set; } // 7405

        [EdiValue("X(3)", Path = "GIR/5/2", Mandatory = false)]
        public string StatusCoded5 { get; set; } // 4405

        // Sixth C206 Composite
        [EdiValue("X(35)", Path = "GIR/6/0", Mandatory = false)]
        public string IdentityNumber6 { get; set; } // 7402

        [EdiValue("X(3)", Path = "GIR/6/1", Mandatory = false)]
        public string IdentityNumberQualifier6 { get; set; } // 7405

        [EdiValue("X(3)", Path = "GIR/6/2", Mandatory = false)]
        public string StatusCoded6 { get; set; } // 4405
    }

    [EdiSegment, EdiPath("QVR")]
    public class QuantityVariances
    {
        // C279 Composite
        [EdiValue("9(15)", Path = "QVR/0/0", Mandatory = true)]
        public decimal QuantityDifference { get; set; } // 6064

        [EdiValue("X(3)", Path = "QVR/0/1", Mandatory = false)]
        public string QuantityQualifier { get; set; } // 6063

        [EdiValue("X(3)", Path = "QVR/1", Mandatory = false)]
        public string DiscrepancyCoded { get; set; } // 4221

        // C960 Composite
        [EdiValue("X(3)", Path = "QVR/2/0", Mandatory = false)]
        public string ChangeReasonCoded { get; set; } // 4295

        [EdiValue("X(3)", Path = "QVR/2/1", Mandatory = false)]
        public string ChangeReasonCodeListQualifier { get; set; } // 1131

        [EdiValue("X(3)", Path = "QVR/2/2", Mandatory = false)]
        public string ChangeReasonCodeListResponsibleAgency { get; set; } // 3055

        [EdiValue("X(35)", Path = "QVR/2/3", Mandatory = false)]
        public string ChangeReason { get; set; } // 4294
    }

    [EdiSegmentGroup("SG25", "LIN", "PIA", "IMD", "MEA", "QTY", "PCD", "ALI", "DTM", "MOA", "GIN", "GIR", "QVR", "DOC",
        "PAI", "FTX", "SG26", "SG27", "SG28", "SG29", "SG30", "SG33", "SG34", "SG35", "SG39", "SG45", "SG47", "SG48",
        "SG49", "SG51", "SG52")]
    public class SegmentGroup25
    {
        [EdiValue("X(35)", Path = "SG25/0")] public LineItem LineItem { get; set; } // LIN segment

        [EdiValue("X(35)", Path = "SG25/1", Mandatory = false)]
        public AdditionalProductId AdditionalProductId { get; set; } // PIA segment

        [EdiValue("X(35)", Path = "SG25/2", Mandatory = false)]
        public ItemDescriptionMessage ItemDescription { get; set; } // IMD segment

        [EdiValue("X(35)", Path = "SG25/3", Mandatory = false)]
        public Measurements Measurements { get; set; } // MEA segment

        [EdiValue("X(35)", Path = "SG25/4", Mandatory = false)]
        public Quantity Quantity { get; set; } // QTY segment

        [EdiValue("X(35)", Path = "SG25/5", Mandatory = false)]
        public PercentageDetails PercentageDetails { get; set; } // PCD segment

        [EdiValue("X(35)", Path = "SG25/6", Mandatory = false)]
        public AdditionalInformationMessage AdditionalInformation { get; set; } // ALI segment

        [EdiValue("X(35)", Path = "SG25/7", Mandatory = false)]
        public DateTimePeriodMessage DateTimePeriod { get; set; } // DTM segment

        [EdiValue("X(35)", Path = "SG25/8", Mandatory = false)]
        public MonetaryAmount MonetaryAmount { get; set; } // MOA segment

        [EdiValue("X(35)", Path = "SG25/9", Mandatory = false)]
        public GoodsIdentityNumber GoodsIdentityNumber { get; set; } // GIN segment

        [EdiValue("X(35)", Path = "SG25/10", Mandatory = false)]
        public RelatedIdentificationNumbers RelatedIdentificationNumbers { get; set; } // GIR segment

        [EdiValue("X(35)", Path = "SG25/11", Mandatory = false)]
        public QuantityVariances QuantityVariances { get; set; } // QVR segment

        [EdiValue("X(35)", Path = "SG25/12", Mandatory = false)]
        public DocumentMessageDetails DocumentMessageDetails { get; set; } // DOC segment

        [EdiValue("X(35)", Path = "SG25/13", Mandatory = false)]
        public PaymentInstructionMessage PaymentInstructions { get; set; } // PAI segment

        [EdiValue("X(35)", Path = "SG25/14", Mandatory = false)]
        public FreeTextMessage FreeText { get; set; } // FTX segment

        // Placeholder for Segment Group 26
        [EdiValue("X(35)", Path = "SG25/15", Mandatory = false)]
        public SegmentGroup26 ProductCharacteristics { get; set; }

        // Placeholder for Segment Group 27
        [EdiValue("X(35)", Path = "SG25/16", Mandatory = false)]
        public SegmentGroup27 TermsOfPayment { get; set; }

        // Placeholder for Segment Group 28
        [EdiValue("X(35)", Path = "SG25/17", Mandatory = false)]
        public SegmentGroup28 RelevantPricingInformation { get; set; }

        // Placeholder for Segment Group 29
        [EdiValue("X(35)", Path = "SG25/18", Mandatory = false)]
        public SegmentGroup29 References { get; set; }

        // Placeholder for Segment Group 30
        [EdiValue("X(35)", Path = "SG25/19", Mandatory = false)]
        public SegmentGroup30 Packaging { get; set; }

        // Placeholder for Segment Group 33
        [EdiValue("X(35)", Path = "SG25/20", Mandatory = false)]
        public SegmentGroup33 DestinationDetails { get; set; }

        // Placeholder for Segment Group 34
        [EdiValue("X(35)", Path = "SG25/21", Mandatory = false)]
        public SegmentGroup34 TaxInformation { get; set; }

        // Placeholder for Segment Group 35
        [EdiValue("X(35)", Path = "SG25/22", Mandatory = false)]
        public SegmentGroup35 PartiesDetails { get; set; }

        // Placeholder for Segment Group 39
        [EdiValue("X(35)", Path = "SG25/23", Mandatory = false)]
        public SegmentGroup39 AllowancesCharges { get; set; }

        // Placeholder for Segment Group 45
        [EdiValue("X(35)", Path = "SG25/24", Mandatory = false)]
        public SegmentGroup45 SegmentGroup45 { get; set; }

        // Placeholder for Segment Group 47
        [EdiValue("X(35)", Path = "SG25/25", Mandatory = false)]
        public SegmentGroup47 SegmentGroup47 { get; set; }

        // Placeholder for Segment Group 48
        [EdiValue("X(35)", Path = "SG25/26", Mandatory = false)]
        public SegmentGroup48 SegmentGroup48 { get; set; }

        // Placeholder for Segment Group 49
        [EdiValue("X(35)", Path = "SG25/27", Mandatory = false)]
        public SegmentGroup49 SegmentGroup49 { get; set; }

        // Placeholder for Segment Group 51
        [EdiValue("X(35)", Path = "SG25/28", Mandatory = false)]
        public SegmentGroup51 SegmentGroup51 { get; set; }

        // Placeholder for Segment Group 52
        [EdiValue("X(35)", Path = "SG25/29", Mandatory = false)]
        public SegmentGroup52 SegmentGroup52 { get; set; }
    }

    [EdiSegment, EdiPath("CCI")]
    public class CharacteristicClassId
    {
        [EdiValue("X(3)", Path = "CCI/0", Mandatory = false)]
        public string PropertyClassCoded { get; set; } // 7059

        // C502 Composite
        [EdiValue("X(3)", Path = "CCI/1/0", Mandatory = false)]
        public string MeasurementDimensionCoded { get; set; } // 6313

        [EdiValue("X(3)", Path = "CCI/1/1", Mandatory = false)]
        public string MeasurementSignificanceCoded { get; set; } // 6321

        [EdiValue("X(3)", Path = "CCI/1/2", Mandatory = false)]
        public string MeasurementAttributeCoded { get; set; } // 6155

        [EdiValue("X(70)", Path = "CCI/1/3", Mandatory = false)]
        public string MeasurementAttribute { get; set; } // 6154

        // C240 Composite
        [EdiValue("X(17)", Path = "CCI/2/0", Mandatory = true)]
        public string CharacteristicIdentification { get; set; } // 7037

        [EdiValue("X(3)", Path = "CCI/2/1", Mandatory = false)]
        public string CodeListQualifier { get; set; } // 1131

        [EdiValue("X(3)", Path = "CCI/2/2", Mandatory = false)]
        public string CodeListResponsibleAgency { get; set; } // 3055

        [EdiValue("X(35)", Path = "CCI/2/3", Mandatory = false)]
        public string Characteristic1 { get; set; } // 7036

        [EdiValue("X(35)", Path = "CCI/2/4", Mandatory = false)]
        public string Characteristic2 { get; set; } // 7036
    }

    [EdiSegment, EdiPath("CAV")]
    public class CharacteristicValue
    {
        // C889 Composite
        [EdiValue("X(3)", Path = "CAV/0/0", Mandatory = false)]
        public string CharacteristicValueCoded { get; set; } // 7111

        [EdiValue("X(3)", Path = "CAV/0/1", Mandatory = false)]
        public string CodeListQualifier { get; set; } // 1131

        [EdiValue("X(3)", Path = "CAV/0/2", Mandatory = false)]
        public string CodeListResponsibleAgency { get; set; } // 3055

        [EdiValue("X(35)", Path = "CAV/0/3", Mandatory = false)]
        public string CharacteristicValue1 { get; set; } // 7110

        [EdiValue("X(35)", Path = "CAV/0/4", Mandatory = false)]
        public string CharacteristicValue2 { get; set; } // 7110
    }

    [EdiSegmentGroup("SG26", "CCI", "CAV", "MEA")]
    public class SegmentGroup26
    {
        [EdiValue("X(35)", Path = "SG26/0")]
        public CharacteristicClassId CharacteristicClassId { get; set; } // CCI segment

        [EdiValue("X(35)", Path = "SG26/1", Mandatory = false)]
        public CharacteristicValue CharacteristicValue { get; set; } // CAV segment

        [EdiValue("X(35)", Path = "SG26/2", Mandatory = false)]
        public Measurements Measurements { get; set; } // MEA segment
    }

    [EdiSegmentGroup("SG27", "PAT", "DTM", "PCD", "MOA")]
    public class SegmentGroup27
    {
        [EdiValue("X(35)", Path = "SG27/0")] public PaymentTermsBasis PaymentTermsBasis { get; set; } // PAT segment

        [EdiValue("X(35)", Path = "SG27/1", Mandatory = false)]
        public DateTimePeriodMessage DateTimePeriod { get; set; } // DTM segment

        [EdiValue("X(35)", Path = "SG27/2", Mandatory = false)]
        public PercentageDetails PercentageDetails { get; set; } // PCD segment

        [EdiValue("X(35)", Path = "SG27/3", Mandatory = false)]
        public MonetaryAmount MonetaryAmount { get; set; } // MOA segment
    }

    [EdiSegment, EdiPath("PRI")]
    public class PriceDetails
    {
        // C509 Composite
        [EdiValue("X(3)", Path = "PRI/0/0", Mandatory = true)]
        public string PriceQualifier { get; set; } // 5125

        [EdiValue("9(15)", Path = "PRI/0/1", Mandatory = false)]
        public decimal? Price { get; set; } // 5118

        [EdiValue("X(3)", Path = "PRI/0/2", Mandatory = false)]
        public string PriceTypeCoded { get; set; } // 5375

        [EdiValue("X(3)", Path = "PRI/0/3", Mandatory = false)]
        public string PriceTypeQualifier { get; set; } // 5387

        [EdiValue("9(9)", Path = "PRI/0/4", Mandatory = false)]
        public decimal? UnitPriceBasis { get; set; } // 5284

        [EdiValue("X(3)", Path = "PRI/0/5", Mandatory = false)]
        public string MeasureUnitQualifier { get; set; } // 6411

        [EdiValue("X(3)", Path = "PRI/1", Mandatory = false)]
        public string SubLinePriceChangeCoded { get; set; } // 5213
    }

    [EdiSegmentGroup("SG28", "PRI", "CUX", "APR", "RNG", "DTM")]
    public class SegmentGroup28
    {
        [EdiValue("X(35)", Path = "SG28/0")] public PriceDetails PriceDetails { get; set; } // PRI segment

        [EdiValue("X(35)", Path = "SG28/1", Mandatory = false)]
        public Currencies Currencies { get; set; } // CUX segment

        [EdiValue("X(35)", Path = "SG28/2", Mandatory = false)]
        public AdditionalPriceInformation AdditionalPriceInformation { get; set; } // APR segment

        [EdiValue("X(35)", Path = "SG28/3", Mandatory = false)]
        public RangeDetails RangeDetails { get; set; } // RNG segment

        [EdiValue("X(35)", Path = "SG28/4", Mandatory = false)]
        public DateTimePeriodMessage DateTimePeriod { get; set; } // DTM segment
    }

    [EdiSegmentGroup("SG29", "RFF", "DTM")]
    public class SegmentGroup29
    {
        [EdiValue("X(35)", Path = "SG29/0")] public ReferenceMessage Reference { get; set; } // RFF segment

        [EdiValue("X(35)", Path = "SG29/1", Mandatory = false)]
        public DateTimePeriodMessage DateTimePeriod { get; set; } // DTM segment
    }

    [EdiSegmentGroup("SG31", "RFF", "DTM")]
    public class SegmentGroup31
    {
        [EdiValue("X(35)", Path = "SG31/0")] public ReferenceMessage Reference { get; set; } // RFF segment

        [EdiValue("X(35)", Path = "SG31/1", Mandatory = false)]
        public DateTimePeriodMessage DateTimePeriod { get; set; } // DTM segment
    }

    [EdiSegmentGroup("SG32", "PCI", "RFF", "DTM", "GIN")]
    public class SegmentGroup32
    {
        [EdiValue("X(35)", Path = "SG32/0")]
        public PackageIdentification PackageIdentification { get; set; } // PCI segment

        [EdiValue("X(35)", Path = "SG32/1", Mandatory = false)]
        public ReferenceMessage Reference { get; set; } // RFF segment

        [EdiValue("X(35)", Path = "SG32/2", Mandatory = false)]
        public DateTimePeriodMessage DateTimePeriod { get; set; } // DTM segment

        [EdiValue("X(35)", Path = "SG32/3", Mandatory = false)]
        public GoodsIdentityNumber GoodsIdentityNumber { get; set; } // GIN segment
    }

    [EdiSegmentGroup("SG30", "PAC", "MEA", "QTY", "DTM", "SG31", "SG32")]
    public class SegmentGroup30
    {
        [EdiValue("X(35)", Path = "SG30/0")] public Package Package { get; set; } // PAC segment

        [EdiValue("X(35)", Path = "SG30/1", Mandatory = false)]
        public Measurements Measurements { get; set; } // MEA segment

        [EdiValue("X(35)", Path = "SG30/2", Mandatory = false)]
        public Quantity Quantity { get; set; } // QTY segment

        [EdiValue("X(35)", Path = "SG30/3", Mandatory = false)]
        public DateTimePeriodMessage DateTimePeriod { get; set; } // DTM segment

        [EdiValue("X(35)", Path = "SG30/4", Mandatory = false)]
        public SegmentGroup31 SegmentGroup31 { get; set; }

        [EdiValue("X(35)", Path = "SG30/5", Mandatory = false)]
        public SegmentGroup32 SegmentGroup32 { get; set; } // SG32 segment group
    }

    [EdiSegmentGroup("SG33", "LOC", "QTY", "DTM")]
    public class SegmentGroup33
    {
        [EdiValue("X(35)", Path = "SG33/0")]
        public PlaceLocationIdentificationMessage PlaceLocationIdentification { get; set; } // LOC segment

        [EdiValue("X(35)", Path = "SG33/1", Mandatory = false)]
        public Quantity Quantity { get; set; } // QTY segment

        [EdiValue("X(35)", Path = "SG33/2", Mandatory = false)]
        public DateTimePeriodMessage DateTimePeriod { get; set; } // DTM segment
    }

    [EdiSegmentGroup("SG34", "TAX", "MOA", "LOC")]
    public class SegmentGroup34
    {
        [EdiValue("X(35)", Path = "SG34/0")] public DutyTaxFeeDetails DutyTaxFeeDetails { get; set; } // TAX segment

        [EdiValue("X(35)", Path = "SG34/1", Mandatory = false)]
        public MonetaryAmount MonetaryAmount { get; set; } // MOA segment

        [EdiValue("X(35)", Path = "SG34/2", Mandatory = false)]
        public PlaceLocationIdentificationMessage PlaceLocationIdentification { get; set; } // LOC segment
    }

    [EdiSegmentGroup("SG40", "QTY", "RNG")]
    public class SegmentGroup40
    {
        [EdiValue("X(35)", Path = "SG40/0")] public Quantity Quantity { get; set; } // QTY segment

        [EdiValue("X(35)", Path = "SG40/1", Mandatory = false)]
        public RangeDetails RangeDetails { get; set; } // RNG segment
    }

    [EdiSegmentGroup("SG41", "PCD", "RNG")]
    public class SegmentGroup41
    {
        [EdiValue("X(35)", Path = "SG41/0")] public PercentageDetails PercentageDetails { get; set; } // PCD segment

        [EdiValue("X(35)", Path = "SG41/1", Mandatory = false)]
        public RangeDetails RangeDetails { get; set; } // RNG segment
    }

    [EdiSegmentGroup("SG42", "MOA", "RNG")]
    public class SegmentGroup42
    {
        [EdiValue("X(35)", Path = "SG42/0")] public MonetaryAmount MonetaryAmount { get; set; } // MOA segment

        [EdiValue("X(35)", Path = "SG42/1", Mandatory = false)]
        public RangeDetails RangeDetails { get; set; } // RNG segment
    }

    [EdiSegmentGroup("SG43", "RTE", "RNG")]
    public class SegmentGroup43
    {
        [EdiValue("X(35)", Path = "SG43/0")] public RateDetails RateDetails { get; set; } // RTE segment

        [EdiValue("X(35)", Path = "SG43/1", Mandatory = false)]
        public RangeDetails RangeDetails { get; set; } // RNG segment
    }

    [EdiSegmentGroup("SG44", "TAX", "MOA")]
    public class SegmentGroup44
    {
        [EdiValue("X(35)", Path = "SG44/0")] public DutyTaxFeeDetails DutyTaxFeeDetails { get; set; } // TAX segment

        [EdiValue("X(35)", Path = "SG44/1", Mandatory = false)]
        public MonetaryAmount MonetaryAmount { get; set; } // MOA segment
    }

    [EdiSegmentGroup("SG39", "ALC", "ALI", "DTM", "SG40", "SG41", "SG42", "SG43", "SG44")]
    public class SegmentGroup39
    {
        [EdiValue("X(35)", Path = "SG39/0")] public AllowanceOrCharge AllowanceOrCharge { get; set; } // ALC segment

        [EdiValue("X(35)", Path = "SG39/1", Mandatory = false)]
        public AdditionalInformationMessage AdditionalInformation { get; set; } // ALI segment

        [EdiValue("X(35)", Path = "SG39/2", Mandatory = false)]
        public DateTimePeriodMessage DateTimePeriod { get; set; } // DTM segment

        [EdiValue("X(35)", Path = "SG39/3", Mandatory = false)]
        public SegmentGroup40 QuantityRangeGroup { get; set; } // SG40 segment group

        [EdiValue("X(35)", Path = "SG39/4", Mandatory = false)]
        public SegmentGroup41 PercentageRangeGroup { get; set; } // SG41 segment group

        [EdiValue("X(35)", Path = "SG39/5", Mandatory = false)]
        public SegmentGroup42 MonetaryRangeGroup { get; set; } // SG42 segment group

        [EdiValue("X(35)", Path = "SG39/6", Mandatory = false)]
        public SegmentGroup43 RateRangeGroup { get; set; } // SG43 segment group

        [EdiValue("X(35)", Path = "SG39/7", Mandatory = false)]
        public SegmentGroup44 TaxMonetaryGroup { get; set; } // SG44 segment group
    }

    [EdiSegmentGroup("SG46", "LOC", "DTM")]
    public class SegmentGroup46
    {
        [EdiValue("X(35)", Path = "SG46/0")]
        public PlaceLocationIdentificationMessage PlaceLocationIdentification { get; set; } // LOC segment

        [EdiValue("X(35)", Path = "SG46/1", Mandatory = false)]
        public DateTimePeriodMessage DateTimePeriod { get; set; } // DTM segment
    }

    [EdiSegmentGroup("SG45", "TDT", "SG46")]
    public class SegmentGroup45
    {
        [EdiValue("X(35)", Path = "SG45/0")] public DetailsOfTransport DetailsOfTransport { get; set; } // TDT segment

        [EdiValue("X(35)", Path = "SG45/1", Mandatory = false)]
        public SegmentGroup46 SegmentGroup46 { get; set; } // SG46 segment group
    }

    [EdiSegmentGroup("SG47", "TOD", "LOC")]
    public class SegmentGroup47
    {
        [EdiValue("X(35)", Path = "SG47/0")]
        public TermsOfDeliveryOrTransport TermsOfDeliveryOrTransport { get; set; } // TOD segment

        [EdiValue("X(35)", Path = "SG47/1", Mandatory = false)]
        public PlaceLocationIdentificationMessage PlaceLocationIdentification { get; set; } // LOC segment
    }

    [EdiSegmentGroup("SG48", "EQD", "HAN", "MEA", "FTX")]
    public class SegmentGroup48
    {
        [EdiValue("X(35)", Path = "SG48/0")] public EquipmentDetails EquipmentDetails { get; set; } // EQD segment

        [EdiValue("X(35)", Path = "SG48/1", Mandatory = false)]
        public HandlingInstructions HandlingInstructions { get; set; } // HAN segment

        [EdiValue("X(35)", Path = "SG48/2", Mandatory = false)]
        public Measurements Measurements { get; set; } // MEA segment

        [EdiValue("X(35)", Path = "SG48/3", Mandatory = false)]
        public FreeTextMessage FreeText { get; set; } // FTX segment
    }

    [EdiSegmentGroup("SG50", "QTY", "DTM")]
    public class SegmentGroup50
    {
        [EdiValue("X(35)", Path = "SG50/0")] public Quantity Quantity { get; set; } // QTY segment

        [EdiValue("X(35)", Path = "SG50/1", Mandatory = false)]
        public DateTimePeriodMessage DateTimePeriod { get; set; } // DTM segment
    }

    [EdiSegmentGroup("SG49", "SCC", "FTX", "RFF", "SG50")]
    public class SegmentGroup49
    {
        [EdiValue("X(35)", Path = "SG49/0")]
        public SchedulingConditions SchedulingConditions { get; set; } // SCC segment

        [EdiValue("X(35)", Path = "SG49/1", Mandatory = false)]
        public FreeTextMessage FreeText { get; set; } // FTX segment

        [EdiValue("X(35)", Path = "SG49/2", Mandatory = false)]
        public ReferenceMessage Reference { get; set; } // RFF segment

        [EdiValue("X(35)", Path = "SG49/3", Mandatory = false)]
        public SegmentGroup50 SegmentGroup50 { get; set; } // SG50 segment group
    }

    [EdiSegmentGroup("SG51", "RCS", "RFF", "DTM", "FTX")]
    public class SegmentGroup51
    {
        [EdiValue("X(35)", Path = "SG51/0")]
        public RequirementsAndConditions RequirementsAndConditions { get; set; } // RCS segment

        [EdiValue("X(35)", Path = "SG51/1", Mandatory = false)]
        public ReferenceMessage Reference { get; set; } // RFF segment

        [EdiValue("X(35)", Path = "SG51/2", Mandatory = false)]
        public DateTimePeriodMessage DateTimePeriod { get; set; } // DTM segment

        [EdiValue("X(35)", Path = "SG51/3", Mandatory = false)]
        public FreeTextMessage FreeText { get; set; } // FTX segment
    }

    [EdiSegment, EdiPath("STG")]
    public class Stages
    {
        [EdiValue("X(3)", Path = "STG/0", Mandatory = true)]
        public string StagesQualifier { get; set; } // 9421

        [EdiValue("9(2)", Path = "STG/1", Mandatory = false)]
        public int? NumberOfStages { get; set; } // 6426

        [EdiValue("9(2)", Path = "STG/2", Mandatory = false)]
        public int? ActualStageCount { get; set; } // 6428
    }

    [EdiSegmentGroup("SG53", "QTY", "MOA")]
    public class SegmentGroup53
    {
        [EdiValue("X(35)", Path = "SG53/0")] public Quantity Quantity { get; set; } // QTY segment

        [EdiValue("X(35)", Path = "SG53/1", Mandatory = false)]
        public MonetaryAmount MonetaryAmount { get; set; } // MOA segment
    }

    [EdiSegmentGroup("SG52", "STG", "SG53")]
    public class SegmentGroup52
    {
        [EdiValue("X(35)", Path = "SG52/0")] public Stages Stages { get; set; } // STG segment

        [EdiValue("X(35)", Path = "SG52/1", Mandatory = false)]
        public SegmentGroup53 QuantityMonetaryGroup { get; set; } // SG53 segment group
    }

    [EdiSegment, EdiPath("UNS")]
    public class SectionControl
    {
        [EdiValue("A(1)", Path = "UNS/0", Mandatory = true)]
        public char SectionIdentification { get; set; } // 0081
    }

    [EdiSegment, EdiPath("CNT")]
    public class ControlTotal
    {
        // C270 Composite
        [EdiValue("X(3)", Path = "CNT/0/0", Mandatory = true)]
        public string ControlQualifier { get; set; } // 6069

        [EdiValue("9(18)", Path = "CNT/0/1", Mandatory = true)]
        public decimal ControlValue { get; set; } // 6066

        [EdiValue("X(3)", Path = "CNT/0/2", Mandatory = false)]
        public string MeasureUnitQualifier { get; set; } // 6411
    }

    [EdiSegmentGroup("SG54", "ALC", "ALI", "MOA")]
    public class SegmentGroup54
    {
        [EdiValue("X(35)", Path = "SG54/0")] public AllowanceOrCharge AllowanceOrCharge { get; set; } // ALC segment

        [EdiValue("X(35)", Path = "SG54/1", Mandatory = false)]
        public AdditionalInformationMessage AdditionalInformation { get; set; } // ALI segment

        [EdiValue("X(35)", Path = "SG54/2", Mandatory = false)]
        public MonetaryAmount MonetaryAmount { get; set; } // MOA segment
    }

    [EdiSegment, EdiPath("UNT")]
    public class MessageTrailer
    {
        [EdiValue("9(6)", Path = "UNT/0", Mandatory = true)]
        public int NumberOfSegments { get; set; } // 0074

        [EdiValue("X(14)", Path = "UNT/1", Mandatory = true)]
        public string MessageReferenceNumber { get; set; } // 0062
    }
}