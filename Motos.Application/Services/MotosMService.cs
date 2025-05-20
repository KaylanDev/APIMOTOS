
using Motos.Application.Interfaces;
using Motos.Domain.Interfaces;
using Motos.Application.DTO;
using System.Linq.Expressions;
using Motos.Domain.Entities;
using Microsoft.AspNetCore.JsonPatch;
using System.Web.Mvc;
using System.Threading.Tasks;


namespace Motos.Application.Services
{
    public class MotosMService : IMotosMService
    {
        private readonly IMotosRepository _motosRepository;
        private readonly IMarcaRepository _marcaRepository;

        private async Task<MotosM> AddMarca(MotosM motosM)
        {
            Marca marca = await _marcaRepository.GetByIdAsync(m => m.Id == motosM.MarcaId);
          motosM.Marca = marca;
            return motosM;
        }

        private async Task<IEnumerable<MotosM>> AddMarcaList(IEnumerable<MotosM>motosM)
        {
            foreach(var moto in motosM){


                Marca marca = await _marcaRepository.GetByIdAsync(m => m.Id == moto.MarcaId);
                moto.Marca = marca;
            }
            return motosM;
        }

        public MotosMService( IMotosRepository MotosRepository,IMarcaRepository marcaRepository)
        {
            _motosRepository = MotosRepository;
            _marcaRepository = marcaRepository;
        }

        public async Task<MotosDTO> Create(MotosDTO motoDto)
        {
           
            if (motoDto is null) throw new ArgumentNullException(nameof(motoDto));
           var Marca = await _marcaRepository.GetByIdAsync(m => m.NomeMarca.ToUpper() == motoDto.Marca.ToUpper());
            if(Marca is null) throw new ArgumentNullException("esta marca  N Existe!");
            MotosM moto = motoDto;
           
            moto.MarcaId = Marca.Id;
            await _motosRepository.Create(moto);

            return motoDto;
            
        }

        public async Task<MotosDTO> Delete(int id)
        {
            var moto = await _motosRepository.GetByIdAsync(m => m.Id == id);
            if (moto is null) throw new ArgumentNullException(nameof(moto));
            await _motosRepository.Delete(moto);
            MotosDTO motoDto =  moto;

            return motoDto;
        }

        public async Task<MotosDTO> GetById(int id)
        {
           var moto = await _motosRepository.GetByIdAsync(m => m.Id == id);
           await AddMarca(moto);
            MotosDTO motoDto = moto;

            return motoDto;

        }

      


        public async Task<IEnumerable<MotosDTO>> GetMotos()
        {
            var motos = await _motosRepository.GetAsync();
            if (motos is null)throw new ArgumentNullException(nameof(motos));
            var motosCmarca = await AddMarcaList(motos);
            var motosDto = MotosDTO.MotosMToDtoList(motos);
            return  motosDto;
            

        }

        public async Task<MotosDTO> Pacth(JsonPatchDocument<MotosM> jsonPatch, int id)
        {
            var moto = await _motosRepository.GetByIdAsync(m => m.Id == id);
            if (moto is null) throw new ArgumentNullException(nameof(moto));
          await  AddMarca(moto);
            jsonPatch.ApplyTo(moto);
            MotosDTO motoDTO= moto;

            return motoDTO;
        }

        public async Task<MotosDTO> Update(MotosDTO moto)
        {
            var motoComum = moto;
            await AddMarca(motoComum);
            if (motoComum is null) throw new ArgumentNullException(nameof(motoComum));
            await _motosRepository.Update(motoComum);
            MotosDTO motoDto = motoComum;
            return motoDto;
        }


    }
}
