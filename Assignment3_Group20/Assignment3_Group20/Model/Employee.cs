namespace Assignment3_Group20.Model
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
    public class Receptionist : Employee
    {
        public int ReceptionistNumber { get; set; }
    }
    public class Waiter : Employee
    {
        public int WaiterNumber { get; set; }
    }
}
