﻿namespace Assignment3_Group20.Model
{
    public class Reservation
    {
        public int ID { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        public DateTime isCheckedIn { get; set; }
        public int RoomNumber { get; set; }
        public bool checkedInBool { get; set; }
    }
}
