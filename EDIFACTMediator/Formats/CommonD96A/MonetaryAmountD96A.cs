using indice.Edi.Serialization;

namespace EDIFACTMediator.Formats.CommonD96A;

[EdiSegment, EdiPath("MOA")]
public class MonetaryAmountD96A
{
    [EdiValue("X(3)", Path = "MOA/0/0", Mandatory = true)]
    public string MonetaryAmountTypeQualifier { get; set; } // Total amount, tax amount, etc.

    [EdiValue("9(18)", Path = "MOA/0/1", Mandatory = true)]
    public decimal Amount { get; set; } // Amount value
}
