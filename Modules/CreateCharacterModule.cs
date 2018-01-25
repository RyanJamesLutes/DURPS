using Discord.Commands;
using System.Threading.Tasks;

namespace DURPSBot
{
    public class CreateCharacterModule : ModuleBase<SocketCommandContext>
    {
        [Command("CreateCharacter")]
        [Summary("Generates a new RPG character.")]
        public async Task CreateCharacterAsync([Remainder] [Summary("Class to create.")] string characterClass)
        {
            DataManager dm = new DataManager();
            if (characterClass == "1" || characterClass.ToLower() == "jack")
            {
                PlayerCharacter pc = new PlayerCharacter("Jack")
                {
                    UserID = Context.Message.Author.Id,
                    Name = Context.Message.Author.Username
                };
                dm.Save(pc);
                await ReplyAsync("Character created.");

            }
            else if (characterClass == "2" || characterClass.ToLower() == "warrior")
            {
                PlayerCharacter pc = new PlayerCharacter("Warrior")
                {
                    UserID = Context.Message.Author.Id,
                    Name = Context.Message.Author.Username
                };
                dm.Save(pc);
                await ReplyAsync("Character created.");
            }
            else if (characterClass == "3" || characterClass.ToLower() == "rogue")
            {
                PlayerCharacter pc = new PlayerCharacter("Rogue")
                {
                    UserID = Context.Message.Author.Id,
                    Name = Context.Message.Author.Username
                };
                dm.Save(pc);
                await ReplyAsync("Character created.");
            }
            else if (characterClass == "4" || characterClass.ToLower() == "mage")
            {
                PlayerCharacter pc = new PlayerCharacter("Mage")
                {
                    UserID = Context.Message.Author.Id,
                    Name = Context.Message.Author.Username
                };
                dm.Save(pc);
                await ReplyAsync("Character created.");
            }
            else if (characterClass == "5" || characterClass.ToLower() == "fool")
            {
                PlayerCharacter pc = new PlayerCharacter("Fool")
                {
                    UserID = Context.Message.Author.Id,
                    Name = Context.Message.Author.Username
                };
                dm.Save(pc);
                await ReplyAsync("Character created.");
            }
            else if (characterClass == "6" || characterClass.ToLower() == "wanderer")
            {
                PlayerCharacter pc = new PlayerCharacter("Wanderer")
                {
                    UserID = Context.Message.Author.Id,
                    Name = Context.Message.Author.Username
                };
                dm.Save(pc);
                await ReplyAsync("Character created.");
            }
            else
            {
                await ReplyAsync("This will overwrite any existing character you have. To continue, type !CreateCharacter <class> \n \n 1. Jack \n 2. Warrior \n 3. Rogue \n 4. Mage \n 5. Fool \n 6. Wanderer");
            }
        }
    }
}