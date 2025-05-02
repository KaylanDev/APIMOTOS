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
    [JsonIgnore]
    public Marca? MarcaM { get;  set; } 
    public string? Imagem { get; set; }

    public MotosDTO(int id, string? modelo, int potencia, decimal preco, string? marca, string? imagem,Marca marca1)
    {
        Id = id;
        Modelo = modelo;
        Potencia = potencia;
        Preco = preco;
        Marca = marca;
        Imagem = imagem;
        MarcaM = marca1;
    }

    public static MotosDTO MotosMToDto(MotosM moto)
    {

        var motoDto = new MotosDTO(moto.Id, moto.Modelo, moto.Potencia, moto.Preco, moto.Marca.NomeMarca, moto.Imagem,moto.Marca);
       

        return motoDto;

    }

    public static MotosM MotosDTOToMotosM(MotosDTO motoDto)
    {
        var moto = new MotosM
        {
            Id = motoDto.Id,
            Modelo = motoDto.Modelo,
            Potencia = motoDto.Potencia,
            Preco = motoDto.Preco,
            Imagem = motoDto.Imagem,
            MarcaId = motoDto.MarcaM.Id,
            Marca = motoDto.MarcaM

        };

        return moto;

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
