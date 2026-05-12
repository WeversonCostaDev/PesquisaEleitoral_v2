using System.ComponentModel.DataAnnotations;

namespace PesquisaEleitoral_v2.Models
{
    public class IntencaoDeVoto
    {
        public int IntencaoDeVotoId { get; set; }
        [Required]
        public int EleitorId { get; set; }
        [Required]
        public int CandidatoId { get; set; }
        [Required]
        public int PesquisaId { get; set; }
        public Eleitor Eleitor { get; set; } = null!;
        public Candidato Candidato { get; set; } = null!;
        public Pesquisa Pesquisa { get; set; } = null!;
        public DateTime DataRegistro { get; set; }
    }
}
