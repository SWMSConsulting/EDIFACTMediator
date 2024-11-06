using indice.Edi.Serialization;

namespace EDIFACTMediator.Formats.CommonD96A;

[EdiSegment, EdiElement, EdiPath("PRI")]
public class PriceDetailsD96A
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
