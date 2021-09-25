using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace ProjetoLoja.Models
{
    public class Cliente
    {
        [Display(Name = "Nome do Cliente")]
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        public string Cliente_Nome { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "CPF obrigatório")]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "Digite um CPF valido!")]
        
        public string Cliente_Cpf { get; set; }

        [Display(Name = "Data de nascimento")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        
        public DateTime Cliente_DataNasc
        {
            get
            {
                return this.cliente_datanasc.HasValue
                    ? this.cliente_datanasc.Value
                    : DateTime.Now;
            }

            set
            {
                this.cliente_datanasc = value;
            }
        }
        private DateTime? cliente_datanasc = null;

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Digite um Email válido!")]
        public string Cliente_Email { get; set; }

        [Display(Name = "Celular do cliente")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Cliente_Celular { get; set; }

        [Display(Name = "Endereço do cliente")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Digite entre 5 e 100 caracteres")]
        public string Cliente_Endereco { get; set; }
    }
}