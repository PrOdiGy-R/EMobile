using EMobile.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMobile.Data
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider services)
        {
            await AddTestData(services.GetRequiredService<EMobileDbContext>());
        }

        public static async Task AddTestData(EMobileDbContext context)
        {
            if (context.Mobiles.Any()) return;

            context.Mobiles.AddRange(
               new MobileEntity
               {
                   Id = Guid.Parse("e6776098-6e6c-4f04-b7ba-07d28dbb0cd5"),
                   Model = "1",
                   Brand = "Samsung",
                   Size = "6 inch",
                   Weight = "200 gr",
                   Resolution = "3840 × 2160",
                   Processor = "Octa-core (1x2.9 GHz Cortex-X1 & 3x2.80 GHz Cortex-A78 & 4x2.2 GHz Cortex-A55) - International",
                   OperatingSystem = "Android 9",
                   Price = 800,
                   ImagePath = "",
                   VideoPath = ""
               },
                new MobileEntity
                {
                    Id = Guid.Parse("59cff2dc-49bc-4c98-8236-0df794657413"),
                    Model = "2",
                    Brand = "IPhone",
                    Size = "6 inch",
                    Weight = "200 gr",
                    Resolution = "3840 × 2160",
                    Processor = "Octa-core (1x2.9 GHz Cortex-X1 & 3x2.80 GHz Cortex-A78 & 4x2.2 GHz Cortex-A55) - International",
                    OperatingSystem = "IOS",
                    Price = 1000,
                    ImagePath = "",
                    VideoPath = ""
                },
                new MobileEntity
                {
                    Id = Guid.Parse("3ac8c4b8-1ce7-490a-90f9-647b7238027d"),
                    Model = "3",
                    Brand = "Samsung",
                    Size = "6 inch",
                    Weight = "200 gr",
                    Resolution = "3840 × 2160",
                    Processor = "Octa-core (1x2.9 GHz Cortex-X1 & 3x2.80 GHz Cortex-A78 & 4x2.2 GHz Cortex-A55) - International",
                    OperatingSystem = "Android 8",
                    Price = 700,
                    ImagePath = "",
                    VideoPath = ""
                }, new MobileEntity
                {
                    Id = Guid.NewGuid(),
                    Model = "4",
                    Brand = "Samsung",
                    Size = "6 inch",
                    Weight = "200 gr",
                    Resolution = "3840 × 2160",
                    Processor = "Octa-core (1x2.9 GHz Cortex-X1 & 3x2.80 GHz Cortex-A78 & 4x2.2 GHz Cortex-A55) - International",
                    OperatingSystem = "Android 9",
                    Price = 800,
                    ImagePath = "",
                    VideoPath = ""
                },
                new MobileEntity
                {
                    Id = Guid.NewGuid(),
                    Model = "5",
                    Brand = "IPhone",
                    Size = "6 inch",
                    Weight = "200 gr",
                    Resolution = "3840 × 2160",
                    Processor = "Octa-core (1x2.9 GHz Cortex-X1 & 3x2.80 GHz Cortex-A78 & 4x2.2 GHz Cortex-A55) - International",
                    OperatingSystem = "IOS",
                    Price = 1000,
                    ImagePath = "",
                    VideoPath = ""
                },
                new MobileEntity
                {
                    Id = Guid.NewGuid(),
                    Model = "6",
                    Brand = "Samsung",
                    Size = "6 inch",
                    Weight = "200 gr",
                    Resolution = "3840 × 2160",
                    Processor = "Octa-core (1x2.9 GHz Cortex-X1 & 3x2.80 GHz Cortex-A78 & 4x2.2 GHz Cortex-A55) - International",
                    OperatingSystem = "Android 8",
                    Price = 700,
                    ImagePath = "",
                    VideoPath = ""
                },
                new MobileEntity
                {
                    Id = Guid.NewGuid(),
                    Model = "7",
                    Brand = "Samsung",
                    Size = "6 inch",
                    Weight = "200 gr",
                    Resolution = "3840 × 2160",
                    Processor = "Octa-core (1x2.9 GHz Cortex-X1 & 3x2.80 GHz Cortex-A78 & 4x2.2 GHz Cortex-A55) - International",
                    OperatingSystem = "Android 9",
                    Price = 800,
                    ImagePath = "",
                    VideoPath = ""
                },
                new MobileEntity
                {
                    Id = Guid.NewGuid(),
                    Model = "8",
                    Brand = "IPhone",
                    Size = "6 inch",
                    Weight = "200 gr",
                    Resolution = "3840 × 2160",
                    Processor = "Octa-core (1x2.9 GHz Cortex-X1 & 3x2.80 GHz Cortex-A78 & 4x2.2 GHz Cortex-A55) - International",
                    OperatingSystem = "IOS",
                    Price = 1000,
                    ImagePath = "",
                    VideoPath = ""
                },
                new MobileEntity
                {
                    Id = Guid.NewGuid(),
                    Model = "9",
                    Brand = "Samsung",
                    Size = "6 inch",
                    Weight = "200 gr",
                    Resolution = "3840 × 2160",
                    Processor = "Octa-core (1x2.9 GHz Cortex-X1 & 3x2.80 GHz Cortex-A78 & 4x2.2 GHz Cortex-A55) - International",
                    OperatingSystem = "Android 8",
                    Price = 700,
                    ImagePath = "",
                    VideoPath = ""
                }
                );
            await context.SaveChangesAsync();
        }
    }
}
