using indice.Edi.Serialization;

namespace EDIFACTMediator.Formats.CommonD96A;


[EdiSegment, EdiPath("BGM")]
public class BeginningOfMessageD96A
{
    [EdiValue("X(3)", Mandatory = true, Path = "BGM/0/0")]
    public string DocumentNameCoded { get; set; } = "380"; // Commercial invoice coded (380 in EDIFACT)

    [EdiValue("X(35)", Path = "BGM/1", Mandatory = true)]
    public string DocumentNumber { get; set; } // Invoice number

    [EdiValue("X(3)", Path = "BGM/2", Mandatory = false)]
    public string MessageFunction { get; set; } = "9"; // Original invoice (1225)
}