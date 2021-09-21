using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace ProjetoLoja.Models
{
    public class Funcionario
    {

        [Display(Name = "Código do Funcionário")]
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [Remote("Cod_Func_Uni", "funcionario", ErrorMessage = "Funcionário já cadastrado")]
       
        public int Func_Cod { get; set; }

        [Display(Name = "Nome do Funcionário")]
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        public string Func_Nome { get; set; }

        [Display(Name = "RG do funcionário")]
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [RegularExpression(@"^\d{2}\.\d{3}\.\d{3}-\d{1}$", ErrorMessage = "Digite um RG válido!")]
        public string Func_Rg { get; set; }

        [Display(Name = "CPF do funcionário")]
        [Required(ErrorMessage = "CPF obrigatório")]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "Digite um CPF válido!")]
        public string Func_Cpf { get; set; }

        [Display(Name = "Data de nascimento")]
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        
        public DateTime Func_DataNasc
        {
            get
            {
                return this.func_datanasc.HasValue
                    ? this.func_datanasc.Value
                    : DateTime.Now;
            }

            set
            {
                this.func_datanasc = value;
            }
        }
        private DateTime? func_datanasc = null;

        [Display(Name = "Cargo do funcionário")]
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        public string Func_Cargo { get; set; }

        [Display(Name = "Endereço")]
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Digite entre 5 e 100 caracteres")]
        public string Func_Endereco { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Digite um E-mail válido")]
        public string Func_Email { get; set; }

        [Display(Name = "Celular")]
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        public string Func_Celular { get; set; }

        

        

    }
}