namespace Game.Planets.Factory
{
    public interface IPlanetsFactory
    {
        IPlanet Create(PlanetInstance prefab, IPlanetParameters parameters);
    }
}