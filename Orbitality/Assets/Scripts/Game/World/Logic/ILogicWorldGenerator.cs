using Game.Generation.Config;
using Game.Generation.State;

namespace Game.Generation
{
    public interface ILogicWorldGenerator
    {
        WorldState Generate(int count, WorldGenerationSettings state);
    }
}