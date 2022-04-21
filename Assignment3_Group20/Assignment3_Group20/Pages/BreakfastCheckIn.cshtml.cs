#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Assignment3_Group20.Data;
using Assignment3_Group20.Data.Hubs;
using Assignment3_Group20.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;


namespace Assignment3_Group20.Pages
{
    [Authorize(Policy = "WaiterOnly")]
    public class BreakfastCheckInModel : PageModel
    {
        private readonly Assignment3_Group20.Data.ApplicationDbContext _context;
        private readonly IHubContext<KitchenOverviewHub, IKitchenOverview> _kitchenOverviewHubContext;
        private readonly object connection;

        public BreakfastCheckInModel(ApplicationDbContext context, IHubContext<KitchenOverviewHub, IKitchenOverview> hubContext)
        {
            _context = context;
            _kitchenOverviewHubContext = hubContext;

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
            Reservation.isCheckedIn = DateTime.Now;
            Reservation.Date = DateTime.Now;
            
            
            _context.Reservation.Add(Reservation);
            await _context.SaveChangesAsync();
            await _kitchenOverviewHubContext.Clients.All.Update();

            return RedirectToPage("./Index");
        }
    }
}
