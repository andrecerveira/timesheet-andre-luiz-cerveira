using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeSheet.Domain.Entities
{
    public class Job
    {
        [Key]
        public int JobId { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        public string Nome { get; set; }

        [ForeignKey("Campanha")]
        [Display(Name = "ID da Campanha")]
        public int CampanhaId { get; set; }

        [Display(Name = "Campanha do Job")]
        public virtual Campanha CampanhaDoJob { get; set; }
    }
}
