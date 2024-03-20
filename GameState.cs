
using Newtonsoft.Json;
using System.IO;

namespace MiniProject
{
    public class GameState
    {
        public string PlayerName { get; set; }
        public int WeaponLevel { get; set; }
        public int Exp { get; set; }
        public DateTime SaveTime { get; set; }
        public Player player { get; set; }

        //public GameState(string playerName, int weaponLevel, int exp, DateTime saveTime, Player player)
        //{
        //    PlayerName = playerName;
        //    WeaponLevel = weaponLevel;
        //    Exp = exp;
        //    SaveTime = saveTime;
        //    this.player = player;
        //}

        public void Save(string filePath)
        {
            string json = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        public static GameState Load(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("File not found", filePath);
            }

            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<GameState>(json);
        }
    }


}
