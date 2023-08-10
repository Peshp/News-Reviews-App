using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using News_Reviews.DataModels;
using News_Reviews.Services.Interfaces;

namespace News_Reviews.Areas.Administration.Controllers
{
    public class AdminController : BaseAdminController
    {
        private IAdminService adminService;
        private UserManager<ApplicationUser> userManager;

        public AdminController(IAdminService adminService,
            UserManager<ApplicationUser> _userManager)
        {
            this.adminService = adminService;
            userManager = _userManager;
        }

        public async Task<IActionResult> All()
        {
            var model = await adminService.GetAllModsAsync();

            return View(model);
        }

        public async Task<IActionResult> AllUsers()
        {
            var users = await adminService.GetAllUsersAsync();
        
            return View(users);
        }
        
        [HttpPost]
        public async Task<IActionResult> Add(string username)
        {
            var user = await userManager.FindByNameAsync(username);
            if (user == null)
            {
                TempData["Message"] = "User not found";
                return RedirectToAction(nameof(All));
            }
        
            var result = await userManager.AddToRoleAsync(user, "Moderator");
            if (result.Succeeded)
            {
                TempData["Message"] = "Moderator role added successfully.";
            }
            else
            {
                TempData["Message"] = "Failed to add Moderator role to the user.";
            }
        
            return RedirectToAction(nameof(All));
        }
        
        public async Task<IActionResult> Remove(string id)
        {
            await adminService.RemoveModeratorAsync(id);    
        
            return RedirectToAction(nameof(All));
        }
        
        public async Task<IActionResult> RemoveUser(string id)
        {            
            await adminService.RemoveUserAsync(id);

            return RedirectToAction(nameof(AllUsers));
        }
    }
}
