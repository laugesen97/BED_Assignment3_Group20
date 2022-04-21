#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Assignment3_Group20.Data;
using Assignment3_Group20.Data.Hubs;
using Assignment3_Group20.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Assignment3_Group20.Pages
{
    [Authorize(Policy = "ReceptionistOnly")]
    public class TodaysBreakfastModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IHubContext<KitchenOverviewHub, IKitchenOverview> _kitchenOverviewHubContext;

        public TodaysBreakfastModel(ApplicationDbContext context, IHubContext<KitchenOverviewHub, IKitchenOverview> hubContext)
        {
            _context = context;
            _kitchenOverviewHubContext = hubContext;
        }

        public IList<Reservation> Reservation { get;set; }

        public async Task OnGetAsync()
        {
            Reservation = await _context.Reservation.ToListAsync();
            await _kitchenOverviewHubContext.Clients.All.Update();
        }
    }
}
