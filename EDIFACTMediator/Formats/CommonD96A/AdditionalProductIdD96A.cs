using EDIFACTMediator.Utils;
using indice.Edi.Serialization;

namespace EDIFACTMediator.Formats;

[EdiSegment, EdiElement, EdiPath("PIA")]
public class AdditionalProductIdD96A
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

    public string ItemNumberCodeListResponsibleAgency1Text
    {
        get
        {
            return CodeListAgency.GetCodeDescription(ItemNumberCodeListResponsibleAgency1);
        }
    }

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