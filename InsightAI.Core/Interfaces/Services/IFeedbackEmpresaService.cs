using InsightAI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightAI.Core.Interfaces.Services
{
    public interface IFeedbackEmpresaService
    {
        Task<FeedbackEmpresa> GetByIdAsync(int id);
        Task<IReadOnlyList<FeedbackEmpresa>> ListAllAsync();
        Task<FeedbackEmpresa> AddAsync(FeedbackEmpresa entity);
        Task UpdateAsync(FeedbackEmpresa entity);
        Task DeleteAsync(int id);
    }
}
