using AnschreibenCreator.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnschreibenCreator.Lib.Service
{
    public class EigeneAnschriftConverter
    {
        private string _rawAnschrift;

        public EigeneAnschriftConverter(string rawAnschrift)
        {
            _rawAnschrift = rawAnschrift;
            GetAnschrift();
        }


        public bool CanConvert { get; set; }

        public EigeneAnschriftModel GetAnschrift()
        {
            CanConvert = false;
            EigeneAnschriftModel model = new();

            var parts = _rawAnschrift.Split("\n", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 5)
            {

                model.Name = parts[0];
                model.Straße = parts[1];
                model.PlzUStadt = parts[2];
                model.Mobile = parts[3];
                model.Email = parts[4];

                CanConvert = true;
            }





            return model;



        }

    }
}
