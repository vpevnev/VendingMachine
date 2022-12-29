using System.Collections.Generic;
using VendingMachine.Models;

namespace VendingMachine.Infrastructure.Extensions
{
    public static class CoinExtensions
    {
        public static int GetTotalSum(this IEnumerable<Coin> coins)
        {
            int totalSum = default;

            foreach (var coin in coins)
                totalSum += coin.Value * coin.Amount;

            return totalSum;
        }
    }
}
