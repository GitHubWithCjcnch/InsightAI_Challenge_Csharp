using InsightAI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightAI.Core.Interfaces.Services
{
    public interface IEnderecoEmpresaService
    {
        Task<EnderecoEmpresa> GetByIdAsync(int id);
        Task<IReadOnlyList<EnderecoEmpresa>> ListAllAsync();
        Task<EnderecoEmpresa> AddAsync(EnderecoEmpresa entity);
        Task UpdateAsync(EnderecoEmpresa entity);
        Task DeleteAsync(int id);
    }

}
