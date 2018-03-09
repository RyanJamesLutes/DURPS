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
        public async Task BuyAsync([Remainder] [Summary("Item to buy.")] string selection)
        {
            DataManager dm = new DataManager();
            PlayerCharacter pc = dm.Load(Context.Message.Author.Id);
            Shop shop = new Shop();
            int selectionNum = Int32.Parse(selection);

            if (selectionNum <= 0 || selectionNum > shop.InStock.Count)
            {
                await ReplyAsync("Invalid selection.");
            }
            else if (pc.Money >= shop.InStock[selectionNum - 1].Price)
            {
                pc.InventoryEquipment.Add(shop.InStock[selectionNum - 1]);
                pc.Money -= shop.InStock[selectionNum - 1].Price;
                await ReplyAsync("Purchased.");
            }
            else if (pc.Money < shop.InStock[selectionNum - 1].Price)
            {
                await ReplyAsync("Not enough funds!");
            }
        }
    }
}