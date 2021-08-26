using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebCadastroCliente.Models
{
    public class RedeSocial
    {

        /*
         * PARTINDO DO PRINCIPIO DA RESPONSABILIDADE UNICA DECIDE REALIZAR A SEPARACAO DE REDESOCIAL E CLIENTE
         * ASSIM CADA CLASSE PODE POSSUI SUAS INDIVUALIDADES E PODE SER REUTILIZADA POR OUTRAS.
         * COMO EM CLIENTE, UTILIZEI ANNOTATIONS.
         */

        public RedeSocial()
        {

        }

        public RedeSocial(string facebook, string linkedIn, string twitter, string instagram, long clienteID)
        {
            Facebook = facebook;
            LinkedIn = linkedIn;
            Twitter = twitter;
            Instagram = instagram;
            ClienteID = clienteID;
        }

        [Key]
        public long ID { get; set; }

        [Display(Name = "Facebook")]
        [MaxLength(250, ErrorMessage = "Endereco Facebook pode possuir 250 caracteres ou menos")]
        public string Facebook { get; set; }

        [Display(Name = "LinkedIn")]
        [MaxLength(250, ErrorMessage = "Endereco LinkedIn pode possuir 250 caracteres ou menos")]
        public string LinkedIn { get; set; }

        [Display(Name = "Twitter")]
        [MaxLength(250, ErrorMessage = "Endereco Twitter pode possuir 250 caracteres ou menos")]
        public string Twitter { get; set; }

        [Display(Name = "Instagram")]
        [MaxLength(250, ErrorMessage = "Endereco Instagram pode possuir 250 caracteres ou menos")]
        public string Instagram { get; set; }
        public long ClienteID { get;  set; }

    }
}
