using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entity
{
    public class User
    {
        public Guid UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public double YearSalary { get; set; }
        //nullable because it is not required when creating a user. It will be generated automatically at the end of the day
        public double? MortgageOffer { get; set; }

    }
}
