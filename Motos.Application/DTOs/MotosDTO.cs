using Motos.Domain.Entities;
using System.IO.Pipes;
using System.Numerics;
using System.Text.Json.Serialization;

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
    public static implicit operator MotosDTO(MotosM moto)
    {

        var motoDto = new MotosDTO
        {
            Id = moto.Id,
            Modelo = moto.Modelo,
            Potencia = moto.Potencia,
            Preco = moto.Preco,
            Imagem = moto.Imagem,
            Marca = moto.Marca?.NomeMarca
        };


        return motoDto;

    }

    public static implicit operator MotosM(MotosDTO motoDto)
    {
        var moto = new MotosM
        {
            Id = motoDto.Id,
            Modelo = motoDto.Modelo,
            Potencia = motoDto.Potencia,
            Preco = motoDto.Preco,
            Imagem = motoDto.Imagem,

        };
        return moto;
    }




    

    public static IEnumerable<MotosDTO> MotosMToDtoList(IEnumerable<MotosM> motos)
    {
        List<MotosDTO> motosDto = new List<MotosDTO>();
        foreach (var moto in motos)
        {

            MotosDTO dto = moto;
            motosDto.Add(dto);
        }

        IEnumerable<MotosDTO> m = motosDto;

        return m;

    }
    

}
