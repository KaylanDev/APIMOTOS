using Motos.Application.DTO;
using Motos.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motos.Application.DTOs
{
    public class MarcaDTO
    {
        public int Id { get; set; }
        public string Marca { get; set; }

      
        public IEnumerable<MotosDTO>? Motos { get; set; } = new List<MotosDTO>();

        public MarcaDTO()
        {

        }

        public static implicit operator MarcaDTO(Marca marca)
        {
            var marcaDto = new MarcaDTO
            {
                Id = marca.Id,
                Marca = marca.NomeMarca,

            };
            return marcaDto;
        }

        public static implicit operator Marca(MarcaDTO marcaDto)
        {
            var marca = new Marca
            {
                Id = marcaDto.Id,
                NomeMarca = marcaDto.Marca,

            };
            return marca;
        }

        public static List<MarcaDTO> MarcaToMarcaDTOList(IEnumerable<Marca> marcas)
        {
            List<MarcaDTO> marcasDTO = new List<MarcaDTO>();
            foreach(var marca in marcas)
            {
                var marcaDto = marca;
                marcasDTO.Add(marca);
            }
            return marcasDTO;
        }
    }
}
