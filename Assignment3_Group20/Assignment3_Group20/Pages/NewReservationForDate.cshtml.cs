#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Assignment3_Group20.Data;
using Assignment3_Group20.Model;

namespace Assignment3_Group20.Pages
{
    public class NewReservationForDateModel : PageModel
    {
        private readonly Assignment3_Group20.Data.ApplicationDbContext _context;

        public NewReservationForDateModel(Assignment3_Group20.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public FutureReservation FutureReservation { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}
            FutureReservation.Dato = DateTime.Now.Date;
            _context.FutureReservation.Add(FutureReservation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
