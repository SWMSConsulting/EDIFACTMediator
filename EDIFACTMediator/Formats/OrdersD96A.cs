using EDIFACTMediator.Formats.CommonD96A;
using EDIFACTMediator.Utils;
using indice.Edi.Serialization;

namespace EDIFACTMediator.Formats.OrdersD96A;

public class OrdersD96A : IEdiFormat
{
    public InterchangeHeader Header { get; set; } = new InterchangeHeader();

    public List<Order> Orders { get; set; } = new List<Order>();
    /*
    //Header
    public MessageHeader MessageHeader { get; set; } = new MessageHeader(); // UNH segment
    public BeginningOfMessage BeginningOfMessage { get; set; } = new BeginningOfMessage(); // BGM segment
    public DateTimePeriodMessage DateTimes { get; set; } = new DateTimePeriodMessage(); // DTM segments
    public List<PaymentInstructionMessage> PaymentInstructions { get; set; } =
  new List<PaymentInstructionMessage>(); // PAI segments

    public List<AdditionalInformationMessage> AdditionalInformations { get; set; } =
        new List<AdditionalInformationMessage>(); // ALI segments

    public List<ItemDescriptionMessage> ItemDescriptions { get; set; } =
        new List<ItemDescriptionMessage>(); // IMD segments

    public List<FreeTextMessage> FreeTexts { get; set; } = new List<FreeTextMessage>(); // FTX segments

    public List<SegmentGroup2> Parties { get; set; } = new List<SegmentGroup2>();

    //Add segment groups if needed (https://service.unece.org/trade/untdid/d96a/trmd/orders_d.htm#HS)




    public List<LineItems> LineItems { get; set; } = new List<LineItems>(); // LIN-PIA-IMD-MEA-QTY-PCD-ALI-DTM-MOA-GIN-GIR-QVR-DOC-PAI-FTX-SG26-SG27-SG28-SG29-SG30-SG33-SG34-SG35-SG39-SG45-SG47-SG48-SG49-SG51-SG52 segment group

    //public Order Orders { get; set; }
    [EdiSegment(Mandatory = true)]
    public SectionControl SectionControl { get; set; } = new SectionControl(); // UNS segment
    public ControlTotal ControlTotal { get; set; } = new ControlTotal(); // CNT segment
    */
    public InterchangeTrailer Trailer { get; set; } = new InterchangeTrailer();

    public void UpdateDerivedProperties()
    {
        throw new NotImplementedException();
    }
}

