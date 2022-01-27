namespace APL.Data.Detail
{
    public interface IDetails
    {
        int Valutazione { get; init; }
        string Modello { get; init; }
        string[] GetDetail();
    }
}
