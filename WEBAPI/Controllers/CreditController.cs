using DATAACCESS.Models;
using Microsoft.AspNetCore.Mvc;
using SERVICES.Interfaces;

namespace WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditController : Controller
    {
        private readonly ICreditManager _creditManager;

        public CreditController(ICreditManager creditManager)
        {
            _creditManager = creditManager;
        }

        /// <summary>
        /// Creates a credit
        /// </summary>
        /// <returns></returns>
        /// <remarks>ALL VALUES ARE NOT REAL</remarks>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(UserData))]
        public async Task<IActionResult> Create([FromBody] int nif)
        {
            System.Diagnostics.Debug.WriteLine("--> Creating ...");

            UserData creditToGenerate = await _creditManager.Create(nif);

            return Ok(creditToGenerate);
        }
    }
}
