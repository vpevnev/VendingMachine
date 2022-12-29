using System.ComponentModel.DataAnnotations;

namespace VendingMachine.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Display(Name = "Товар")]
        public string Name { get; set; }

        [Display(Name = "Количество")]
        public int Amount { get; set; }

        [Display(Name = "Стоимость")]
        public int Cost { get; set; }
    }
}
