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
    public class AnaliseService : IAnaliseService
    {
        private readonly IAnaliseRepository _repository;

        public AnaliseService(IAnaliseRepository repository)
        {
            _repository = repository;
        }

        public async Task<Analise> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IReadOnlyList<Analise>> ListAllAsync()
        {
            return await _repository.ListAllAsync();
        }

        public async Task<Analise> AddAsync(Analise entity)
        {
            return await _repository.AddAsync(entity);
        }

        public async Task UpdateAsync(Analise entity)
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
