using Newtonsoft.Json;

namespace Motos.API.Model
{
    public class Marca
    {
        public int MarcaId { get; set; }
        public string NomeMarca { get; set; }


        public ICollection<MotosM> Motos { get; set; } = new List<MotosM>();


    }
}
