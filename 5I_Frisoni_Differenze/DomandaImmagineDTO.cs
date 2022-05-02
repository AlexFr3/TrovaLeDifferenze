public class DomandaImmagineDTO {

    public string PercorsoOriginale { get; set; }
    public string PercorsoModificata { get; set; }
    public int Width { get; set; }
    public int Height{ get; set; }

    public List<DifferenzaDTO> ElencoDifferenze { get; set; }  
    
}
