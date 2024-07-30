using DATAACCESS;
using DATAACCESS.Models;
using DATAACCESS.Repo;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SERVICES.Interfaces;

namespace SERVICES.Implementations
{
    /// <summary>
    /// Manages credit operations
    /// </summary>
    public class CreditManager : ICreditManager
    {
        private CofidisDbContext dbContext;
        private readonly IChaveMovelDigitalManager _chaveMovelDigital;
        private readonly ICofidisRepo _cofidisRepo;

        public CreditManager(IChaveMovelDigitalManager chaveMovelDigital, ICofidisRepo cofidisRepo)
        {
            _chaveMovelDigital = chaveMovelDigital;
            _cofidisRepo = cofidisRepo;
        }

        /// <summary>
        /// Creates a credit for user
        /// </summary>
        /// <param name="nif"></param>
        /// <returns>Returns credit to create</returns>
        public async Task<UserData> Create(int nif)
        {
            UserData userDataWithNewCredit = new();

            try
            {
                // Get user data from Chave Movel Digital
                UserData userData = await _chaveMovelDigital.GetByNif(nif);

                userDataWithNewCredit = userData;

                if (userData != null)
                {
                    // Call SP to evaluate limits and get values 
                    // Script found in folder "Scripts"
                    //_cofidisRepo.ExecuteStoredProcedure();
                    //IQueryable<Credit> limits = dbContext.Database.SqlQuery<Credit>("CofidisSP");

                    // Example credit values to test, user can choose from 2 credits
                    List<Credit> limits = new()
                    {
                        new Credit()
                        {
                            Id = 2,
                            Name = "Credit 2",
                            Tax = 5,
                            Term = 180,
                            Value = 1000
                        },
                        new Credit()
                        {
                            Id = 4,
                            Name = "Credit 4",
                            Tax = 6,
                            Term = 360,
                            Value = 1000
                        },
                    };

                    // Unable to give new credit if user has credit history, debt, low income or invalid country rates
                    if (userData.Debt > 1000 || userData.Credits.Count > 1 || userData.Country.InflationRate > 15 ||
                        userData.Country.UnemploymentRate > 15 || userData.BirthDate.Year < 1970 || userData.MonthlyIncome < 700)
                    {
                        return userDataWithNewCredit;
                    }
                    else
                    {
                        // Fill creditToGenerate values                        
                        if (limits != null && userData.Credits != null)
                        {
                            foreach (var c in limits)
                            {

                                userDataWithNewCredit.Credits.Add(c);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(@$"--> Can't create credit for user with NIF: {nif} --- {ex}");
            }

            return userDataWithNewCredit;
        }

        public IEnumerable<Credit> GetAll()
        {
            throw new NotImplementedException();
        }

        public Credit GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
