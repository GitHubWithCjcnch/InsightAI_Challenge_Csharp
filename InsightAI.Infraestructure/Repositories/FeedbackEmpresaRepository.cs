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
    public class FeedbackEmpresaRepository : AsyncRepository<FeedbackEmpresa>, IFeedbackEmpresaRepository
    {
        public FeedbackEmpresaRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
