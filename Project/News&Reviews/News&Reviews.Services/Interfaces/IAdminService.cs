using News_Reviews.Models.Models.Admin;

namespace News_Reviews.Services.Interfaces
{
    public interface IAdminService
    {
        Task<IEnumerable<ApplicationUserModel>> GetAllModsAsync();

        Task<IEnumerable<ApplicationUserModel>> GetAllUsersAsync();

        Task RemoveModeratorAsync(string id);

        Task RemoveUserAsync(string id);
    }
}
