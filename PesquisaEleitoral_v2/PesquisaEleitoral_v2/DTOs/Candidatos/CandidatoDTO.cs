using PesquisaEleitoral_v2.Models;
using System.ComponentModel.DataAnnotations;

namespace PesquisaEleitoral_v2.DTOs.Candidatos
{
    public class CandidatoDTO
    {
        [Required(ErrorMessage ="Informe o nome.")]
        [StringLength(40, ErrorMessage =("Informe no máximo 40 caracteres."))]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage ="Informe o nome.")]
        [StringLength(6, ErrorMessage ="Informe no máximo 6 letras.")]
        public string Partido { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe o nome.")]
        public int Numero { get; set; }
    }
}
