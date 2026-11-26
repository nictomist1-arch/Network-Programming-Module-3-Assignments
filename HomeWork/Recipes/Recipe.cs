namespace Recipes
{
    public class Recipe
    {
        public string Name { get; set; }
        public string[] Products { get; set; }
        public string Description { get; set; }

        public Recipe(string name, string products, string description)
        {
            Name = name;
            Products = products.Split(',');
            Description = description;
        }
    }
}
