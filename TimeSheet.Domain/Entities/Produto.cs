using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeSheet.Domain.Entities
{
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        public string Nome { get; set; }

        [ForeignKey("Cliente")]
        [Display(Name = "ID do Cliente")]
        public int ClienteId { get; set; }

        [Display(Name = "Cliente do Produto")]
        public virtual Cliente ClienteDoProduto { get; set; }
    }
}
