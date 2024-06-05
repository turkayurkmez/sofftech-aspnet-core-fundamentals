using eshop.Entities;

namespace eshop.Web.Models
{

    public class BasketItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
    public class ShoppingCardCollection
    {
        public List<BasketItem> Products { get; set; } = new List<BasketItem>();
        public void Add(BasketItem product)
        {

            var existingProduct = Products.Find(bi => bi.Product.Id == product.Product.Id);
            if (existingProduct != null)
            {
                existingProduct.Quantity += product.Quantity;
            }
            else
            {
                Products.Add(product);
            }
        }

        public void Clear() => Products.Clear();
        public decimal GetTotalPrice() => Products.Sum(p => p.Quantity * p.Product.Price);
        public int GetTotalQuantity() => Products.Sum(p => p.Quantity);

    }
}
