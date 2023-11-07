using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Lib.Models.User
{
    public class Guest
    {
        [Key]
        public int Id { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
