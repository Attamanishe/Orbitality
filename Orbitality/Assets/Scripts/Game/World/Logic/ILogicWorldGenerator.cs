using Game.World.Config;
using Game.World.State;

namespace Game.World.Logic
{
    public interface ILogicWorldGenerator
    {
        WorldState Generate(int count, WorldGenerationSettings state);
    }
}