namespace Motos.Model
{
    public class Marca
    {
        public int MarcaId { get; set; }
        public string NomeMarca { get; set; }
        public ICollection<MotosM> Motos { get; set; } = new List<MotosM>();

    }
}
