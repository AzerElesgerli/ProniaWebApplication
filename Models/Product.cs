namespace ProniaWebApplication.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
      
        public int?  Price { get; set; }
        public string? Image { get; set; }

           
        public List<Color>Colors { get; set; }
        public List<Size> Sizes { get; set; }

        public List<Tag> Tags { get; set; }

    }
}
