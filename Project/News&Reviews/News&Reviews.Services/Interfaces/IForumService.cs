using News_Reviews.Models.Models.Forum;

namespace News_Reviews.Services.Interfaces
{
    public interface IForumService
    {
        Task<IEnumerable<ThemesViewModel>> GetThemesAsync(IEnumerable<PostViewModel> posts);

        Task<IEnumerable<PostViewModel>> GetPostsAsync(int themeId, string username);

        Task AddNewThemeAsync(ThemesFormModel model);

        Task RemoveThemeAsync(int themeId);

        Task AddNewPostAsync(PostViewModel model, string username, int themeId);

        Task RemovePostAsync(int postId);
    }
}
