using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace ProjetoLoja.Models
{
    public class Jogo
    {
        [Display(Name = "Código do Jogo")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [RegularExpression(@"^[0-9]{7}", ErrorMessage = "O código precisa ter 7 números!")]
        public int Jogo_Cod { get; set; }

        [Display(Name = "Nome do Jogo")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Jogo_Nome { get; set; }

        [Display(Name = "Versão")]
        public string Jogo_Versao { get; set; }

        [Display(Name = "Desenvolvedor do Jogo")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [StringLength(50, ErrorMessage = "Este campo deve conter no máximo 50 caracteres")]
        public string Jogo_Desenv { get; set; }

        [Display(Name = "Gênero do jogo")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [StringLength(30, ErrorMessage = "Digite no máximo 30 caracteres")]
        public string Jogo_Genero { get; set; }

        [Display(Name = "Faixa Etária")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Jogo_FxEtaria { get; set; }

        [Display(Name = "Plataforma(s)")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [StringLength(25, ErrorMessage = "Digite no máximo 25 caracteres")]
        public string Jogo_Plataforma { get; set; }

        [Display(Name = "Ano de Lançamento")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [RegularExpression(@"^[0-9]{4}", ErrorMessage = "Digite 4 números!")]
        public int Jogo_Lanc { get; set; }

        [Display(Name = "Sinopse")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [StringLength(500, MinimumLength = 20, ErrorMessage = "Digite de 20 a 500 caracteres")]
        public string Jogo_Sinopse { get; set; }
    }
}