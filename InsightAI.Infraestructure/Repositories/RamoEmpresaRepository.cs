using InsightAI.Core.Entities;
using InsightAI.Infraestructure.Data;
using InsightAI.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightAI.Infraestructure.Repositories
{
    public class RamoEmpresaRepository : AsyncRepository<RamoEmpresa>, IRamoEmpresaRepository
    {
        public RamoEmpresaRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
