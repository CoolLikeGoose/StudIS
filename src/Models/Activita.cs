namespace src.Models;

public class Aktivita
{
    public int Id { get; set; }
    public DateTime Zacatek { get; set; }
    public DateTime Konec { get; set; }
    public Mistnost Mistnost { get; set; }
    public TypAktivity Typ { get; set; }
    public string Popis { get; set; }
    public int PredmetId { get; set; }
    public virtual Predmet Predmet { get; set; }
    // нужна ли тут последняя часть не до конца уверен 
    public virtual ICollection<Hodnoceni> Hodnoceni { get; set; } = new List<Hodnoceni>(); 
}