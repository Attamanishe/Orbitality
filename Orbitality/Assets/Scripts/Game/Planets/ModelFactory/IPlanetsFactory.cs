using Game.Planets.Instance;
using Game.World.Config;

namespace Game.Planets.ModelFactory
{
    public interface IPlanetsFactory
    {
        IPlanet Create(PlanetInstance prefab, Weapon.Base.Weapon weaponPrefab, IPlanetParameters parameters);
    }
}