using System.Collections.Generic;
using VendingMachine.Models;

namespace VendingMachine.Services
{
    public interface IMenuService
    {
        List<Product> GetMenu();

        int Buy(int sum, int productId);
    }
}
