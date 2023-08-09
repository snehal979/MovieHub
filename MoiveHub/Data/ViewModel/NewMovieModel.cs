using MoiveHub.Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace MoiveHub.Data.ViewModel
{
    public class NewMovieModel
    {
        public int Id { get; set; }

        [Display(Name = "MovieName")]
        [Required(ErrorMessage = "Name is required")]
        public string MovieName { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Display(Name = "Prize in Rs.")]
        [Required(ErrorMessage = "Price is required")]
        public double Prize { get; set; }

        [Display(Name = "MovieUrl")]
        [Required(ErrorMessage = "Movie poster URL is required")]
        public string MovieUrl { get; set; }

        [Display(Name = "Movie start date")]
        [Required(ErrorMessage = "Start date is required")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Movie end date")]
        [Required(ErrorMessage = "End date is required")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Select a category")]
        [Required(ErrorMessage = "Movie category is required")]
        public MovieCatogory MovieCatogory { get; set; }

        //Relationships
        [Display(Name = "Select actor(s)")]
        [Required(ErrorMessage = "Movie actor(s) is required")]
        public List<int> ActorId { get; set; }

        [Display(Name = "Select a cinema")]
        [Required(ErrorMessage = "Movie cinema is required")]
        public int CinemaId { get; set; }

        [Display(Name = "Select a producer")]
        [Required(ErrorMessage = "Movie producer is required")]
        public int ProducerId { get; set; }


    }
}
