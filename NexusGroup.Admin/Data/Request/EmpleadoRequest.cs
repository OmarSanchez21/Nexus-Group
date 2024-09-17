namespace NexusGroup.Admin.Data.Request
{  
    public partial class EmpleadoRequest
    {
        public string Cedula { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public decimal Salary { get; set; }
        public int PositionID { get; set; }
        public string AccessLevelsID { get; set; }
    }
    public partial class AddEmpleadoRequest: EmpleadoRequest
    {
        public bool IsValidForAdd()
        {
            return !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Email);
        }
    }
    public partial class EditEmpleadoRequest : EmpleadoRequest
    {
        public int EmpleadoID { get; set; }
    }
}
