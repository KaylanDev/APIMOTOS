

namespace Motos.Domain.Entities;

public class Marca 
{
    public int Id { get; set; }
    public string NomeMarca { get; set; }


    public ICollection<MotosM> Motos { get; set; } = new List<MotosM>();


}
