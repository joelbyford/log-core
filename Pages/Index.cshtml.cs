using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using log_core.Data;

namespace log_core.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [BindProperty]
        public ErrorObj errorObj {get; set;}

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            //Check for some limits and just do 1 if the user provided out of range.
            if (errorObj.Count <= 1000 && errorObj.Count >=0)
                errorObj.Count = 1;

            for(int i=0; i<= errorObj.Count; i++)
            {

                switch (errorObj.Level)
                {
                    case 5:
                        _logger.LogCritical(errorObj.Message + i);
                        break;
                    case 4:
                        _logger.LogError(errorObj.Message + i);
                        break;
                    case 3:
                        _logger.LogWarning(errorObj.Message + i);
                        break;
                    case 2:
                        _logger.LogInformation(errorObj.Message + i);
                        break;
                    case 1:
                        _logger.LogDebug(errorObj.Message + i);
                        break;
                    case 0:
                        _logger.LogTrace(errorObj.Message + i);
                        break;
                    default:
                        _logger.LogCritical("Failed to provide an error level/severity.");
                        break;
                }
            }            
            return RedirectToPage("./Index");
        }
    }
}
