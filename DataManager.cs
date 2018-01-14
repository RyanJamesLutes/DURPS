using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace DURPSBot
{
    class DataManager
    {
        public void Save(PlayerCharacter pc)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("PlayerData\\" + pc.UserID + ".bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, pc);
            stream.Close();
        }

        public PlayerCharacter Load(string userID)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("PlayerData\\" + userID + ".bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            PlayerCharacter pc = (PlayerCharacter)formatter.Deserialize(stream);
            stream.Close();
            return pc;
        }
    }
}