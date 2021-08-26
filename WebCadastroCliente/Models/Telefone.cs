using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebCadastroCliente.Models
{

    public class Telefone
    {
        /*
         * PARTINDO DO PRINCIPIO DA RESPONSABILIDADE UNICA DECIDE REALIZAR A SEPARACAO DE TELEFONE E CLIENTE
         * ASSIM CADA CLASSE PODE POSSUI SUAS INDIVUALIDADES E PODE SER REUTILIZADA POR OUTRAS.
         * COMO EM CLIENTE, UTILIZEI ANNOTATIONS.
         */

        public Telefone()
        {

        }

        public Telefone(string numero, string identificador, long clienteID)
        {
            Numero = numero;
            Identificador = identificador;
            ClienteID = clienteID;
        }

        [Key]
        public long ID { get; set; }

        [Display(Name = "Telefone")]
        [StringLength(15, MinimumLength = 14, ErrorMessage = "Por favor. Informe o telefone corretamente")]
        public string Numero { get; set; }

        [Display(Name = "Identificação")]
        public string Identificador { get; set; }
        public long ClienteID { get; set; }
    }
}
