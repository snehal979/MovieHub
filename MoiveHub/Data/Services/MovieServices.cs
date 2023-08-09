using Microsoft.EntityFrameworkCore;
using MoiveHub.Data.Base;
using MoiveHub.Data.BaseGeneric;
using MoiveHub.Data.Enum;
using MoiveHub.Data.ViewModel;
using MoiveHub.Models;

namespace MoiveHub.Data.Services
{
    public class MovieServices : EntityBaseRespository<Movie>, IMovieServices
    {
        private readonly AppDbContext _context;
        public MovieServices(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewMovieAsync(NewMovieModel data)
        {
            var newMovie = new Movie()
            {
                MovieName = data.MovieName,
                Description = data.Description,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                Prize = data.Prize,
                CinemaId = data.CinemaId,
                MovieCatogory = data.MovieCatogory,
                ProducerId = data.ProducerId,
                MovieUrl = data.MovieUrl
            };
            await _context.Movies.AddAsync(newMovie);
            await _context.SaveChangesAsync();

            //Add Movie Actors
            foreach (var actorId in data.ActorId)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieId = newMovie.Id,
                    ActorId = actorId
                };
                await _context.Actor_Movies.AddAsync(newActorMovie);
            }
            await _context.SaveChangesAsync();


        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movieDetail = await _context.Movies
                .Include(c => c.Cinema)
                .Include(p => p.Producer)
                .Include(am => am.Actor_Movies).ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(n => n.Id == id);
           
            return movieDetail;
        }

        public async Task<MovieDropDownListModel> GetNewMovieDropdownsValues()
        {
            var response = new MovieDropDownListModel()
            {
                Actors = await _context.Actors.OrderBy(n => n.ActorName).ToListAsync(),
                Cinemas = await _context.Cinemas.OrderBy(n => n.CinemaName).ToListAsync(),
                Producers = await _context.Producers.OrderBy(n => n.ProducerName).ToListAsync()
            };

            return response;
        }


        public async Task UpdateNewMovieAsync(NewMovieModel data)
        {
            var db = await _context.Movies.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (db != null)
            {
                db.MovieName = data.MovieName;
                db.Description = data.Description;
                db.Prize = data.Prize;
                db.MovieUrl = data.MovieUrl;
                db.CinemaId = data.CinemaId;
                db.StartDate = data.StartDate;
                db.EndDate = data.EndDate;
                db.MovieCatogory = data.MovieCatogory;
                db.ProducerId = data.ProducerId;
                await _context.SaveChangesAsync();
            }

            //Remove existing actors
            var existingActorsDb = _context.Actor_Movies.Where(n => n.MovieId == data.Id).ToList();
            _context.Actor_Movies.RemoveRange(existingActorsDb);
            await _context.SaveChangesAsync();

            //Add Movie Actors
            foreach (var actorId in data.ActorId)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieId = data.Id,
                    ActorId = actorId
                };
                await _context.Actor_Movies.AddAsync(newActorMovie);
            }
            await _context.SaveChangesAsync();
        }
       
    }


}


