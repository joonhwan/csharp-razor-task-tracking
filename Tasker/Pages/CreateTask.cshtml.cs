using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Tasker.Pages
{
    public class CreateTask : PageModel
    {
        private readonly ILogger<CreateTask> _logger;

        public CreateTask(ILogger<CreateTask> logger)
        {
            _logger = logger;
            _logger.LogInformation("The Name of Type : {TypeName}", this.GetType().FullName);
        }
        
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