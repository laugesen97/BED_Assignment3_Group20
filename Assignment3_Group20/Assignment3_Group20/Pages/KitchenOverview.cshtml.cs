#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [DataType(DataType.Date)]
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
        public IList<Reservation> ReservationsUnfiltered { get; set; }

        public async Task OnGetAsync()
        {
           Reservation = await _context.Reservation.ToListAsync();
        }

        public async Task OnPostFilterList()
        {

            ReservationsUnfiltered = await _context.Reservation.ToListAsync();
            Reservation = new List<Reservation>();

            foreach (var reservation in ReservationsUnfiltered)
            {
                if (reservation.isCheckedIn.Date == ChosenDate)
                {
                    Reservation.Add(reservation);
                }
            }
        }
    }
}
