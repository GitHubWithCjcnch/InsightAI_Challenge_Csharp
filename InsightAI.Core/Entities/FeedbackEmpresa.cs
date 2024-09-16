using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightAI.Core.Entities
{
    public class FeedbackEmpresa
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        public ICollection<Analise> Analises { get; set; }
    }

}
