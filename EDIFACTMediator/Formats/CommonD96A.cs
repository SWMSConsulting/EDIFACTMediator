using EDIFACTMediator.Utils;
using indice.Edi.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDIFACTMediator.Formats
{
    [EdiSegment, EdiElement, EdiPath("PRI")]
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


    [EdiSegment, EdiPath("UNZ")]
    public class InterchangeTrailer
    {
        [EdiValue("9(6)", Path = "UNZ/0", Mandatory = true)]
        public int? InterchangeControlCount { get; set; }

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

    [EdiSegment, EdiElement, EdiPath("DTM")]
    public class DateTimePeriodMessage
    {
        // DTM
        [EdiValue("X(3)", Path = "DTM/0/0", Mandatory = true)]
        public string DateTimePeriodFunctionCode { get; set; } = "137"; // 2005

        [EdiValue("9(6)", Path = "DTM/0/1", Description = "Date and Time of Preparation")]
        public string DateOfPreparation { get; set; } // 2380

        [EdiValue("X(3)", Path = "DTM/0/2")]
        public string FormatQualifier { get; set; }

        public DateTime DateOfPreparationDate
        {
            get
            {

                if (DateTime.TryParseExact(DateOfPreparation, DateTimeFormat.GetDateTimeFormat(FormatQualifier), null, System.Globalization.DateTimeStyles.None, out DateTime date))
                {
                    return date;
                }
                return DateTime.MinValue;
            }
        }
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

    [EdiElement, EdiPath("UNS")]
    public class SectionControl
    {
        [EdiValue("X(1)", Path = "UNS/0", Mandatory = true)]
        public string SectionIdentification { get; set; } // 0081
    }


    [EdiElement, EdiPath("CNT")]
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

    [EdiSegment, EdiElement, EdiPath("LIN")]
    public class LineItem
    {
        [EdiValue("9(6)", Path = "LIN/0", Mandatory = false)]
        public int? LineItemNumber { get; set; } // 1082

        [EdiValue("X(3)", Path = "LIN/1", Mandatory = false)]
        public string? ActionRequestNotificationCoded { get; set; } = "";// 1229

        // C212 Composite
        [EdiValue("X(35)", Path = "LIN/2/0", Mandatory = false)]
        public string? ItemNumber { get; set; } // 7140

        [EdiValue("X(3)", Path = "LIN/2/1", Mandatory = false)]
        public string? ItemNumberTypeCoded { get; set; } = "EN"; // 7143

        [EdiValue("X(3)", Path = "LIN/2/2", Mandatory = false)]
        public string? ItemNumberCodeListQualifier { get; set; } // 1131

        [EdiValue("X(3)", Path = "LIN/2/3", Mandatory = false)]
        public string? ItemNumberCodeListResponsibleAgency { get; set; } // 3055

        // C829 Composite
        [EdiValue("X(3)", Path = "LIN/3/0", Mandatory = false)]
        public string? SubLineIndicatorCoded { get; set; } = ""; // 5495

        [EdiValue("9(6)", Path = "LIN/3/1", Mandatory = false)]
        public int? SubLineItemNumber { get; set; } // 1082

        [EdiValue("9(2)", Path = "LIN/4", Mandatory = false)]
        public int? ConfigurationLevel { get; set; } // 1222

        [EdiValue("X(3)", Path = "LIN/5", Mandatory = false)]
        public string? ConfigurationCoded { get; set; }  // 7083
    }

    [EdiSegment, EdiElement, EdiPath("IMD")]
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

    [EdiSegment, EdiElement, EdiPath("QTY")]
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

    [EdiSegment, EdiPath("UNT")]
    public class MessageTrailer
    {
        [EdiValue("9(6)", Path = "UNT/0", Mandatory = true)]
        public int? NumberOfSegments { get; set; } // 0074

        [EdiValue("X(14)", Path = "UNT/1", Mandatory = true)]
        public string MessageReferenceNumber { get; set; } // 0062
    }

}
