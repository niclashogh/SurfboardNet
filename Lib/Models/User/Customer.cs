using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Lib.Models.User
{
    public class Customer : IdentityUser
    {
        [Required, DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required, DisplayName("Last Name")]
        public string LastName { get; set; }
    }
}
