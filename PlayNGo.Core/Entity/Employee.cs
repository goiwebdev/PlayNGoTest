using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayNGo.Core.Entity
{
    [Table("Employees")]
    public partial class Employee
    {

        [Key]
        public int Id { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        public int ContactNumber { get; set; }

    }
}
