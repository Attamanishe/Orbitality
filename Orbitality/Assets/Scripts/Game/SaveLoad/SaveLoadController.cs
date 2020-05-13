using Comon;
using Game.Generation.State;
using UnityEngine;

namespace Game.SaveLoad
{
    public class SaveLoadController : Singleton<SaveLoadController>
    {
        private const string SaveGameKey = "Save";
        public WorldState LoadedSave;
        public void Save(WorldState state)
        {
            PlayerPrefs.SetString(SaveGameKey,JsonUtility.ToJson(state));
        }

        public WorldState LoadGame()
        {
            return JsonUtility.FromJson<WorldState>(PlayerPrefs.GetString(SaveGameKey));
        }

        public bool HasSave()
        {
            return PlayerPrefs.HasKey(SaveGameKey);
        }
    }
}