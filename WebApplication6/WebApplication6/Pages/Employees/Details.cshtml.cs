using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication6;
using WebApplication6.Data;

namespace WebApplication6.Pages.Employees
{
    public class DetailsModel : PageModel
    {
        private readonly WebApplication6.Data.WebApplication6Context _context;

        public DetailsModel(WebApplication6.Data.WebApplication6Context context)
        {
            _context = context;
        }

      public Employee Employee { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Employee == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee.FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }
            else 
            {
                Employee = employee;
            }
            return Page();
        }
    }
}
