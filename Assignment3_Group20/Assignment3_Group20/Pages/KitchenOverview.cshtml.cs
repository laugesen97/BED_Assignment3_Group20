#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Assignment3_Group20.Data;
using Assignment3_Group20.Model;

namespace Assignment3_Group20.Pages
{
    public class KitchenOverviewModel : PageModel
    {
        private readonly Assignment3_Group20.Data.ApplicationDbContext _context;
        private DateTime _chosenDate = DateTime.Today;

        [BindProperty]
        public DateTime ChosenDate
        {
            get => _chosenDate;
            set => _chosenDate = value;
        }

        public KitchenOverviewModel(Assignment3_Group20.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Reservation> Reservation { get;set; }

        public async Task OnGetAsync()
        {
            Reservation = await _context.Reservation.ToListAsync();
        }
    }
}
