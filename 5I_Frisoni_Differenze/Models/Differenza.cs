using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
public class Differenza
{
    [Key] 
    public int idDifferenza { get; set; }
    public int X { get; set; }
    public int Y {get; set; }
    public int Raggio {get; set; }
    
    public int? DomandaImmagineID { get; set; }
    public DomandaImmagine DomandaImmagine { get; set; }

    public DifferenzaDTO GetDTO() {
        return new DifferenzaDTO() {
            X = this.X,
            Y = this.Y,
            Raggio = this.Raggio
        };
    }

}

