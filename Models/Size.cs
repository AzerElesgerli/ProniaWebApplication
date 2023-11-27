namespace ProniaWebApplication.Models
{
    public class Size
    {
        public int Id { get; set; }
        public string  SizeName { get; set; }
        public List<ProductSize>? ProductSizes  { get; set; }
    }
}
