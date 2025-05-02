

using System.ComponentModel.DataAnnotations;

namespace Motos.Domain.Entities;
public class MotosM 
{

    [Key]
    public int Id { get; set; }
    public string? Modelo { get; set; }
    
    public int Potencia { get; set; }
   
    public decimal Preco { get; set; }

    public string? Imagem { get; set; }
    
    public int? MarcaId { get; set; }
    
    
    public Marca? Marca { get; set; }

    



}
