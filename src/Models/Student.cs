namespace src.Models;

public class Student
{
    public int Id { get; set; }
    public string Jmeno { get; set; }
    public string Prijmeni { get; set; }
    public string FotografieUrl { get; set; }
    public virtual ICollection<Predmet> Predmety { get; set; } = new List<Predmet>();
}
