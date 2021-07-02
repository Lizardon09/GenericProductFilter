using System;

namespace AmazonProductFilter.Models
{
    public class Product
    {
        public int Id { get; set; }
        public Size Size { get; set; }
        public Color Color { get; set; }

        public Product(int id, Size size, Color color)
        {
            this.Id = id;
            this.Size = size;
            this.Color = color;
        }

        public string ProductDescription()
        {
            string description = "Product: ";
            foreach(var property in typeof(Product).GetProperties())
            {
                description += String.Format("'{0}' : '{1}' ", property.Name, property.GetValue(this));
            }
            return description;
        }
    }
}
