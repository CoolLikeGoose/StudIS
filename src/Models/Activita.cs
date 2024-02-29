namespace src.Models;

public class Aktivita
{
    public int Id { get; set; }
    public DateTime Zacatek { get; set; }
    public DateTime Konec { get; set; }
    public Místnost Mistnost { get; set; }
    public TypAktivity Typ { get; set; }
    public string Popis { get; set; }
    public int PredmetId { get; set; }
    public virtual Predmet Predmet { get; set; }
    // нужна ли тут последняя часть не до конца уверен 
    public virtual ICollection<Hodnocení> Hodnocení { get; set; } = new List<Hodnocení>(); 
}