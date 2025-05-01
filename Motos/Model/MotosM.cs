using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Motos.API.Model;

public class MotosM
{
    
    public int Id { get; set; }
  
    public string? Modelo { get; set; }
    
    public int Potencia { get; set; }
   
    public decimal Preco { get; set; }

    public string? Imagem { get; set; }
    
    public int? MarcaId { get; set; }
    
    [JsonIgnore]
    public Marca? Marca { get; set; }

    



}
