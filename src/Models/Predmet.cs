namespace src.Models;

public class Predmet
{
    public int Id { get; set; }
    public string Nazev { get; set; }
    public string Zkratka { get; set; }
    public virtual ICollection<Aktivita> Aktivity { get; set; } = new List<Aktivita>();
    public virtual ICollection<Student> Studenti { get; set; } = new List<Student>();
}