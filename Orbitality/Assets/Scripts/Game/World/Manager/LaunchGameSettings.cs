using Common;
using Game.World.State;

namespace Game.World.Manager
{
    //this class for storing cross scene information
    public class LaunchGameSettings : Singleton<LaunchGameSettings>
    {
        public int PlayersCount;
        public WorldState StateToLoad;

        protected LaunchGameSettings() : base()
        {
            
        }
    }
}