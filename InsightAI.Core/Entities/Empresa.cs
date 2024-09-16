using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightAI.Core.Entities
{
    public class Empresa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public int EnderecoId { get; set; }
        public EnderecoEmpresa Endereco { get; set; }
        public int RamoEmpresaId { get; set; }
        public RamoEmpresa Ramo { get; set; }
        public ICollection<Colaborador> Colaboradores { get; set; }
        public ICollection<FeedbackEmpresa> Feedbacks { get; set; }
    }
}
