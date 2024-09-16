using InsightAI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightAI.Core.Interfaces.Services
{
    public interface IColaboradorService
    {
        Task<Colaborador> GetByIdAsync(int id);
        Task<IReadOnlyList<Colaborador>> ListAllAsync();
        Task<Colaborador> AddAsync(Colaborador entity);
        Task UpdateAsync(Colaborador entity);
        Task DeleteAsync(int id);
    }
}
