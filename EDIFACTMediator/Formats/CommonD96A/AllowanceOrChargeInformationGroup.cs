using EDIFACTMediator.Formats.OrdersD96A;
using indice.Edi.Serialization;

namespace EDIFACTMediator.Formats.CommonD96A;

[EdiSegmentGroup("ACL")]
public class AllowanceOrChargeInformationGroup
{
    public AllowanceOrCharge AllowanceOrCharge { get; set; } = new AllowanceOrCharge();

    public MonetaryAmountD96A? MonetaryAmount { get; set; }
}
