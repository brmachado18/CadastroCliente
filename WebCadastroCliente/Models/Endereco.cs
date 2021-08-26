using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebCadastroCliente.Models
{
    public class Endereco
    {
        /*
         * PARTINDO DO PRINCIPIO DA RESPONSABILIDADE UNICA DECIDE REALIZAR A SEPARACAO DE ENDEREÇO E CLIENTE
         * ASSIM CADA CLASSE PODE POSSUI SUAS INDIVUALIDADES E PODE SER REUTILIZADA POR OUTRAS.
         * COMO EM CLIENTE, UTILIZEI ANNOTATIONS.
         * 
         * UMA BEM INTERESSANTE [Display(Name = "")] QUE CONCENTRA O VALOR DO LABEL UTILIZADO A PARTIR DAS TAG HELPERS DE VIEW
         * EM UM UNICO LOCAL. ASSIM CONSIGO GANHAR TEMPO CASO SEJA NECESSARIO RELIZAR UMA ALTERAÇÃO NESTE CAMPO POIS E REPLICADA 
         * EM TODAS VIEWS
         */
        public Endereco()
        {

        }

        public Endereco(string cep, string logradouro, int numero, string complemento, string bairro, string cidade, string estado, long clienteID)
        {
            Cep = cep;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            ClienteID = clienteID;
        }

        [Key]
        public long ID { get; set; }

        public string Cep { get; set; }

        [Display(Name = "Logradouro")]
        [MaxLength(50, ErrorMessage = "Nome do logradouro pode possuir 50 caracteres ou menos")]
        [StringLength(50)]
        public string Logradouro { get; set; }
   
        [Display(Name = "Nº")]
        public int Numero { get; set; }

        [Display(Name = "Complemento")]
        [MaxLength(50, ErrorMessage = "O Complemento pode possuir 50 caracteres ou menos")]
        [StringLength(50)]
        public string Complemento { get; set; }

        [Display(Name = "Bairro")]
        [MaxLength(30, ErrorMessage = "Nome do bairro pode possuir 30 caracteres ou menos")]
        [StringLength(30)]
        public string Bairro { get; set; }

        [Display(Name = "Cidade")]
        [RegularExpression(@"^[a-zA-ZáàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ''-'\s]{1,40}$", ErrorMessage = "Números e caracteres especiais não são permitidos no nome da cidade.")]
        [MaxLength(30, ErrorMessage = "Nome da cidade pode possuir 30 caracteres ou menos")]
        public string Cidade { get; set; }

        [Display(Name = "Estado")]
        public string Estado { get; set; }

        public long ClienteID { get; set; }
    }
}
