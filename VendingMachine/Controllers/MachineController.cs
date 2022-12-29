using Microsoft.AspNetCore.Mvc;
using VendingMachine.Models;
using VendingMachine.Services;

namespace VendingMachine.Controllers
{
    public class MachineController : Controller
    {
        private IWalletService WalletService { get; set; }
        private IMenuService MenuService { get; set; }

        public MachineController(IWalletService walletService, IMenuService menuService)
        {
            WalletService = walletService;
            MenuService = menuService;
        }

        public IActionResult Index()
        {
            Machine machine = new();

            machine.Menu = MenuService.GetMenu();
            machine.VmWallet = WalletService.VmWallet;
            machine.ClientWallet = WalletService.ClientWallet;

            return View(machine);
        }

        public IActionResult Deposit(int coin)
        {
            WalletService.Deposit(coin);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Refund(int sum)
        {
            WalletService.Refund(sum);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Buy(int sum, int productId)
        {
            var cost = MenuService.Buy(sum, productId);

            WalletService.DeductFromDeposit(cost);

            return Ok();
        }
    }
}
