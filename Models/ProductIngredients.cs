﻿namespace IndianRestaurant.Models
{
    public class ProductIngredients
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }

    }
}