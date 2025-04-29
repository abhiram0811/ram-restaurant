using IndianRestaurant.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IndianRestaurant.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<ProductIngredients> ProductIngredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {   base.OnModelCreating(modelbuilder);

            // Define the composite key and relationships for ProductIngredients
            modelbuilder.Entity<ProductIngredients>()
                .HasKey(pi => new { pi.ProductId, pi.IngredientId });

            modelbuilder.Entity<ProductIngredients>()
                .HasOne(pi => pi.Product)
                .WithMany(p => p.ProductIngredients)
                .HasForeignKey(pi => pi.ProductId);

            modelbuilder.Entity<ProductIngredients>()
                .HasOne(pi => pi.Ingredient)
                .WithMany(i => i.ProductIngredients)
                .HasForeignKey(pi => pi.IngredientId);

            // Seed data
            modelbuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Appetizers" },
                new Category { CategoryId = 2, Name = "Entree" },
                new Category { CategoryId = 3, Name = "Side Dish" },
                new Category { CategoryId = 4, Name = "Desserts" },
                new Category { CategoryId = 5, Name = "Beverages" }
            );

            modelbuilder.Entity<Ingredient>().HasData(
                new Ingredient { IngredientId = 1, Name = "Chicken" },
                new Ingredient { IngredientId = 2, Name = "Goat" },
                new Ingredient { IngredientId = 3, Name = "Fish" },
                new Ingredient { IngredientId = 4, Name = "Vegetables" },
                new Ingredient { IngredientId = 5, Name = "Rice" },
                new Ingredient { IngredientId = 6, Name = "Flour" },
                new Ingredient { IngredientId = 7, Name = "Yogurt" },
                new Ingredient { IngredientId = 8, Name = "Paneer" },
                new Ingredient { IngredientId = 9, Name = "Butter" }
            );

            modelbuilder.Entity<Product>().HasData(

                // Add Indian Restaurant food entrees

                new Product
                {
                    ProductId = 1,
                    Name = "Butter Chicken",
                    Description = "Tender chicken pieces cooked in a creamy tomato sauce.",
                    Price = 12.99m,
                    Stock = 100,
                    CategoryId = 2
                },

                new Product
                {
                    ProductId = 2,
                    Name = "Chicken Tikka Masala",
                    Description = "Grilled chicken pieces in a spiced tomato sauce.",
                    Price = 11.99m,
                    Stock = 100,
                    CategoryId = 2
                },

                new Product
                {
                    ProductId = 3,
                    Name = "Goat Curry",
                    Description = "Slow-cooked goat meat in a rich curry sauce.",
                    Price = 13.99m,
                    Stock = 100,
                    CategoryId = 2
                },

                new Product
                {
                    ProductId = 4,
                    Name = "Samosa",
                    Description = "Crispy pastry filled with spiced potatoes and peas.",
                    Price = 5.99m,
                    Stock = 100,
                    CategoryId = 1
                },

                new Product
                {
                    ProductId = 5,
                    Name = "Paneer Tikka",
                    Description = "Grilled paneer marinated in spices.",
                    Price = 6.99m,
                    Stock = 100,
                    CategoryId = 1
                },

                new Product
                {
                    ProductId = 6,
                    Name = "Biryani",
                    Description = "Fragrant rice dish with spices and meat.",
                    Price = 10.99m,
                    Stock = 100,
                    CategoryId = 3
                },


                new Product
                {
                    ProductId = 7,
                    Name = "Naan",
                    Description = "Soft Indian bread.",
                    Price = 2.99m,
                    Stock = 100,
                    CategoryId = 3
                },


                new Product
                {
                    ProductId = 8,
                    Name = "Mango Lassi",
                    Description = "Sweet yogurt drink with mango.",
                    Price = 3.99m,
                    Stock = 100,
                    CategoryId = 5
                }

                );

            modelbuilder.Entity<ProductIngredients>().HasData(
                // Butter Chicken - Ingredients: Chicken, Vegetables
                new ProductIngredients { ProductId = 1, IngredientId = 1 }, // Chicken
                new ProductIngredients { ProductId = 1, IngredientId = 4 }, // Vegetables

                // Chicken Tikka Masala - Ingredients: Chicken, Vegetables
                new ProductIngredients { ProductId = 2, IngredientId = 1 }, // Chicken
                new ProductIngredients { ProductId = 2, IngredientId = 4 }, // Vegetables

                // Goat Curry - Ingredients: Goat, Vegetables
                new ProductIngredients { ProductId = 3, IngredientId = 2 }, // Goat
                new ProductIngredients { ProductId = 3, IngredientId = 4 }, // Vegetables

                // Samosa - Ingredients: Vegetables, Flour
                new ProductIngredients { ProductId = 4, IngredientId = 4 }, // Vegetables
                new ProductIngredients { ProductId = 4, IngredientId = 6 }, // Flour

                // Paneer Tikka - Ingredients: Paneer, Vegetables
                new ProductIngredients { ProductId = 5, IngredientId = 8 }, // Paneer
                new ProductIngredients { ProductId = 5, IngredientId = 4 }, // Vegetables

                // Biryani - Ingredients: Chicken, Rice, Vegetables
                new ProductIngredients { ProductId = 6, IngredientId = 1 }, // Chicken
                new ProductIngredients { ProductId = 6, IngredientId = 5 }, // Rice
                new ProductIngredients { ProductId = 6, IngredientId = 4 }, // Vegetables

                // Naan - Ingredients: Naan
                new ProductIngredients { ProductId = 7, IngredientId = 6 }, // Flour


                // Mango Lassi - Ingredients: Yogurt, Mango
                new ProductIngredients { ProductId = 8, IngredientId = 7 }, // Yogurt
                new ProductIngredients { ProductId = 8, IngredientId = 4 } // Vegetables

            );

        }
    }
}
