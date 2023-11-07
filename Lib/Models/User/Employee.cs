using System.ComponentModel.DataAnnotations;

namespace Lib.Models.User
{
    public class Employee : Customer
    {
        [Required]
        public bool CanEditProducts { get; set; } = true; //Needed ?
    }
}
