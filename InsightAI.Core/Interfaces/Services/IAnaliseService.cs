using InsightAI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightAI.Core.Interfaces.Services
{
    public interface IAnaliseService
    {
        Task<Analise> GetByIdAsync(int id);
        Task<IReadOnlyList<Analise>> ListAllAsync();
        Task<Analise> AddAsync(Analise entity);
        Task UpdateAsync(Analise entity);
        Task DeleteAsync(int id);
    }
}
