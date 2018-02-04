using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace DURPSBot
{
    class DataManager
    {

        public ulong[] AllPlayerIDs()
        {
            string filePath = "PlayerData\\";
            List<ulong> userIDs = new List<ulong>();
            foreach (string file in Directory.GetFiles(filePath))
            {
                userIDs.Add(Load(Path.GetFileNameWithoutExtension(file)).UserID);
            }
            return userIDs.ToArray();

        }

        public void Save(PlayerCharacter pc)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("PlayerData\\" + pc.UserID.ToString() + ".bin", FileMode.Create, FileAccess.Write, FileShare.None);
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
        public PlayerCharacter Load(ulong userID)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("PlayerData\\" + userID.ToString() + ".bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            PlayerCharacter pc = (PlayerCharacter)formatter.Deserialize(stream);
            stream.Close();
            return pc;
        }
    }
}