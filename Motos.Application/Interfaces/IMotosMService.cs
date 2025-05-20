
using Microsoft.AspNetCore.JsonPatch;
using Motos.Application.DTO;
using Motos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Motos.Application.Interfaces;

public interface IMotosMService
{
    public Task<IEnumerable<MotosDTO>> GetMotos();
    public Task<MotosDTO> GetById(int id);
    public Task<MotosDTO> Create(MotosDTO moto);
    public Task<MotosDTO> Update(MotosDTO moto);
    public Task<MotosDTO> Pacth(JsonPatchDocument<MotosM> jsonPatch, int id);
    public Task<MotosDTO> Delete(int id);
}
