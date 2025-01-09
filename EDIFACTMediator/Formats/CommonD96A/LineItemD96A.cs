using indice.Edi.Serialization;

namespace EDIFACTMediator.Formats.CommonD96A;
// there were problems parsing the LIN segment inside an LineItemGroup so i moved these parameters into the LineItemGroup


/*
[EdiSegment, EdiElement, EdiPath("LIN")]
public class LineItemD96A
{
    [EdiValue("9(6)", Path = "LIN/0", Mandatory = false)]
    public int? LineItemNumber { get; set; } // 1082

    [EdiValue("X(3)", Path = "LIN/1", Mandatory = false)]
    public string? ActionRequestNotificationCoded { get; set; } // 1229

    // Composite Element (C212)
    [EdiValue("X(35)", Path = "LIN/2/0", Mandatory = false)]
    public string? ItemNumber { get; set; } // 7140

    [EdiValue("X(3)", Path = "LIN/2/1", Mandatory = false)]
    public string? ItemNumberTypeCoded { get; set; } // 7143
}
*/

/*

[EdiElement, EdiPath("LIN")]
public class LineItem
{
[EdiValue("9(6)", Path = "LIN/0", Mandatory = false)]
public int? LineItemNumber { get; set; } // 1082

[EdiValue("X(3)", Path = "LIN/2/0", Mandatory = false)]
public string? ItemNumber { get; set; } // 7140



[EdiValue("X(3)", Path = "LIN/1", Mandatory = false)]
public string? ActionRequestNotificationCoded { get; set; } // 1229

[EdiValue("X(3)", Path = "LIN/2/1", Mandatory = false)]
public string? ItemNumberTypeCoded { get; set; } // 7143

[EdiValue("X(3)", Path = "LIN/2/2", Mandatory = false)]
public string? ItemNumberCodeListQualifier { get; set; } // 1131

[EdiValue("X(3)", Path = "LIN/2/3", Mandatory = false)]
public string? ItemNumberCodeListResponsibleAgency { get; set; } // 3055

// C829 Composite
[EdiValue("X(3)", Path = "LIN/3/0", Mandatory = false)]
public string? SubLineIndicatorCoded { get; set; } = ""; // 5495

[EdiValue("9(6)", Path = "LIN/3/1", Mandatory = false)]
public string? SubLineItemNumber { get; set; } // 1082

[EdiValue("9(2)", Path = "LIN/4", Mandatory = false)]
public int? ConfigurationLevel { get; set; } // 1222

[EdiValue("X(3)", Path = "LIN/5", Mandatory = false)]
public string? ConfigurationCoded { get; set; }  // 7083
}
*/