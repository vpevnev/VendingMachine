using System.Collections.Generic;
using System.Linq;
using VendingMachine.Models;

namespace VendingMachine.Services
{
    public class MenuService : IMenuService
    {
        private List<Product> Menu = new()
        {
            new Product { Id = 1, Name = "Чай", Amount = 10, Cost = 13 },
            new Product { Id = 2, Name = "Кофе", Amount = 20, Cost = 18 },
            new Product { Id = 3, Name = "Кофе с молоком", Amount = 20, Cost = 21 },
            new Product { Id = 4, Name = "Сок", Amount = 15, Cost = 35 }
        };

        public List<Product> GetMenu()
        {
            return Menu;
        }

        private Product GetProductById(int productId)
            => Menu.FirstOrDefault(p => p.Id == productId);

        public int Buy(int sum, int productId)
        {
            var product = GetProductById(productId);
            int costToDeduct = default;

            if (product != default && product.Amount > 0
                && product.Cost <= sum)
            {
                product.Amount--;
                costToDeduct = product.Cost;
            }

            return costToDeduct;
        }
    }
}
