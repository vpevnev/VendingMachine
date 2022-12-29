using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using VendingMachine.Models;

namespace VendingMachine.Services
{
    public class WalletService : IWalletService
    {
        private const string sessionKey = "clientWallet";

        private IOptions<Machine> Machine { get; set; }

        public ISessionService SessionService { get; set; }

        private static VmWallet vmWallet;

        public VmWallet VmWallet
        {
            get => vmWallet;
            set
            {
                if (vmWallet == default)
                    vmWallet = value;
            }
        }

        public ClientWallet ClientWallet
        {
            get
            {
                string clientWallet = SessionService.GetString(sessionKey);

                return DeserializeWallet<ClientWallet>(clientWallet);
            }
            set
            {
                if (SessionService.GetString(sessionKey) == default)
                {
                    string clientWalletToSession = SerializeWallet(value);
                    SessionService.SetString(sessionKey, clientWalletToSession);
                }
            }
        }

        public WalletService(IOptions<Machine> machine, ISessionService sessionService)
        {
            Machine = machine;

            SessionService = sessionService;

            VmWallet = Machine.Value.VmWallet;
            ClientWallet = Machine.Value.ClientWallet;
        }

        public void Deposit(int coinValue)
        {
            var clientWallet = DeserializeWallet<ClientWallet>(SessionService.GetString("clientWallet"));
            clientWallet.Deduct(coinValue);

            VmWallet.Add(coinValue);
            VmWallet.AddToDeposit(coinValue);

            SessionService.SetString("clientWallet", SerializeWallet(clientWallet));
        }

        public void DeductFromDeposit(int sum)
        {
            VmWallet.DeductFromDeposit(sum);
        }

        public void Refund(int sum)
        {
            VmWallet.DeductFromDeposit(sum);

            var coins = ConversionSumToCoins(sum);

            VmWallet.Deduct(coins);

            var clientWallet = DeserializeWallet<ClientWallet>(SessionService.GetString("clientWallet"));
            clientWallet.Add(coins);

            SessionService.SetString("clientWallet", SerializeWallet(clientWallet));
        }

        public IEnumerable<Coin> ConversionSumToCoins(int sum)
        {
            List<Coin> coins = new();

            foreach (var coin in VmWallet.Coins.OrderByDescending(coin => coin.Value))
            {
                var amount = sum / coin.Value;

                if (amount > coin.Amount)
                    amount = coin.Amount;

                coins.Add(new Coin(coin.Value, amount));
                sum -= coin.Value * amount;
            }

            return coins;
        }

        public T DeserializeWallet<T>(string value) where T : Wallet
        {
            return JsonConvert.DeserializeObject<T>(value);
        }

        public string SerializeWallet<T>(T wallet) where T : Wallet
        {
            return JsonConvert.SerializeObject(wallet);
        }
    }
}
