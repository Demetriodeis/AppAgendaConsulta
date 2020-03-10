using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppAgendaConsulta.Models
{
    public class ConsultaMedica : Entity
    {
        public Guid MedicoId { get; set; }

        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage ="O campo {0} precisa ter entre {2} e {1}", MinimumLength =2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(1000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1}", MinimumLength = 2)]
        public string Descricao { get; set; }

        [DisplayName("Data Consulta")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataConsulta { get; set; }

        [DisplayName("Data Cadastro")]
        public DateTime DataCadastro { get; set; }

        /*EF Relation*/
        public Medico Medico { get; set; }
    }
}
