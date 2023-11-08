using Lib.Models.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Lib.Services.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ProductContext(serviceProvider.GetRequiredService<DbContextOptions<ProductContext>>()))
            {
                if (context.Surfboard.Any())
                {
                    return;
                }
                else
                {
                    context.Surfboard.AddRange(
                    new Surfboard
                    {
                        Name = "The Minilog",
                        InStock = 1,
                        Length = 6,
                        Width = 21,
                        Thickness = 2.75,
                        Volume = 38.8,
                        Type = BoardType.Shortboard,
                        Price = 565,
                        ImgUrl = "https://images.blue-tomato.com/is/image/bluetomato/304985477_front.jpg-sc3VZ7vW-FFI4Aqdn9Iz-SHhuWM/Lost+Glydra+7+0+Surfboard.jpg?$b8$"
                    },

                    new Surfboard
                    {
                        Name = "The Wide Glider",
                        InStock = 1,
                        Length = 7.1,
                        Width = 21.75,
                        Thickness = 2.75,
                        Volume = 44.16,
                        Type = BoardType.Funboard,
                        Price = 685
                    },

                    new Surfboard
                    {
                        Name = "The Golden Ratio",
                        InStock = 1,
                        Length = 6.3,
                        Width = 21.85,
                        Thickness = 2.9,
                        Volume = 43.22,
                        Type = BoardType.Funboard,
                        Price = 695
                    },

                    new Surfboard
                    {
                        Name = "Mahi Mahi",
                        InStock = 1,
                        Length = 5.4,
                        Width = 20.75,
                        Thickness = 2.3,
                        Volume = 29.39,
                        Type = BoardType.Fish,
                        Price = 645
                    },

                    new Surfboard
                    {
                        Name = "The Emerald Glider",
                        InStock = 1,
                        Length = 9.2,
                        Width = 22.8,
                        Thickness = 2.8,
                        Volume = 65.4,
                        Type = BoardType.Longboard,
                        Price = 895,
                        ImgUrl = "https://images.blue-tomato.com/is/image/bluetomato/304199479_front.jpg-3c-91210fWAvivUDHGWJiePAiFo/Bomber+FCS+II+5+10+Softtop+Surfboard.jpg?$b8$"
                    },

                    new Surfboard
                    {
                        Name = "The Bomb",
                        InStock = 1,
                        Length = 5.5,
                        Width = 21,
                        Thickness = 2.5,
                        Volume = 33.7,
                        Type = BoardType.Shortboard,
                        Price = 645
                    },

                    new Surfboard
                    {
                        Name = "Walden Magic",
                        InStock = 1,
                        Length = 9.6,
                        Width = 19.4,
                        Thickness = 3,
                        Volume = 80,
                        Type = BoardType.Longboard,
                        Price = 1025,
                        ImgUrl = "https://images.blue-tomato.com/is/image/bluetomato/304199483_front.jpg-DYt5uJfJyxC7tZlhbOGpyt7BFL0/Flash+Eric+Geiselman+FCS+II+5+7+Softtop+Surfboard.jpg?$b8$"
                    },

                    new Surfboard
                    {
                        Name = "Naish One",
                        InStock = 1,
                        Length = 12.6,
                        Width = 30,
                        Thickness = 6,
                        Volume = 301,
                        Type = BoardType.SUB,
                        Price = 854,
                        Equipment = "Paddle",
                        ImgUrl = "https://images.blue-tomato.com/is/image/bluetomato/304736912_front.jpg-iRn1K4X-y97gnlbsMVx8V83u7yw/Ezi+Rider+7+039+0+Surfboard.jpg?$b8$"
                    },

                    new Surfboard
                    {
                        Name = "SiX Tourer",
                        InStock = 1,
                        Length = 11.6,
                        Width = 32,
                        Thickness = 6,
                        Volume = 270,
                        Type = BoardType.SUB,
                        Price = 611,
                        Equipment = "Fin, Paddle, Pump & Leash",
                        ImgUrl = "https://images.blue-tomato.com/is/image/bluetomato/304736908_front.jpg-H4PsPhTNHmbDVcLjz0z9rBUUEp0/Happy+Hour+Epoxy+6+6+Surfboard.jpg?$b8$"
                    },

                    new Surfboard
                    {
                        Name = "Naish Maliko",
                        InStock = 1,
                        Length = 14,
                        Width = 25,
                        Thickness = 6,
                        Volume = 330,
                        Type = BoardType.SUB,
                        Price = 1304,
                        Equipment = "Fin, Paddle, Pump & Leash"
                    }
                    );

                    context.SaveChanges();
                }
            }
        }
    }
}
