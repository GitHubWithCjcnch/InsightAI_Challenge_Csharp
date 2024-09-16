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
    public class ColaboradorRepository : AsyncRepository<Colaborador>, IColaboradorRepository
    {
        public ColaboradorRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
