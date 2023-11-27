namespace ProniaWebApplication.Areas.Pronia.ViewModels.Product
{
    public class CreateProductVM
    {


        public string Title { get; set; }


        public double Price { get; set; }
        public int Order { get; set; }
        public string Image { get; set; }


        public int? CategoryId { get; set; }
    }
}
