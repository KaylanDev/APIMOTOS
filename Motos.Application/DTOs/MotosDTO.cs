using Motos.Domain.Entities;

namespace Motos.Application.DTO;
public class MotosDTO
{

    public int Id { get; set; }

    public string? Modelo { get; set; }

    public int Potencia { get; set; }

    public decimal Preco { get; set; }
    public string? Marca { get; set; }
    public string? Imagem { get; set; }




    public MotosDTO()
    {

    }

    public static MotosDTO MotosMToDto(MotosM moto)
    {

        var motoDto = new MotosDTO
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



    public static IEnumerable<MotosDTO> MotosMToDtoList(IEnumerable<MotosM> motos)
    {
        List<MotosDTO> motosDto = new List<MotosDTO>();
        foreach (var moto in motos)
        {

            var dto = MotosMToDto(moto);
            motosDto.Add(dto);
        }

        IEnumerable<MotosDTO> m = motosDto;

        return m;

    }

}
