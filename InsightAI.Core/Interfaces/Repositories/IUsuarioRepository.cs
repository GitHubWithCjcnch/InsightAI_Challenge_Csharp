using InsightAI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightAI.Core.Interfaces.Repositories
{
    public interface IUsuarioRepository : IAsyncRepository<Usuario>
    {
        Task<Usuario> GetByEmailAsync(string email);
    }
}
