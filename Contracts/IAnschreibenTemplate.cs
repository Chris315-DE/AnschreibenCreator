namespace AnschreibenCreator.Lib.Contracts
{
    public interface IAnschreibenTemplate<T> : IEquatable<T> where T : class
    {
        string TemplateID { get; set; }

        public string Headder { get; set; }


        string Einleitung { get; set; }

        string Hauptteil { get; set; }

        string Abschluss { get; set; }

        DateTime StartDatum { get; set; }

        string StartDatumSatz { get; set; }

        string UnterschriftPfad { get; set; }
        string BruttoGehalt { get; set; }

        string BruttoGehaltSatz { get; set; }

    }

}
