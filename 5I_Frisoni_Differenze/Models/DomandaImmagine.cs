using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
public class DomandaImmagine
{
    [Key] public int DomandaImmagineID { get; set; }
    public string PercorsoOriginale { get; set; }
    public string PercorsoModificata { get; set; }
    public int Width { get; set; }
    public int Height{ get; set; }
       
    public ICollection<Differenza> Differenze {get; set;}   

    public async Task<DomandaImmagineDTO> GetDTO(DbTrovaLeDifferenze context) {
        List<Differenza> elencoDifferenze = await context.Differenze.Where(x => x.DomandaImmagineID == this.DomandaImmagineID).ToListAsync();
        List<DifferenzaDTO> elencoDTO = new List<DifferenzaDTO>();
        
        foreach(Differenza d in elencoDifferenze) elencoDTO.Add(d.GetDTO());
        return new DomandaImmagineDTO() {
            PercorsoOriginale = this.PercorsoOriginale,
            PercorsoModificata = this.PercorsoModificata,
            Width = this.Width,
            Height = this.Height,
            ElencoDifferenze = elencoDTO
        };
    }

}


