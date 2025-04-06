using Motos.Repository;

namespace Motos.Model.Dtos;

public class MotosDto
{

    public int Id { get; set; }

    public string? Modelo { get; set; }

    public int Potencia { get; set; }

    public decimal Preco { get; set; }
    public string Marca { get; set; }
    public string? Imagem { get; set; }

   

   
    public MotosDto()
    {

    }

    public static MotosDto MotosMToDto(MotosM moto)
    {
      
        var motoDto = new MotosDto
        {
            Id = moto.Id,
            Modelo = moto.Modelo,
            Potencia = moto.Potencia,
            Preco = moto.Preco,
            Imagem = moto.Imagem,
            Marca = moto.Marca.NomeMarca

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

}
