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
            PlayerCharacter pc = new PlayerCharacter(characterClass.ToLower(), Context.Message.Author.Id, Context.Message.Author.Username);
            await ReplyAsync("Character created with ID " + Context.Message.Author.Id);
        }

        [Command("CreateCharacter")]
        [Summary("Generates a new RPG character.")]
        public async Task CreateCharacterAsync()
        {
            await ReplyAsync("This will overwrite any existing character you have. To continue, type !CreateCharacter <class> \n \n 1. Jack \n 2. Warrior \n 3. Rogue \n 4. Mage \n 5. Fool \n 6. Wanderer");
        }
    }
}