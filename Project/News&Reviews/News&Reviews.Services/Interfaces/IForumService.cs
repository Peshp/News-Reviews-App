using News_Reviews.Models.Models.Forum;

namespace News_Reviews.Services.Interfaces
{
    public interface IForumService
    {
        Task<IEnumerable<ThemesViewModel>> GetThemesAsync();

        Task<IEnumerable<PostViewModel>> GetPostsAsync(int themeId, string username);

        Task AddNewThemeAsync(ThemesFormModel model);

        Task RemoveThemeAsync(int themeId);
    }
}
