using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TimeSheet.Domain.Entities
{
    public class Departamento
    {
        [Key]
        public int DepartamentoId { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        public string Nome { get; set; }

        public IEnumerable<Usuario> Usuarios { get; set; }
    }
}
