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
using Microsoft.AspNetCore.SignalR.Client;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Assignment3_Group20.Data.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace Assignment3_Group20.Pages
{
    public class KitchenOverviewModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IHubContext<KitchenOverviewHub, IKitchenOverview> _kitchenOverviewHubContext;

        private DateTime _chosenDate = DateTime.Today;

        [BindProperty]
        [DataType(DataType.Date)]
        public DateTime ChosenDate
        {
            get => _chosenDate;
            set => _chosenDate = value;
        }

        public KitchenOverviewModel(ApplicationDbContext context, IHubContext<KitchenOverviewHub, IKitchenOverview> hubContext)
        {
            _context = context;
            _kitchenOverviewHubContext = hubContext;
            KitchenDataList = new List<KitchenData>();
        }

        public IList<Reservation> Reservation { get;set; }
        public IList<Reservation> ReservationsUnfiltered { get; set; }
        public IList<KitchenData> KitchenDataList { get; set; }

        public async Task OnGetAsync()
        {
           Reservation = await _context.Reservation.ToListAsync();

           int totalGuests = 0;
           int totalAdults = 0;
           int totalChildren = 0;
           int adultsCheckedIn = 0;
           int childrenCheckedIn = 0;
           int adultsNotCheckedIn = 0;
           int childrenNotCheckedIn = 0;
           int totalNotCheckedIn = 0;

           foreach (var reservation in Reservation)
           {
               if (reservation.Date.Date == ChosenDate.Date)
               {
                   totalAdults += reservation.Adults;
                   totalChildren += reservation.Children;
                   totalGuests = totalAdults + totalChildren;
                   adultsNotCheckedIn += reservation.Adults;
                   childrenNotCheckedIn += reservation.Children;
                   totalNotCheckedIn = adultsNotCheckedIn + childrenNotCheckedIn;
                   if (reservation.isCheckedIn != DateTime.MinValue)
                   {
                       adultsCheckedIn += reservation.Adults;
                       childrenCheckedIn += reservation.Children;
                       adultsNotCheckedIn = totalAdults - adultsCheckedIn;
                       childrenNotCheckedIn = totalChildren - childrenCheckedIn;
                       totalNotCheckedIn = adultsNotCheckedIn + childrenNotCheckedIn;

                   }
               }
           }
           KitchenDataList.Add(new KitchenData
           {
               TotalAdults = totalAdults,
               TotalChildren = totalChildren,
               AdultsCheckedIn = adultsCheckedIn,
               ChildrenCheckedIn = childrenCheckedIn,
               AdultsNotCheckedIn = adultsNotCheckedIn,
               ChildrenNotCheckedIn = childrenNotCheckedIn,
               TotalNotCheckedIn = totalNotCheckedIn,
               TotalGuests = totalGuests
           });
        }

        public async Task OnPostFilterList()
        {

            ReservationsUnfiltered = await _context.Reservation.ToListAsync();

            int totalGuests = 0;
            int totalAdults = 0;
            int totalChildren = 0;
            int adultsCheckedIn = 0;
            int childrenCheckedIn = 0;
            int adultsNotCheckedIn = 0;
            int childrenNotCheckedIn = 0;
            int totalNotCheckedIn = 0;

            foreach (var reservation in ReservationsUnfiltered)
            {
                if (reservation.Date == ChosenDate)
                {
                    totalAdults += reservation.Adults;
                    totalChildren += reservation.Children;
                    totalGuests = totalAdults + totalChildren;
                    adultsNotCheckedIn += reservation.Adults;
                    childrenNotCheckedIn += reservation.Children;
                    totalNotCheckedIn = adultsNotCheckedIn + childrenNotCheckedIn;
                    if (reservation.isCheckedIn != DateTime.MinValue)
                    {
                        adultsCheckedIn += reservation.Adults;
                        childrenCheckedIn += reservation.Children;
                        adultsNotCheckedIn = totalAdults - adultsCheckedIn;
                        childrenNotCheckedIn = totalChildren - childrenCheckedIn;
                        totalNotCheckedIn = adultsNotCheckedIn + childrenNotCheckedIn;

                    }
                }
            }
            KitchenDataList.Add(new KitchenData
            {
                TotalAdults = totalAdults,
                TotalChildren = totalChildren,
                AdultsCheckedIn = adultsCheckedIn,
                ChildrenCheckedIn = childrenCheckedIn,
                AdultsNotCheckedIn = adultsNotCheckedIn,
                ChildrenNotCheckedIn = childrenNotCheckedIn,
                TotalNotCheckedIn = totalNotCheckedIn,
                TotalGuests = totalGuests
            });

            //_kitchenOverviewHubContext.Clients.All.SendAsync("update");
        }

    }
}
