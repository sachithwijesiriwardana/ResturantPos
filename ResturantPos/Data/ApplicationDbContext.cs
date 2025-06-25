using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ResturantPos.Models;

namespace ResturantPos.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product>Products { get; set; }

        public DbSet<Category>Categories { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItem { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<ProductIngredient> ProductIngredients { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Define composite Key and relationships for ProductIngredients
            modelBuilder.Entity<ProductIngredient>()
                .HasKey(pi => new { pi.ProductId, pi.IngredientId });

            modelBuilder.Entity<ProductIngredient>()
                .HasOne(pi => pi.Product)
                .WithMany(p => p.ProductIngredients)
                .HasForeignKey(pi => pi.ProductId);

            modelBuilder.Entity<ProductIngredient>()
                .HasOne(pi => pi.Ingredient)
                .WithMany(p => p.ProductIngredients)
                .HasForeignKey(pi => pi.IngredientId);

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Appetizer" },
                new Category { CategoryId = 2, Name = "Entree" },
                new Category { CategoryId = 3, Name = "Side Dish" },
                new Category { CategoryId = 4, Name = "Dessert" },
                new Category { CategoryId = 5, Name = "Beverage" }

             );

            modelBuilder.Entity<Ingredient>().HasData(
                  new Ingredient { IngredientId = 1, Name = "Beef" },
                  new Ingredient { IngredientId = 2, Name = "Chicken" },
                  new Ingredient { IngredientId = 3, Name = "Onion" },
                  new Ingredient { IngredientId = 4, Name = "Garlic" },
                  new Ingredient { IngredientId = 5, Name = "Tomato" }


                );
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 1,
                    Name  =  "Beef Taco",
                    Description = "A delicious taco",
                    Price =2.50m,
                    Stock =100,
                    CategoryId = 1,

                },
                 new Product
                 {
                     ProductId = 2,
                     Name = "Chicken Burrito",
                     Description = "A tasty chicken burrito",
                     Price = 3.75m,
                     Stock = 80,
                     CategoryId = 1
                 },
                new Product
                {
                    ProductId = 3,
                    Name = "Veggie Wrap",
                    Description = "A healthy vegetable wrap",
                    Price = 2.25m,
                    Stock = 50,
                    CategoryId = 2
                },
                new Product
                {
                    ProductId = 4,
                    Name = "Cheese Quesadilla",
                    Description = "Cheesy and warm quesadilla",
                    Price = 2.00m,
                    Stock = 70,
                    CategoryId = 2
                },
                new Product
                {
                    ProductId = 5,
                    Name = "Fish Tacos",
                    Description = "Fresh fish with spicy sauce",
                    Price = 3.00m,
                    Stock = 60,
                    CategoryId = 3
                }


                );
            modelBuilder.Entity<ProductIngredient>().HasData(

                new ProductIngredient 
                {
                    ProductId = 1,IngredientId = 1,
                },
                new ProductIngredient
                 {
                     ProductId = 1,
                     IngredientId = 4,
                 },
                new ProductIngredient
                   {
                       ProductId = 1,
                       IngredientId = 5,
                   },
                 new ProductIngredient
                 {
                     ProductId = 1,
                     IngredientId = 3,
                 }

                );



        }

    }
}
