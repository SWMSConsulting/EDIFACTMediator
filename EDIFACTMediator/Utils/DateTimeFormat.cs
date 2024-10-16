using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDIFACTMediator.Utils
{
    using System;

    public static class DateTimeFormat
    {
        public static string GetDateTimeFormat(string code)
        {
            //Convert the string to an integer
            int codeInt = Convert.ToInt32(code);
            switch (codeInt)
            {
                case 2:
                    return "ddMMyy";
                case 3:
                    return "MMddyy";
                case 101:
                    return "yyMMdd";
                case 102:
                    return "yyyyMMdd";
                case 103:
                    return "yy'W'wwd";
                case 105:
                    return "yyDDD";
                case 106:
                    return "MMdd";
                case 107:
                    return "DDD";
                case 108:
                    return "ww";
                case 109:
                    return "MM";
                case 110:
                    return "dd";
                case 201:
                    return "yyMMddHHmm";
                case 202:
                    return "yyMMddHHmmss";
                case 203:
                    return "yyyyMMddHHmm";
                case 204:
                    return "yyyyMMddHHmmss";
                case 301:
                    return "yyMMddHHmmzzz";
                case 302:
                    return "yyMMddHHmmsszzz";
                case 303:
                    return "yyyyMMddHHmmzzz";
                case 304:
                    return "yyyyMMddHHmmsszzz";
                case 305:
                    return "MMddHHmm";
                case 306:
                    return "ddHHmm";
                case 401:
                    return "HHmm";
                case 402:
                    return "HHmmss";
                case 404:
                    return "HHmmsszzz";
                case 405:
                    return "mmss";
                case 501:
                    return "HHmmHHmm";
                case 502:
                    return "HHmmssHHmmss";
                case 503:
                    return "HHmmsszzzHHmmsszzz";
                case 600:
                    return "yy";
                case 601:
                    return "yy";
                case 602:
                    return "yyyy";
                case 603:
                    return "yyS";
                case 604:
                    return "yyyyS";
                case 608:
                    return "yyyyQ";
                case 609:
                    return "yyMM";
                case 610:
                    return "yyyyMM";
                case 613:
                    return "yyMMA";
                case 614:
                    return "yyyyMMA";
                case 615:
                    return "yy'W'ww";
                case 616:
                    return "yyyy'W'ww";
                case 701:
                    return "yy-yy";
                case 702:
                    return "yyyy-yyyy";
                case 703:
                    return "yyS-yyS";
                case 704:
                    return "yyyyS-yyyyS";
                case 705:
                    return "yyPyyP";
                case 706:
                    return "yyyyP-yyyyP";
                case 707:
                    return "yyQ-yyQ";
                case 708:
                    return "yyyyQ-yyyyQ";
                case 709:
                    return "yyMM-yyMM";
                case 710:
                    return "yyyyMM-yyyyMM";
                case 711:
                    return "yyyyMMdd-yyyyMMdd";
                case 713:
                    return "yyMMddHHmm-yyMMddHHmm";
                case 715:
                    return "yy'W'ww-yy'W'ww";
                case 716:
                    return "yyyy'W'ww-yyyy'W'ww";
                case 717:
                    return "yyMMdd-yyMMdd";
                case 718:
                    return "yyyyMMdd-yyyyMMdd";
                case 801:
                    return "yyyy";
                case 802:
                    return "MM";
                case 803:
                    return "ww";
                case 804:
                    return "dd";
                case 805:
                    return "HH";
                case 806:
                    return "mm";
                case 807:
                    return "ss";
                case 808:
                    return "S";
                case 809:
                    return "P";
                case 810:
                    return "T";
                case 811:
                    return "hh";
                case 812:
                    return "A";
                case 813:
                    return "d";
                case 814:
                    return "E";
                default:
                    throw new ArgumentException("Invalid code");
            }
        }
    }

}
