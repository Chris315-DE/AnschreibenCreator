using AnschreibenCreator.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnschreibenCreator.Lib.Service
{
    public class AnschriftLoader
    {

        const string seperator = "###";

        private string _path;
        public AnschriftLoader(string path)
        {
            _path = path;
        }


        public List<FirmenAnschriftModel> GetFirmenAnschriftModels() 
        {

            List<FirmenAnschriftModel> results = [];

            string raw = File.ReadAllText(_path);

            var splittet = raw.Split(seperator,StringSplitOptions.TrimEntries|StringSplitOptions.RemoveEmptyEntries);

            foreach (var firma in splittet)
            {
                var parts = firma.Split("\n",StringSplitOptions.RemoveEmptyEntries|StringSplitOptions.TrimEntries);

                if(parts.Length == 3)
                {
                    FirmenAnschriftModel model = new()
                    {
                        FirmenName = parts[0],
                        Straße = parts[1],
                        PlzUStadt = parts[2],
                        ZuHänden = "Personal Abteilung",
                      
                        AnredeGeschlecht = "Damen und Herren"

                    };

                        
                    results.Add(model);
                }

                if (parts.Length == 4) 
                {
                    FirmenAnschriftModel model = new()
                    {
                        FirmenName = parts[0],
                        ZuHänden = parts[1],
                        Straße = parts[2],
                        PlzUStadt = parts[3],
                        


                        

                    };

                    results.Add(model);
                }

            }
            return results;

        }

    }
}
