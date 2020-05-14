using Game.Planets.Instance;

namespace Game.Planets.Collection
{
    public interface IPlanetsContainer
    {
        int Count { get; }
        void Add(IPlanet planet);
        void Remove(IPlanet planet);
        IPlanet Get(int index);
    }
}