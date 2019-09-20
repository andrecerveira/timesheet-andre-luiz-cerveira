using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeSheet.Domain.Entities
{
    public class Campanha
    {
        [Key]
        public int CampanhaId { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        public string Nome { get; set; }

        [ForeignKey("Produto")]
        [Display(Name = "ID do Produto")]
        public int ProdutoId { get; set; }

        [Display(Name = "Produto da Campanha")]
        public virtual Produto ProdutoDaCampanha { get; set; }
    }
}
