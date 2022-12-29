using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VendingMachine.Models
{
    [Display(Name = "Торговый автомат")]
    public class Machine
    {
        [Display(Name = "Меню")]
        public List<Product> Menu { get; set; }
        
        public VmWallet VmWallet { get; set; }

        public ClientWallet ClientWallet { get; set; }
    }
}
