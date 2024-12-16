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
    public class DeleteModel : PageModel
    {
        private readonly WebApplication6.Data.WebApplication6Context _context;

        public DeleteModel(WebApplication6.Data.WebApplication6Context context)
        {
            _context = context;
        }

        [BindProperty]
      public Request Request { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Request == null)
            {
                return NotFound();
            }

            var request = await _context.Request.FirstOrDefaultAsync(m => m.RequestId == id);

            if (request == null)
            {
                return NotFound();
            }
            else 
            {
                Request = request;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Request == null)
            {
                return NotFound();
            }
            var request = await _context.Request.FindAsync(id);

            if (request != null)
            {
                Request = request;
                _context.Request.Remove(Request);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
