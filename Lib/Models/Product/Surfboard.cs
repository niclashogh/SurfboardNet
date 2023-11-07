using System.ComponentModel.DataAnnotations;

namespace Lib.Models.Product
{
    public class Surfboard : AbstractProduct
    {
        [Required]
        public double Length { get; set; }

        [Required]
        public double Width { get; set; }

        [Required]
        public double Thickness { get; set; }

        [Required]
        public double Volume { get; set; }

        [Required]
        public BoardType Type { get; set; }

        public string? Equipment { get; set; }

        public string? ImgUrl { get; set; }
    }
}