[EdiMessage]
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

    public List<PartySegment> Parties { get; set; } = new List<PartySegment>();

    //Add segment groups if needed (https://service.unece.org/trade/untdid/d96a/trmd/orders_d.htm#HS)




    public List<LineItemGroupD96A> LineItems { get; set; } = new List<LineItemGroupD96A>(); // LIN-PIA-IMD-MEA-QTY-PCD-ALI-DTM-MOA-GIN-GIR-QVR-DOC-PAI-FTX-SG26-SG27-SG28-SG29-SG30-SG33-SG34-SG35-SG39-SG45-SG47-SG48-SG49-SG51-SG52 segment group


    //public Order Orders { get; set; }
    [EdiSegment(Mandatory = true)]
    public SectionControl SectionControl { get; set; } = new SectionControl(); // UNS segment
    public ControlTotal ControlTotal { get; set; } = new ControlTotal(); // CNT segment


    //public List<SegmentGroup1> References { get; set; } = new List<SegmentGroup1>(); // RFF-DTM segment group

    //public List<SegmentGroup2> Parties { get; set; } =
    //    new List<SegmentGroup2>(); // NAD-LOC-FII-SG3-SG4-SG5 segment group

    //public List<SegmentGroup6> Taxes { get; set; } = new List<SegmentGroup6>(); // TAX-MOA-LOC segment group
    //public List<SegmentGroup7> Currencies { get; set; } = new List<SegmentGroup7>(); // CUX-PCD-DTM segment group

    //public List<SegmentGroup8> PaymentTerms { get; set; } =
    //    new List<SegmentGroup8>(); // PAT-DTM-PCD-MOA segment group

    //public List<SegmentGroup9> TransportDetails { get; set; } = new List<SegmentGroup9>(); // TDT-SG10 segment group
    //public List<SegmentGroup11> DeliveryTerms { get; set; } = new List<SegmentGroup11>(); // TOD-LOC segment group

    //public List<SegmentGroup12> PackagingDetails { get; set; } =
    //    new List<SegmentGroup12>(); // PAC-MEA-SG13 segment group

    //public List<SegmentGroup15> SchedulingConditions { get; set; } =
    //    new List<SegmentGroup15>(); // SCC-FTX-RFF-SG16 segment group

    //public List<SegmentGroup17> AdditionalPrices { get; set; } =
    //    new List<SegmentGroup17>(); // APR-DTM-RNG segment group

    //public List<SegmentGroup18> AllowancesAndCharges { get; set; } =
    //    new List<SegmentGroup18>(); // ALC-ALI-DTM-SG19-SG20-SG21-SG22-SG23 segment group

    //public List<SegmentGroup24> Regulations { get; set; } =
    //    new List<SegmentGroup24>(); // RCS-RFF-DTM-FTX segment group

    //public List<SegmentGroup25> LineItems { get; set; } =
    //    new List<SegmentGroup25>(); // LIN-PIA-IMD-MEA-QTY-PCD-ALI-DTM-MOA-GIN-GIR-QVR-DOC-PAI-FTX-SG26-SG27-SG28-SG29-SG30-SG33-SG34-SG35-SG39-SG45-SG47-SG48-SG49-SG51-SG52 segment group

    //public List<SegmentGroup54> AllowanceChargeSummaries { get; set; } =
    //    new List<SegmentGroup54>(); // ALC-ALI-MOA segment group

    //public SectionControl SectionControl { get; set; } = new SectionControl(); // UNS segment
    //public ControlTotal ControlTotal { get; set; } = new ControlTotal(); // CNT segment
    //public MessageTrailer MessageTrailer { get; set; } = new MessageTrailer(); // UNT segment
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

[EdiSegment, EdiElement, EdiPath("PAI")]
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

[EdiSegment, EdiElement, EdiPath("ALI")]
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

[EdiElement, EdiSegment, EdiPath("FTX")]
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

[EdiSegmentGroup("SG1", "RFF", "DTM")]
public class SegmentGroup1
{
    [EdiValue("X(35)", Path = "SG1/0")] public ReferenceMessage Reference { get; set; } // RFF segment

    [EdiValue("X(35)", Path = "SG1/1")] public DateTimePeriodMessage DateTimePeriod { get; set; } // DTM segment
}

[EdiSegment, EdiElement, EdiPath("LOC")]
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

[EdiSegment, EdiElement, EdiPath("DOC")]
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

[EdiSegmentGroup("RFF")]
public class SegmentGroup36
{
    public ReferenceMessage Reference { get; set; } // RFF segment

    public DateTimePeriodMessage DateTimePeriod { get; set; } // DTM segment
}

[EdiSegmentGroup("DOC")]
public class SegmentGroup37
{
    public DocumentMessageDetails Document { get; set; } // DOC segment

    public DateTimePeriodMessage DateTimePeriod { get; set; } // DTM segment
}


[EdiSegmentGroup("CTA", "COM")]
public class SegmentGroup38
{
    public ContactInformation ContactInformation { get; set; } // CTA segment

    public CommunicationContact CommunicationContact { get; set; } // COM segment
}


[EdiSegmentGroup("NAD")]
public class SegmentGroup35
{
    //public NameAndAddressMessage NameAndAddress { get; set; } // NAD segment

    public PlaceLocationIdentificationMessage PlaceLocationIdentification { get; set; } // LOC segment

    public SegmentGroup36 ReferenceDateTimePeriod { get; set; } // SG36

    public SegmentGroup37 DocumentDateTimePeriod { get; set; } // SG37

    public SegmentGroup38 ContactCommunication { get; set; } // SG38
}

