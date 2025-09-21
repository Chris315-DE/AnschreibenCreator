using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnschreibenCreator.Lib.Models
{
    public class EigeneAnschriftModel
    {
        public string Name { get; set; } = string.Empty;
        public string Straße {  get; set; } = string.Empty ;
        public string PlzUStadt {  get; set; } = string.Empty ;
        public string Mobile {  get; set; } = string.Empty ;
        public string Email {  get; set; } = string.Empty ;

    }
}
