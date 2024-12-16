using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication6;
using WebApplication6.Data;

namespace WebApplication6.Pages.Requests
{
    public class IndexModel : PageModel
    {
        private readonly WebApplication6.Data.WebApplication6Context _context;

        public IndexModel(WebApplication6.Data.WebApplication6Context context)
        {
            _context = context;
        }

        public IList<Request> Request { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Request != null)
            {
                Request = await _context.Request.ToListAsync();
            }
        }
    }
}