[EdiSegmentGroup("RFF")]
public class SegmentGroup3
{
    public ReferenceMessage Reference { get; set; } // RFF segment

    [EdiValue(Mandatory = false)]
    public DateTimePeriodMessage DateTimePeriod { get; set; } // DTM segment
}

[EdiSegmentGroup("DOC")]
public class SegmentGroup4
{
    public DocumentMessageDetails Document { get; set; } // DOC segment

    [EdiValue(Mandatory = false)]
    public DateTimePeriodMessage DateTimePeriod { get; set; } // DTM segment
}

[EdiSegmentGroup("CTA")]
public class SegmentGroup5
{
    public ContactInformation ContactInformation { get; set; } // CTA segment

    [EdiValue(Mandatory = false)]
    public CommunicationContact CommunicationContact { get; set; } // COM segment
}

[EdiSegmentGroup("NAD", SequenceEnd = "LIN")]
public class PartySegment
{
    //public NameAndAddressMessage NameAndAddress { get; set; } // NAD segment

    [EdiValue("X(3)", Path = "NAD/0", Mandatory = true)]
    public string PartyQualifier { get; set; } // 3035

    // C082 Composite
    [EdiValue("X(35)", Path = "NAD/1/0", Mandatory = false)]
    public string PartyIdIdentification { get; set; } // 3039

    [EdiValue("X(3)", Path = "NAD/1/1", Mandatory = false)]
    public string CodeListQualifier { get; set; } // 1131

    [EdiValue("X(3)", Path = "NAD/1/2", Mandatory = false)]
    public string CodeListResponsibleAgency { get; set; } = "9";// 3055

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
    /*
    [EdiValue(Mandatory = false)]
    public PlaceLocationIdentificationMessage? PlaceLocationIdentification { get; set; } = null;// LOC segment

    [EdiValue(Mandatory = false)]
    public FinancialInstitutionInformationMessage? FinancialInstitutionInformation { get; set; } = null;// FII segment

    [EdiValue(Mandatory = false)]
    public SegmentGroup3? ReferenceDateTimePeriod { get; set; } = null;// SG3

    [EdiValue(Mandatory = false)]
    public SegmentGroup4? DocumentDateTimePeriod { get; set; } = null;// SG4

    [EdiValue(Mandatory = false)]
    public SegmentGroup5? ContactCommunication { get; set; } = null;// SG5
    */

    public List<ReferenceMessage> References { get; set; } = new List<ReferenceMessage>(); // RFF segments

}

[EdiSegment, EdiPath("TAX")]
public class TaxDetails
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

/*
[EdiSegment, EdiElement, EdiPath("MOA")]
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
*/
[EdiSegmentGroup("SG6", "TAX", "MOA", "LOC")]
public class SegmentGroup6
{
    [EdiValue("X(35)", Path = "SG6/0")] public TaxDetails Tax { get; set; } // TAX segment

    [EdiValue("X(35)", Path = "SG6/1", Mandatory = false)]
    public MonetaryAmountD96A MonetaryAmount { get; set; } // MOA segment

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

    /*
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
    */
}

[EdiSegment, EdiElement, EdiPath("PCD")]
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

/*
[EdiSegmentGroup("SG7", "CUX", "PCD", "DTM")]
public class CurrencyGroup
{
    [EdiValue("X(35)", Path = "SG7/0")] 
    public Currencies Currencies { get; set; } // CUX segment

    [EdiValue("X(35)", Path = "SG7/1", Mandatory = false)]
    public PercentageDetails PercentageDetails { get; set; } // PCD segment

    [EdiValue("X(35)", Path = "SG7/2", Mandatory = false)]
    public DateTimePeriodMessage DateTimePeriod { get; set; } // DTM segment
    
}
*/

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
    public MonetaryAmountD96A MonetaryAmount { get; set; } // MOA segment
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

[EdiSegment, EdiElement, EdiPath("MEA")]
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

