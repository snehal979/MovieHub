using MoiveHub.Data.BaseGeneric;
using MoiveHub.Models;

namespace MoiveHub.Data.Services
{
    public class CinemaServices : EntityBaseRespository<Cinema>, ICinemaServices
    {
        public CinemaServices(AppDbContext context) : base(context)
        {

        }
    }
   
}
