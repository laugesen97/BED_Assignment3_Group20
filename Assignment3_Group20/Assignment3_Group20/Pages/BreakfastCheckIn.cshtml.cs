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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR.Client;


namespace Assignment3_Group20.Pages
{
    [Authorize(Policy = "WaiterOnly")]
    public class BreakfastCheckInModel : PageModel
    {
        private readonly Assignment3_Group20.Data.ApplicationDbContext _context;
        private readonly object connection;

        public BreakfastCheckInModel(Assignment3_Group20.Data.ApplicationDbContext context)
        {
            _context = context;
            connection = new HubConnectionBuilder()
                .WithUrl("/kitchenOverviewHub")
                .Build();
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Reservation Reservation { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}
            Reservation.isCheckedIn = DateTime.Now;
            _context.Reservation.Add(Reservation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
