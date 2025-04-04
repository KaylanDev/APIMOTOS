using Motos.Repository;

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

        public MotosDto()
        {
         
        }

        public static Moto MotosMToDto(MotosM moto)
        {
            var motoDto = new MotosDto
            {
                Id = moto.Id,
                Modelo = moto.Modelo,
                Potencia = moto.Potencia,
                Preco = moto.Preco,
                Imagem = moto.Imagem,
                MarcaMoto = moto.MarcaMoto
            };

            return motoDto;
            
        }

        public static IEnumerable<MotosDto> MotosMToDtoList(IEnumerable<MotosM> motos)
        {
            List<MotosDto> motosDto = new List<MotosDto>();
            foreach (var moto in motos)
            {
                var dto = MotosDto.MotosMToDto(moto);
                motosDto.Add(dto);
            }

            IEnumerable<MotosDto> m = motosDto;

            return m;

        }

        public static MotosM DtoToMotosM (MotosDto moto)
        {
            return new MotosM
            {
                Id = moto.Id,
                Modelo = moto.Modelo,
                Potencia = moto.Potencia,
                Preco = moto.Preco,
                Imagem = moto.Imagem,
                MarcaMoto = moto.MarcaMoto
            };
        }

        public static MotosM DtoToMotosMPost(MotosDto moto)
        {
            return new MotosM
            {
                
                Modelo = moto.Modelo,
                Potencia = moto.Potencia,
                Preco = moto.Preco,
                Imagem = moto.Imagem,
                MarcaMoto = moto.MarcaMoto
            };
        }

    }
}
