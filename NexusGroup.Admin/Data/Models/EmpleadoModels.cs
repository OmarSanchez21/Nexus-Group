namespace NexusGroup.Admin.Data.Models
{
    public class EmpleadoModels: _Core
    {
        public int EmployeeID { get; set; }
        public string Cedula { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string photoURL { get; set; }
        public decimal Salary { get; set; }
        public int PositionID { get; set; }
        public string AccessLevelsID { get; set; }
    }
}
