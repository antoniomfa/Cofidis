using DATAACCESS.Models;
using SERVICES.Interfaces;

namespace SERVICES.Implementations
{
    /// <summary>
    /// Get mock data from Chave Digital
    /// </summary>
    public class ChaveMovelDigitalManager : IChaveMovelDigitalManager
    {
        public async Task<UserData> GetByNif(int nif)
        {
            UserData data = new()
            {
                Country = new(),
                Credits = new List<Credit>()                
            };

            try
            {
                if (nif == 0)
                    return data;

                data.Address = "Address 1";
                data.Name = "Name 1";
                data.Email = "email@email.com";
                data.BirthDate = DateTime.Now;
                data.Credits = new List<Credit>(); // IF NO PAST CREDITS -> EMPTY LIST
                data.Debt = 0;
                data.MonthlyIncome = 1600;
                data.Country = new CountryStatistics()
                {
                    CountryName = "Portugal",
                    InflationRate = 6,
                    UnemploymentRate = 11
                };
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(@$"--> Can't get user data: {ex}");
            }

            return data;
        }
    }
}
