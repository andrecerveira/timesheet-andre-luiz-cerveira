using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeSheet.Domain.Entities
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        public string Nome { get; set; }

        [ForeignKey("Cliente")]
        [Display(Name = "ID do Departamento")]
        public int DepartamentoId { get; set; }

        [Display(Name = "Departamento do Usuário")]
        public virtual Departamento DepartamentoDoUsuario { get; set; }

        //public Departamento DepartamentoDoUsfvfdfvfçµuario { get; set; }
    }
}
