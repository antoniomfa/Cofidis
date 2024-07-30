namespace DATAACCESS.Models
{
    public class UserData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public decimal MonthlyIncome { get; set; }
        public List<Credit> Credits { get; set; }
        public int Debt { get; set; }
        public CountryStatistics Country { get; set; }
    }
}
