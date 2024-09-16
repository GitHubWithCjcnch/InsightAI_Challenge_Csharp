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
    public class EnderecoEmpresaService : IEnderecoEmpresaService
    {
        private readonly IEnderecoEmpresaRepository _repository;

        public EnderecoEmpresaService(IEnderecoEmpresaRepository repository)
        {
            _repository = repository;
        }

        public async Task<EnderecoEmpresa> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IReadOnlyList<EnderecoEmpresa>> ListAllAsync()
        {
            return await _repository.ListAllAsync();
        }

        public async Task<EnderecoEmpresa> AddAsync(EnderecoEmpresa entity)
        {
            return await _repository.AddAsync(entity);
        }

        public async Task UpdateAsync(EnderecoEmpresa entity)
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
