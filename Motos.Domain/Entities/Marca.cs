

namespace Motos.Domain.Entities;

public class Marca : Entity
{
    
    public string NomeMarca { get; set; }


    public ICollection<MotosM> Motos { get; set; } = new List<MotosM>();


}
