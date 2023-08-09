using MoiveHub.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace MoiveHub.Models
{
    public class Actor: IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="ActorUrl")]
        [Required(ErrorMessage = "Profile Picture is required")]
        public string ActorUrl { get; set; }

        [Display(Name = "ActorName")]
        [Required(ErrorMessage = "Full Name is required")]
        public string ActorName { get; set; }


        [Display(Name = "Bio")]
        [Required(ErrorMessage = "Bio is required")]
        public string Bio { get; set; }

        //relation
        public List<Actor_Movie> Actor_Movies { get; set; }
    }
}
