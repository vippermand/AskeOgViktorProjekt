using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace AskeOgViktorProjekt.Pages
{
    public class Images : PageModel
    {
        private readonly ILogger<Images> _logger;

        public Images(ILogger<Images> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}