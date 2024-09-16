using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightAI.Core.Entities
{
    public class Analise
    {
        public int Id { get; set; }
        public string Resultados { get; set; }
        public DateTime Data { get; set; }
        public int FeedbackEmpresaId { get; set; }
        public FeedbackEmpresa FeedbackEmpresa { get; set; }
    }

}
