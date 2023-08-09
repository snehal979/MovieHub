using MoiveHub.Data.BaseGeneric;
using MoiveHub.Models;

namespace MoiveHub.Data.Services
{
    public class ProducerServices : EntityBaseRespository<Producer>, IProducerServices
    {
        public ProducerServices(AppDbContext context) : base(context)
        {

        }
    }
   
}
