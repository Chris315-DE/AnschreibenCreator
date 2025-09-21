using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnschreibenCreator.Lib.Models
{
    public class FirmenAnschriftModel
    {
        public string FirmenName { get; set; } = string.Empty;
        public string ZuHänden { get; set; } = string.Empty;

        public string Straße { get; set; } = string.Empty;
        public string PlzUStadt { get; set; } = string.Empty;
        public string AnredeText
        {
            get
            {
                if (string.IsNullOrEmpty(AnredeGeschlecht) || AnredeGeschlecht == "NV" || AnredeGeschlecht == "Damen und Herren")
                {
                    return "Sehr geehrte Damen und Herren";
                }
                if (!string.IsNullOrEmpty(AnredeGeschlecht) && AnredeGeschlecht == "Herr")
                {
                    return $"Sehr geehrter Herr {ZuHänden}";
                }
                else
                {
                    return $"Sehr geehrte Frau {ZuHänden}";
                }
            }
        }


        public string AnredeGeschlecht { get; set; } = string.Empty;








    }
}
