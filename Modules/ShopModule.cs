using Discord.Commands;
using System.Threading.Tasks;
using System.Text;
using System;

namespace DURPSBot
{
    public class ShopModule : ModuleBase<SocketCommandContext>
    {
        [Command("shop")]
        [Summary("Displays shop inventory.")]
        public async Task ShopAsync()
        {
            Shop shop = new Shop();
            StringBuilder sb = new StringBuilder();

            foreach (Equipment e in shop.InStock)
            {
                // TODO: use FullName and total attributes when modifiers are added. Add checks for other requirements.
                sb.AppendLine((shop.InStock.IndexOf(e) + 1) + ". " + e.Name + " - " + "Price: " + e.Price + " Req. STR: " + e.RequiredStrength);
            }
            await ReplyAsync(sb.ToString());
        }

        [Command("buy")]
        [Summary("Buy an item from the shop.")]
        public async Task BuyAsync([Remainder] [Summary("Item to buy.")] int selection)
        {
            DataManager dm = new DataManager();
            PlayerCharacter pc = dm.Load(Context.Message.Author.Id);
            Shop shop = new Shop();

            if (selection <= 0 || selection > shop.InStock.Count)
            {
                await ReplyAsync("Invalid selection.");
            }
            else if (pc.Money >= shop.InStock[selection - 1].Price)
            {
                pc.InventoryEquipment.Add(shop.InStock[selection - 1]);
                pc.Money -= shop.InStock[selection - 1].Price;
                dm.Save(pc);
                await ReplyAsync("Purchased.");
            }
            else if (pc.Money < shop.InStock[selection - 1].Price)
            {
                await ReplyAsync("Not enough funds!");
            }
        }

        [Command("sell")]
        [Summary("Sell an item to the shop.")]
        public async Task SellAsync([Remainder] [Summary("Item to buy.")] int selection)
        {
            DataManager dm = new DataManager();
            PlayerCharacter pc = dm.Load(Context.Message.Author.Id);
            Shop shop = new Shop();

            if (selection <= 0 || selection > pc.InventoryEquipment.Count)
            {
                await ReplyAsync("Invalid selection.");
            }
            // TODO: Use totals.
            else
            {
                int sellPrice = pc.InventoryEquipment[selection - 1].Price;
                pc.Money += sellPrice;
                pc.InventoryEquipment.RemoveAt(selection - 1);
                dm.Save(pc);
                await ReplyAsync("Sold for " + sellPrice + " gold.");
            }
        }
    }
}