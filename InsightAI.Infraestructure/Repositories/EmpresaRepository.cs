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
    public class EmpresaRepository : AsyncRepository<Empresa>, IEmpresaRepository
    {
        public EmpresaRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IReadOnlyList<Empresa>> GetByRamoEmpresaAsync(int ramoEmpresaId)
        {
            return await _dbContext.Empresas
                .Where(e => e.RamoEmpresaId == ramoEmpresaId)
                .ToListAsync();
        }
    }
}
