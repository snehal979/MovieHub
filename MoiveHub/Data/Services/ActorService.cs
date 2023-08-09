using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using MoiveHub.Data.BaseGeneric;
using MoiveHub.Models;

namespace MoiveHub.Data.Services
{
    public class ActorService : EntityBaseRespository<Actor>, IActorServices
    {
        public ActorService(AppDbContext context) : base(context)
        {

        }
    }
    //public class ActorService : IActorServices
    //{
    //    private readonly AppDbContext _context;
    //    public ActorService(AppDbContext context)
    //    {
    //        _context=context;
    //    }

    //    public async Task AddAsync(Actor actor)
    //    {
    //        await _context.Actors.AddAsync(actor);
    //        await _context.SaveChangesAsync();
    //    }

    //    public async Task DeleteAsync(int id)
    //    {
    //        var result = await _context.Actors.FirstOrDefaultAsync(n => n.Id ==id);
    //        _context.Actors.Remove(result);
    //        await _context.SaveChangesAsync();
    //    }

    //    public async Task<IEnumerable<Actor>> GetAllAsync()
    //    {
    //        var result = await _context.Actors.ToListAsync();
    //        return result;
    //    }

    //    public async Task<Actor> GetByIdAsync(int id)
    //    {
    //        var result = await _context.Actors.FirstOrDefaultAsync(n => n.Id ==id);
    //        return result;
    //    }

    //    public async Task UpdateAsync(int id, Actor nameActor)
    //    {
    //        _context.Update(nameActor);
    //        await _context.SaveChangesAsync();

    //    }
    //}
}
