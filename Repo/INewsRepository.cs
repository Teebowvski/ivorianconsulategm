using Ivory_Coast.ViewModels;

namespace Ivory_Coast.Repo
{
    public interface INewsRepository
    {
        // Get all news items
        Task<List<HomeViewModel.News>> GetAllNewsAsync();

        // Get news by ID
        Task<HomeViewModel.News> GetNewsByIdAsync(Guid id);
        Task<List<HomeViewModel.News>> GetNewsByCategoryAsync(string category);
    }
}