[EdiSegment, EdiElement, EdiPath("GIN")]
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
    [EdiValue("X(35)", Path = "SG21/0")] 
    public MonetaryAmountD96A MonetaryAmount { get; set; } // MOA segment

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
    [EdiValue("X(35)", Path = "SG23/0")] public TaxDetails DutyTaxFeeDetails { get; set; } // TAX segment

    [EdiValue("X(35)", Path = "SG23/1", Mandatory = false)]
    public MonetaryAmountD96A MonetaryAmount { get; set; } // MOA segment
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


[EdiSegment, EdiElement, EdiPath("GIR")]
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

[EdiSegment, EdiElement, EdiPath("QVR")]
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

[EdiSegmentGroup("CCI")]
public class SegmentGroup26
{
    public CharacteristicClassId CharacteristicClassId { get; set; } // CCI segment

    public CharacteristicValue CharacteristicValue { get; set; } // CAV segment

    public Measurements Measurements { get; set; } // MEA segment
}

[EdiSegmentGroup("PAT")]
public class SegmentGroup27
{
    public PaymentTermsBasis PaymentTermsBasis { get; set; } // PAT segment

    public DateTimePeriodMessage DateTimePeriod { get; set; } // DTM segment

    public PercentageDetails PercentageDetails { get; set; } // PCD segment

    public MonetaryAmountD96A MonetaryAmount { get; set; } // MOA segment
}

[EdiSegmentGroup("PRI", SequenceEnd = "DTM")]
public class RelevantPriceInformation
{
    public PriceDetailsD96A PriceDetails { get; set; } // PRI segment

    public Currencies Currencies { get; set; } // CUX segment

    public AdditionalPriceInformation AdditionalPriceInformation { get; set; } // APR segment

    public RangeDetails RangeDetails { get; set; } // RNG segment

    public DateTimePeriodMessage DateTimePeriod { get; set; } // DTM segment
}

[EdiSegmentGroup("RFF")]
public class SegmentGroup29
{
    public ReferenceMessage Reference { get; set; } // RFF segment

    public DateTimePeriodMessage DateTimePeriod { get; set; } // DTM segment
}


[EdiSegmentGroup("PCI")]
public class SegmentGroup32
{
    public PackageIdentification PackageIdentification { get; set; } // PCI segment

    public ReferenceMessage Reference { get; set; } // RFF segment

    public DateTimePeriodMessage DateTimePeriod { get; set; } // DTM segment

    public GoodsIdentityNumber GoodsIdentityNumber { get; set; } // GIN segment
}

[EdiSegmentGroup("PAC")]
public class SegmentGroup30
{
    public Package Package { get; set; } // PAC segment

    public Measurements Measurements { get; set; } // MEA segment

    public Quantity Quantity { get; set; } // QTY segment

    public DateTimePeriodMessage DateTimePeriod { get; set; } // DTM segment

    public SegmentGroup29 SegmentGroup29 { get; set; }

    public SegmentGroup32 SegmentGroup32 { get; set; } // SG32 segment group
}

[EdiSegmentGroup("LOC")]
public class SegmentGroup33
{
    public PlaceLocationIdentificationMessage PlaceLocationIdentification { get; set; } // LOC segment

    public Quantity Quantity { get; set; } // QTY segment

    public DateTimePeriodMessage DateTimePeriod { get; set; } // DTM segment
}

[EdiSegmentGroup("TAX")]
public class SegmentGroup34
{
    public TaxDetails DutyTaxFeeDetails { get; set; } // TAX segment

    public MonetaryAmountD96A MonetaryAmount { get; set; } // MOA segment

    public PlaceLocationIdentificationMessage PlaceLocationIdentification { get; set; } // LOC segment
}

[EdiSegmentGroup("QTY")]
public class SegmentGroup40
{
    public Quantity Quantity { get; set; } // QTY segment

    public RangeDetails RangeDetails { get; set; } // RNG segment
}

[EdiSegmentGroup("PCD")]
public class SegmentGroup41
{
    public PercentageDetails PercentageDetails { get; set; } // PCD segment

    public RangeDetails RangeDetails { get; set; } // RNG segment
}

