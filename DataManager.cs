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
            DirectoryInfo d = new DirectoryInfo(filePath);

            foreach (var file in d.GetFiles("*.bin"))
            {
                // Remove ".bin" extension.
                string s = file.Name.Remove(file.Name.Length - 4);
                userIDs.Add(uint.Parse(s));
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