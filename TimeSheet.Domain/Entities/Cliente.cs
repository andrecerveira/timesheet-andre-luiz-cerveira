using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TimeSheet.Domain.Entities
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        public string Nome { get; set; }

        public IEnumerable<Produto> Produtos { get; set; }
    }
}
