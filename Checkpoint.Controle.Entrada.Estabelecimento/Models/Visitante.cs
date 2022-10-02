using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Checkpoint.Controle.Entrada.Estabelecimento.Models
{
    public class Visitante
    {
        [HiddenInput]
        public int Codigo { get; set; }
        public string? Nome { get; set; }
        public int Idade { get; set; }
        public long CPF { get; set; }
        public Sexo? Sexo { get; set; }
        [Display(Name = "Data de Entrada")]
        public DateTime DataEntrada { get; set; }
        [Display(Name = "Pessoa com Deficiência")]
        public bool PCD { get; set; }
    }
    public enum Sexo
    {
        Masculino, Feminino, [Display(Name = "Não Definido")] NaoDefinido
    }
}
