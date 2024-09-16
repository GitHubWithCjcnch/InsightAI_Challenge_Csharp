using InsightAI.Core.Entities;
using InsightAI.Core.Interfaces.Repositories;
using InsightAI.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightAI.Infraestructure.Services
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IEmpresaRepository _repository;

        public EmpresaService(IEmpresaRepository repository)
        {
            _repository = repository;
        }

        public async Task<Empresa> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IReadOnlyList<Empresa>> ListAllAsync()
        {
            return await _repository.ListAllAsync();
        }

        public async Task<Empresa> AddAsync(Empresa entity)
        {
            return await _repository.AddAsync(entity);
        }

        public async Task UpdateAsync(Empresa entity)
        {
            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity != null)
            {
                await _repository.DeleteAsync(entity);
            }
        }

        public async Task<IReadOnlyList<Empresa>> GetByRamoEmpresaAsync(int ramoEmpresaId)
        {
            return await _repository.GetByRamoEmpresaAsync(ramoEmpresaId);
        }
    }
}
