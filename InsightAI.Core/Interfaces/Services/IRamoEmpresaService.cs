using InsightAI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightAI.Core.Interfaces.Services
{
    public interface IRamoEmpresaService
    {
        Task<RamoEmpresa> GetByIdAsync(int id);
        Task<IReadOnlyList<RamoEmpresa>> ListAllAsync();
        Task<RamoEmpresa> AddAsync(RamoEmpresa entity);
        Task UpdateAsync(RamoEmpresa entity);
        Task DeleteAsync(int id);
    }

}
