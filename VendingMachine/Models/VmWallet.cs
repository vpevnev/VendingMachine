using System.ComponentModel.DataAnnotations;

namespace VendingMachine.Models
{
    [Display(Name = "Кошелёк торгового автомата")]
    public class VmWallet : Wallet
    {
        [Display(Name = "Внесённая сумма")]
        public int Deposit { get; set; }

        public void AddToDeposit(int coinValue)
        {
            Deposit += coinValue;
        }

        public void DeductFromDeposit(int sum)
        {
            Deposit -= sum;
        }
    }
}
