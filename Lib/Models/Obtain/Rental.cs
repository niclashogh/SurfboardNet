using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Lib.Models.Obtain
{
    public class Rental : AbstractObtain
    {
        [Required, DisplayName("Start date"), DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required, DisplayName("End date"), DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
    }
}
