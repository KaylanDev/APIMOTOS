using Motos.Application.DTO;
using Motos.Application.DTOs;
using Motos.Application.Interfaces;
using Motos.Domain.Entities;
using Motos.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Motos.Application.Services
{
    public class MarcaService : IMarcaService
    {
        private readonly IMarcaRepository _marcaRepository;

        public MarcaService(IMarcaRepository marcaRepository)
        {
            _marcaRepository = marcaRepository;
        }

        public Task<Marca> GetById(int id)
        {
            var marca = _marcaRepository.GetByIdAsync(m => m.Id == id);
            return marca;
        }


        public async Task<IEnumerable<Marca>> GetMarcas()
        {
         
            var marcas = await _marcaRepository.GetAsync();
            return marcas;
        }

        public async Task<Marca> Update(Marca marca)
        {
            if(marca is null) throw new ArgumentNullException(nameof(marca));

            var marcaUp = await _marcaRepository.Update(marca);
            return marcaUp;

        }
        public Task<Marca> Create(Marca marca)
        {
           if (marca is null) throw new ArgumentNullException(nameof(marca));
            var marcaUp = _marcaRepository.Create(marca);
            return marcaUp;
        }

        public async Task<Marca> Delete(int id)
        {
            var marca = await _marcaRepository.GetByIdAsync(m => m.Id == id);
            if (marca is null) throw new ArgumentNullException(nameof(marca));
            var marcaDel = await _marcaRepository.Delete(marca);
            return marcaDel;
        }

        public async Task<IEnumerable<MarcaDTO>> GetMotosPorMarca()
        {
           var marcasCMotos = await _marcaRepository.GetMotosByMarca();
            var MarcasDto = MarcaDTO.MarcaToMarcaDTOList(marcasCMotos);
            foreach(var marca in MarcasDto)
            {
                var moto = marcasCMotos.FirstOrDefault(m => m.Id == marca.Id);
                marca.Motos = MotosDTO.MotosMToDtoList(moto.Motos);
            }
            return MarcasDto;
        }

        public async Task<MarcaDTO> GetMotoPorMarcaOne(int id)
        {
            var marca = await _marcaRepository.GetMotosByMarcaOne(m => m.Id == id);
            MarcaDTO marcaDto = marca;
            marcaDto.Motos = MotosDTO.MotosMToDtoList(marca.Motos);
            return marcaDto;
        }
    }
}
