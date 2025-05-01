
using Motos.Application.Interfaces;
using Motos.Domain.Interfaces;
using Motos.Application.DTO;
using System.Linq.Expressions;
using Motos.Domain.Entities;
using Microsoft.AspNetCore.JsonPatch;
using System.Web.Mvc;


namespace Motos.Application.Services
{
    public class MotosMService : IMotosMService
    {
        private readonly IMotosRepository _motosRepository;

        

        public MotosMService( IMotosRepository marcaRepository)
        {
            _motosRepository = marcaRepository;
        }

        public async Task<MotosDTO> Create(MotosM moto)
        {
           
            if (moto is null) throw new ArgumentNullException(nameof(moto));
          await  _motosRepository.Create(moto);

            return MotosDTO.MotosMToDto(moto);
        }

        public async Task<MotosDTO> Delete(int id)
        {
            var moto = await _motosRepository.GetByIdAsync(m => m.Id == id);
            if (moto is null) throw new ArgumentNullException(nameof(moto));
            await _motosRepository.Delete(moto);
            return MotosDTO.MotosMToDto(moto);
        }

        public async Task<MotosDTO> GetById(Expression<Func<MotosM, bool>> predicate)
        {
           var moto = await _motosRepository.GetByIdAsync(predicate);
            return MotosDTO.MotosMToDto(moto);
        }

        public async Task<MotosM> GetByIdSemDTO(Expression<Func<MotosM, bool>> predicate)
        {
            var moto = await _motosRepository.GetByIdAsync(predicate);
            return moto;
        }


        public async Task<IEnumerable<MotosDTO>> GetMotos()
        {
            var motos = await _motosRepository.GetAsync();
            if (motos is null)throw new ArgumentNullException(nameof(motos));
            return  MotosDTO.MotosMToDtoList(motos);
            

        }

        public async Task<MotosDTO> Pacth(JsonPatchDocument<MotosM> jsonPatch, int id)
        {
            var moto = await _motosRepository.GetByIdAsync(m => m.Id == id);
            if (moto is null) throw new ArgumentNullException(nameof(moto));
            jsonPatch.ApplyTo(moto);
            var motoDTO= MotosDTO.MotosMToDto(moto);
            return motoDTO;
        }

        public async Task<MotosDTO> Update(MotosM moto)
        {
           var motoComum = await _motosRepository.GetByIdAsync(m => m.Id == moto.Id);
            if (motoComum is null) throw new ArgumentNullException(nameof(motoComum));
            await _motosRepository.Update(motoComum);
            return MotosDTO.MotosMToDto(motoComum);
        }

        
    }
}
