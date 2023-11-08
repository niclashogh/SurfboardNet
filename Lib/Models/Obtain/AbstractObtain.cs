using Lib.Models.User;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Lib.Models.Product;

namespace Lib.Models.Service
{
    public abstract class AbstractObtain
    {
        #region Ids
        public int Id { get; set; }

        public string? CustomerId { get; set; }

        public string? GuestEmail { get; set; }

        [Required]
        public int SurfboardId { get; set; }
        #endregion

        [Required, DisplayName("Price"), Column(TypeName = "decimal(18, 2)")]
        public decimal Cost { get; set; }

        #region ForeignKey navigation properties
        [ForeignKey("CustomerId")]
        public Customer? Customer { get; set; }

        [ForeignKey("GuestEmail")]
        public Guest? Guest { get; set; }

        [ForeignKey("SurfboardId")]
        public Surfboard Surbroad { get; set; }
        #endregion

        [Timestamp]
        public byte[]? RowVersion { get; set; }
    }
}
