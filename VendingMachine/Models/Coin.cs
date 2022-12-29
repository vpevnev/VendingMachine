using System.ComponentModel.DataAnnotations;

namespace VendingMachine.Models
{
    public class Coin
    {
        [Display(Name = "Монета")]
        public int Value { get; set; }

        [Display(Name = "Количество")]
        public int Amount { get; set; } = 1;

        public Coin()
        { }

        public Coin(int value, int amount)
        {
            Value = value;
            Amount = amount;
        }
    }
}
