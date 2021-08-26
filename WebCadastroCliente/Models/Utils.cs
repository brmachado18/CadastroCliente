using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace WebCadastroCliente.Models
{
    public static class Utils
    {
        /*
         * ESTA STATIC CLASSE DE UTILIDADES FOI CRIADA PARA SE CRIAR METODOS MAIS COMUNS EM OUTRAS FUNCIONALIDADES DO SISTEMA
         * PODENDO SER COMPARTILHADAS ENTRE SI.
         * 
         * EXEMPLO: UM METODO PARA PREENCHER O SELECT COM ESTADOS.
         */
        public static List<SelectListItem> GetSelectListEstados()
        {
            // PODE SER UTILIZADO UMA IMPLEMENTAÇÃO COM A BUSCA DE VALORES EM UM BANCO DE DADOS
            // MAS PARA DEMONSTRAÇÃO CRIEI UM PREENCHIMENTO MANUAL
            
            List<SelectListItem> _selectListEstados = new List<SelectListItem>();
            var _estados = new List<string>()
            {
                "Acre",
                "Alagoas",
                "Amapá",
                "Amazonas",
                "Bahia",
                "Ceará",
                "Distrito Federal",
                "Espírito Santo",
                "Goiás",
                "Maranhão",
                "Mato Grosso",
                "Mato Grosso do Sul",
                "Minas Gerais",
                "Pará",
                "Paraíba",
                "Paraná",
                "Pernambuco",
                "Piauí",
                "Rio de Janeiro",
                "Rio Grande do Norte",
                "Rio Grande do Sul",
                "Rondônia",
                "Roraima ",
                "Santa Catarina",
                "São Paulo",
                "Sergipe",
                "Tocantins",
                "Estrangeiro"
            };

            foreach(var estado in _estados)
            {
                _selectListEstados.Add(new SelectListItem
                {
                    Value = estado,
                    Text = estado
                });
            }

            return _selectListEstados;
        }
    }
}
