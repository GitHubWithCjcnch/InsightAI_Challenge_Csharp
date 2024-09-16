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
    public class ColaboradorService : IColaboradorService
    {
        private readonly IColaboradorRepository _repository;

        public ColaboradorService(IColaboradorRepository repository)
        {
            _repository = repository;
        }

        public async Task<Colaborador> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IReadOnlyList<Colaborador>> ListAllAsync()
        {
            return await _repository.ListAllAsync();
        }

        public async Task<Colaborador> AddAsync(Colaborador entity)
        {
            return await _repository.AddAsync(entity);
        }

        public async Task UpdateAsync(Colaborador entity)
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
    }
}
