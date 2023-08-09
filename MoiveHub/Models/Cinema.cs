using MoiveHub.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace MoiveHub.Models
{
    public class Cinema: IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="CinemaUrl")]
        public string CinemaUrl { get; set; }
        [Display(Name = "CinemaName")]
        public string CinemaName { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }


        //Relationship
        public List<Movie> Movies { get; set; }
    }
}
