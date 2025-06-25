namespace ResturantPos.Models
{
    public class ProductIngredient
    {
        public int ProductId { get; set; }

        public Product ProductName { get; set; }

        public int IngredientId { get; set; }

        public Ingredient Ingredient { get;}
    }
}