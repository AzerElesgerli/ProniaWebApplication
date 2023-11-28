using ProniaWebApplication.Models;

namespace ProniaWebApplication.Areas.Pronia.ViewModels.Product
{
    public class ProductUpdateVM
    {
        public string Tittle { get; set; }


        public double Price { get; set; }

        public string Image { get; set; }


        public int? CategoryId { get; set; }
        public List<int> TagIds { get; set; }
        public List<Category>? Categories { get; set; }
        public List<int>? Tags { get; }
    }
}
