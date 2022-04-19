using System.ComponentModel.DataAnnotations;

namespace Assignment3_Group20.Model
{
    public class FutureReservation
    {
        public int FutureReservationId { get; set; }
        [DataType(DataType.Date)]
        public DateTime Dato { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
    }
}
