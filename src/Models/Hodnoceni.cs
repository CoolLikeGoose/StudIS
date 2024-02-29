namespace src.Models;

public class Hodnoceni
{
    public int Id { get; set; }
    public int Body { get; set; }
    public string Poznamka { get; set; }
    public int StudentId { get; set; }
    public virtual Student Student { get; set; }
    public int AktivitaId { get; set; }
    public virtual Aktivita Aktivita { get; set; }
}