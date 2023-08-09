using MoiveHub.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace MoiveHub.Models
{
    public class Producer: IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "ProducerUrl")]
        public string ProducerUrl { get; set; }
        [Display(Name = "ProducerName")]
        public string ProducerName { get; set; }
        [Display(Name = "Bio")]
        public string Bio { get; set; }

        //Relationship
        public List<Movie> Movies { get; set; }
    }
}
