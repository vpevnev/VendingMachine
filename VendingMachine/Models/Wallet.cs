using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace VendingMachine.Models
{
    public abstract class Wallet
    {
        [Display(Name = "Валюта")]
        public string Currency { get; set; }

        [Display(Name = "Монеты")]
        public IEnumerable<Coin> Coins { get; set; }

        public Wallet()
        { }

        public void Add(int coinValue, int amount = 1)
        {
            var coin = Coins.FirstOrDefault(c => c.Value == coinValue);

            if (coin != default)
                coin.Amount += amount;
        }

        public void Add(IEnumerable<Coin> coins)
        {
            foreach (var coin in coins)
                Add(coin.Value, coin.Amount);
        }

        public void Deduct(int coinValue, int amount = 1)
        {
            var coin = Coins.FirstOrDefault(c => c.Value == coinValue);

            if (coin != default)
                coin.Amount -= amount;
        }

        public void Deduct(IEnumerable<Coin> coins)
        {
            foreach (var coin in coins)
                Deduct(coin.Value, coin.Amount);
        }
    }
}