[EdiSegmentGroup("MOA")]
public class SegmentGroup42
{
    public MonetaryAmountD96A MonetaryAmount { get; set; } // MOA segment

    public RangeDetails RangeDetails { get; set; } // RNG segment
}

[EdiSegmentGroup("RTE")]
public class SegmentGroup43
{
    public RateDetails RateDetails { get; set; } // RTE segment

    public RangeDetails RangeDetails { get; set; } // RNG segment
}

[EdiSegmentGroup("SG44", "TAX", "MOA")]
public class SegmentGroup44
{
    [EdiValue("X(35)", Path = "SG44/0")] public TaxDetails DutyTaxFeeDetails { get; set; } // TAX segment

    [EdiValue("X(35)", Path = "SG44/1", Mandatory = false)]
    public MonetaryAmountD96A MonetaryAmount { get; set; } // MOA segment
}

[EdiSegmentGroup("ALC")]
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

[EdiSegmentGroup("LOC")]
public class SegmentGroup46
{
    public PlaceLocationIdentificationMessage PlaceLocationIdentification { get; set; } // LOC segment

    public DateTimePeriodMessage DateTimePeriod { get; set; } // DTM segment
}

[EdiSegmentGroup("TDT")]
public class SegmentGroup45
{
    public DetailsOfTransport DetailsOfTransport { get; set; } // TDT segment

    public SegmentGroup46 SegmentGroup46 { get; set; } // SG46 segment group
}

[EdiSegmentGroup("TOD")]
public class SegmentGroup47
{
    public TermsOfDeliveryOrTransport TermsOfDeliveryOrTransport { get; set; } // TOD segment

    public PlaceLocationIdentificationMessage PlaceLocationIdentification { get; set; } // LOC segment
}

[EdiSegmentGroup("EQD")]
public class SegmentGroup48
{
    public EquipmentDetails EquipmentDetails { get; set; } // EQD segment

    public HandlingInstructions HandlingInstructions { get; set; } // HAN segment

    public Measurements Measurements { get; set; } // MEA segment

    public FreeTextMessage FreeText { get; set; } // FTX segment
}

[EdiSegmentGroup("QTY")]
public class SegmentGroup50
{
    public Quantity Quantity { get; set; } // QTY segment

    public DateTimePeriodMessage DateTimePeriod { get; set; } // DTM segment
}

[EdiSegmentGroup("SCC")]
public class SegmentGroup49
{
    public SchedulingConditions SchedulingConditions { get; set; } // SCC segment

    public FreeTextMessage FreeText { get; set; } // FTX segment

    public ReferenceMessage Reference { get; set; } // RFF segment

    public SegmentGroup50 SegmentGroup50 { get; set; } // SG50 segment group
}

[EdiSegmentGroup("RCS")]
public class SegmentGroup51
{
    public RequirementsAndConditions RequirementsAndConditions { get; set; } // RCS segment

    public ReferenceMessage Reference { get; set; } // RFF segment

    public DateTimePeriodMessage DateTimePeriod { get; set; } // DTM segment

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

[EdiSegmentGroup("QTY", SequenceEnd = "MOA")]
public class SegmentGroup53
{
    public Quantity Quantity { get; set; } // QTY segment
    public MonetaryAmountD96A MonetaryAmount { get; set; } // MOA segment
}

[EdiSegmentGroup("STG")]
public class SegmentGroup52
{
    public Stages Stages { get; set; } // STG segment
    public SegmentGroup53 QuantityMonetaryGroup { get; set; } // SG53 segment group
}

[EdiSegmentGroup("SG54", "ALC", "ALI", "MOA")]
public class SegmentGroup54
{
    [EdiValue("X(35)", Path = "SG54/0")] public AllowanceOrCharge AllowanceOrCharge { get; set; } // ALC segment

    [EdiValue("X(35)", Path = "SG54/1", Mandatory = false)]
    public AdditionalInformationMessage AdditionalInformation { get; set; } // ALI segment

    [EdiValue("X(35)", Path = "SG54/2", Mandatory = false)]
    public MonetaryAmountD96A MonetaryAmount { get; set; } // MOA segment
}
