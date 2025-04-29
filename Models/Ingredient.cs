using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace IndianRestaurant.Models
{
    public class Ingredient
    {
        public int IngredientId { get; set; }
        public string? Name { get; set; }

        [ValidateNever]
        public ICollection<ProductIngredients>? ProductIngredients { get; set; }
    }
}