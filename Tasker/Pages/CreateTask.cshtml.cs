using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Tasker.Pages
{
    public class CreateTask : PageModel
    {
        [BindProperty]
        public Task NewTask { get; set; }
        
        public void OnGet()
        {
            
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("Index");
        }
    }
}