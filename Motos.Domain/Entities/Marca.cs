

namespace Motos.Domain.Entities;

public class Marca : Entity
{
    
    public string NomeMarca { get;private set; }


    public ICollection<MotosM> Motos { get; set; } = new List<MotosM>();


}
