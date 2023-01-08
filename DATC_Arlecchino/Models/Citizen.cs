using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace DATC_Arlecchino.Models
{
    public class Citizen
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public ICollection<Alert> Alerts { get; set; }
    }
}
