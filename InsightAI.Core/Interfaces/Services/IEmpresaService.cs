using InsightAI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightAI.Core.Interfaces.Services
{
    public interface IEmpresaService
    {
        Task<Empresa> GetByIdAsync(int id);
        Task<IReadOnlyList<Empresa>> ListAllAsync();
        Task<Empresa> AddAsync(Empresa entity);
        Task UpdateAsync(Empresa entity);
        Task DeleteAsync(int id);
        Task<IReadOnlyList<Empresa>> GetByRamoEmpresaAsync(int ramoEmpresaId);
    }
}
