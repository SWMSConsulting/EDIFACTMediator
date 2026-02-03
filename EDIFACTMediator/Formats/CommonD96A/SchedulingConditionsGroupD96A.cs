using EDIFACTMediator.Formats.OrdersD96A;
using indice.Edi.Serialization;

namespace EDIFACTMediator.Formats.CommonD96A;

[EdiSegmentGroup("SCC", "FTX", "RFF", "QTY", "DTM")]
public class SchedulingConditionsGroupD96A
{
    // SCC – Scheduling conditions
    [EdiValue("9(1)", Path = "SCC/0", Mandatory = true)]
    public int ScheduleType { get; set; } // 7075 (z.B. 1 = firm)

    public List<FreeTextMessage> FreeTexts { get; set; } = new();

    public List<ReferenceMessage> References { get; set; } = new();

    public List<ScheduledQuantityGroupD96A> ScheduledQuantities { get; set; }
        = new(); // SG52
}

[EdiSegmentGroup("QTY", "DTM")]
public class ScheduledQuantityGroupD96A
{
    // QTY
    [EdiValue("X(3)", Path = "QTY/0/0", Mandatory = true)]
    public string QuantityQualifier { get; set; }
    // oder 21 / 113 – abhängig vom Partnerprofil

    [EdiValue("9(15)", Path = "QTY/0/1", Mandatory = true)]
    public decimal Quantity { get; set; }

    // DTM
    [EdiValue("X(3)", Path = "DTM/0/0", Mandatory = true)]
    public string DateQualifier { get; set; }

    [EdiValue("9(8)", Path = "DTM/0/1", Mandatory = true)]
    public string Date { get; set; }

    [EdiValue("X(3)", Path = "DTM/0/2", Mandatory = true)]
    public string Format { get; set; } = "102";
}

