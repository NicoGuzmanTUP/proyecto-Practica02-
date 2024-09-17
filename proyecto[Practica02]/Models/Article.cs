using static System.Runtime.InteropServices.JavaScript.JSType;

namespace proyecto_Practica02_.Models
{
    public class Article
    {
        //public int Id { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public Article()
        {
            //Id = 0;
            Name = string.Empty;
            Price = 0;
            Description = string.Empty;
        }

        public Article( string name, double price, string description)
        {
            //Id = id;
            Name = name;
            Price = price;
            Description = description;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
