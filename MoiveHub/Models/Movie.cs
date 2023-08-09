using MoiveHub.Data.Base;
using MoiveHub.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoiveHub.Models
{
    public class Movie : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string MovieName { get; set; }
        public string Description { get; set; }
        public double Prize { get; set; }
        public string MovieUrl { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MovieCatogory MovieCatogory { get; set; }

        //relationship
        public List<Actor_Movie> Actor_Movies { get; set; }

        //Cinema
        public int CinemaId { get; set; }
        [ForeignKey("CinemaId")]
        public Cinema Cinema { get; set; }

        //Producer
        public int ProducerId { get; set; }
        [ForeignKey("ProducerId")]
        public Producer Producer { get; set; }
    }
}
