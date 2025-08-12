namespace DapperUserApi.DTO
{
    public class UserListDTO
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
        public double Salary { get; set; }
        public string TaxNumber { get; set; }
        public bool Situation { get; set; } = true;
        public string Password { get; set; }
    }
}