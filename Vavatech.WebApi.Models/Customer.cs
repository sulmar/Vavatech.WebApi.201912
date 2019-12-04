using System;

namespace Vavatech.WebApi.Models
{


    public class Customer : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Pesel { get; set; }
        public string HashPassword { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public decimal Salary { get; set; }
        public Gender Gender { get; set; }
        public bool IsRemoved { get; set; }

        public Customer()
        {
            Salary = 100;
            Gender = Gender.Female;
            IsRemoved = false;
        }

    }
}
