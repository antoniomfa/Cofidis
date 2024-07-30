using DATAACCESS.Models;


namespace TESTS.Mock
{
    public class CreditMock
    {
        public Credit Credit = new()
        {
            Id = 1,
            Name = "Credit 1",
            Tax = 5,
            Term = 180,
            Value = 1000
        };
    }
}
