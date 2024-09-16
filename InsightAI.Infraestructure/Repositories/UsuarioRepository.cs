using InsightAI.Core.Entities;
using InsightAI.Infraestructure.Data;
using InsightAI.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightAI.Infraestructure.Repositories
{
    public class UsuarioRepository : AsyncRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Usuario> GetByEmailAsync(string email)
        {
            return await _dbContext.Usuarios
                .FirstOrDefaultAsync(u => u.EmailCorporativo == email);
        }
    }
}
