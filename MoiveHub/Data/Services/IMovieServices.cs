using MoiveHub.Data.Base;
using MoiveHub.Data.ViewModel;
using MoiveHub.Models;

namespace MoiveHub.Data.Services
{
    public interface IMovieServices : IEntityBaseRespository<Movie>
    {
        //Add new mwthod for movie
        Task<Movie> GetMovieByIdAsync(int id);
        Task<MovieDropDownListModel> GetNewMovieDropdownsValues();
        Task AddNewMovieAsync(NewMovieModel data);
        Task UpdateNewMovieAsync(NewMovieModel data);

    }
     
}
