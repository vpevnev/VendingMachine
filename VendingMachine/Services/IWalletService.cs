using System.Collections.Generic;
using VendingMachine.Models;

namespace VendingMachine.Services
{
    public interface IWalletService
    {
        VmWallet VmWallet { get; set; }

        ClientWallet ClientWallet { get; set; }

        //void SetVmWallet(VmWallet vmWallet);

        //VmWallet GetVmWallet();

        //void SetClientWallet(ClientWallet clientWallet);

        //ClientWallet GetClientWallet();

        void Deposit(int coinValue);

        void DeductFromDeposit(int sum);

        void Refund(int sum);

        IEnumerable<Coin> ConversionSumToCoins(int sum);

        T DeserializeWallet<T>(string value) where T : Wallet;

        string SerializeWallet<T>(T wallet) where T : Wallet;
    }
}
