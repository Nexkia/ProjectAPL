using APL.Data.Detail;


namespace APL.Data
{
    public class ConstructorDetail
    {
       
        public Details GetDetails(string detail) 
        {
            switch (detail)
            {
                case "cpu":
                    return new Cpu();
                case "schedaVideo":
                    return new SchedaVideo();
                case "schedaMadre":
                    return new SchedaMadre();
                case "dissipatore":
                    return new Dissipatore();
                case "alimentatore":
                    return new Alimentatore();
                case "casepc":
                    return new CasePC();
                case "ram":
                    return new Ram();
                case "memoria":
                    return new Memoria();
                default:
                    return null;
            }
        }
    }
}
