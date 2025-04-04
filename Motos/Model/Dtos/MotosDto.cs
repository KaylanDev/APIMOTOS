namespace Motos.Model.Dtos
{
    public class MotosDto
    {

        public int Id { get; set; }

        public string? Modelo { get; set; }

        public int Potencia { get; set; }

        public decimal Preco { get; set; }

        public string? Imagem { get; set; }

        public string? MarcaMoto { get; set; }

        public MotosDto(MotosM moto)
        {
            Id = moto.Id;
            Modelo = moto.Modelo;
            Potencia = moto.Potencia;
            Preco = moto.Preco;
            Imagem = moto.Imagem;
            MarcaMoto = moto.MarcaMoto;
        }

        public static IEnumerable<MotosDto> List(IEnumerable<MotosM> motos)
        {
            List<MotosDto> motosDto = new List<MotosDto>();
            foreach (var moto in motos)
            {
                motosDto.Add(new MotosDto(moto));
            }

            IEnumerable<MotosDto> m = motosDto;

            return m;

        }
    }
}
