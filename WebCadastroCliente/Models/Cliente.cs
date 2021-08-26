using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebCadastroCliente.Models
{
    /*
     * CLASSE CLIENTE, UTILIZEI ANNOTATION AFIM DE CRIAR VALIDAÇÕES E GERAÇÃO DA VIEW
     * E PENSANDO NO PADRÃO CODE FIRST PARA GERAÇÃO DO BANCO DE DADOS COM EF CORE   
     */
    public class Cliente
    { 
        public Cliente()
        {

        }

        public Cliente(string nome, DateTime dataNascimento, string cPF, string rG, RedeSocial redeSocial, List<Telefone> telefones, List<Endereco> enderecos )
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            CPF = cPF;
            RG = rG;
            RedesSociais = redeSocial;
            Telefones = telefones;
            Enderecos = enderecos;
        }

        [Key]
        public long ID { get; set; }

        [Display(Name = "Nome Completo")]
        [RegularExpression(@"^[a-zA-ZáàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ''-'\s]{1,40}$", ErrorMessage = "Números e caracteres especiais não são permitidos no nome.")]
        [Required(ErrorMessage = "Nome é de preenchimento obrigatório")]
        public string Nome { get; set; }

        [Display(Name = "Data de Nascimento")]
        [Required(ErrorMessage = "Data de Nascimento é de preenchimento obrigatório")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }


        [Display(Name = "CPF")]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}\-\d{2}$", ErrorMessage = "Por favor. Informe o cpf corretamente")]
        [Required(ErrorMessage = "CPF é de preenchimento obrigatório")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "CPF deve conter 14 caracteres somando . e -")]
        [Remote("ValidarCliente", "Clientes", ErrorMessage = "Cliente já cadastrado.")]
        public string CPF { get; set; }

        [Display(Name = "RG")]
        [MaxLength(15)]
        public string RG { get; set; }

        public RedeSocial RedesSociais { get; set; }

        public List<Telefone> Telefones { get; set; }

        public List<Endereco> Enderecos { get; set; }

    }
}
