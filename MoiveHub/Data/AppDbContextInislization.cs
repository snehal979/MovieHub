using MoiveHub.Data.Enum;
using MoiveHub.Models;

namespace MoiveHub.Data
{
    public class AppDbContextInislization
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            try
            {

                using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
                {
                    var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                    context.Database.EnsureCreated();

                    //cinemas
                    if (!context.Cinemas.Any())
                    {
                        var listCinema = new List<Cinema>()
                   {
                       new Cinema()
                       {
                            CinemaName = "Cinema 1",
                                   CinemaUrl = "http://dotnethow.net/images/cinemas/cinema-1.jpeg",
                                    Description = "This is the description of the first cinema"
                       },
                       new Cinema()
                       {
                             CinemaName = "Cinema 2",
                                    CinemaUrl= "http://dotnethow.net/images/cinemas/cinema-2.jpeg",
                                    Description= "This is the description of the first cinema"
                       },
                       new Cinema()
                       {
                            CinemaName = "Cinema 3",
                           CinemaUrl = "http://dotnethow.net/images/cinemas/cinema-3.jpeg",
                            Description = "This is the description of the first cinema"
                       },

                   };
                        context.Cinemas.AddRange(listCinema);
                        context.SaveChanges();
                    }

                    //Actors

                    if (!context.Actors.Any())
                    {
                        var listActor = new List<Actor>()
                    {
                        new Actor()
                        {
                              ActorName = "Actor 1",
                              Bio = "This is the Bio of the first actor",
                              ActorUrl= "http://dotnethow.net/images/actors/actor-1.jpeg"

                        },
                        new Actor()
                        {
                             ActorName = "Actor 2",
                             Bio = "This is the Bio of the second actor",
                             ActorUrl  = "http://dotnethow.net/images/actors/actor-2.jpeg"
                        },
                        new Actor()
                        {
                              ActorName = "Actor 3",
                              Bio = "This is the Bio of the second actor",
                              ActorUrl = "http://dotnethow.net/images/actors/actor-3.jpeg"
                        }
                    };
                        context.Actors.AddRange(listActor);
                        context.SaveChanges();

                    }
                    //Producers
                    if (!context.Producers.Any())
                    {
                        var listProducer = new List<Producer>()
                    {
                                 new Producer()
                                 {
                                      ProducerName = "Producer 1",
                                       Bio = "This is the Bio of the first actor",
                                       ProducerUrl = "http://dotnethow.net/images/producers/producer-1.jpeg"

                                 },
                                 new Producer()
                                 {
                                    ProducerName= "Producer 2",
                                     Bio = "This is the Bio of the second actor",
                                   ProducerUrl= "http://dotnethow.net/images/producers/producer-2.jpeg"
                                 },
                                 new Producer()
                                 {
                                      ProducerName= "Producer 3",
                                      Bio = "This is the Bio of the second actor",
                                       ProducerUrl= "http://dotnethow.net/images/producers/producer-3.jpeg"
                                 }
                    };
                        context.Producers.AddRange(listProducer);
                        context.SaveChanges();

                    }
                    //Movies
                    if (!context.Movies.Any())
                    {
                        var listMovie = new List<Movie>()
                    {
                                 new Movie()
                                 {
                                     MovieName = "Life",
                                     Description = "This is the Life movie description",
                                     Prize=30.30,
                                     MovieUrl = "http://dotnethow.net/images/movies/movie-3.jpeg",
                                     StartDate = DateTime.Now.AddDays(-10),
                                     EndDate = DateTime.Now.AddDays(10),
                                     CinemaId = 1,
                                     ProducerId = 1,
                                    MovieCatogory = MovieCatogory.Horror

                                 },
                                  new Movie()
                                  {
                                      MovieName= "The Shawshank Redemption",
                                       Description = "This is the Shawshank Redemption description",
                                      Prize = 29.50,
                                      MovieUrl = "http://dotnethow.net/images/movies/movie-1.jpeg",
                                       StartDate = DateTime.Now,
                                      EndDate = DateTime.Now.AddDays(3),
                                       CinemaId = 1,
                                      ProducerId = 2,
                                         MovieCatogory=MovieCatogory.Action
                                  },
                                   new Movie()
                                   {
                                      MovieName = "Ghost",
                                       Description = "This is the Ghost movie description",
                                        Prize = 39.50,
                                          MovieUrl = "http://dotnethow.net/images/movies/movie-4.jpeg",
                                         StartDate = DateTime.Now,
                                        EndDate = DateTime.Now.AddDays(7),
                                         CinemaId = 2,
                                       ProducerId =3,
                                         MovieCatogory= MovieCatogory.Horror
                                   },
                                    new Movie()
                                    {
                                       MovieName = "Race",
                                        Description = "This is the Race movie description",
                                        Prize= 39.50,
                                         MovieUrl= "http://dotnethow.net/images/movies/movie-6.jpeg",
                                         StartDate = DateTime.Now.AddDays(-10),
                                        EndDate = DateTime.Now.AddDays(-5),
                                         CinemaId = 3,
                                        ProducerId =1,
                                          MovieCatogory = MovieCatogory.Rommance
                                    },
                                     new Movie()
                                     {
                                          MovieName = "Scoob",
                                            Description = "This is the Scoob movie description",
                                           Prize = 39.50,
                                           MovieUrl = "http://dotnethow.net/images/movies/movie-7.jpeg",
                                         StartDate = DateTime.Now.AddDays(-10),
                                          EndDate = DateTime.Now.AddDays(-2),
                                            CinemaId = 2,
                                         ProducerId = 1,
                                           MovieCatogory = MovieCatogory.Horror
                                     },


                    };
                        context.Movies.AddRange(listMovie);
                        context.SaveChanges();
                    }
                    //Actor_Movies
                    if (!context.Actor_Movies.Any())
                    {
                        context.Actor_Movies.AddRange(new List<Actor_Movie>()
                    {
                                 new Actor_Movie()
                                 {
                                    ActorId = 1,
                                     MovieId = 1
                                 },
                                 new Actor_Movie()
                                 {
                                    ActorId = 2,
                                     MovieId = 2
                                 },
                                 new Actor_Movie()
                                 {
                                    ActorId = 3,
                                     MovieId = 3
                                 },
                                 new Actor_Movie()
                                 {
                                    ActorId = 1,
                                     MovieId = 3
                                 },
                                 new Actor_Movie()
                                 {
                                    ActorId = 3,
                                     MovieId = 4
                                 },


                    });
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
