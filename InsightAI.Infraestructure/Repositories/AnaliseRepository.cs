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
    public class AnaliseRepository : AsyncRepository<Analise>, IAnaliseRepository
    {
        public AnaliseRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
