using Microsoft.EntityFrameworkCore;
namespace SportsStore.Models
{
	public class SeedData
	{
		public static void EnsurePopulated(IApplicationBuilder app)
		{
			StoreDBContext context = app.ApplicationServices
				.CreateScope().ServiceProvider
				.GetRequiredService<StoreDBContext> ();

			if (context.Database.GetPendingMigrations().Any())
			{
				context.Database.Migrate();

			}
			if (!context.Products.Any())
				{
				context.Products.AddRange(
					new Product
					{
						Name = "Kayak",
						Description = "A boat for one person.",
						Category = "WaterSports",
						Price = 499.95m
					},
					new Product
					{
						Name = "LifeJacket",
						Description = "Protextive and fashionable.",
						Category = "WaterSports",
						Price = 249.95m
					},
					new Product
					{
						Name = "Soccer Ball",
						Description = "FIFA-Approved",
						Category = "Soccer",
						Price = 399.95m
					},
					new Product
					{
						Name = "Corner Flags",
						Description = "Give your playing field a chuchu.",
						Category = "Soccer",
						Price = 999.95m
					},
					new Product
					{
						Name = "Stadium",
						Description = "Flat-picked 35,000 seats",
						Category = "Soccer",
						Price = 99499.95m
					},
						new Product
						{
							Name = "Bling-Bling King",
							Description = "Gold-plated sturdy King",
							Category = "Chess",
							Price = 199.95m
						},
							new Product
							{
								Name = "Chess Board",
								Description = "A board game with pieces",
								Category = "Chess",
								Price = 299.95m
							},
							new Product
							{
								Name = "Thinking Cap",
								Description = "Improve your brain",
								Category = "Chess",
								Price = 699.95m
							},
							new Product
							{
								Name = "Unsteady Chair",
								Description = "A secret chair",
								Category = "Chess",
								Price = 499.95m
							}

					);
				context.SaveChanges();
				}

			
		}
	}
}
