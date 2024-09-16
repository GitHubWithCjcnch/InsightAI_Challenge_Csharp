using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightAI.Core.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string EmailCorporativo { get; set; }
        public string Senha { get; set; }
        public ICollection<Colaborador> Colaboradores { get; set; }
        public ICollection<FeedbackEmpresa> Feedbacks { get; set; }
    }

}
