


using Motos.Application.DTOs;
using Motos.Domain.Entities;
using System.Linq.Expressions;

namespace Motos.Application.Interfaces;

public interface IMarcaService
{
    public Task<IEnumerable<Marca>> GetMarcas();
    public Task<Marca> GetById(int id);
    public Task<IEnumerable<MarcaDTO>> GetMotosPorMarca();
    public Task<MarcaDTO> GetMotoPorMarcaOne(int id);
    public Task<Marca> Create(Marca marca);
    public Task<Marca> Update(Marca marca);
    public Task<Marca> Delete(int id);

}
