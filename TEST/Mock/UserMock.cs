using DATAACCESS.Models;

namespace TESTS.Mock
{
    public class UserMock
    {
        public UserData UserData => new()
        {
            Id = 1,
            Address = "Addres 1 Mock",
            BirthDate = DateTime.Now,
            Credits = new List<Credit>()
            {
                new Credit()
                {
                    Id = 1,
                    Name = "User Credit 1",
                    Tax = 1,
                    Term = 50,
                    Value = 6000
                },
                new Credit()
                {
                    Id = 2,
                    Name = "User Credit 2",
                    Tax = 2,
                    Term = 90,
                    Value = 2000
                }
            },
            Email = "email@email.com",
            Name = "User 1",
            MonthlyIncome = 1500,
            Country = new CountryStatistics()
            {
                CountryName = "Portugal",
                InflationRate = 6,
                UnemploymentRate = 11
            },
            Debt = 0
        };
    }
}
