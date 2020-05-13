namespace Game.Planets
{
    public interface IPlanetsContainer
    {
        int Count { get; }
        void Add(IPlanet planet);
        void Remove(IPlanet planet);
        IPlanet Get(int index);
    }
}